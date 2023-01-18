using System;
namespace NoteWith.Application.Repositorys
{
	public interface IUnitOfWork
	{
		public IRepository Repository {get;}


		Task<int> SaveChange();
    }
}

