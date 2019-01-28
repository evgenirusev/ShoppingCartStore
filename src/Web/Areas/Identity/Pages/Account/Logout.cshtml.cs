using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ShoppingCartStore.Models;
using ShoppingCartStore.Services.DataServices;
using SoppingCartStore.Common.Helpers;

namespace SoppingCartStore.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<Customer> _signInManager;
        private readonly ILogger<LogoutModel> _logger;
        private readonly ICartService _cartService;

        public LogoutModel(SignInManager<Customer> signInManager
            , ILogger<LogoutModel> logger, ICartService cartService)
        {
            _signInManager = signInManager;
            _logger = logger;
            _cartService = cartService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {

            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");

            _cartService.ClearSessionCart(HttpContext.Session);

            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return Page();
            }
        }
    }
}