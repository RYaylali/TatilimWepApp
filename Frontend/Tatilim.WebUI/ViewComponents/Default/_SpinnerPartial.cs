﻿
using Microsoft.AspNetCore.Mvc;


namespace Tatilim.WebUI.ViewComponents.Default
{
    public class _SpinnerPartial : ViewComponent
    {
        public   IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
