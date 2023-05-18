using System;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NoteWith.Application.Repositorys;
using NoteWith.Application.Services;
using NoteWith.Domain.DTOModels.SecurityModels;
using NoteWith.Infrastructure.Injectors;
using NoteWith.Persistence.NoteDataContexts;

namespace NoteWith.Infrastructure.Repositorys
{
	public class UnitOfWork: IUnitOfWork
    {
        private readonly NoteDataContext context;

        private readonly SessionModel user;
        //her özel repoya eklecek!!
        private readonly IMapper mapper;
        private readonly INotificationServices noti;
        private readonly ITokenGeneratorService tokenGeneratorService;

        public UnitOfWork(NoteDataContext _context, IHttpContextAccessor _httpContextAccessor, IMapper _mapper, INotificationServices _noti,ITokenGeneratorService _tokenGeneratorService)
		{
            context = _context;
            mapper = _mapper;
            noti = _noti;
            user = Injector.SessionUser(_httpContextAccessor);
            tokenGeneratorService = _tokenGeneratorService;
        }
        //base repostory
		private IRepository _Repository;
        public IRepository Repository
		{
            get => _Repository ?? (_Repository = new Repository(context, user));
        }
        private IGroupRepository _GroupRepository;
        public IGroupRepository GroupRepository
        {
            get => _GroupRepository ??
                (_GroupRepository = new GroupRepository(context, user, mapper, this,tokenGeneratorService));
        }
        private INoteRepository _NoteRepository;
        public INoteRepository NoteRepository => _NoteRepository ??
            (_NoteRepository = new NoteRepository(context, user, mapper, this));

        private IWorkListRepository _workListRepository;
        public IWorkListRepository WorkListRepository
        {
            get => _workListRepository ?? (_workListRepository = new WorkListRepository(context, user, mapper, this));
        }

        private INoticeRepository _NoticeRepository;
        public INoticeRepository NoticeRepository
        {
            get => _NoticeRepository ?? (_NoticeRepository = new NoticeRepository(context, user, mapper, this));
        }

        public IWorkEventRepository _WorkEventRepository;
        public IWorkEventRepository WorkEventRepository
        {
            get => _WorkEventRepository ?? (_WorkEventRepository = new WorkEventRepository(context, user, mapper, this));
        }

        public IBudgetRepository _BudgetRepository;
        public IBudgetRepository BudgetRepository
        {
            get => _BudgetRepository ?? (_BudgetRepository = new BudgetRepository(context, user, mapper, this));
        }

        public Task<int> SaveChange()
        {
            try
            {
                return context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

