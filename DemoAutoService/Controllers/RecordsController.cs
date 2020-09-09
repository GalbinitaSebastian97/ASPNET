using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecordsDatabaseClassLibrary.RecordsDatabase;
using Microsoft.AspNetCore.Mvc;
using RecordsDatabaseClassLibrary;

namespace DemoAutoService.Controllers
{
    public class RecordsController : Controller
    {
      

        private List<IRecordModel> list;

        IRecordsDatabaseCRUD RecordsCRUDOperations =  RecordsDatabaseClassLibrary.RecordsAbstractizationFactory.CreateInstanceForCRUDOperations();


        public IActionResult Index()
        {
            if (Startup.isLogged == true)
                return View();
            else return RedirectToAction("Login", "Login");
        }

        public IActionResult Records(List<IRecordModel> model)
        {

            if (Startup.isLogged == true)
            {
                if (model.Count == 0)
                {
                    list = RecordsDatabaseClassLibrary.RecordsAbstractizationFactory.ReturningRecordsList();

                    return View(list);
                }
                else return View(model);
            }
            else return RedirectToAction("Login", "Login");



        }




        public IActionResult AddNewRecordSubmitButton(string Client, string Car, string DateOfEntry, string Malfunction, string Mechanic, string Price)
        {

            


            if (Startup.isLogged == true)
            {
                try
                {
                   IRecordModel Dummy = RecordsDatabaseClassLibrary.RecordsAbstractizationFactory.CreateRecordInstance(Client, Car, DateOfEntry, Malfunction, Mechanic, Price);

                    RecordsCRUDOperations.AddNewRecordToDatabase(Dummy);

                    return RedirectToAction("Records");

                }
                catch (Exception ex)
                { return RedirectToAction("Error"); }
            }
            else return RedirectToAction("Login", "Login");



        }

        public IActionResult DeleteRecordButton(int id)
        {




            if (Startup.isLogged == true)
            {
                try
                {
                    RecordsCRUDOperations.DeleteUser(id);

                    return RedirectToAction("Records");

                }
                catch (Exception ex)
                { Console.WriteLine(ex.ToString()); return RedirectToAction("Error"); }



            }
            else return RedirectToAction("Login", "Login");


        }


        public IActionResult EditRecordButton(int id)
        {

            if (Startup.isLogged == true)
            {


                try
                {
                    list = RecordsAbstractizationFactory.ReturningRecordsList();
                    IRecordModel Dummy = list.Find(x => x.ID == id);
                    Dummy.ID = id;
                  
                    return View("EditRecords", Dummy);


                }
                catch (Exception ex)
                { Console.WriteLine(ex); return RedirectToAction("Error"); }



            }
            else return RedirectToAction("Login", "Login");

        }

        public IActionResult SaveModificationRecord(int ID, string Client, string Car, string DateOfEntry, string Malfunction, string Mechanic, string Price)
        {

            if (Startup.isLogged == true)
            {
                try
                {

                    IRecordModel Dummy =RecordsAbstractizationFactory.CreateRecordInstance(ID, Client, Car, DateOfEntry, Malfunction, Mechanic, Price);

                    RecordsCRUDOperations.UpdateRecordInDatabase(Dummy);


                    return RedirectToAction("Records");


                }
                catch (Exception ex)
                { Console.WriteLine(ex); return RedirectToAction("Error"); }


            }
            else return RedirectToAction("Login", "Login");


        }


        public IActionResult SearchBarMethod(string SearchBarRecords)
        {

            if (Startup.isLogged == true)
            {
                try
                {

                    list = RecordsAbstractizationFactory.ReturningRecordsList();

                    List<IRecordModel> SearchList = new List<IRecordModel>();

                    foreach (RecordsDatabaseClassLibrary.RecordsDatabase.IRecordModel individ in list)
                    {
                        if (individ.Car.Contains(SearchBarRecords))
                        {
                            SearchList.Add(individ);
                            
                        }
                    }



                    return View("Records", SearchList);
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

