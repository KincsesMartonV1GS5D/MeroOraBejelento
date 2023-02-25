using Meroora_bejelento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meroora_bejelento.DataAccess.Repository.IRepository
{
    public interface IFelhasznaloRepository : IRepository<Felhasznalo>
    {
        void Update(Felhasznalo obj);
        // 91-s nél kivesszük void Save();
    }
}
