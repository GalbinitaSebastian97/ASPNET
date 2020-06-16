using System.Collections.Generic;

namespace DatabaseClassLibrary.EmployeesDatabase
{
    public interface IEmployeeDatabaseCRUD
    {
        void AddNewEmployeeToDatabase(IEmployeeModel person);
        void DeleteUser(int id);
        List<IEmployeeModel> GetEmployeesFromDatabase();
        void UpdateEmployeeInDatabase(IEmployeeModel person);
    }
}