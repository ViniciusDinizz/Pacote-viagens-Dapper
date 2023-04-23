using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pacote_viagens_Dapper.Model;
using Pacote_viagens_Dapper.Repository;

namespace Pacote_viagens_Dapper.Services
{
    internal class CityService
    {
        private ICityRepository cityRepository;
        public CityService() 
        {
            cityRepository = new CityRepository();
        }
        public int Add(City city)
        {
            return cityRepository.Add(city);
        }
        public int Update(City city)
        {
            return cityRepository.Update(city);
        }
        public bool Delete(int id)
        {
            return cityRepository.Delete(id);
        }
        public List<City> GetAll()
        {
            return cityRepository.GetAll();
        }

    }
}
