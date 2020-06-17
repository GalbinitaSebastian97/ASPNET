﻿using System;
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

        IEmployeeDatabaseCRUD EmployeesCRUDOperations = AbstractizationFactory.CreateInstanceForCRUDOperations();


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Employees(List<IEmployeeModel> model)
        {

            if (model.Count == 0)
            {
                list = AbstractizationFactory.ReturningEmployeesList();

                return View(list);
            }
            else return View(model);
        }

      


        public IActionResult AddNewEmployeeSubmitButton(string FullNameInput, string BirthDayInput, string QualificationInput, string FirstDayInput)
        {
            Console.WriteLine(FullNameInput + "  " + BirthDayInput + "   " + QualificationInput + "  " + FirstDayInput);

            try
            {
                IEmployeeModel Dummy = AbstractizationFactory.CreateEmployeeInstance(FullNameInput, BirthDayInput, QualificationInput, FirstDayInput);

                EmployeesCRUDOperations.AddNewEmployeeToDatabase(Dummy);

                return RedirectToAction("Employees");

            }
            catch (Exception ex)
            { return RedirectToAction("Error"); }

        }

        public IActionResult DeleteEmployeeButton(int id)
        {


            try
            {
                EmployeesCRUDOperations.DeleteUser(id);

                return RedirectToAction("Employees");

            }
            catch (Exception ex)
            { return RedirectToAction("Error"); }
        }


        public IActionResult EditEmployeeButton(int id)
        {
            Console.WriteLine(id.ToString());

            try
            {
                list = AbstractizationFactory.ReturningEmployeesList();
                IEmployeeModel Dummy = list.Find(x => x.ID == id);
                Dummy.ID = id;
                Console.WriteLine(Dummy.ID.ToString() + "----->" + Dummy.ID.ToString() + Dummy.FullName);
                return View("EditEmployee", Dummy);


            }
            catch (Exception ex)
            { Console.WriteLine(ex); return RedirectToAction("Error"); }

        }

        public IActionResult SaveModificationEmployee(int ID, string FullName, string BirthDay, string Qualification, string FirstDay)
        {

            try
            {

                IEmployeeModel Dummy = AbstractizationFactory.CreateEmployeeInstance(ID, FullName, BirthDay, Qualification, FirstDay);
                Console.WriteLine(Dummy.ID.ToString() + "->" + Dummy.FullName + "  " + Dummy.BirthDay);
                EmployeesCRUDOperations.UpdateEmployeeInDatabase(Dummy);


                return RedirectToAction("Employees");


            }
            catch (Exception ex)
            { Console.WriteLine(ex); return RedirectToAction("Error"); }





        }

    
        public  IActionResult SearchBarMethod(string SearchBarEmployee)
        {


            try
            {

                list = AbstractizationFactory.ReturningEmployeesList();

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
            catch(Exception ex)
            {
                return View(list);
            }







        }








    }


}


