namespace DatabaseClassLibrary.EmployeesDatabase
{
    public interface IEmployeeModel
    {
        string BirthDay { get; set; }
        string FirstDay { get; set; }
        string FullName { get; set; }
        int ID { get; set; }
        bool IsFree { get; set; }
        string Qualification { get; set; }
    }
}