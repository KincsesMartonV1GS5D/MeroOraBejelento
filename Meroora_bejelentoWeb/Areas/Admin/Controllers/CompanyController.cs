using Microsoft.AspNetCore.Mvc;
//29 Retrive all companies

using Meroora_bejelento.DataAccess;
using Meroora_bejelento.Models;
using Meroora_bejelento.DataAccess.Repository.IRepository;

namespace MeterWeb.Controllers
// 96
{
    [Area("Admin")]
    public class CompanyController : Controller
    {
        //29                  88 IcompanyRepository 92 UnitOfWork
        private readonly IUnitOfWork _unitOfWork;
        //29                             88
        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            // 29,30                                    88      92
            IEnumerable<Company> objCompanyList = _unitOfWork.Company.GetAll();                ;
            return View(objCompanyList);
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
            var companyFromDbFirst = _unitOfWork.Company.GetFirstOrDefault(u => u.Id==id);
            // var
            if (companyFromDbFirst == null)
            {
                return NotFound();
            }
            return View(companyFromDbFirst);
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
