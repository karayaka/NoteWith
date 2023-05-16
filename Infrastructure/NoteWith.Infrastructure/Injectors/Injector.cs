using System;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using NoteWith.Domain.DTOModels.SecurityModels;
namespace NoteWith.Infrastructure.Injectors
{
    public static class Injector
	{
        public static SessionModel SessionUser(IHttpContextAccessor httpContextAccessor)
        {
            var user = new SessionModel();

            if (httpContextAccessor.HttpContext == null)
            {
                user.ID = Guid.Empty;
            }
            else if (httpContextAccessor.HttpContext.User == null)
            {
                user.ID = Guid.Empty;
            }
            var val = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            if (val != null)
            {
                if (val != null)
                    user.ID = new Guid(val.Value);
                //mobilden gelen herkes müşteri
            }
            var name= httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name);
            if (name != null)
            {
                user.Name = name.Value;
            }
            var surname= httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Surname);
            if (surname != null)
                user.Surname = surname.Value;
            var email= httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email);
            if (email != null)
                user.Email = email.Value;
            var fireCon= httpContextAccessor.HttpContext.User.FindFirst("fireBaseConnectionID");
            if (fireCon != null)
                user.FireBaseConnectionID = fireCon.Value;
            var mailConfirmet = httpContextAccessor.HttpContext.User.FindFirst("IsMailConfirmet");
            if (mailConfirmet != null)
                user.IsConfirmeEmail = Convert.ToBoolean(mailConfirmet.Value);

            return user;
        }

    }
}

