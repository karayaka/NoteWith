using System;
namespace NoteWith.Application.Repositorys
{
	public interface IUnitOfWork
	{
		public IRepository Repository {get;}

		/// <summary>
		/// Çalışma grubuna ait işlemler
		/// </summary>
		public IGroupRepository GroupRepository { get; }
		/// <summary>
		/// Note işlemleri repositorysi
		/// </summary>
		public INoteRepository NoteRepository { get; }
		/// <summary>
		/// Kaydet
		/// </summary>
		/// <returns></returns>
		Task<int> SaveChange();
    }
}

