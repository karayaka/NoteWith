using System;
using NoteWith.Domain.EntitiyModels.BaseModels;

namespace NoteWith.Domain.EntitiyModels.WorkFiles
{
	public class WorkFile:BaseEntity
	{
		public WorkFile()
		{
		}
		public Guid WorkFilesFolderID { get; set; }
        public WorkFilesFolder WorkFilesFolder { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}

