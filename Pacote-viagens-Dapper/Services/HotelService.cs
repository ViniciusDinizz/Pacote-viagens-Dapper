using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pacote_viagens_Dapper.Model;
using Pacote_viagens_Dapper.Repository;

namespace Pacote_viagens_Dapper.Services
{
    public class HotelService
    {
        private IHotelRepository hotelRepository;
        public HotelService()
        {
            hotelRepository = new HotelRepository();
        }
        public int Add(Hotel hotel)
        {
            return hotelRepository.Add(hotel);
        }
        public int Update(Hotel hotel)
        {
            return hotelRepository.Update(hotel);
        }
        public bool Delete(int Id)
        {
            return hotelRepository.Delete(Id);
        }
        public List<Hotel> GetAll()
        {
            return hotelRepository.GetAll();
        }
    }
}
