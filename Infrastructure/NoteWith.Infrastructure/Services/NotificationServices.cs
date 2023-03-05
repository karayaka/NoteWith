using System;
using AutoMapper;
using NoteWith.Application.Services;
using NoteWith.Domain.DTOModels.NotifiedModels;
using NoteWith.Domain.EntitiyModels.NotifiedModels;
using NoteWith.Persistence.NoteDataContexts;

namespace NoteWith.Infrastructure.Services
{
	public class NotificationServices: INotificationServices
    {
        private readonly NoteDataContext context;
        private readonly IMapper mapper;
        public NotificationServices(NoteDataContext _context, IMapper _mapper)
		{
            context = _context;
            mapper = _mapper;
		}

        public async Task SendNotificatiıon(NotificationDTO model)
        {
            try
            {
                //bidimi gönderecek ve bildirimleri veri tabanına ekelecek kod
                var noti = mapper.Map<NotificationModel>(model);
                context.Add(noti);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

