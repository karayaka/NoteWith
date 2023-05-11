using NoteWith.Domain.DTOModels.BudgetModels;
using NoteWith.Domain.EntitiyModels.BudgetModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteWith.Application.Repositorys
{
    public interface IBudgetRepository:IRepository
    {
        Task<IQueryable<BudgetListDTO>> GetAllBudget();
        IQueryable<BudgetListDTO> GetUserBudget();
        /// <summary>
        /// Bütçe ekleme
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task AddBudget(BudetCreateDTO model);
        /// <summary>
        /// Bütçe güncelleme
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task UpdateBudget(BudetCreateDTO model);
        /// <summary>
        /// bütçe kayıları sil
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteBudget(Guid id);
        /// <summary>
        /// Bütçe etalarını getiran kod
        /// </summary>
        /// <param name="budgetId"></param>
        /// <returns></returns>
        IQueryable<BudgetDetail> GetBudgetDetail(Guid? budgetId,string q);

        /// <summary>
        /// bütçeye kayıt ekleme işlemi düşüş veye yükseliş
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task AddBudgetDetail(BudgetDetailCreateDTO model);
        /// <summary>
        /// Eklenene kayıt güncellemesi
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task UpdateBudgetDetail(BudgetDetailCreateDTO model);
        /// <summary>
        /// Detail KAydı slinmsi durumu
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteBudgetDetail(Guid id);
        /// <summary>
        /// bütçe güncellemeye yetkilimi?
        /// </summary>
        /// <param name="budget"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<bool> IsAuth(Budget budget, Guid userId);
        /// <summary>
        /// convet budget list model
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        IQueryable<BudgetListDTO> ConvertBudget(IQueryable<Budget> models);
        /// <summary>
        /// budeget detail convert
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        IQueryable<BudgetDetailListDTO> ConvertBudgetDetail(IQueryable<BudgetDetail> models);
        /// <summary>
        /// Budegt toplamı hesaplama
        /// </summary>
        /// <param name="budegtId"></param>
        /// <returns></returns>
        decimal CalculateBudegtTotal(Guid budegtId);
    }
}
