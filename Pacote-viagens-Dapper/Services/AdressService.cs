using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pacote_viagens_Dapper.Model;
using Pacote_viagens_Dapper.Repository;
using static System.Formats.Asn1.AsnWriter;

namespace Pacote_viagens_Dapper.Services
{
    public class AdressService
    {
        private IAdressRepository adressRepository;

        public AdressService()
        {
            adressRepository = new AdressRepository();
        }
        public int Add(Adress adress)
        {
            return adressRepository.Add(adress);
        }
        public bool Delete(int id) 
        {
            return adressRepository.Delete(id);
        }
        public List<Adress> GetAll()
        {
            return adressRepository.GetAll();
        }
        public int Update(Adress adress)
        {
            return adressRepository.Update(adress);
        }

    }
}
