using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NoteWith.Application.Repositorys;
using NoteWith.Application.Services;
using NoteWith.Domain.DTOModels.CustomExceptionModels;
using NoteWith.Domain.DTOModels.SecurityModels;
using NoteWith.Domain.EntitiyModels.UserModels;
using NoteWith.Persistence.NoteDataContexts;

namespace NoteWith.Infrastructure.Repositorys
{
	public class SecurityRepository:ISecurityRepository
	{
        private readonly NoteDataContext context;
        private readonly IEmailService emailService;
        private readonly IMapper mapper;
        private readonly ITokenGeneratorService tokenService;
        public SecurityRepository(NoteDataContext _context, IEmailService _emailService, IMapper _mapper, ITokenGeneratorService _tokenService)
		{
            context = _context;
            emailService = _emailService;
            tokenService = _tokenService;

            mapper = _mapper;
		}
        //tekrer migrtion yapılmalı ve base controlleer ve repoler yazılmalı!!
        public async Task SendConfirmeEmail(Guid userID)
        {
            try
            {
                var user = await context.Users.FirstOrDefaultAsync(t => t.ID == userID);
                if (user == null)
                    throw new CusEx("Kullanıcı Bulunamadı");
                await SendConfirmeEmail(user);
            }
            catch (Exception ex)
            {
                throw new CusEx();
            }
        }

        public async Task SendConfirmeEmail(UserModel user)
        {
            try
            {
                var key = tokenService.DigitTokenGenerator();
                user.EmailConfirmeToken = key;
                await emailService.SendEmailConfirmeMail(user.Email, key);
                context.Update(user);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new CusEx();
            }
        }

        public async Task ConfirmeEmil(EmailConfirmeDTO model)
        {
            try
            {
                var user = await context.Users.FirstOrDefaultAsync(t => t.Email == model.Email&&t.EmailConfirmeToken==model.Token);
                if (user == null)
                    throw new CusEx("Hatalı Veya Süresi Geçmiş Kod");
                user.IsEmailConfirmed = true;
                context.Update(user);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<LoginResultModel> Login(LoginDTO model)
        {
            try
            {
                var user = await context.Users.FirstOrDefaultAsync(t => t.Email == model.Email && t.Password == model.Password);
                if (user == null)
                    throw new UnAuthEx("Kullanıcı Adı Veya Şifre Hatalı");
                return SetLoginResult(user);
            }
            catch (Exception ex)
            {
                throw new CusEx();
            }
        }

        public async Task<LoginResultModel> Register(RegisterDTO model)
        {
            try
            {
                if (!IsUnicEmail(model.Email))
                    throw new CusEx("Bu Mail ile Kullanıcı Bulunmaktadır Lütfen Şifrenizi Sıfırlayın");
                var user = mapper.Map<UserModel>(model);
                
                await context.AddAsync(user);
                await context.SaveChangesAsync();
                await SendConfirmeEmail(user);//email doğrulama şartmı olmalı
                return SetLoginResult(user);
            }
            catch (Exception ex)
            {
                throw new CusEx();
            }
        }

        public async Task ResetPassword(EmailConfirmeDTO model)
        {
            try
            {
                var user = await context.Users.FirstOrDefaultAsync(t => t.Email == model.Email && t.EmailConfirmeToken == model.Token);
                if (user == null)
                    throw new CusEx("Hatalı Veya Süresi Geçmiş Kod");
                user.IsEmailConfirmed = true;
                if (string.IsNullOrEmpty(model.NewPassword))
                    throw new CusEx("Şifre Alanı Zorunlu Alan");
                user.Password = model.NewPassword;
                context.Update(user);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task SendResetPasswordEmail(string email)
        {
            try
            {
                var user = await context.Users.FirstOrDefaultAsync(t => t.Email == email);
                if (user == null)
                    throw new CusEx("Kullanıcı Bulunamadı");
                user.IsEmailConfirmed = false;
                await SendConfirmeEmail(user);
            }
            catch (Exception ex)
            {
                throw new CusEx();
            }
        }

        public bool IsUnicEmail(string email)
        {
            try
            {
                return !context.Users.Any(t => t.Email == email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public LoginResultModel SetLoginResult(UserModel model)
        {
            try
            {
                var sesionModel = mapper.Map<SessionModel>(model);
                return new()
                {
                    Email = model.Email,
                    Name = model.Name,
                    Surname = model.Surname,
                    ID = model.ID,
                    IsConfirmeEmail = model.IsEmailConfirmed,
                    Token = tokenService.JWTTokenGenerate(sesionModel, DateTime.Now.AddDays(14)),
                    ProfilImage = model.ProfileImage ?? "",
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<LoginResultModel> GoogleLogin(RegisterDTO model)
        {
            try
            {
                var user = mapper.Map<UserModel>(model);
                user.IsEmailConfirmed = true;
                await context.AddAsync(user);
                await context.SaveChangesAsync();
                return SetLoginResult(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

