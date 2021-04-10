using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreWebUI.ViewComponents
{
    public class Register:ViewComponent
    {
        public ViewViewComponentResult Invoke()
        {
            return View(new UserForRegisterDto());
        }
    }
}
