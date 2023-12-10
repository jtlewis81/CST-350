﻿using Microsoft.AspNetCore.Mvc;
using Minesweeper.Models;
/*
 * CST-350
 * Dashboard Controller
 * This is where the user is taken to after logging in
 * 
 */
namespace Minesweeper.Controllers
{
    public class DashboardController : Controller
    {
        // dshboard/index view
        public IActionResult Index(UserModel user)
        {
            return View(user);
        }
    }
}
