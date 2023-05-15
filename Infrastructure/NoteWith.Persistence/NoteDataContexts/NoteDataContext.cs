using System;
using Microsoft.EntityFrameworkCore;
using NoteWith.Domain.EntitiyModels.BudgetModels;
using NoteWith.Domain.EntitiyModels.EventModels;
using NoteWith.Domain.EntitiyModels.GroupModels;
using NoteWith.Domain.EntitiyModels.MessageModels;
using NoteWith.Domain.EntitiyModels.NoteModels;
using NoteWith.Domain.EntitiyModels.NoticeModels;
using NoteWith.Domain.EntitiyModels.NotifiedModels;
using NoteWith.Domain.EntitiyModels.UserModels;
using NoteWith.Domain.EntitiyModels.WorkFiles;
using NoteWith.Domain.EntitiyModels.WorkLists;

namespace NoteWith.Persistence.NoteDataContexts
{
	public class NoteDataContext:DbContext
	{
        //veri tabanı yeniden oluşturulacak!
		public NoteDataContext(DbContextOptions options):base(options)
		{
		}
		//userModelleri
		public DbSet<UserModel> Users { get; set; }
		//even modelleri
        public DbSet<WorkEvent> WorkEvents { get; set; }

        public DbSet<WorkEventExcludedUser> WorkEventExcludedUsers { get; set; }

		public DbSet<WorkEventGroup> WorkEventGroups { get; set; }

        public DbSet<WorkEventNotifiedMe> WorkEventNotifiedMes { get; set; }
        //work group models
        public DbSet<WorkGroup> WorkGroups { get; set; }

        public DbSet<WorkGroupUsers> WorkGroupUsers { get; set; }

        public DbSet<WorkGroupAccesKey> WorkGroupAccesKeys { get; set; }
        //message models
        public DbSet<PersonelMessageModel> PersonelMessageModels { get; set; }

        public DbSet<WorkGroupMessage> WorkGroupMessages { get; set; }
        //notemodels
        public DbSet<Note> Notes { get; set; }

        public DbSet<NoteExcludedUser> NoteExcludedUsers { get; set; }

        public DbSet<NoteGroup> NoteGroups { get; set; }

        public DbSet<NoteNotifiedMe> NoteNotifiedMes { get; set; }
        //notice duyuru models
        public DbSet<Notice> Notices { get; set; }

        public DbSet<NoticeSeenUser> NoticeSeenUsers { get; set; }

        public DbSet<WorkGroupNotice> WorkGroupNotices { get; set; }
        //WorkFiles
        public DbSet<WorkFile> WorkFiles { get; set; }

        public DbSet<WorkFilesFolder> WorkFilesFolders { get; set; }

        public DbSet<WorkGroupAlbum> WorkGroupAlbums { get; set; }

        public DbSet<WorkPhoto> WorkPhotos { get; set; }
        //work list models
        public DbSet<ListWorkGroup> ListWorkGroups { get; set; }

        public DbSet<WorkList> WorkLists { get; set; }

        public DbSet<WorkListExcludedUser> WorkListExcludedUsers { get; set; }

        public DbSet<WorkListItem> WorkListItems { get; set; }

        public DbSet<WorkListNotifiedMe> WorkListNotifiedMes { get; set; }
        //notifire models
        public DbSet<NotificationModel> Notifications { get; set; }
        //budget
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<BudgetDetail> BudgetDetails { get; set; }
    }
}

