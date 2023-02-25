using Meroora_bejelento.DataAccess.Repository.IRepository;
using Meroora_bejelento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meroora_bejelento.DataAccess.Repository
{
    public class BerloRepository : Repository<Berlo>, IBerloRepository
    {

        //87 , majd 91nél copy a UnitoF Workben a constructort
        private ApplicationDbContext _db;
        public BerloRepository(ApplicationDbContext db) : base(db)
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

        public void Update(Berlo obj)
        {
            _db.Berlok.Update(obj);
            //throw new NotImplementedException();
        }

        // 88-s nál progrm.cs-be bejegyzi a (...web projekt) builder.service.addscope...
    }
}
