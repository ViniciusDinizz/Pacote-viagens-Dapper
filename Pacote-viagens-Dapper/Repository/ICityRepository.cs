using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pacote_viagens_Dapper.Model;

namespace Pacote_viagens_Dapper.Repository
{
    internal interface ICityRepository
    {
        int Add(City city);
        int Update(City city);
        bool Delete(int Id);
        List<City> GetAll();    
    }
}
