using Microsoft.AspNetCore.Mvc;
using Piizapan.BusinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzapan.PresantationLayer.ViewComponents.Default
{
    public class _ProductPartial:ViewComponent
    {
        private readonly IProductService _productService;

        public _ProductPartial(IProductService productService)
        {
            _productService = productService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _productService.TGetList();
            return View(values);
        }
    }
}
