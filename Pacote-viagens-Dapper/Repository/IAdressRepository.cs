using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pacote_viagens_Dapper.Model;

namespace Pacote_viagens_Dapper.Repository
{
    public interface IAdressRepository
    {
        int Add(Adress adress);
        bool Delete(int Id);
        List<Adress> GetAll();
        int Update(Adress adress);
    }
}
