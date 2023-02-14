using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MimeKit.Encodings;
using NewSHPTH.Data.ViewModels;
using SHPTH.Data;
using SHPTH.Data.Services;
using SHPTH.Data.Static;
using SHPTH.Data.ViewModels;
using SHPTH.Models;
using SHPTH.Models.Categories;

namespace SHPTH.Controllers
{
    [Authorize(Roles = UserRolesClass.Admin)]
    public class ClothesController : Controller
    {

        private readonly IClothService _clothService;
    

        public ClothesController(IClothService clothService)
        { 
            _clothService = clothService;
        }





        // GET: Clothes/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
           
            if (id == null)
            {
                return View("NONFound");
            }

            var cloth = await _clothService.GetByIdAsync(id);

            if (cloth == null)
            {
                return View("NONFound");
            }

            return View(cloth);
        }

        //GET: Clothes/Create
        public async Task<IActionResult> Create()
        {
            var movieDropdownsData = await _clothService.GetNewMovieDropdownsValues();

            ViewBag.ClothSeparations = new SelectList(movieDropdownsData.ClothSeparations, "Id", "Name");
            ViewBag.SizeSeparations = new SelectList(movieDropdownsData.SizeSeparations, "id", "Name");
          

            return View();  
        }

        // POST: Clothes/Create
 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateVM MVdata)
        {
            if (!ModelState.IsValid)
            {
                var clothDDData = await _clothService.GetNewMovieDropdownsValues();

                ViewBag.ClothSeparations = new SelectList(clothDDData.ClothSeparations, "Id", "Name");
                ViewBag.SizeSeparations = new SelectList(clothDDData.SizeSeparations, "id", "Name");

                return View(MVdata);
            }

            await _clothService.AddAsync(MVdata); 
            return RedirectToAction(nameof(WelcomePage));
        }

        // GET: Clothes/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var cloth = await _clothService.GetByIdAsync(id);
            if (cloth == null) return View("NotFound");

            var response = new CreateVM()
            {
                Id = cloth.Id,
                Brand = cloth.Brand,
                IMGURL = cloth.IMGURL,
                Price = cloth.Price,
                CloId = cloth.CloId,
                SizeId= cloth.SizeId,
                GenSep= cloth.GenderSeparation
            };

            var clothDDData = await _clothService.GetNewMovieDropdownsValues();

            ViewBag.ClothSeparations = new SelectList(clothDDData.ClothSeparations, "Id", "Name");
            ViewBag.SizeSeparations = new SelectList(clothDDData.SizeSeparations, "id", "Name");

            return View(response);
        }

        // POST: Clothes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CreateVM VM)
        {
            if (id != VM.Id)
            {
                return NotFound();
            }

           
            if(!ModelState.IsValid)
            {
                    var clothDDData = await _clothService.GetNewMovieDropdownsValues();

                    ViewBag.ClothSeparations = new SelectList(clothDDData.ClothSeparations, "Id", "Name");
                    ViewBag.SizeSeparations = new SelectList(clothDDData.SizeSeparations, "id", "Name");

                    return View(VM);
                
            }

            await _clothService.UpdateAsync(VM);         
            return RedirectToAction(nameof(WelcomePage));
        }

        // GET: Clothes/Delete/5s
        public async Task<IActionResult> Delete(int id)
        {

            var cloth = await _clothService.GetByIdAsync(id);
            if (id == null || cloth == null)
            {
                return NotFound();
            }

            return View(cloth);
        }

        // POST: Clothes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cloth = await _clothService.GetByIdAsync(id);
            if (cloth == null) return View("NONFound");

            await _clothService.DeleteAsync(id);
            return RedirectToAction(nameof(WelcomePage));
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(int GenSep)
        {
            var response = new ShopVM()
            {
                CloList = _clothService.GetCloList(GenSep),
                SizeSeparations = _clothService.GetSizeSepList(),
                clothSeparations = _clothService.GetCloSepList(),
            };

            switch (GenSep)
            {
                case 1:
                    return View("Men", response);
                    break;
                case 2:
                    return View("Women", response);
                    break;
                case 3:
                    return View("Kids", response);
                    break;
            }

            return View("WelcomePage");
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Men(ShopVM shVM)
        {
            
            
            
            shVM.GenderSeparate = 1;
            shVM.clothSeparations = _clothService.GetCloSepList();
            shVM.SizeSeparations = _clothService.GetSizeSepList();
            var products = _clothService.GetFilteredCloList(shVM);
            shVM.CloList = products;

            return View(shVM);
        }

        [AllowAnonymous]
        
        public async Task<IActionResult> ResetMen(int GenSep)
        {
            var shVM = new ShopVM();
            shVM.clothSeparations = _clothService.GetCloSepList();
            shVM.SizeSeparations = _clothService.GetSizeSepList();
            var cloth = _clothService.ResetFilters(GenSep);
            
            shVM.CloList = cloth;
            return View("Men" , shVM);

        }
        public async Task<IActionResult> ResetWomen(int GenSep)
        {
            var shVM = new ShopVM();
            shVM.clothSeparations = _clothService.GetCloSepList();
            shVM.SizeSeparations = _clothService.GetSizeSepList();
            var cloth = _clothService.ResetFilters(GenSep);

            shVM.CloList = cloth;
            return View("Women", shVM);

        }
        public async Task<IActionResult> ResetKids(int GenSep)
        {
            var shVM = new ShopVM();
            shVM.clothSeparations = _clothService.GetCloSepList();
            shVM.SizeSeparations = _clothService.GetSizeSepList();
            var cloth = _clothService.ResetFilters(GenSep);

            shVM.CloList = cloth;
            return View("Kids", shVM);

        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Women(ShopVM shVM)
        {

            int GenSep = 2;
            shVM.GenderSeparate = 2;
            shVM.clothSeparations = _clothService.GetCloSepList();
            shVM.SizeSeparations = _clothService.GetSizeSepList();
            var products = _clothService.GetFilteredCloList(shVM);
            shVM.CloList = products;

            return View(shVM);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Kids(ShopVM shVM)
        {
            int GenSep = 3;
            shVM.GenderSeparate = 3;
            shVM.clothSeparations = _clothService.GetCloSepList();
            shVM.SizeSeparations = _clothService.GetSizeSepList();
            var products = _clothService.GetFilteredCloList(shVM);
            shVM.CloList = products;

            return View(shVM);
        }


        [AllowAnonymous]
        public async Task<IActionResult> WelcomePage()
        {
            return View();
        }


     
    }
}