using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineQuiz.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineQuiz.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class SearchController : Controller
    {
        [HttpPost]
        public IActionResult Find(string keyword)
        {
            var url = $"/admin/{Utilities.convertToUnSign(keyword).ToLower().Replace(' ', '-')}";
            return Redirect(url);
        }
    }
}
