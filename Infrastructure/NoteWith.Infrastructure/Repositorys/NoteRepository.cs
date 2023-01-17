using System;
using NoteWith.Application.Repositorys;
using NoteWith.Domain.DTOModels.SecurityModels;
using NoteWith.Persistence.NoteDataContexts;

namespace NoteWith.Infrastructure.Repositorys
{
	public class NoteRepository:Repository,INoteRepository
	{
        private readonly NoteDataContext context;
        private readonly SessionModel user;
		public NoteRepository(NoteDataContext _context, SessionModel _user):base(_context,_user)
		{
            context = _context;
            user = _user;
		}

        public Task AddNote()
        {
            throw new NotImplementedException();
        }
    }
}

