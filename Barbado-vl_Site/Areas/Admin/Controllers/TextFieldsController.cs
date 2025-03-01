﻿using Microsoft.AspNetCore.Mvc;

using Barbado_vl_Site.Domain;
using Barbado_vl_Site.Domain.Entities;
using Barbado_vl_Site.Service;

namespace Barbado_vl_Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TextFieldsController : Controller
    {
        private readonly DataManager dataManager;

        public TextFieldsController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Edit(string codeWord)
        {
            var entity = dataManager.TextFields.GetTextByCodeWord(codeWord);
            
            return View(entity);
        }


        [HttpPost]
        public IActionResult Edit(TextField model)
        {
            if(ModelState.IsValid)
            {
                dataManager.TextFields.SaveTextField(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            
            return View(model);
        }
    }
}
