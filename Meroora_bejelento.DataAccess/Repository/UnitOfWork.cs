using Meroora_bejelento.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meroora_bejelento.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        // 91 Constructort áthoztuk a CompanyRepositoryíból
        private ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Company = new CompanyRepository(_db);
            Berlo = new BerloRepository(_db);
            Felhasznalo = new FelhasznaloRepository(_db);
            Lakas = new LakasRepository(_db);
            MeroOraTipus = new MeroOraTipusRepository(_db);
            Szerepkor = new SzerepkorRepository(_db);
            MeroOra = new MeroOraRepository(_db);
            Leolvasas = new LeolvasasRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
        }
        public ICompanyRepository Company { get; private set; }
        public IBerloRepository Berlo { get; private set; }
        
        public IFelhasznaloRepository Felhasznalo { get; private set; }
        public ILakasRepository Lakas { get; private set; }
        public IMeroOraTipusRepository MeroOraTipus { get; private set; }
        public ISzerepkorRepository Szerepkor { get; private set; }
        public IMeroOraRepository MeroOra { get; private set; }
        public ILeolvasasRepository Leolvasas { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }
        



        public void Save()
        {
            _db.SaveChanges();
            //throw new NotImplementedException();
        }

        public void Update(Object obj)
        {
            _db.Update(obj);
        }
    }
}
