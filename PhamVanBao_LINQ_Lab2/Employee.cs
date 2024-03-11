using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhamVanBao_LINQ_Lab2
{
    internal class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public int DepartmentID { get; set; }
        public int Age { get; set; }
        public double Salaray { get; set; }
        public DateTime Birthday { get; set; }
        
        public static List<Employee> getEmployees()
        {
            
            return new List<Employee>()
            {
                new Employee() { ID = 1,Name="A",DepartmentID = 1,Age=20,Salaray = 130000,Birthday=new DateTime(2003,11,17)},
                new Employee() { ID = 1,Name="A",DepartmentID = 1,Age=20,Salaray = 130000,Birthday=new DateTime(2003,10,17)},
                new Employee() { ID = 2,Name="B",DepartmentID = 2,Age=21,Salaray = 140000,Birthday=new DateTime(2000,09,17)},
                new Employee() { ID = 3,Name="C",DepartmentID = 3,Age=22,Salaray = 150000,Birthday=new DateTime(2009,08,17)},
                new Employee() { ID = 4,Name="D",DepartmentID = 1,Age=23,Salaray = 160000,Birthday=new DateTime(2000,07,17)},
                new Employee() { ID = 5,Name="E",DepartmentID = 2,Age=24,Salaray = 170000,Birthday=new DateTime(2001,6,17)},
            };
        }
    }
}
