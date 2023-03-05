using System;
using NoteWith.Domain.DTOModels.WorklistModels;

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
		Task DeleteWorkListıtem(Guid ItemID);
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
        Task TogleNotifiedMe(Guid noteID);
		/// <summary>
		/// Çalışma Listelerni getiren kod
		/// </summary>
		/// <param name="q"></param>
		/// <returns></returns>
		IQueryable<WorkListDTO> GetWorkLists(string q);
    }
}

