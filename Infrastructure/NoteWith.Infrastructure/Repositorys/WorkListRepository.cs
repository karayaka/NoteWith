using System;
using System.Text.RegularExpressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NoteWith.Application.Repositorys;
using NoteWith.Domain.DTOModels.SecurityModels;
using NoteWith.Domain.DTOModels.WorklistModels;
using NoteWith.Domain.EntitiyModels.NoteModels;
using NoteWith.Domain.EntitiyModels.WorkLists;
using NoteWith.Persistence.NoteDataContexts;

namespace NoteWith.Infrastructure.Repositorys
{
	public class WorkListRepository:Repository,IWorkListRepository
    {
        private readonly NoteDataContext context;
        private readonly SessionModel user;
        private readonly IMapper mapper;
        private readonly IUnitOfWork uow;
        public WorkListRepository(NoteDataContext _context, SessionModel _user, IMapper _mapper, IUnitOfWork _uow) : base(_context, _user)
        {
            context = _context;
            user = _user;
            mapper = _mapper;
            uow = _uow;
        }

        public async Task AddItemsToList(WorkListItemDTO Items)
        {
            try
            {
                var noteItem = mapper.Map<WorkListItem>(Items);

                await Add(noteItem);
                await uow.SaveChange();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddWorkList(CreateWorkListDTO model)
        {
            try
            {
                var workList = mapper.Map<WorkList>(model);

                await Add(workList);
                //liste itemleri ekleniyor!
                foreach (var item in model.Items)
                {
                    var workItem = mapper.Map<WorkListItem>(item);
                    workItem.WorkListID = Guid.Empty;
                    workItem.WorkList = workList;

                    await Add(workItem);
                }
                //gruplar ile paylaşılıyor
                foreach (var group in model.SharedGroups)
                {
                    var listGroup = new ListWorkGroup()
                    {
                        WorkGroupID = group,
                        WorkList=workList,
                    };
                    await Add(listGroup);
                }
                //beni haberdar et buttonu var
                var notifiredMe = new WorkListNotifiedMe()
                {
                    UserID=user.ID,
                    WorkList=workList,
                };
                await Add(notifiredMe);

                await uow.SaveChange();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteWorkList(Guid ID)
        {
            try
            {
                var items = GetNonDeletedAndActive<WorkListItem>(t => t.WorkListID == ID);
                await DeleteRange(items);
                await Delete<WorkList>(ID);
                await uow.SaveChange();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteWorkListItem(Guid ItemID)
        {
            try
            {
                await Delete<WorkListItem>(ItemID);
                await uow.SaveChange();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IQueryable<WorkList>> GetWorkLists(string q, List<Guid> groupID)
        {
            try
            {
                //yetkii olduğu gruplar
                var authGroups = await uow.GroupRepository.GetUserAuthWorkGroup();

                var noteIDs = await GetNonDeletedAndActive<WorkList>(t => t.CreadedBy == user.ID).Select(s => s.ID).ToListAsync();

                var groupNoteIDs = new List<Guid>();

                if (groupID.Count <= 0)
                    groupNoteIDs = await GetNonDeletedAndActive<ListWorkGroup>(t => authGroups.Contains(t.WorkGroupID)).Select(s => s.WorkListID).ToListAsync();
                else
                    groupNoteIDs = await GetNonDeletedAndActive<ListWorkGroup>(t => groupID.Contains(t.WorkGroupID)).Select(s => s.WorkListID).ToListAsync();

                foreach (var item in groupNoteIDs)
                {
                    if (!noteIDs.Contains(item))
                        noteIDs.Add(item);
                }

                var workLists = GetNonDeletedAndActive<WorkList>(t => noteIDs.Contains(t.ID));
                //başlıktan arama
                if (!string.IsNullOrEmpty(q))
                    workLists = workLists.Where(t => t.Title.ToLower().Contains(q.ToLower()));
                return workLists;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IQueryable<WorkList>> GetGroupsWorkLists(string q, List<Guid> groupID)
        {
            try
            {
                var authGroups = await uow.GroupRepository.GetUserAuthWorkGroup();
                var groupNoteIDs = new List<Guid>();

                if (groupID.Count <= 0)
                    groupNoteIDs = await GetNonDeletedAndActive<ListWorkGroup>(t => authGroups.Contains(t.WorkGroupID)).Select(s => s.WorkListID).ToListAsync();
                else
                    groupNoteIDs = await GetNonDeletedAndActive<ListWorkGroup>(t => groupID.Contains(t.WorkGroupID)).Select(s => s.WorkListID).ToListAsync();


                var workLists = GetNonDeletedAndActive<WorkList>(t => groupNoteIDs.Contains(t.ID));
                //başlıktan arama
                if (!string.IsNullOrEmpty(q))
                    workLists = workLists.Where(t => t.Title.ToLower().Contains(q.ToLower()));

                return workLists;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<WorkList> GetUserWorkLists(string q)
        {
            try
            {
                var workLists = GetNonDeletedAndActive<WorkList>(t => t.CreadedBy == user.ID);
                if (!string.IsNullOrEmpty(q))
                    workLists = workLists.Where(t => t.Title.ToLower().Contains(q.ToLower()));
                return workLists;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task TogleItemComplated(Guid itemID)
        {
            try
            {
                var item = await GetByID<WorkListItem>(itemID);
                item.IsCoplated = !item.IsCoplated;
                await Update(item);
                await uow.SaveChange();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task ShareGroup(Guid listID, List<Guid> groups)
        {
            try
            {
                foreach (var item in groups)
                {
                    if (AnyNonDeletedAndActive<ListWorkGroup>(t => t.WorkGroupID == item && t.WorkListID == listID))
                        continue;
                    await Add<ListWorkGroup>(new()
                    {
                        WorkListID = listID,
                        WorkGroupID = item
                    });
                }
                var removetShareing = GetNonDeletedAndActive<NoteGroup>(t => !groups.Contains(t.WorkGroupID));//bu kod test edilecek!!
                RemoveRange(removetShareing);//çıkartılan grouplr dbden kaldırıloyor
                await uow.SaveChange();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task TogleNotifiedMe(Guid listID)
        {
            try
            {
                var notiferd = await FindNonDeleted<NoteNotifiedMe>(t => t.NoteID == listID && t.UserID == user.ID);
                if (notiferd != null)
                    await Delete(notiferd);
                else
                {
                    await Add<NoteNotifiedMe>(new()
                    {
                        UserID = user.ID,
                        NoteID = listID,
                    });
                }
                await uow.SaveChange();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateWorkList(CreateWorkListDTO model)
        {
            try
            {
                var work = await GetByID<WorkList>(model.ID);
                var list = mapper.Map<CreateWorkListDTO, WorkList>(model,work);
                await Update(list);
                await uow.SaveChange();
                //beni haberdar et bölümü eklenecek
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateWorkListItem(WorkListItemDTO item)
        {
            try
            {
                var listItem = await GetByID<WorkListItem>(item.ID);
                var workItem = mapper.Map<WorkListItemDTO, WorkListItem>(item, listItem);
                await Update(workItem);
                await uow.SaveChange();
                //item değişti haberdar edilecek
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<WorkListDTO> ConvertWorkListGroups(IQueryable<WorkList> models)
        {
            try
            {
                return models.Select(s => new WorkListDTO()
                {
                    ID = s.ID,
                    Color = s.Color ?? "",
                    Desc = s.Desc ?? "",
                    Title = s.Title,
                    CanEdit = (s.CreadedBy == user.ID) || (s.GroupEditable),
                    Items = s.Items.Select(it => new WorkListItemDTO()
                    {
                        Color = it.Color,
                        ComplatedUser = it.ComplaterUser.Name + " " + it.ComplaterUser.Surname,//bu test edileceks
                        Content = it.Content,
                        IsCoplated = it.IsCoplated,
                        Title = it.Title,
                        WorkListID = s.ID,
                        ID = it.ID,
                    }).ToList(),
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

