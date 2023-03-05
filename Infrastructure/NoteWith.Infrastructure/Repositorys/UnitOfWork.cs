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

        public UnitOfWork(NoteDataContext _context, IHttpContextAccessor _httpContextAccessor, IMapper _mapper, INotificationServices _noti)
		{
            context = _context;
            mapper = _mapper;
            noti = _noti;
            user = Injector.SessionUser(_httpContextAccessor);
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
            get => _GroupRepository ?? (_GroupRepository = new GroupRepository(context, user, mapper, this));
        }
        private INoteRepository _NoteRepository;
        public INoteRepository NoteRepository => _NoteRepository ??
            (_NoteRepository = new NoteRepository(context, user, mapper, this));

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

