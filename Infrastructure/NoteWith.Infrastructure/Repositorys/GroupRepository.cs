using System;
using System.Security.Cryptography;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NoteWith.Application.Repositorys;
using NoteWith.Domain.DTOModels.CustomExceptionModels;
using NoteWith.Domain.DTOModels.GroupModels;
using NoteWith.Domain.DTOModels.SecurityModels;
using NoteWith.Domain.EntitiyModels.GroupModels;
using NoteWith.Domain.Enums;
using NoteWith.Persistence.NoteDataContexts;

namespace NoteWith.Infrastructure.Repositorys
{
	public class GroupRepository:Repository, IGroupRepository
    {
        private readonly NoteDataContext context;
        private readonly SessionModel user;
        private readonly IMapper mapper;
        private readonly IUnitOfWork uow;

        public GroupRepository(NoteDataContext _context, SessionModel _user,IMapper _mapper, IUnitOfWork _uow) :base(_context, _user)
		{
            context = _context;
            user = _user;
            mapper = _mapper;
            uow = _uow;
        }
        //grup işlemlerinde devam edielecek
        public async Task AddGuop(GroupDTO model)
        {
            try
            {
                var gruop = mapper.Map<WorkGroup>(model);

                await Add(gruop);
                var groupFirstUser = new WorkGroupUsers()
                {
                    UserID = user.ID,
                    WorkGroup=gruop,
                    IsManager=true,
                    IsNute=false,
                };
                await Add(groupFirstUser);
                await uow.SaveChange();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> CheckGroupMemberByLeave(Guid groupID)
        {
            try
            {
                var groupUser = CountNonDeletedAndActive<WorkGroupUsers>(t => t.WorkGroupID == groupID&&t.UserID==user.ID);
                if (groupUser <= 0)
                    return false;
                await Delete<WorkGroup>(groupID);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        public async Task DeteGroup(Guid uid)
        {
            try
            {
                if (!IsManager(uid))
                    throw new CusEx("Yöneticisi Oladınız Grubu Silemezsini");
                var group = await GetByID<WorkGroup>(uid);
                await Delete(group);
                await uow.SaveChange();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task EditGroup(GroupDTO model)
        {
            try
            {
                if (!IsManager(model.ID))
                    throw new CusEx("Yöneticisi Oladınız Grubu Güncelleyemezsiniz");
                var group = await GetByID<WorkGroup>(model.ID);
                var editGroup = mapper.Map<GroupDTO, WorkGroup>(model, group);
                await Update(editGroup);
                await uow.SaveChange();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Guid>> GetGroupUsers(Guid groupID)
        {
            try
            {
                return await GetNonDeletedAndActive<WorkGroupUsers>(t => t.WorkGroupID == groupID)
                    .Select(s=>s.UserID).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Guid>> GetUserAuthWorkGroup()
        {
            try
            {
                return await (await GetUserGroup()).Select(s => s.ID).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //grubun kullanacılarını getiriren kod yazılacak
        public async Task<IQueryable<GroupListDTO>> GetUserGroup()
        {
            try
            {
                return GetNonDeletedAndActive<WorkGroupUsers>(t => t.UserID == user.ID).Select(s => new GroupListDTO()
                {
                    ID=s.WorkGroupID,
                    Name=s.WorkGroup.Name,
                    Color=s.WorkGroup.Color,
                    IsManager=s.IsManager
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Guid>> GetUserManagerWorkGroup()
        {
            try
            {
                return await (await GetUserGroup()).Where(t => t.IsManager == true).Select(s => s.ID).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsManager(Guid workGroupID)
        {
            try
            {
                return IsManager(workGroupID, user.ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsManager(Guid userID, Guid workGroupID)
        {
            try
            {
                return AnyNonDeletedAndActive<WorkGroupUsers>(t => t.WorkGroupID == workGroupID &&
                t.UserID == userID && t.IsManager == true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task LeaveGruop(Guid gruopID)
        {
            try
            {
                if (await CheckGroupMemberByLeave(gruopID))
                    return;
                await SetNextManager(gruopID);
                var groupUser = await FindNonDeletedActive<WorkGroupUsers>(t => t.WorkGroupID == gruopID &&
                t.UserID == user.ID);
                
                await Delete(groupUser);
                await uow.SaveChange();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task SetNextManager(Guid groupID)
        {
            try
            {
                var workUser =  AnyNonDeletedAndActive<WorkGroupUsers>(t => t.WorkGroupID == groupID
                && t.UserID == user.ID&&t.IsManager==true);
                if (!workUser)
                    return;
                var nextUser = await GetNonDeletedAndActive<WorkGroupUsers>(t => t.UserID != user.ID&&t.IsManager==false)
                    .OrderBy(t => t.CreadedDate).FirstOrDefaultAsync();
                if (nextUser == null)
                    return;
                nextUser.IsManager = true;
                await Update(nextUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task SetNuteTogle(Guid uid)
        {
            try
            {
                var worGroupUser = await FindNonDeletedActive<WorkGroupUsers>(t => t.WorkGroupID == uid && t.UserID == user.ID);
                worGroupUser.IsNute = !worGroupUser.IsNute;
                await Update(worGroupUser);
                await uow.SaveChange();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

