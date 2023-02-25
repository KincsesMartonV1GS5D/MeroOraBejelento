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
    public class MeroOraController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public MeroOraController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
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
            MeroOraVM meroOraVM = new()
            {
                MeroOra = new(),
                MeroOraTipusList = _unitOfWork.MeroOraTipus.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
            };
            if (id == null || id == 0)
            {
                //letrehozas ag
                //ViewBag.meroOraTipusList = meroOraTipusList;
                return View(meroOraVM);
            }
            else
            {
                //modositas ag
                meroOraVM.MeroOra = _unitOfWork.MeroOra.GetFirstOrDefault(u => u.Id == id);
                return View(meroOraVM);
            }
            
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(MeroOraVM obj, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                //--foto file muveletek 
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"images\MintaMeroOra");
                    var extension = Path.GetExtension(file.FileName);
                     
                    if (obj.MeroOra.MintaFoto !=null)
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, obj.MeroOra.MintaFoto.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }
                    obj.MeroOra.MintaFoto = @"\images\MintaMeroOra\" + fileName + extension;
                }
                //create
                if (obj.MeroOra.Id == 0 || obj.MeroOra.Id == null)
                {
                    _unitOfWork.MeroOra.Add(obj.MeroOra);
                }
                //insert
                else
                {
                    _unitOfWork.MeroOra.Update(obj.MeroOra);
                }
                _unitOfWork.Save();
                TempData["success"] = "Mérőóra módosítva";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        
        
        

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var meroOraList = _unitOfWork.MeroOra.GetAll(includeProperties: "MeroOraTipus");
            return Json(new { data = meroOraList });
        }

        //POST
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.MeroOra.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Error törléskor" });
            }

            var oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, obj.MintaFoto.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            _unitOfWork.MeroOra.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Sikeres törlés" });

        }
        #endregion

    }
}