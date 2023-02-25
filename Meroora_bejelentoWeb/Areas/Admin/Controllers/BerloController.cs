using Microsoft.AspNetCore.Mvc;
//29 Retrive all companies
using Meroora_bejelento.DataAccess;
using Meroora_bejelento.Models;
using Meroora_bejelento.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;

namespace MeterWeb.Controllers
// 96
{
    [Area("Admin")]
    public class BerloController : Controller
    {
        //29                  88 IcompanyRepository 92 UnitOfWork
        private readonly IUnitOfWork _unitOfWork;
        //29                             88
        public BerloController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Authorize]
        public IActionResult Index()
        {
            // 29,30                                    88      92
            IEnumerable<Berlo> objBerloList = _unitOfWork.Berlo.GetAll();                ;
            return View(objBerloList);
        }

        //
        // 86 teljesen, mert a companyhoz nem csináltam még semmi ilyesmit
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            //                           88,92      
            var BerloFromDbFirst = _unitOfWork.Berlo.GetFirstOrDefault(u => u.Id==id);
            // var
            if (BerloFromDbFirst == null)
            {
                return NotFound();
            }
            return View(BerloFromDbFirst);
        }
        // 86 vége - repositoryhoz

        // 86-87
        // Create, modi, delete, post...

        // 88 - így érhető el az object update, save... A Save mint metodust innen érdemes hívni.
        // _db.Update(obj);
        // _db.Remove(obj);
        // _db.Save();

        // 92 - így érhető el az object update, save... A Save mint metodust innen érdemes hívni.
        // _unitOfWork.Company.Update(obj);
        // _unitOfWork.Company.Remove(obj);
        // _unitOfWork.Save();

    }
}
