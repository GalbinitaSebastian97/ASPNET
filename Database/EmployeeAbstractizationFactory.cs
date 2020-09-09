using DatabaseClassLibrary.EmployeesDatabase;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

using System.Threading.Tasks;

namespace DatabaseClassLibrary
{
    public static  class EmployeeAbstractizationFactory
    {

        //---  Employees

        public static IEmployeeModel CreateEmployeeInstance( string FullName, string BirthDay, string Qualification, string FirstDay)
        {
            return new DatabaseClassLibrary.EmployeesDatabase.EmployeeModel(FullName,BirthDay, Qualification, FirstDay);
        }

        public static IEmployeeModel CreateEmployeeInstance(int ID, string FullName, string BirthDay, string Qualification, string FirstDay)
        {
            return new DatabaseClassLibrary.EmployeesDatabase.EmployeeModel(ID,FullName, BirthDay, Qualification, FirstDay);
        }

        public static IEmployeeDatabaseCRUD CreateInstanceForCRUDOperations()
        {
            return new DatabaseClassLibrary.EmployeesDatabase.EmployeeDatabaseCRUD();
        } 
        
        public static IEmployeesDatabaseConnection CreateEmployeeDatabaseConnection()
        {
            return new DatabaseClassLibrary.EmployeesDatabase.EmployeesDatabaseConnection();
        }


        public static List<IEmployeeModel> ReturningEmployeesList()
        {
            return new DatabaseClassLibrary.EmployeesDatabase.EmployeeDatabaseCRUD().GetEmployeesFromDatabase();
        }

      






    }
}
