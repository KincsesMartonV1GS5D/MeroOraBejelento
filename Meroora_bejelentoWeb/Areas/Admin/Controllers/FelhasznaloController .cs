using Microsoft.AspNetCore.Mvc;
using Meroora_bejelento.DataAccess;
using Meroora_bejelento.Models;
using Meroora_bejelento.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Meroora_bejelento.Models.ViewModels;

namespace MeterWeb.Controllers
{
    [Area("Admin")]
    public class FelhasznaloController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public FelhasznaloController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        
        //GET
        public IActionResult Upsert(int? id)
        {
            FelhasznaloVM felhasznaloVM = new()
            {
                Felhasznalo = new(),
                SzerepkorList = _unitOfWork.Szerepkor.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
            };
            if (id == null || id == 0)
            {
                //letrehozas ag
                //ViewBag.meroOraTipusList = meroOraTipusList;
                return View(felhasznaloVM);
            }
            else
            {
                //modositas ag
                felhasznaloVM.Felhasznalo = _unitOfWork.Felhasznalo.GetFirstOrDefault(u => u.Id == id);
                return View(felhasznaloVM);
            }
            
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(FelhasznaloVM obj, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                //create
                if (obj.Felhasznalo.Id == 0 || obj.Felhasznalo.Id == null)
                {
                    _unitOfWork.Felhasznalo.Add(obj.Felhasznalo);
                }
                //insert
                else
                {
                    _unitOfWork.Felhasznalo.Update(obj.Felhasznalo);
                }
                _unitOfWork.Save();
                TempData["success"] = "Felhasználó módosítva";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        
        
        

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var felhasznaloList = _unitOfWork.Felhasznalo.GetAll(includeProperties: "Szerepkor");
            return Json(new { data = felhasznaloList });
        }

        //POST
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Felhasznalo.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Error törléskor" });
            }

            _unitOfWork.Felhasznalo.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Sikeres törlés" });

        }
        #endregion

    }
}