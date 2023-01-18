using System;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NoteWith.Application.Repositorys;
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

        public UnitOfWork(NoteDataContext _context, IHttpContextAccessor _httpContextAccessor, IMapper _mapper)
		{
            context = _context;
            mapper = _mapper;
            user = Injector.SessionUser(_httpContextAccessor);
        }
        //base repostory
		private IRepository _Repository;
        public IRepository Repository
		{
            get => _Repository ?? (_Repository = new Repository(context, user));
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

