using Microsoft.AspNetCore.Mvc;
using Piizapan.BusinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzapan.PresantationLayer.ViewComponents.Default
{
    
    public class _TestimonialPartial : ViewComponent
    {
        private readonly ITestimonialService _testimonialService;


        public _TestimonialPartial(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public  IViewComponentResult Invoke()
        {
            var values = _testimonialService.TGetList();
            return View(values);
        }
    }
}
