using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Pacote_viagens_Dapper.Model;
using Pacote_viagens_Dapper.Services;

namespace Pacote_viagens_Dapper.Repository
{
    public class HotelRepository : IHotelRepository
    {
        private string _conn;
        public HotelRepository()
        {
            _conn = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        }
        public int Add(Hotel hotel)
        {
            using(var db = new SqlConnection(_conn))
            {
                var query = Hotel.INSERT.Replace("@IdEndereco", new AdressService().Add(hotel.Adress).ToString());
                return (int)db.ExecuteScalar(query, hotel);
            }
        }

        public bool Delete(int Id)
        {
            bool status = false;
            using(var db = new SqlConnection(_conn))
            {
                db.ExecuteScalar(Hotel.DELETE, new { Id });
                status = true;
            }
            return status;
        }

        public List<Hotel> GetAll()
        {
            using(var db = new SqlConnection(_conn))
            {
                var hotel = db.Query<Hotel, Adress, City, Hotel>(Hotel.SELECT,
                    (Hotel, Adress, City) =>
                    {
                        Hotel.Adress = Adress;
                        Hotel.Adress.City = City;
                        return Hotel;
                    }
                    ) ;
                return (List<Hotel>) hotel ;
            }
        }

        public int Update(Hotel hotel)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE Hotel SET Name = '" + hotel.Name + "', Valor = " + hotel.Value + ", IdEndereco = " + new AdressService().Update(hotel.Adress).ToString()+" WHERE Id = "+hotel.Id);
            using(var db = new SqlConnection(_conn))
            {
               db.Execute(sb.ToString());
                int id = hotel.Id; 
               return id;
            }
        }
    }
}
