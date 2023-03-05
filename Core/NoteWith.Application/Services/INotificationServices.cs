using System;
using NoteWith.Domain.DTOModels.NotifiedModels;

namespace NoteWith.Application.Services
{
	public interface INotificationServices
	{
		/// <summary>
		/// Bildirim gönderen metod 
		/// </summary>
		/// <param name="model">bildirim bilgileri</param>
		/// <returns></returns>
		Task SendNotificatiıon(NotificationDTO model);
	}
}

