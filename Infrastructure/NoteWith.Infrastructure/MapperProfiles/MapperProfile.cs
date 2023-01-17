using System;
using AutoMapper;
using NoteWith.Domain.DTOModels.SecurityModels;
using NoteWith.Domain.EntitiyModels.UserModels;

namespace NoteWith.Infrastructure.MapperProfiles
{
	public class MapperProfile : Profile
    {
		public MapperProfile()
		{
			CreateMap<UserModel, RegisterDTO>().ReverseMap();

            CreateMap<UserModel, SessionModel>().ReverseMap();
        }
	}
}

