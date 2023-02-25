using Meroora_bejelento.DataAccess.Repository.IRepository;
using Meroora_bejelento.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace Meroora_bejelentoWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SzerepkorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public SzerepkorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [Authorize]
        public IActionResult Index()
        {
            IEnumerable<Szerepkor> objSzerepkorList = _unitOfWork.Szerepkor.GetAll();
            return View(objSzerepkorList);
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Szerepkor obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Szerepkor.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Szerepkör létrehozva";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //GET
        public IActionResult Upsert(int? id)
        {
            Szerepkor szerepkor = new();

            if (id == null || id == 0)
            {
                //letrehozas ag
                return View(szerepkor);
            }
            else
            {
                //modositas ag
                szerepkor = _unitOfWork.Szerepkor.GetFirstOrDefault(u => u.Id == id);
                return View(szerepkor);
            }
            //var SzerepkorFromDbFirst = _unitOfWork.Szerepkor.GetFirstOrDefault(u => u.Id == id);
            //if (SzerepkorFromDbFirst == null)
            //{
            //    return NotFound();
            //}


        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Szerepkor obj)
        {
            if (ModelState.IsValid)
            {
                //create
                if (obj.Id == 0)
                {
                    _unitOfWork.Szerepkor.Add(obj);
                }
                //insert
                else
                {
                    _unitOfWork.Szerepkor.Update(obj);
                }
                _unitOfWork.Save();
                TempData["success"] = "Szerepkör módosítva";
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        //POST
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Szerepkor.GetFirstOrDefault(u => u.Id == id);
            

            _unitOfWork.Szerepkor.Remove(obj);
            _unitOfWork.Save();
            return RedirectToAction("Index");

        }
    }
}
