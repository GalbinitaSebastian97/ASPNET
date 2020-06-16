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



namespace DemoAutoService
{
    public class Program
    {
        public static void Main(string[] args)
        {




            IEmployeesDatabaseConnection EmployeesDatabaseConnection = AbstractizationFactory.CreateEmployeeDatabaseConnection();


            EmployeesDatabaseConnection.SetConnectionToLocalDatabase();


            IEmployeeDatabaseCRUD EmployeesCRUDOperations = AbstractizationFactory.CreateInstanceForCRUDOperations();




            IEmployeeModel vasile = AbstractizationFactory.CreateEmployeeInstance("vasile1", "10.11.1128", "Wheel", "10.2.2008");

            //  IEmployeeModel vasile2 = AbstractizationFactory.CreateEmployeeInstance("vasile2", "10.11.1128", "Wheel", "10.2.2008");l
            //    IEmployeeModel vasile3= AbstractizationFactory.CreateEmployeeInstance("vasile3", "10.11.1128", "Wheel", "10.2.2008");
            for (int i = 1; i < 2; i++)
            {
               vasile=AbstractizationFactory.CreateEmployeeInstance((string)("vasile" + i.ToString()), "10.11.1128", "Wheel", "10.2.2008");
                EmployeesCRUDOperations.AddNewEmployeeToDatabase(vasile);
            }


           List <IEmployeeModel> abc = new List<IEmployeeModel>();
          
            //  vasile.ID = EmployeesCRUDOperations.GettingLastIncrementedId();
            //vasile2.ID= EmployeesCRUDOperations.AddNewEmployeeToDatabase(vasile2);
            //vasile3.ID=  EmployeesCRUDOperations.AddNewEmployeeToDatabase(vasile3);
            /*
                        foreach (IEmployeeModel model in abc)
                        {
                            if (model.ID % 3 == 0)
                             EmployeesCRUDOperations.DeleteUser(model);


                        }



                         <nav class="navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow mb-3">
                        <div class="container">
                            <a class="navbar-brand" asp-area="" asp-controller="Home" asp-action="Index">DemoAutoService</a>
                            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target=".navbar-collapse" aria-controls="navbarSupportedContent"
                                    aria-expanded="false" aria-label="Toggle navigation">
                                <span class="navbar-toggler-icon"></span>
                            </button>
                            <div class="navbar-collapse collapse d-sm-inline-flex flex-sm-row-reverse">
                                <ul class="navbar-nav flex-grow-1">
                                    <li class="nav-item">
                                        <a class="nav-link text-dark" asp-area="" asp-controller="Home" asp-action="Index">Home</a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link text-dark" asp-area="" asp-controller="Home" asp-action="Privacy">Privacy</a>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </nav>








                        */


           


            abc = AbstractizationFactory.ReturningEmployeesList();

            Console.WriteLine("\n Reading \n");


            EmployeesCRUDOperations.GetEmployeesFromDatabase();




            //    //  EmployeesCRUDOperations.AddNewEmployeeToDatabase(vasile);
            //   vasile.ID= EmployeesCRUDOperations.GettingLastIncrementedId();



            //  Console.WriteLine(vasile.ID.ToString() + "  " + vasile.FullName + "  " + vasile.BirthDay);


            //    DatabaseClassLibrary.EmployeesDatabaseConnection.DatabaseConnection.DeleteUser(vasile3);






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
