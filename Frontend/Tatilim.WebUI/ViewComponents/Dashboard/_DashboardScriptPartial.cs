﻿using Microsoft.AspNetCore.Mvc;

namespace Tatilim.WebUI.ViewComponents.Dashboard
{
    public class _DashboardScriptPartial :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
