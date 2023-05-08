using System;
using NoteWith.Domain.DTOModels.GroupModels;

namespace NoteWith.Application.Repositorys
{
	public interface IGroupRepository:IRepository
	{
		/// <summary>
		/// Kullanıcının Üyesi Olduğu Gruğları Getirir Ve yetkileri ile getiren kod
		/// </summary>
		/// <returns></returns>
		Task<IQueryable<GroupListDTO>> GetUserGroup();
		/// <summary>
		/// grop eklecek ve sessiondaki
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		Task AddGuop(GroupDTO model);
		/// <summary>
		/// gruıp adi ve rengini değiştirm işlemi
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		Task EditGroup(GroupDTO model);
		/// <summary>
		/// yetkiye göre gruop silme
		/// </summary>
		/// <param name="uid"></param>
		/// <returns></returns>
		Task DeleteGroup(Guid uid);

        /// <summary>
        /// Gurup Paylaşma İşlemi Sırasında keyOluşturma işlemi
        /// ve bu key paylaşım keyini kaydeten kod bloğu
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<string> GenerateShareGroupKey(Guid Id);
		/// <summary>
		/// Oluşturulan key e göre kullanıcı gruba eklenecek
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		Task JoinWorkGroupWithAccesKey(string key);
		/// <summary>
		/// grubdan ayrıma kodu
		/// Gruptaki son kişi ise ayrılan group siliniyor
		/// yönetici ise yönticiliği devrediyor
		/// </summary>
		/// <param name="gruopID"></param>
		/// <returns></returns>
		Task LeaveGruop(Guid gruopID);
		/// <summary>
		/// Sesiondaki Grup Yöneticisimi
		/// </summary>
		/// <returns></returns>
		bool IsManager(Guid workGroupID);
		/// <summary>
		/// verilen ID Deki Kişi Grup Yöneticisimi
		/// </summary>
		/// <param name="userID"></param>
		/// <param name="workGroupID"></param>
		/// <returns></returns>
		bool IsManager(Guid userID, Guid workGroupID);
		/// <summary>
		/// Grubu sessize al veye sesliye al!
		/// </summary>
		/// <param name="uid"></param>
		/// <returns></returns>
		Task SetNuteTogle(Guid uid);
		/// <summary>
		/// Kullanıcının grupları
		/// </summary>
		/// <returns></returns>
		Task<List<Guid>> GetUserAuthWorkGroup();
		/// <summary>
		/// kullanıcının yönetici olduğu gruplar
		/// </summary>
		/// <returns></returns>
        Task<List<Guid>> GetUserManagerWorkGroup();
		/// <summary>
		/// gruptan ayrılma işlemni yapan yönetici ise yönticilik devredilir
		/// </summary>
		/// <param name="groupID"></param>
		/// <returns></returns>
		Task SetNextManager(Guid groupID);
		/// <summary>
		/// Eğer gruptan son ayrılan kişi ise oturumdaki kullanıcı grup silinir
		/// </summary>
		/// <param name="groupID"></param>
		/// <returns></returns>
		Task<bool> CheckGroupMemberByLeave(Guid groupID);
		/// <summary>
		/// Grup içerisindeki kullanıcıları getiren kod
		/// </summary>
		/// <param name="groupID"></param>
		/// <returns></returns>
		Task<List<Guid>> GetGroupUsers(Guid groupID);
    }
}

