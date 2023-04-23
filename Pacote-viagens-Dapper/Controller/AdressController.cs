using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pacote_viagens_Dapper.Model;
using Pacote_viagens_Dapper.Services;

namespace Pacote_viagens_Dapper.Controller
{
    public class AdressController
    {
   
        public int Add(Adress adress)
        {
            return new AdressService().Add(adress);
        }
        public bool Delete(int id) 
        {
            return new AdressService().Delete(id);
        }
        public List<Adress> GetAll()
        {
            return new AdressService().GetAll();
        }
        public int Update(Adress adress)
        {
            return new AdressService().Update(adress);
        }
    }
}
