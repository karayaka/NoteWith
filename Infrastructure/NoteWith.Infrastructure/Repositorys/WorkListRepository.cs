using System;
using AutoMapper;
using NoteWith.Application.Repositorys;
using NoteWith.Domain.DTOModels.SecurityModels;
using NoteWith.Domain.DTOModels.WorklistModels;
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

        public Task AddItemsToList(WorkListItemDTO Items)
        {
            throw new NotImplementedException();
        }

        public async Task AddWorkList(CreateWorkListDTO model)
        {
            try
            {
                var workList = mapper.Map<WorkList>(model);

                await Add(workList);
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

        public Task DeleteWorkList(Guid ID)
        {
            throw new NotImplementedException();
        }

        public Task DeleteWorkListıtem(Guid ItemID)
        {
            throw new NotImplementedException();
        }

        public IQueryable<WorkListDTO> GetWorkLists(string q)
        {
            throw new NotImplementedException();
        }

        public Task ShareGroup(Guid listID, List<Guid> groups)
        {
            throw new NotImplementedException();
        }

        public Task TogleNotifiedMe(Guid noteID)
        {
            throw new NotImplementedException();
        }

        public Task UpdateWorkList(CreateWorkListDTO model)
        {
            throw new NotImplementedException();
        }

        public Task UpdateWorkListItem(WorkListItemDTO item)
        {
            throw new NotImplementedException();
        }
    }
}

