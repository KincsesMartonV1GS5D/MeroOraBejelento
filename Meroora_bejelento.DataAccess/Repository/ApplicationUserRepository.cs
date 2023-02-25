using Meroora_bejelento.DataAccess.Repository.IRepository;
using Meroora_bejelento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meroora_bejelento.DataAccess.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {

        //87 , majd 91nél copy a UnitoF Workben a constructort
        private ApplicationDbContext _db;
        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        

        /* 91-s ben itt töröljük
          public void Save()
        {
            _db.SaveChanges();
            //throw new NotImplementedException();
        }
        */

        

    }
}
