using System;
using AutoMapper;
using NoteWith.Domain.DTOModels.GroupModels;
using NoteWith.Domain.DTOModels.NoteModels;
using NoteWith.Domain.DTOModels.NotifiedModels;
using NoteWith.Domain.DTOModels.SecurityModels;
using NoteWith.Domain.DTOModels.WorklistModels;
using NoteWith.Domain.EntitiyModels.GroupModels;
using NoteWith.Domain.EntitiyModels.NoteModels;
using NoteWith.Domain.EntitiyModels.NotifiedModels;
using NoteWith.Domain.EntitiyModels.UserModels;
using NoteWith.Domain.EntitiyModels.WorkLists;

namespace NoteWith.Infrastructure.MapperProfiles
{
	public class MapperProfile : Profile
    {
		public MapperProfile()
		{
			//userModels
			CreateMap<UserModel, RegisterDTO>().ReverseMap();
            CreateMap<UserModel, SessionModel>().ReverseMap();
			//grup modelleri
            CreateMap<WorkGroup, GroupDTO>().ReverseMap();
            CreateMap<WorkGroup, GroupListDTO>().ReverseMap();
            //Note modelleri
            CreateMap<NoteCreateDTO, Note>().ReverseMap();
            //NotifiedModels
            CreateMap<NotificationModel, NotificationDTO>().ReverseMap();
            //work list models
            CreateMap<WorkListItemDTO, WorkList>().ReverseMap();


        }
    }
}

