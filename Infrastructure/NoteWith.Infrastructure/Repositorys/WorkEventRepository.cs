using System;
using System.Text.RegularExpressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NoteWith.Application.Repositorys;
using NoteWith.Domain.DTOModels.CustomExceptionModels;
using NoteWith.Domain.DTOModels.EventModels;
using NoteWith.Domain.DTOModels.NoteModels;
using NoteWith.Domain.DTOModels.SecurityModels;
using NoteWith.Domain.EntitiyModels.EventModels;
using NoteWith.Domain.EntitiyModels.NoteModels;
using NoteWith.Persistence.NoteDataContexts;

namespace NoteWith.Infrastructure.Repositorys
{
	public class WorkEventRepository:Repository , IWorkEventRepository
    {
        private readonly NoteDataContext context;
        private readonly SessionModel user;
        private readonly IMapper mapper;
        private readonly IUnitOfWork uow;
        public WorkEventRepository(NoteDataContext _context, SessionModel _user, IMapper _mapper, IUnitOfWork _uow) : base(_context, _user)
        {
            context = _context;
            user = _user;
            mapper = _mapper;
            uow = _uow;
        }

        public async Task AddEvent(WorkEventDTO model)
        {
            try
            {
                var workEvent = mapper.Map<WorkEvent>(model);
                await Add(workEvent);
                foreach (var group in model.SharedGroups)
                {
                    await Add<WorkEventGroup>(new()
                    {
                        Event = workEvent,
                        WorkGroupID = group,
                    });
                }
                await Add<WorkEventNotifiedMe>(new()
                {
                    Event = workEvent,
                    NotificatonID = model.NotificationID,
                    UserID = user.ID,
                });

                await uow.SaveChange();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<WorkEventDTO> ConvertWorkEvntModel(IQueryable<WorkEvent> events)
        {
            try
            {
                return events.Select(s => new WorkEventDTO()
                {
                    Content = s.Content,
                    Date = s.Date,
                    ID = s.ID,
                    Title = s.Title,
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteEvent(Guid ID)
        {
            try
            {
                await Delete<WorkEvent>(ID);
                await uow.SaveChange();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IQueryable<WorkEvent>> GetGroupWorkEvents(string q, List<Guid> groups)
        {
            try
            {
                List<Guid> unickNoteIDs = new();
                if (groups.Count <= 0)
                    groups = await uow.GroupRepository.GetUserAuthWorkGroup();
                var groupWorkEventIDs = await GetNonDeletedAndActive<WorkEventGroup>(t => groups.Contains(t.WorkGroupID)).Select(s => s.EventID).ToListAsync();
                foreach (var item in groupWorkEventIDs)
                {
                    if (!unickNoteIDs.Contains(item))
                        unickNoteIDs.Add(item);
                }
                var workEvents = GetNonDeletedAndActive<WorkEvent>(t => unickNoteIDs.Contains(t.ID));
                //başlıktan arama
                if (!string.IsNullOrEmpty(q))
                    workEvents = workEvents.Where(t => t.Title.ToLower().Contains(q.ToLower()));

                return workEvents;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<WorkEvent> GetUserWorkEvents(string q)
        {
            try
            {
                var workEvents = GetNonDeletedAndActive<WorkEvent>(t => t.CreadedBy == user.ID);
                if (!string.IsNullOrEmpty(q))
                    workEvents = workEvents.Where(t => t.Title.ToLower().Contains(q.ToLower()));

                return workEvents;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IQueryable<WorkEvent>> GetWorkEvents(string q, List<Guid> groups)
        {
            try
            {
                var authGroups = await uow.GroupRepository.GetUserAuthWorkGroup();
                //Kullanıcının Kendi Oluşturduğu notlar!

                var noteIDs = await GetNonDeletedAndActive<WorkEvent>(t => t.CreadedBy == user.ID).Select(s => s.ID).ToListAsync();
                //Kullanıcının Bağlı Oluğu Grup İle Paylaşılan Notlar! kullanıcı notları hariç!!
                var groupWorkEvenIDs = new List<Guid>();

                if (groups.Count <= 0)
                    groupWorkEvenIDs = await GetNonDeletedAndActive<WorkEventGroup>(t => authGroups.Contains(t.WorkGroupID)).Select(s => s.EventID).ToListAsync();
                else
                    groupWorkEvenIDs = await GetNonDeletedAndActive<WorkEventGroup>(t => groups.Contains(t.WorkGroupID)).Select(s => s.EventID).ToListAsync();

                foreach (var item in groupWorkEvenIDs)
                {
                    if (!noteIDs.Contains(item))
                        noteIDs.Add(item);
                }

                var workEvents = GetNonDeletedAndActive<WorkEvent>(t => noteIDs.Contains(t.ID));
                //başlıktan arama
                if (!string.IsNullOrEmpty(q))
                    workEvents = workEvents.Where(t => t.Title.ToLower().Contains(q.ToLower()));

                return workEvents;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task ShareGroup(Guid eventID, List<Guid> groupID)
        {
            try
            {
                foreach (var item in groupID)
                {
                    if (AnyNonDeletedAndActive<WorkEventGroup>(t => t.WorkGroupID == item && t.EventID == eventID))
                        continue;
                    await Add<WorkEventGroup>(new()
                    {
                        EventID = eventID,
                        WorkGroupID = item
                    });
                }
                var removetShareing = GetNonDeletedAndActive<WorkEventGroup>(t => !groupID.Contains(t.WorkGroupID));//bu kod test edilecek!!
                RemoveRange(removetShareing);//çıkartılan grouplr dbden kaldırıloyor
                await uow.SaveChange();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task TogleComplated(Guid evetID)
        {
            var workEvent = await GetByID<WorkEvent>(evetID);
            workEvent.IsComplated = !workEvent.IsComplated;
            await Update<WorkEvent>(workEvent);
            await uow.SaveChange();
        }

        public async Task TogleNotifiedMe(Guid evetID, string notificationID)
        {
            try
            {
                var notiferd = await FindNonDeleted<WorkEventNotifiedMe>(t => t.EventID == evetID && t.UserID == user.ID);
                if (notiferd != null)
                    await Delete(notiferd);
                else
                {
                    await Add<WorkEventNotifiedMe>(new()
                    {
                        UserID = user.ID,
                        EventID = evetID,
                        NotificatonID = notificationID,

                    });
                }
                await uow.SaveChange();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateEvent(WorkEventDTO model)
        {
            try
            {
                try
                {
                    var workEvent = await GetByID<WorkEvent>(model.ID);
                  
                    if (workEvent.CreadedBy == user.ID)
                    {
                        mapper.Map<WorkEventDTO, WorkEvent>(model, workEvent);
                        await Update(workEvent);
                        await uow.SaveChange();
                        return;
                    }
                    else
                        throw new CusEx("Bu Eventi Güncelleme Yetkiniiz Yok!");//bu hata mesajaları nasıl multi languge yapılabilir!

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

