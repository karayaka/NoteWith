using System;
namespace NoteWith.Application.Repositorys
{
	public interface INoteRepository:IRepository
	{
		Task AddNote();
	}
}

