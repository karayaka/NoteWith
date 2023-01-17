using System;
using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NoteWith.Application.Repositorys;
using NoteWith.Domain.DTOModels.SecurityModels;
using NoteWith.Domain.EntitiyModels.BaseModels;
using NoteWith.Domain.Enums;
using NoteWith.Persistence.NoteDataContexts;

namespace NoteWith.Infrastructure.Repositorys
{
	public class Repository: IRepository
    {
        private readonly NoteDataContext context;
        private readonly SessionModel user;//sesion model yaz ve moelle çalış
        
        public Repository(NoteDataContext _context, SessionModel _user)
		{
            context = _context;
            user = _user;
		}

        public async Task<T> Add<T>(T model) where T : BaseEntity
        {
            try
            {
                model.CreadedBy = user.ID;
                model.UpdatedBy = user.ID;
                await context.Set<T>().AddAsync(model);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<T>> AddRange<T>(IEnumerable<T> models) where T : BaseEntity
        {
            try
            {
                foreach (var item in models)
                {
                    item.CreadedBy = user.ID;
                    item.UpdatedBy = user.ID;
                }
                await context.Set<T>().AddRangeAsync(models);
                return models;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IQueryable<T>> AddRange<T>(IQueryable<T> models) where T : BaseEntity
        {
            try
            {
                foreach (var item in models)
                {
                    item.CreadedBy = user.ID;
                    item.UpdatedBy = user.ID;
                }
                await context.Set<T>().AddRangeAsync(models);
                return models;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Any<T>(Expression<Func<T, bool>> expression) where T : BaseEntity
        {
            try
            {
                return context.Set<T>().Any(expression);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AnyNonDeleted<T>(Expression<Func<T, bool>> expression) where T : BaseEntity
        {
            try
            {
                return GetNonDeleted<T>(expression).Any();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AnyNonDeletedAndActive<T>(Expression<Func<T, bool>> expression) where T : BaseEntity
        {
            try
            {
                return GetNonDeletedAndActive<T>(expression).Any();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<bool> CheckAppKey(string Key)
        {
            throw new NotImplementedException();
        }

        public int Count<T>(Expression<Func<T, bool>> expression) where T : BaseEntity
        {
            try
            {
                return GetNonDeleted<T>(expression).Count();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int CountNonDeleted<T>(Expression<Func<T, bool>> expression) where T : BaseEntity
        {
            try
            {
                return GetNonDeleted<T>(expression).Count();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int CountNonDeletedAndActive<T>(Expression<Func<T, bool>> expression) where T : BaseEntity
        {
            try
            {
                return GetNonDeletedAndActive<T>(expression).Count();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> Delete<T>(Guid ID) where T : BaseEntity
        {
            try
            {
                var model = await GetByID<T>(ID);
                await Delete<T>(model);
                return model;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> Delete<T>(T model) where T : BaseEntity
        {
            try
            {
                model.ObjectStatus = ObjectStatus.Deleted;
                model.Status = Status.Pasive;
                await Update<T>(model);
                return model;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<T>> DeleteRange<T>(IEnumerable<T> models) where T : BaseEntity
        {
            try
            {
                foreach (var item in models)
                {
                    await Delete(item);
                }
                return models;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> Find<T>(Expression<Func<T, bool>> expression) where T : BaseEntity
        {
            try
            {
                return await context.Set<T>().FirstOrDefaultAsync(expression);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> FindNonDeleted<T>(Expression<Func<T, bool>> expression) where T : BaseEntity
        {
            try
            {
                return await GetNonDeleted<T>(t => true).FirstOrDefaultAsync(expression);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> FindNonDeletedActive<T>(Expression<Func<T, bool>> expression) where T : BaseEntity
        {
            try
            {
                return await GetNonDeletedAndActive<T>(t => true).FirstOrDefaultAsync(expression);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<T> Get<T>(Expression<Func<T, bool>> expression) where T : BaseEntity
        {
            try
            {
                return context.Set<T>().Where(expression);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> GetByID<T>(Guid ID) where T : BaseEntity
        {
            try
            {
                return await context.Set<T>().FirstOrDefaultAsync(t => t.ID == ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<T> GetNonDeleted<T>(Expression<Func<T, bool>> expression) where T : BaseEntity
        {
            try
            {
                return Get<T>(t => t.ObjectStatus == ObjectStatus.NonDeleted).Where(expression);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<T> GetNonDeletedAndActive<T>(Expression<Func<T, bool>> expression) where T : BaseEntity
        {
            try
            {
                return GetNonDeleted<T>(t => t.Status == Status.Active).Where(expression);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetPageCount<T>(Expression<Func<T, bool>> expression, int pageSize) where T : BaseEntity
        {
            try
            {
                var count = context.Set<T>().Count(expression);
                return (count / pageSize);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int GetPageCount<T>(int pageSize) where T : BaseEntity
        {
            try
            {
                return GetPageCount<T>(t => t.ObjectStatus == ObjectStatus.NonDeleted && t.Status == Status.Active, pageSize);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int GetPageCount<T>(IQueryable<T> models, int pageSize) where T : BaseEntity
        {
            try
            {
                var count = models.Count();
                return (count / pageSize);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IQueryable<T> GetPaginate<T>(IQueryable<T> models, int pageCount, int pageSize) where T : BaseEntity
        {
            try
            {
                return models.Skip<T>(pageCount * pageSize).Take(pageSize);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Guid> Remove<T>(Guid ID) where T : BaseEntity
        {
            try
            {
                var model = await GetByID<T>(ID);
                context.Remove(model);
                return ID;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void RemoveRange<T>(IEnumerable<T> models) where T : BaseEntity
        {
            try
            {
                context.RemoveRange(models);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public TResult SelectByID<T, TResult>(int ID, Expression<Func<T, TResult>> selection) where T : BaseEntity
        {
            throw new NotImplementedException();
        }

        public async Task<T> Update<T>(T Entitiy) where T : BaseEntity
        {
            try
            {
                Entitiy.UpdatedDate = DateTime.Now;
                Entitiy.UpdatedBy = user.ID;
                context.Update(Entitiy);
                return Entitiy;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<T>> UpdateRange<T>(IEnumerable<T> models) where T : BaseEntity
        {
            try
            {
                foreach (var item in models)
                {
                    item.UpdatedDate = DateTime.Now;
                    item.UpdatedBy = user.ID;
                    item.Status = Status.Active;
                }
                context.UpdateRange(models);
                return models;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

