using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RecordsDatabaseClassLibrary.RecordsDatabase
{
    public class RecordModel : IRecordModel
    {

        [Required]
        public int ID { get; set; }

        [Required]
        public string Client { get; set; }

        [Required]
        public string Car { get; set; }

        [Required]
        public string DateOfEntry { get; set; }

        public string Malfunction { get; set; }
        [Required]
        public string Mechanic { get; set; }
        [Required]
        public string Price { get; set; }





        public RecordModel(int ID, string Client, string Car, string DateOfEntry, string Malfunction, string Mechanic, string Price)
        {
            this.ID = ID;
            this.Client = Client;
            this.Car = Car;
            this.DateOfEntry = DateOfEntry;
            this.Malfunction = Malfunction;
            this.Mechanic = Mechanic;
            this.Price = Price;



        }

        public RecordModel(string Client, string Car, string DateOfEntry, string Malfunction, string Mechanic, string Price)
        {
            ID = 0;
            this.Client = Client;
            this.Car = Car;
            this.DateOfEntry = DateOfEntry;
            this.Malfunction = Malfunction;
            this.Mechanic = Mechanic;
            this.Price = Price;


        }


    }





}

