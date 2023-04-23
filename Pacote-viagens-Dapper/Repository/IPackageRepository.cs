using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pacote_viagens_Dapper.Model;

namespace Pacote_viagens_Dapper.Repository
{
    public interface IPackageRepository
    {
        int Add(Package package);
        int Update(Package package);
        bool Delete(int Id);
        List<Package> GetAll();
        Client ReturnClient(int Id);
        Ticket ReturnTicket(int Id);
        Hotel ReturnHotel(int Id);
        Adress ReturnAdress(int Id);
        City ReturnCity(int Id);
    }
}
