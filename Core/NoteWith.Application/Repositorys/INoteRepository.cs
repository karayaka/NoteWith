using System;
using NoteWith.Domain.DTOModels.NoteModels;
using NoteWith.Domain.EntitiyModels.NoteModels;

namespace NoteWith.Application.Repositorys
{
	public interface INoteRepository:IRepository
	{
		/// <summary>
		/// Oturumdki kullanıcı ve gruplarının notlarını getirenKod
		/// </summary>
		/// <returns></returns>
		Task<IQueryable<NoteListDTO>> GetAllNotes(string q, List<Guid> labelID);
		/// <summary>
		/// Oturumdaki Kullanıcnın Notları
		/// </summary>
		/// <param name="q"></param>
		/// <returns></returns>
        IQueryable<NoteListDTO> GetUserNotes(string q, List<Guid> labelID);
		/// <summary>
		/// Oturumdaki Kullanıcnın Group Notları
		/// </summary>
		/// <param name="q"></param>
		/// <returns></returns>
        Task<IQueryable<NoteListDTO>> GetGroupsNotes(string q, List<Guid> groupID);
        /// <summary>
        /// Note ekleme metodu Burda Share Özeliğide Alınacak
        /// </summary>
        /// <returns></returns>
        Task AddNote(NoteCreateDTO model);
		/// <summary>
		/// Sahibi Olduğun Nptu silme kodu
		/// </summary>
		/// <param name="noteID"></param>
		/// <returns></returns>
		Task DeleteNote(Guid noteID);
		/// <summary>
		/// Sahibi Olduğun veya public olan notu güncelleme
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		Task UpdateNote(NoteCreateDTO model);
		/// <summary>
		/// Notu Paylaşacağın grupları seç
		/// </summary>
		/// <param name="noteID"></param>
		/// <param name="groupID"></param>
		/// <returns></returns>
		Task ShareGroup(Guid noteID,List<Guid> groupID);
		/// <summary>
		/// seninle paylaşılan notu ignore et
		/// </summary>
		/// <param name="noteID"></param>
		/// <returns></returns>
		Task SetExcludeMe(Guid noteID);
		/// <summary>
		/// Note de değişiklik olursa haberdar et
		/// </summary>
		/// <param name="noteID"></param>
		/// <returns></returns>
		Task TogleNotifiedMe(Guid noteID);
		/// <summary>
		/// notları select ile reurn modelin ayarlayan kod
		/// </summary>
		/// <param name="notes"></param>
		/// <returns></returns>
		IQueryable<NoteListDTO> ConverNoteModels(IQueryable<Note> notes);
		/// <summary>
		/// Gruptak Paylaşımı kaldıranmetod
		/// </summary>
		/// <param name="groupID"></param>
		/// <param name="userID"></param>
		/// <returns></returns>
		Task LeaveGroup(Guid groupID, Guid noteID);
		/// <summary>
		/// notun paylaşıldığı grupların kullanıcılarını getiren kod
		/// </summary>
		/// <param name="noteID"></param>
		/// <returns></returns>
		Task<List<Guid>> GetNoteGroupUsers(Guid noteID);
    }
}

