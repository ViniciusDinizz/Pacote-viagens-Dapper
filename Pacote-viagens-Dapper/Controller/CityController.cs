using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pacote_viagens_Dapper.Model;
using Pacote_viagens_Dapper.Services;

namespace Pacote_viagens_Dapper.Controller
{
    public class CityController
    {
        public int Add(City city)
        {
            return new CityService().Add(city);
        }
        public int Update(City city)
        {
            return new CityService().Update(city);
        }
        public bool Delete(int city) 
        {
            return new CityService().Delete(city);
        }
        public List<City> GetAll()
        {
            return new CityService().GetAll();
        }
    }
}
