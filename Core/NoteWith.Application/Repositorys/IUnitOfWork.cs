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
		/// lşstelere ait rpositoryler
		/// </summary>
		public IWorkListRepository WorkListRepository { get; }
		/// <summary>
		/// Duyurulara ait repository
		/// </summary>
		public INoticeRepository NoticeRepository { get; }
		/// <summary>
		/// evetler görev ve yapılacaklar repositorysi
		/// </summary>
		public IWorkEventRepository WorkEventRepository { get; }
		/// <summary>
		/// Bütçe repositorisi
		/// </summary>
		public IBudgetRepository BudgetRepository { get; }
		/// <summary>
		/// Kaydet
		/// </summary>
		/// <returns></returns>
		Task<int> SaveChange();
    }
}



 