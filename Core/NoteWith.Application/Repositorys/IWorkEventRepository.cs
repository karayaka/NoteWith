using System;
using NoteWith.Domain.DTOModels.EventModels;
using NoteWith.Domain.DTOModels.NoteModels;
using NoteWith.Domain.EntitiyModels.EventModels;
using NoteWith.Domain.EntitiyModels.NoteModels;

namespace NoteWith.Application.Repositorys
{
	public interface IWorkEventRepository:IRepository
	{
		/// <summary>
		/// evet ekleyen metod
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		Task AddEvent(WorkEventDTO model);
		/// <summary>
		/// Evet Güncelleyene Kod
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		Task UpdateEvent(WorkEventDTO model);
		/// <summary>
		/// evetleri silme kodu
		/// </summary>
		/// <param name="ID"></param>
		/// <returns></returns>
		Task DeleteEvent(Guid ID);
		/// <summary>
		/// eventleri gruplarda paylaşılması
		/// </summary>
		/// <param name="eventID"></param>
		/// <param name="groupID"></param>
		/// <returns></returns>
        Task ShareGroup(Guid eventID, List<Guid> groupID);
		/// <summary>
		/// eventler ceviren metod
		/// </summary>
		/// <param name="events"></param>
		/// <returns></returns>
        IQueryable<WorkEventDTO> ConvertWorkEvntModel(IQueryable<WorkEvent> events);
		/// <summary>
		/// tüm eventleri getiren kod
		/// </summary>
		/// <param name="q"></param>
		/// <param name="groups"></param>
		/// <returns></returns>
		Task<IQueryable<WorkEventDTO>> GetWorkEvents(string q, List<Guid> groups);
		/// <summary>
		/// gruplardaki evenleri getiren kod
		/// </summary>
		/// <param name="q"></param>
		/// <param name="groups"></param>
		/// <returns></returns>
        Task<IQueryable<WorkEventDTO>> GetGroupWorkEvents(string q, List<Guid> groups);
		/// <summary>
		/// kullanıcının eventleri
		/// </summary>
		/// <param name="q"></param>
		/// <returns></returns>
        IQueryable<WorkEventDTO> GetUserWorkEvents(string q);
		/// <summary>
		/// notification ekliyor
		/// </summary>
		/// <param name="noteID"></param>
		/// <param name="notificationID"></param>
		/// <returns></returns>
        Task TogleNotifiedMe(Guid evetID, string notificationID);
		/// <summary>
		/// eventi tamamala
		/// </summary>
		/// <param name="evetID"></param>
		/// <returns></returns>
        Task TogleComplated(Guid evetID);
    }
}

