using LifeTrack.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LifeTrack.UI.Web.Controllers.Transactions
{
    public class TransactionCategoryController : Controller
    {
        private readonly ITransactionCategoryService _transactionCategoryService;
        
        public TransactionCategoryController(ITransactionCategoryService transactionCategoryService)
        {
            _transactionCategoryService = transactionCategoryService;
        }

        public async Task<IEnumerable<SelectListItem>> GetByType(int id)
        {
            var categories = await _transactionCategoryService.GetByTypeAsync(id);
            return categories.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
        }
    }
}
