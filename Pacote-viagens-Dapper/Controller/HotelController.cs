using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pacote_viagens_Dapper.Model;
using Pacote_viagens_Dapper.Services;

namespace Pacote_viagens_Dapper.Controller
{
    internal class HotelController
    {
        public int Add(Hotel hotel)
        {
            return new HotelService().Add(hotel);
        }
        public int Update(Hotel hotel)
        {
            return new HotelService().Update(hotel);
        }
        public bool Delete(int Id) 
        {
            return new HotelService().Delete(Id);
        }
        public List<Hotel> GetAll()
        {
            return new HotelService().GetAll();
        }
    }
}
