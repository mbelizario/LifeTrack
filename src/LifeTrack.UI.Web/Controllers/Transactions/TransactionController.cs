using LifeTrack.Application.DTOs;
using LifeTrack.Application.Interfaces;
using LifeTrack.Application.Services;
using LifeTrack.UI.Web.ViewModels.Transaction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;
using System.Reflection;

namespace LifeTrack.UI.Web.Controllers.Transactions
{
    public class TransactionController : Controller
    {
        private readonly ITransactionCategoryService _transactionCategoryService;
        private readonly ITransactionService _transactionService;
        public TransactionController(ITransactionCategoryService transactionCategoryService,
                                    ITransactionService transactionService)
        {
            _transactionCategoryService = transactionCategoryService;
            _transactionService = transactionService;
        }
        public async Task<IActionResult> Create()
        {
            var viewModel = new TransactionCreateViewModel()
            {
                Types = new List<SelectListItem> { new SelectListItem() { Text = "Entrada", Value = "1"}, new SelectListItem() { Text = "Saída", Value = "2" } }
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] CreateTransactionInput input)
        {
            try
            {
                if (!DateTime.TryParseExact(input.TransactionDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                {
                    return BadRequest("Data em formato inválido.");
                }
                if (!ModelState.IsValid)
                    throw new Exception();

                input.StatusId = 1;
                await _transactionService.InsertAsync(input);
                return Ok(new { message = "Transação inserida com sucesso!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao inserir transação: {ex.Message}");
            }

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
