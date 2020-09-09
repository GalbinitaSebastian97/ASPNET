using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DemoAutoService.Models;
using DatabaseClassLibrary.EmployeesDatabase;
using DatabaseClassLibrary;

namespace DemoAutoService.Controllers
{
    public class EmployeesController : Controller
    {
        private List<IEmployeeModel> list;

        IEmployeeDatabaseCRUD EmployeesCRUDOperations = EmployeeAbstractizationFactory.CreateInstanceForCRUDOperations();


        public IActionResult Index()
        {
            if (Startup.isLogged == true)
                return View();
            else return RedirectToAction("Login", "Login");
        }

        public IActionResult Employees(List<IEmployeeModel> model)
        {

            if (Startup.isLogged == true)
            {
                if (model.Count == 0)
                {
                    list = EmployeeAbstractizationFactory.ReturningEmployeesList();

                    return View(list);
                }
                else return View(model);
            }
            else return RedirectToAction("Login", "Login");


            
        }

      


        public IActionResult AddNewEmployeeSubmitButton(string FullNameInput, string BirthDayInput, string QualificationInput, string FirstDayInput)
        {

            Console.WriteLine(FullNameInput + "  " + BirthDayInput + "   " + QualificationInput + "  " + FirstDayInput);


            if (Startup.isLogged == true)
            {
                try
                {
                    IEmployeeModel Dummy = EmployeeAbstractizationFactory.CreateEmployeeInstance(FullNameInput, BirthDayInput, QualificationInput, FirstDayInput);

                    EmployeesCRUDOperations.AddNewEmployeeToDatabase(Dummy);

                    return RedirectToAction("Employees");

                }
                catch (Exception ex)
                { return RedirectToAction("Error"); }
            }
            else return RedirectToAction("Login", "Login");

           

        }

        public IActionResult DeleteEmployeeButton(int id)
        {




            if (Startup.isLogged == true)
            {
                try
                {
                    EmployeesCRUDOperations.DeleteUser(id);

                    return RedirectToAction("Employees");

                }
                catch (Exception ex)
                { Console.WriteLine(ex.ToString()); return RedirectToAction("Error"); }



            }
            else return RedirectToAction("Login", "Login");

            
        }


        public IActionResult EditEmployeeButton(int id)
        {

            if (Startup.isLogged == true)
            {
             

                try
                {
                    list = EmployeeAbstractizationFactory.ReturningEmployeesList();
                    IEmployeeModel Dummy = list.Find(x => x.ID == id);
                    Dummy.ID = id;
                    Console.WriteLine(Dummy.ID.ToString() + "----->" + Dummy.ID.ToString() + Dummy.FullName);
                    return View("EditEmployee", Dummy);


                }
                catch (Exception ex)
                { Console.WriteLine(ex); return RedirectToAction("Error"); }



            }
            else return RedirectToAction("Login", "Login");

        }

        public IActionResult SaveModificationEmployee(int ID, string FullName, string BirthDay, string Qualification, string FirstDay)
        {

            if (Startup.isLogged == true)
            {
                try
                {

                    IEmployeeModel Dummy = EmployeeAbstractizationFactory.CreateEmployeeInstance(ID, FullName, BirthDay, Qualification, FirstDay);
                    Console.WriteLine(Dummy.ID.ToString() + "->" + Dummy.FullName + "  " + Dummy.BirthDay);
                    EmployeesCRUDOperations.UpdateEmployeeInDatabase(Dummy);


                    return RedirectToAction("Employees");


                }
                catch (Exception ex)
                { Console.WriteLine(ex); return RedirectToAction("Error"); }


            }
            else return RedirectToAction("Login", "Login");

           
        }

    
        public  IActionResult SearchBarMethod(string SearchBarEmployee)
        {

            if (Startup.isLogged == true)
            {
                try
                {

                    list = EmployeeAbstractizationFactory.ReturningEmployeesList();

                    List<IEmployeeModel> SearchList = new List<IEmployeeModel>();

                    foreach (DatabaseClassLibrary.EmployeesDatabase.IEmployeeModel individ in list)
                    {
                        if (individ.FullName.Contains(SearchBarEmployee))
                        {
                            SearchList.Add(individ);
                            Console.WriteLine(individ.FullName);
                            Console.WriteLine(SearchList.Count().ToString());
                        }
                    }



                    return View("Employees", SearchList);
                }
                catch (Exception ex)
                {
                    return View(list);
                }
            }
            else return RedirectToAction("Login", "Login");


            
        }








    }


}


