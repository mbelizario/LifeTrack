using LifeTrack.Application.Interfaces;
using LifeTrack.UI.Web.ViewModels.Transaction.TransactionCategory;
using Microsoft.AspNetCore.Mvc;

namespace LifeTrack.UI.Web.Controllers.Transactions
{
    public class TransactionCategoryController : Controller
    {
        private readonly ITransactionCategoryService _transactionCategoryService;
        
        public TransactionCategoryController(ITransactionCategoryService transactionCategoryService)
        {
            _transactionCategoryService = transactionCategoryService;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }

    }
}
