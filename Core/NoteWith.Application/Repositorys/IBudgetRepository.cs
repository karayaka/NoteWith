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

    }
}
