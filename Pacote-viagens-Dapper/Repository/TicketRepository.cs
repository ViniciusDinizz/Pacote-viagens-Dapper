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
    public class TicketRepository : ITicketRepository
    {
        private string _conn;
        public TicketRepository()
        {
            _conn = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        }
        public int Add(Ticket ticket)
        {
            using(var db = new SqlConnection(_conn))
            {
                var query = Ticket.INSERT.Replace("@IdOrigin", new AdressService().Add(ticket.Origin).ToString());
                query = query.Replace("@IdDestin", new AdressService().Add(ticket.Destin).ToString());

                return (int)db.ExecuteScalar(query, ticket);
            }
        }

        public bool Delete(int Id)
        {
            bool status = false;
            using(var db = new SqlConnection(_conn))
            {
                db.ExecuteScalar(Ticket.DELETE, new { Id });
                return status = true;
            }
        }

        public List<Ticket> GetAll()
        {
            List<Ticket> lstTicket = new List<Ticket>();
            StringBuilder sb = new StringBuilder();
            sb.Append(Ticket.SELECT);

            SqlConnection db = new SqlConnection(_conn);
            db.Open();
            IDataReader dr = db.ExecuteReader(sb.ToString());

            Ticket ticket = new Ticket();
            while(dr.Read())
            {
                ticket.Id = (int)dr["Id"];
                ticket.Data = (DateTime)dr["Date"];
                ticket.Value = (decimal)dr["Value"];
                int IdOrigin = (int)dr["IdOrigin"];
                int IdDestin = (int)dr["IdDestin"];
                ticket.Origin = ReturnAdress(IdOrigin);
                ticket.Destin = ReturnAdress(IdDestin);
                
                lstTicket.Add(ticket);
            }
            dr.Close();
            db.Close();
            return lstTicket;
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
                adress.Id = (int)dr["id"];
                adress.Street = (string)dr["Street"];
                adress.Number = (int)dr["Number"];
                adress.Burgh = (string)dr["Burgh"];
                adress.Cep = (string)dr["Cep"];
                adress.Complement = (string)dr["Complement"];
                adress.DtCadastro = (DateTime)dr["DtCadastro"];
                int idCity = (int)dr["IdCity"];
                adress.City = ReturnCity(idCity);
            }
            dr.Close();
            db.Close();

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

            while (dr.Read())
            {
                city.Id = (int)dr["Id"];
                city.Description = (string)dr["Description"];
                city.DtCadastro = (DateTime)dr["DtCadastro"];
            }
            dr.Close();
            db.Close();

            return city;
        }

        public int Update(Ticket ticket)
        {
            using(var db = new SqlConnection(_conn))
            {
                var query = Ticket.UPDATE.Replace("@IdOrigin", new AdressService().Update(ticket.Origin).ToString());
                query = query.Replace("@IdDestin", new AdressService().Update(ticket.Destin).ToString());
                query = query.Replace("@Id", ticket.Id.ToString());
                query = query.Replace("@Value", ticket.Value.ToString());
                int id = ticket.Id;
                IDataReader dr = db.ExecuteReader(query);
                db.Close();
                dr.Close();
                return id;
            }
        }
    }
}
