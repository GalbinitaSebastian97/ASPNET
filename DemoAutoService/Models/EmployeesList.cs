using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseClassLibrary;
using DatabaseClassLibrary.EmployeesDatabase;

namespace DemoAutoService.Models
{
    public  class EmployeesList
    {

        public  List<IEmployeeModel> workers = new List<IEmployeeModel>();


        public  void RefreshEmployeeList()
        {

            workers = AbstractizationFactory.ReturningEmployeesList();


        }

        public  void WriteAllEmployeesIntoConsole()
        {
            if (workers.Count == 0)
                Console.WriteLine(" Lista goala ");
            else
            {
                Console.WriteLine("Show elements in list");
;                foreach (IEmployeeModel Individual in workers)
                    Console.WriteLine(Individual.ID + "  " + Individual.FullName);


            }
        }











    }
}
