using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NoteWith.Application.Repositorys;
using NoteWith.Domain.DTOModels.NoticeModels;
using NoteWith.Domain.DTOModels.SecurityModels;
using NoteWith.Domain.EntitiyModels.NoteModels;
using NoteWith.Domain.EntitiyModels.NoticeModels;
using NoteWith.Persistence.NoteDataContexts;

namespace NoteWith.Infrastructure.Repositorys
{
	public class NoticeRepository:Repository ,INoticeRepository
	{
        private readonly NoteDataContext context;
        private readonly SessionModel user;
        private readonly IMapper mapper;
        private readonly IUnitOfWork uow;

        public NoticeRepository(NoteDataContext _context, SessionModel _user, IMapper _mapper, IUnitOfWork _uow) : base(_context, _user)
        {
            context = _context;
            user = _user;
            mapper = _mapper;
            uow = _uow;
        }

        public async Task AddNotice(NoticeDTO model)
        {
            try
            {
                var notice = mapper.Map<Notice>(model);
                foreach (var groupID in model.WorkGroups)
                {
                    var noticeGroup = new WorkGroupNotice()
                    {
                        Notice=notice,
                        WorkGroupID=groupID
                    };
                    await Add(notice);
                }

                await Add(notice);
                await uow.SaveChange();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteNotice(Guid noticeID)
        {
            try
            {
                await Delete<Notice>(noticeID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IQueryable<Notice>> GetNotices(string q)
        {
            try
            {
                var authGroups = await uow.GroupRepository.GetUserAuthWorkGroup();
                var noticesIds = await GetNonDeletedAndActive<WorkGroupNotice>(t => authGroups.Contains(t.WorkGroupID)).Select(s=>s.ID).ToListAsync();
                var notices = GetNonDeletedAndActive<Notice>(t => noticesIds.Contains(t.ID));
                if (!string.IsNullOrEmpty(q))
                    notices = notices.Where(t => t.Content.ToLower().Contains(q.ToLower()));
                return notices;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateNotice(NoticeDTO model)
        {
            try
            {
                var notice = await GetByID<Notice>(model.ID);
                mapper.Map<NoticeDTO, Notice>(model, notice);
                await Update(notice);
                await uow.SaveChange();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IQueryable<NoticeDTO> ConvertModel(IQueryable<Notice> notices)
        {
            return notices.Select(s => new NoticeDTO() 
            {
                ID = s.ID,
                Content= s.Content,
                EndDate= s.EndDate,
            });
        }
    }
}

