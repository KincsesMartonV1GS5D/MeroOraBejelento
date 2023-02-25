using Meroora_bejelento.DataAccess;
using Meroora_bejelento.DataAccess.Repository.IRepository;
using Meroora_bejelento.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Meroora_bejelentoWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MeroOratipusController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public MeroOratipusController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [Authorize]
        public IActionResult Index()
        {
            IEnumerable<MeroOraTipus> objMeroOraTipusList = _unitOfWork.MeroOraTipus.GetAll();
            return View(objMeroOraTipusList);
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MeroOraTipus obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.MeroOraTipus.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Mérő tipus létrehozva";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //GET
        public IActionResult Upsert(int? id)
        {
            MeroOraTipus meroOraTipus = new();
            
            if (id == null || id == 0)
            {
                //letrehozas ag
                return View(meroOraTipus);
            }
            else
            {
                //modositas ag
                meroOraTipus = _unitOfWork.MeroOraTipus.GetFirstOrDefault(u => u.Id == id);
                return View(meroOraTipus);
            }
            //var MeroOratipusFromDbFirst = _unitOfWork.MeroOraTipus.GetFirstOrDefault(u => u.Id == id);
            //if (MeroOratipusFromDbFirst == null)
            //{
            //    return NotFound();
            //}

            
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(MeroOraTipus obj)
        {
            if (ModelState.IsValid)
            {
                //create
                if (obj.Id == 0)
                {
                    _unitOfWork.MeroOraTipus.Add(obj);
                }
                //insert
                else
                {
                    _unitOfWork.MeroOraTipus.Update(obj);
                }
                _unitOfWork.Save();
                TempData["success"] = "Mérő típus módosítva";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var MeroOraTipusFromDbFirst = _unitOfWork.MeroOraTipus.GetFirstOrDefault(u => u.Id == id);
            if (MeroOraTipusFromDbFirst == null)
            {
                return NotFound();
            }

            return View(MeroOraTipusFromDbFirst);
        }
        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.MeroOraTipus.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.MeroOraTipus.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Mérő tipus törölve";
            return RedirectToAction("Index");

            //return View(obj);
        }
    }
}