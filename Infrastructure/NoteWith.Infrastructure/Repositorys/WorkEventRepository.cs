using System;
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

        public IQueryable<WorkEventDTO> ConverNoteModels(IQueryable<WorkEvent> events)
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

        public IQueryable<WorEventDTO> GetGroupWorkEvents(string q, List<Guid> groups)
        {
            throw new NotImplementedException();
        }

        public IQueryable<WorEventDTO> GetUserWorkEvents(string q)
        {
            throw new NotImplementedException();
        }

        public IQueryable<WorEventDTO> GetWorkEvents(string q, List<Guid> groups)
        {
            throw new NotImplementedException();
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

        public Task TogleComplated(Guid evetID)
        {
            throw new NotImplementedException();
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

        public Task UpdateEvent(WorkEventDTO model)
        {
            throw new NotImplementedException();
        }
    }
}

