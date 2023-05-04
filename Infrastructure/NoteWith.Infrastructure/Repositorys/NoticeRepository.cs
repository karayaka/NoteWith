using System;
using AutoMapper;
using NoteWith.Application.Repositorys;
using NoteWith.Domain.DTOModels.NoticeModels;
using NoteWith.Domain.DTOModels.SecurityModels;
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

        public IQueryable<NoticeDTO> GetNotices(string q)
        {
            throw new NotImplementedException();
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
    }
}

