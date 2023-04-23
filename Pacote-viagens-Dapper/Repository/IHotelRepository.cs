using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pacote_viagens_Dapper.Model;

namespace Pacote_viagens_Dapper.Repository
{
    public interface IHotelRepository
    {
        int Add(Hotel hotel);
        int Update(Hotel hotel);
        bool Delete(int Id);
        List<Hotel> GetAll();
    }
}
