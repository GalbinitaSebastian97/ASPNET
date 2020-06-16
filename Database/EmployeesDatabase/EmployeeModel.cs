
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseClassLibrary.EmployeesDatabase
{
    public class EmployeeModel : IEmployeeModel
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string BirthDay { get; set; }

        public string Qualification { get; set; }

        [Required]
        public string FirstDay { get; set; }

        public bool IsFree { get; set; }

        public EmployeeModel(int ID, string FullName, string BirthDay, string Qualification, string FirstDay)
        {
            this.ID = ID;
            this.FullName = FullName;
            this.BirthDay = BirthDay;
            this.Qualification = Qualification;
            this.FirstDay = FirstDay;
            IsFree = false;


        }

        public EmployeeModel( string FullName, string BirthDay, string Qualification, string FirstDay)
        {
            ID = 0;
            this.FullName = FullName;
            this.BirthDay = BirthDay;
            this.Qualification = Qualification;
            this.FirstDay = FirstDay;
            IsFree = false;


        }


    }









}
