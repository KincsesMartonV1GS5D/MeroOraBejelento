using Meroora_bejelento.DataAccess.Repository.IRepository;
using Meroora_bejelento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meroora_bejelento.DataAccess.Repository
{
    public class LeolvasasRepository : Repository<Leolvasas>, ILeolvasasRepository
    {

        //87 , majd 91nél copy a UnitoF Workben a constructort
        private ApplicationDbContext _db;
        public LeolvasasRepository(ApplicationDbContext db) : base(db)
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

        public void Update(Leolvasas obj)
        {
            // 102-nél ezt töröljük, mert mi monduk meg mit frissítsen, esetleg külön check.
            // _db.Leolvasasok.Update(obj);
            //throw new NotImplementedException();

                 _db.Leolvasasok.Update(obj);

        }
        // 88-s nál progrm.cs-be bejegyzi a (...web projekt) builder.service.addscope...
    }
}
