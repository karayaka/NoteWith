using System;
using NoteWith.Domain.DTOModels.NoticeModels;
using NoteWith.Domain.EntitiyModels.NoticeModels;

namespace NoteWith.Application.Repositorys
{
	public interface INoticeRepository:IRepository
	{
        /// <summary>
        /// kullanıcnın kendi duyularını getiren kod
        /// Herken kendi duyusunu görür düzenler ve siler
        /// </summary>
        /// <param name="q"></param>
        /// <returns></returns>
        Task<IQueryable<Notice>> GetNotices(string q);

		/// <summary>
		/// Duyuru ekleyen metod
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		Task AddNotice(NoticeDTO model);
		/// <summary>
		/// Duyuru güncelleyen metod
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		Task UpdateNotice(NoticeDTO model);
		/// <summary>
		/// duyuru sişen kod
		/// </summary>
		/// <param name="noticeID"></param>
		/// <returns></returns>
		Task DeleteNotice(Guid noticeID);

        IQueryable<NoticeDTO> ConvertModel(IQueryable<Notice> notices)

    }
}

