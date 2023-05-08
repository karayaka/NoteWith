using System;
using NoteWith.Domain.DTOModels.WorklistModels;
using NoteWith.Domain.EntitiyModels.WorkLists;

namespace NoteWith.Application.Repositorys
{
	public interface IWorkListRepository:IRepository
	{
		/// <summary>
		/// Çalışma Listesi Ekle
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		Task AddWorkList(CreateWorkListDTO model);
		/// <summary>
		/// Çalışma Lisesinin İtemlerinei ekleyen kod
		/// </summary>
		/// <param name="Items"></param>
		/// <returns></returns>
		Task AddItemsToList(WorkListItemDTO Items);
		/// <summary>
		/// liste elamanını güncelleyenkod
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		Task UpdateWorkListItem(WorkListItemDTO item);
		/// <summary>
		/// liste elamanını güncelleten kod
		/// </summary>
		/// <param name="ItemID"></param>
		/// <returns></returns>
		Task DeleteWorkListItem(Guid ItemID);
		/// <summary>
		/// lite bilgilerini güncelleyen kod
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		Task UpdateWorkList(CreateWorkListDTO model);
		/// <summary>
		/// listyi silen note
		/// </summary>
		/// <param name="ID"></param>
		/// <returns></returns>
		Task DeleteWorkList(Guid ID);
		/// <summary>
		/// listeyi grupta paylaş
		/// </summary>
		/// <param name="listID"></param>
		/// <param name="Items"></param>
		/// <returns></returns>
		Task ShareGroup(Guid listID, List<Guid> groups);//paylaş veya paylaşımdan çıkart burda olmalı
		/// <summary>
		/// Beni HAberdar et etme
		/// </summary>
		/// <param name="noteID"></param>
		/// <returns></returns>
        Task TogleNotifiedMe(Guid listID);
        /// <summary>
        /// Çalışma Listelerni getiren kod
        /// </summary>
        /// <param name="q"></param>
        /// <returns></returns>
        Task<IQueryable<WorkList>> GetWorkLists(string q, List<Guid> groupID);
        /// <summary>
        /// Gruplara Ait Listeleri getiren kod
        /// </summary>
        /// <param name="q"></param>
        /// <returns></returns>
        Task<IQueryable<WorkList>> GetGroupsWorkLists(string q, List<Guid> groupID);
		/// <summary>
		/// Kullanıcıya ait listeler getiren kod
		/// </summary>
		/// <param name="q"></param>
		/// <returns></returns>
        IQueryable<WorkList> GetUserWorkLists(string q);
        /// <summary>
        /// liste elemenı tamamalandı işaretleyen kod
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns></returns>
        Task TogleItemComplated(Guid itemID);
        /// <summary>
        /// çalışma listelerini dönüştüren kod
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        IQueryable<WorkListDTO> ConvertWorkListGroups(IQueryable<WorkList> models);
    }
}

