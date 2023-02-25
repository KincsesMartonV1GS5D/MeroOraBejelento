using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meroora_bejelento.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICompanyRepository Company { get; }
        IBerloRepository Berlo { get; }

        IFelhasznaloRepository Felhasznalo { get; }
        ILakasRepository Lakas { get; }
        ILeolvasasRepository Leolvasas { get; }
        IMeroOraRepository MeroOra { get; }
        IMeroOraTipusRepository MeroOraTipus { get; }
        ISzerepkorRepository Szerepkor { get; }
        IApplicationUserRepository ApplicationUser { get; }

        void Save();
        void Update(Object obj);
    }
}
