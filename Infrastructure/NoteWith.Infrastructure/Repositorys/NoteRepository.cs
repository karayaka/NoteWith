using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NoteWith.Application.Repositorys;
using NoteWith.Domain.DTOModels.CustomExceptionModels;
using NoteWith.Domain.DTOModels.GroupModels;
using NoteWith.Domain.DTOModels.NoteModels;
using NoteWith.Domain.DTOModels.SecurityModels;
using NoteWith.Domain.EntitiyModels.NoteModels;
using NoteWith.Domain.Enums;
using NoteWith.Persistence.NoteDataContexts;

namespace NoteWith.Infrastructure.Repositorys
{
	public class NoteRepository:Repository,INoteRepository
	{
        private readonly NoteDataContext context;
        private readonly SessionModel user;
        private readonly IMapper mapper;
        private readonly IUnitOfWork uow;
        public NoteRepository(NoteDataContext _context, SessionModel _user,IMapper _mapper,IUnitOfWork _uow):base(_context,_user)
		{
            context = _context;
            user = _user;
            mapper = _mapper;
            uow = _uow;
		}
        //add ve delete metodlarıyazılacak!
        public async Task AddNote(NoteCreateDTO model)
        {
            try
            {
                var note = mapper.Map<Note>(model);
                await Add(note);
                //paylaşılan gruplara eklendi
                if (model.SharedGoups != null)
                {
                    foreach (var groupID in model.SharedGoups)
                    {
                        var noteGroup = new NoteGroup()
                        {
                            Note = note,
                            WorkGroupID = groupID
                        };
                        await Add(noteGroup);
                    }
                }
                //notta değişiklik olunca haberdar et beni 
                var notifire = new NoteNotifiedMe()
                {
                    Note = note,
                    UserID = user.ID
                };
                await Add(notifire);
                await uow.SaveChange();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<NoteListDTO> ConverNoteModels(IQueryable<Note> notes)
        {
            try
            {
                    return notes.Select(s => new NoteListDTO()
                    {
                        ID = s.ID,
                        CanEdit = (s.CreadedBy==user.ID)||(s.GroupEditable),//editlye bilmesi için kedi notu olmalı veya grup edite açık olmalı!!
                        Color = s.Color,
                        Content = s.Content,
                        Title=s.Title,
                        IsOwner = (s.CreadedBy == user.ID),
                        NotifiedMe=s.Notifieds.Any(t=>t.UserID==user.ID&&t.ObjectStatus==ObjectStatus.NonDeleted),//eğer bu kullanıcı kendini haber vere ekledi ise notta değişiklik olunca haberdar edileceks 
                        NoteGroups = s.NoteGroups.Where(t=>t.ObjectStatus==ObjectStatus.NonDeleted&&t.Status==Status.Active)
                        .Select(ns => new GroupListDTO()
                        {
                            Color = ns.WorkGroup.Color,
                            ID = ns.WorkGroupID,
                            Name = ns.WorkGroup.Name,
                        }).ToList(),
                    });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteNote(Guid noteID)
        {
            try
            {
                var note = await GetByID<Note>(noteID);
                if (note.GroupEditable)
                {
                    var authUsers = await GetNoteGroupUsers(noteID);
                    if (authUsers.Any(t => t == user.ID))
                    {
                        await Delete(note);
                        await uow.SaveChange();
                        return;
                    }
                }
                if (note.CreadedBy == user.ID)
                {
                    await Delete(note);
                    await uow.SaveChange();
                    return;
                }
                else
                    throw new CusEx("Bu Notu Silme Yetkiniiz Yok!");//bu hata mesajaları nasıl multi languge yapılabilir!
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //burdaki algoritmaya bakılacak
        public async Task<IQueryable<Note>> GetAllNotes(string q, List<Guid> groupID)
        {
            try
            {
                //Kullanıcının Grupları!
                var authGroups = await uow.GroupRepository.GetUserAuthWorkGroup();
                //Kullanıcının Kendi Oluşturduğu notlar!

                var noteIDs = await GetNonDeletedAndActive<Note>(t => t.CreadedBy == user.ID).Select(s => s.ID).ToListAsync();
                //Kullanıcının Bağlı Oluğu Grup İle Paylaşılan Notlar! kullanıcı notları hariç!!
                var groupNoteIDs = new List<Guid>();

                if (groupID.Count<=0)
                    groupNoteIDs = await GetNonDeletedAndActive<NoteGroup>(t => authGroups.Contains(t.WorkGroupID)).Select(s => s.NoteID).ToListAsync();
                else
                    groupNoteIDs = await GetNonDeletedAndActive<NoteGroup>(t => groupID.Contains(t.WorkGroupID)).Select(s => s.NoteID).ToListAsync();

                foreach (var item in groupNoteIDs)
                {
                    if (!noteIDs.Contains(item))
                        noteIDs.Add(item);
                }

                var notes = GetNonDeletedAndActive<Note>(t => noteIDs.Contains(t.ID));
                //başlıktan arama
                if (!string.IsNullOrEmpty(q))
                    notes = notes.Where(t => t.Title.ToLower().Contains(q.ToLower()));

                return notes;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        //excludet yapısını ele görmek istmiyorsa grptan ayrılsın! uygulamada benim notlarım tüm notlar diye ayrılabisin
        //etikete göre filitreleme yapılabvildsin!!
        public async Task<IQueryable<Note>> GetGroupsNotes(string q, List<Guid> groupID)
        {
            try
            {
                List<Guid> unickNoteIDs = new();
                if(groupID.Count<=0)
                    groupID=await uow.GroupRepository.GetUserAuthWorkGroup();
                var groupNoteIDs = await GetNonDeletedAndActive<NoteGroup>(t => groupID.Contains(t.WorkGroupID)).Select(s => s.NoteID).ToListAsync();
                foreach (var item in groupNoteIDs)
                {
                    if(!unickNoteIDs.Contains(item))
                        unickNoteIDs.Add(item);
                }
                var notes = GetNonDeletedAndActive<Note>(t => unickNoteIDs.Contains(t.ID));
                //başlıktan arama
                if (!string.IsNullOrEmpty(q))
                    notes = notes.Where(t => t.Title.ToLower().Contains(q.ToLower()));

                return notes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<Note> GetUserNotes(string q)
        {
            try
            {
                var notes = GetNonDeletedAndActive<Note>(t => t.CreadedBy == user.ID);
                if(!string.IsNullOrEmpty(q))
                    notes= notes.Where(t => t.Title.ToLower().Contains(q.ToLower()));

                return notes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task SetExcludeMe(Guid noteID)
        {
            throw new NotImplementedException();
        }

        public async Task TogleNotifiedMe(Guid noteID)
        {
            try
            {
                var notiferd = await FindNonDeleted<NoteNotifiedMe>(t => t.NoteID == noteID && t.UserID == user.ID);
                if (notiferd != null)                
                    await Delete(notiferd);
                else
                {
                    await Add<NoteNotifiedMe>(new()
                    {
                        UserID=user.ID,
                        NoteID=noteID,
                    });
                }
                await uow.SaveChange();


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //tek tek paylaşma işlemi
        public async Task ShareGroup(Guid noteID, List<Guid> groupID)
        {
            try
            {
                foreach (var item in groupID)
                {
                    if (AnyNonDeletedAndActive<NoteGroup>(t => t.WorkGroupID == item && t.NoteID == noteID))
                        continue;
                    await Add<NoteGroup>(new()
                    {
                        NoteID=noteID,
                        WorkGroupID=item
                    });
                }
                var removetShareing = GetNonDeletedAndActive<NoteGroup>(t => !groupID.Contains(t.WorkGroupID));//bu kod test edilecek!!
                RemoveRange(removetShareing);//çıkartılan grouplr dbden kaldırıloyor
                await uow.SaveChange();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateNote(NoteCreateDTO model)
        {
            try
            {
                var note = await GetByID<Note>(model.ID);
                if (note.GroupEditable)
                {
                    var authUsers = await GetNoteGroupUsers(model.ID);
                    if (authUsers.Any(t => t == user.ID))
                    {
                        mapper.Map<NoteCreateDTO, Note>(model, note);
                        await Update(note);
                        await uow.SaveChange();
                        return;
                    }
                }
                if (note.CreadedBy == user.ID)
                {
                    mapper.Map<NoteCreateDTO, Note>(model, note);
                    await Update(note);
                    await uow.SaveChange();
                    return;
                }
                else
                    throw new CusEx("Bu Notu Güncelleme Yetkiniiz Yok!");//bu hata mesajaları nasıl multi languge yapılabilir!

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task LeaveGroup(Guid groupID, Guid noteID)
        {
            try
            {
                var noteGroup = await FindNonDeletedActive<NoteGroup>(t => t.WorkGroupID == groupID && t.NoteID == noteID);
                await Delete(noteGroup);
                await uow.SaveChange();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Guid>> GetNoteGroupUsers(Guid noteID)
        {
            try
            {
                var users = new List<Guid>();
                //notun grupları bulunuyor
                var noteGroups = await GetNonDeletedAndActive<NoteGroup>(t => t.NoteID == noteID)
                    .Select(s => s.WorkGroupID).ToListAsync();
                foreach (var gropID in noteGroups)
                {
                    var gropuUser = await uow.GroupRepository.GetGroupUsers(gropID);
                    foreach (var userID in gropuUser)
                    {
                        if (!users.Any(t => t == userID))
                            users.Add(userID);
                    }
                }
                return users;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

