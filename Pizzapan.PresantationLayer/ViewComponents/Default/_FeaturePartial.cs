using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzapan.PresantationLayer.ViewComponents.Default
{
    public class _FeaturePartial :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ViewBag.title = "Her gün pizza yiyin";
            ViewBag.title2 = "Sevdiğiniz Pizzaları paylaşın";
            return View();
        }
    }
}
