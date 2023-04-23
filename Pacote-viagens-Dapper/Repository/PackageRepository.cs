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
    internal class PackageRepository : IPackageRepository
    {
        private string _conn;
        public PackageRepository()
        {
            _conn = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        }
        public int Add(Package package)
        {
                using(var db = new SqlConnection(_conn))
                {
                    var query = Package.INSERT.Replace("@IdClient", new ClientService().Add(package.Client).ToString());
                    query = query.Replace("@IdTicket", new TicketService().Add(package.Ticket).ToString());
                    query = query.Replace("@IdHotel", new HotelService().Add(package.Hotel).ToString());
                    return (int)db.ExecuteScalar(query, package);
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
        public int Update(Package package)
        {
            using(var db = new SqlConnection(_conn))
            {
                var query = Package.UPDATE.Replace("@IdHotel", new HotelService().Update(package.Hotel).ToString());
                query = query.Replace("@IdTicket", new TicketService().Update(package.Ticket).ToString());
                query = query.Replace("@Id", package.Id.ToString());
                query = query.Replace("@Value", package.Value.ToString());
                int id = package.Id;
                IDataReader dr = db.ExecuteReader(query);
                db.Close();
                dr.Close();
                return id;
            }
        }

        public List<Package> GetAll()
        {
            List<Package> lstPackage = new List<Package>();
            StringBuilder sb = new StringBuilder();
            sb.Append(Package.SELECT);

            using (var db = new SqlConnection(_conn))
            {
                IDataReader dr = db.ExecuteReader(sb.ToString());

                Package package = new Package();
                while (dr.Read())
                {
                    package.Id = (int)dr["Id"];
                    package.DtCadastro = (DateTime)dr["DtCadastro"];
                    package.Value = (decimal)dr["Value"];

                    int idClient = (int)dr["IdClient"];
                    int idTicket = (int)dr["IdTicket"];
                    int idHotel = (int)dr["IdHotel"];
                    package.Client = ReturnClient(idClient);
                    package.Ticket = ReturnTicket(idTicket);
                    package.Hotel = ReturnHotel(idHotel);

                    lstPackage.Add(package);
                }
                db.Close();
                dr.Close();

                return lstPackage;
            }
        }

        public Adress ReturnAdress(int Id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT Id, Street, Number, Burgh, Cep, Complement, IdCity, DtCadastro FROM Adress WHERE Id = " + Id);

            SqlConnection db = new SqlConnection(_conn);
            db.Open();
            IDataReader dr = db.ExecuteReader(sb.ToString());

            Adress adress = new Adress();
            while (dr.Read())
            {
                adress.Id = (int)dr["Id"];
                adress.Street = (string)dr["Street"];
                adress.Number = (int)dr["Number"];
                adress.Burgh = (string)dr["Burgh"];
                adress.Cep = (string)dr["Cep"];
                adress.Complement = (string)dr["Complement"];
                int idCity = (int)dr["IdCity"];
                adress.DtCadastro = (DateTime)dr["DtCadastro"];
                adress.City = ReturnCity(idCity);
            }
            db.Close();
            dr.Close();
            return adress;
        }

        public City ReturnCity(int Id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT Id, Description, DtCadastro FROM City WHERE Id = " + Id);

            SqlConnection db = new SqlConnection(_conn);
            db.Open();
            IDataReader dr = db.ExecuteReader(sb.ToString());

            City city = new City();
            while(dr.Read())
            {
                city.Id = (int)dr["Id"];
                city.Description = (string)dr["Description"];
                city.DtCadastro = (DateTime)dr["DtCadastro"];
            }
            db.Close();
            dr.Close();
            return city;
        }

        public Client ReturnClient(int Id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT Id, Name, Telephone, IdEndereco, DtCadastro FROM Client WHERE Id = " + Id);

            SqlConnection db = new SqlConnection(_conn);
            db.Open();
            IDataReader dr = db.ExecuteReader(sb.ToString());

            Client client = new Client();
            while(dr.Read())
            {
                client.Id = (int)dr["Id"];
                client.Name = (string)dr["Name"];
                client.Telephone = (string)dr["Telephone"];
                int idAdress = (int)dr["IdEndereco"];
                client.DtCadastro = (DateTime)dr["DtCadastro"];
                client.Adress = ReturnAdress(idAdress);
            }
            db.Close();
            dr.Close();

            return client;
        }

        public Hotel ReturnHotel(int Id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT Id, Name, DtCadastro, Valor, IdEndereco FROM Hotel WHERE Id = " + Id);

            SqlConnection db = new SqlConnection(_conn);
            db.Open();
            IDataReader dr = db.ExecuteReader(sb.ToString());

            Hotel hotel = new Hotel();
            while(dr.Read())
            {
                hotel.Id = (int)dr["Id"];
                hotel.Name = (string)dr["Name"];
                hotel.DtCadastro = (DateTime)dr["DtCadastro"];
                int idAdress = (int)dr["IdEndereco"];
                hotel.Adress = ReturnAdress(idAdress);
            }
            db.Close();
            dr.Close();

            return hotel;
        }

        public Ticket ReturnTicket(int Id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT Id, Date, Value, IdOrigin, IdDestin FROM Ticket Where Id = " + Id);

            SqlConnection db = new SqlConnection(_conn);
            db.Open();
            IDataReader dr = db.ExecuteReader(sb.ToString());

            Ticket ticket = new Ticket();
            while(dr.Read())
            {
                ticket.Id = (int)dr["Id"];
                ticket.Data = (DateTime)dr["Date"];
                ticket.Value = (decimal)dr["Value"];
                int idOrigin = (int)dr["IdOrigin"];
                int idDestin = (int)dr["IdDestin"];
                ticket.Origin = ReturnAdress(idOrigin);
                ticket.Destin = ReturnAdress(idDestin);
            }
            db.Close();
            dr.Close();
            return ticket;
        }

    }
}
