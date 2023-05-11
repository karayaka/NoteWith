using AutoMapper;
using NoteWith.Application.Repositorys;
using NoteWith.Domain.DTOModels.BudgetModels;
using NoteWith.Domain.DTOModels.CustomExceptionModels;
using NoteWith.Domain.DTOModels.SecurityModels;
using NoteWith.Domain.EntitiyModels.BudgetModels;
using NoteWith.Domain.EntitiyModels.GroupModels;
using NoteWith.Domain.Enums;
using NoteWith.Persistence.NoteDataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NoteWith.Infrastructure.Repositorys
{
    public class BudgetRepository : Repository, IBudgetRepository
    {
        private readonly NoteDataContext context;
        private readonly SessionModel user;
        private readonly IMapper mapper;
        private readonly IUnitOfWork uow;

        public BudgetRepository(NoteDataContext _context, SessionModel _user, IMapper _mapper, IUnitOfWork _uow)
            : base(_context, _user)
        {
            context = _context;
            user = _user;
            mapper = _mapper;
            uow = _uow;
        }
        
        public async Task AddBudget(BudetCreateDTO model)
        {
            try
            {
                var budget = new Budget() 
                {
                    BudgetName= model.BudgetName,
                };
                if (model.UserID != null)
                {
                    budget.UserID = model.UserID;
                    budget.BudgeType = BudgeType.personel;
                }
                else
                {
                    budget.WorkGroupID = model.WorkGroupID;
                    budget.BudgeType = BudgeType.group;
                    if (!(await IsAuth(budget, user.ID)))
                        throw new CusEx("Yöneticisi Olamdığınız Grubab Bütçe ekleyemezsiniz");
                }
                await Add(budget);
                    
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateBudget(BudetCreateDTO model)
        {
            try
            {
                var budget = await GetByID<Budget>(model.ID);
                if (!(await IsAuth(budget, user.ID)))
                    throw new CusEx("Büteçeyi güncellemeyezsiniz!");
                budget.BudgetName= model.BudgetName;
                if (model.UserID != null)
                {
                    budget.UserID = model.UserID;
                    budget.BudgeType = BudgeType.personel;
                }
                else
                {
                    budget.WorkGroupID = model.WorkGroupID;
                    budget.BudgeType = BudgeType.group;
                }
                await Update(budget);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task DeleteBudget(Guid ID)
        {
            try
            {
                var budget = await GetByID<Budget>(ID);
                if ((await IsAuth(budget, user.ID)))
                    throw new CusEx("Bütçeyi silemezsiniz");
                await Delete(budget);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddBudgetDetail(BudgetDetailCreateDTO model)
        {
            try
            {
                await Add(new BudgetDetail()
                {
                   BudgetID=model.BudgetID,
                   Desc=model.Desc,
                   BudgetDetailType=model.BudgetDetailType,
                   UserID=user.ID,
                   Sum=model.Sum,
                });
                var budegt = await GetByID<Budget>(model.BudgetID);
                budegt.BudgetTotal =CalculateBudegtTotal(model.BudgetID);
                await Update(budegt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteBudgetDetail(Guid id)
        {
            try
            {
                var budegtDetail=await GetByID<BudgetDetail>(id);
                await Delete(budegtDetail);
                var budegt = await GetByID<Budget>(budegtDetail.BudgetID);
                budegt.BudgetTotal = CalculateBudegtTotal(budegtDetail.BudgetID);
                await Update(budegt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateBudgetDetail(BudgetDetailCreateDTO model)
        {
            try
            {
                var budgetDetail = await GetByID<BudgetDetail>(model.ID);
                budgetDetail.Desc = model.Desc;
                budgetDetail.BudgetDetailType = model.BudgetDetailType;
                await Update(budgetDetail);
                var budegt = await GetByID<Budget>(model.BudgetID);
                budegt.BudgetTotal = CalculateBudegtTotal(model.BudgetID);
                await Update(budegt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> IsAuth(Budget budget, Guid userId)
        {
            try
            {
                if(budget.BudgeType==BudgeType.personel)
                    return budget.CreadedBy==userId;
                var detail = await FindNonDeletedActive<WorkGroupUsers>(t => t.WorkGroupID == budget.WorkGroupID && t.UserID == userId);
                if (detail != null)
                    return detail.IsManager;
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IQueryable<BudgetListDTO>> GetAllBudget()
        {
            try
            {
                var authGroups = await uow.GroupRepository.GetUserAuthWorkGroup();
                return ConvertBudget(GetNonDeletedAndActive<Budget>(t => authGroups.Contains(t.ID) || t.UserID == user.ID));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<BudgetListDTO> GetUserBudget()
        {
            try
            {
                var budget = GetNonDeletedAndActive<Budget>(t => t.UserID == user.ID);
                return ConvertBudget(budget);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public IQueryable<BudgetListDTO> ConvertBudget(IQueryable<Budget> models)
        {
            try
            {
                return models.Select(s => new BudgetListDTO()
                {
                    BudgetName=s.BudgetName,
                    BudgeType=s.BudgeType,
                    ID=s.ID,
                    WorkGroupID=s.WorkGroupID,
                    WorkGroupName=s.WorkGroup!.Name
                });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IQueryable<BudgetDetail> GetBudgetDetail(Guid? budgetId,string q)
        {
            try
            {
                var details = GetNonDeletedAndActive<BudgetDetail>(t => t.BudgetID == budgetId);
                if (!string.IsNullOrEmpty(q))
                    details = details.Where(t => t.Desc.ToLower().Contains(q.ToLower()));
                return details;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<BudgetDetailListDTO> ConvertBudgetDetail(IQueryable<BudgetDetail> models)
        {
            try
            {
                return models.Select(s => new BudgetDetailListDTO()
                {
                    BudgetDetailType=s.BudgetDetailType,
                    BudgetID=s.BudgetID,
                    Desc=s.Desc,
                    ID=s.ID,
                    Sum=s.Sum,
                    UserID=s.UserID,
                    UserName=$"{s.User.Name} {s.User.Surname}"
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal CalculateBudegtTotal(Guid budegtId)
        {
            try
            {
                var incrs = GetNonDeletedAndActive<BudgetDetail>(t => t.BudgetDetailType == BudgetDetailType.increase)
                    .Sum(s => s.Sum);
                var decrs= GetNonDeletedAndActive<BudgetDetail>(t => t.BudgetDetailType == BudgetDetailType.decrease)
                    .Sum(s => s.Sum);
                return incrs - decrs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
