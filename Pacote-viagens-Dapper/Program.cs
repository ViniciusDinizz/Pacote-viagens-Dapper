using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using Microsoft.VisualBasic;
using Pacote_viagens_Dapper.Controller;
using Pacote_viagens_Dapper.Model;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Viagens!!!");
        //GETALL
        /*new ClientController().GetAll().ForEach(x => Console.WriteLine(x));*/

        //DELETE
        /*bool status = new AdressController().Delete(5);
        Console.WriteLine(status);*/

        //INSERT
        /*Adress adress = new Adress()
        {
            Street = "Av Teófilo dias de Toledo",
            Number = 233,
            Burgh = "Santa Cruz",
            Cep = "15652-000",
            Complement = "Ap.12",
            DtCadastro = DateTime.Now,
            City = new City() { Description = "Pernambuco", DtCadastro = DateTime.Now }
        };
        new AdressController().Add(adress);*/

        //UPDATE
        
        /*var lst = new PackageController().GetAll();
        Package package = lst.FirstOrDefault();

        package.Hotel.Name = "José Fina";

        new PackageController().Update(package);*/

    }
}