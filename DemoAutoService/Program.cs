using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;
using DatabaseClassLibrary;
using DemoAutoService.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using DatabaseClassLibrary.EmployeesDatabase;
using System.Security.Cryptography.X509Certificates;
using RecordsDatabaseClassLibrary.RecordsDatabase;
using RecordsDatabaseClassLibrary;

namespace DemoAutoService
{
    public class Program
    {

        

        public static void Main(string[] args)
        {

            


            IEmployeesDatabaseConnection EmployeesDatabaseConnection = EmployeeAbstractizationFactory.CreateEmployeeDatabaseConnection();


            EmployeesDatabaseConnection.SetConnectionToLocalDatabase();

            IRecordsDatabaseConnection RecordsDatabaseConnection = RecordsAbstractizationFactory.CreateRecordsDatabaseConnection();

            RecordsDatabaseConnection.SetConnectionToLocalDatabase();

            IEmployeeDatabaseCRUD EmployeesCRUDOperations = EmployeeAbstractizationFactory.CreateInstanceForCRUDOperations();
            IRecordsDatabaseCRUD RecordsCRUDOperations = RecordsAbstractizationFactory.CreateInstanceForCRUDOperations();




            IEmployeeModel vasile = EmployeeAbstractizationFactory.CreateEmployeeInstance("vasile1", "10.11.1128", "Wheel", "10.2.2008");

            for (int i = 1; i < 2; i++)
            {
               vasile=EmployeeAbstractizationFactory.CreateEmployeeInstance((string)("vasile" + i.ToString()), "10.11.1128", "Wheel", "10.2.2008");
                EmployeesCRUDOperations.AddNewEmployeeToDatabase(vasile);


            }


   


            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
