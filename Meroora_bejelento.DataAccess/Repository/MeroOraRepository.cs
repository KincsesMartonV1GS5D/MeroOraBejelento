using Meroora_bejelento.DataAccess.Repository.IRepository;
using Meroora_bejelento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meroora_bejelento.DataAccess.Repository
{
    public class MeroOraRepository : Repository<MeroOra>, IMeroOraRepository
    {

        //87 , majd 91nél copy a UnitoF Workben a constructort
        private ApplicationDbContext _db;
        public MeroOraRepository(ApplicationDbContext db) : base(db)
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

        public void Update(MeroOra obj)
        {
            //    var objFromDb = _db.MeroOrak.FirstOrDefault(u=> u.Id == obj.Id);
            //    if (objFromDb != null)
            //    {
            //        objFromDb.Id = obj.Id;
            //        objFromDb.Name=obj.Name;
            //        objFromDb.Gyariszam=obj.Gyariszam;
            //        objFromDb.MertekEgyseg=obj.MertekEgyseg;
            //        objFromDb.EgysegAr=obj.EgysegAr;
            //        objFromDb.TipusId=obj.TipusId;
            //        if (obj.MintaFoto != null)
            //        {
            //            objFromDb.MintaFoto = obj.MintaFoto;
            //        }

            //    }
            _db.MeroOrak.Update(obj);
            //throw new NotImplementedException();
        }

        // 88-s nál progrm.cs-be bejegyzi a (...web projekt) builder.service.addscope...
    }
}
