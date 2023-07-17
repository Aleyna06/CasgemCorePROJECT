using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzapan.PresantationLayer.Models
{
    public class ImageFileViewModel
    {
        public string  ImageUrl { get; set; }
        public IFormFile  Image { get; set; }
    }
}
