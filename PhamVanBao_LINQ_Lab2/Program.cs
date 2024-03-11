using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhamVanBao_LINQ_Lab2
{
    internal class Program
    {
        public DateTime dateTime;
        static void Main(string[] args)
        {
            List<Employee>employees =   Employee.getEmployees();


            Console.WriteLine($"Max salaray:{employees.Max(emp =>emp.Salaray)}");
            Console.WriteLine($"Min salaray:{employees.Min(emp => emp.Salaray)}");
            Console.WriteLine($"Average salaray:{employees.Average(emp => emp.Salaray)}");


            var resultLeftJoin = from e in Employee.getEmployees()
                               join d in Department.getDepartments()
                               on e.DepartmentID equals d.ID into eGroup
                               from d in eGroup.DefaultIfEmpty()
                               select new
                               {
                                   DepartmentName = d == null?"No department": d.Name,
                                   EmployeeName = e.Name
                               };
            var resultJoinGroup = from d in Department.getDepartments()
                                  join e in Employee.getEmployees()
                                  on d.ID equals e.DepartmentID into eGroup
                                  select new
                                  {
                                      Department = d,
                                      Employee = eGroup
                                  };
            var resultRightJoin = from d in Department.getDepartments()
                                  join e in Employee.getEmployees()
                                  on d.ID equals e.DepartmentID into eGroup
                                  from e in eGroup.DefaultIfEmpty()
                                  select new
                                  {
                                      DepartmentName = d == null ? "No department" : d.Name,
                                      EmployeeName = e.Name
                                  };
            Console.WriteLine("Join Group:");
            foreach (var department in resultJoinGroup)
            {
                Console.WriteLine(department.Department.Name);
                foreach(var employee in department.Employee)
                {
                    Console.WriteLine(" " + employee.Name);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Join left:");
            foreach ( var employee in resultLeftJoin)
            {
                Console.WriteLine("{0} - {1}",employee.EmployeeName,employee.DepartmentName);
            }
            Console.WriteLine("Join Right:");
            foreach (var employee in resultRightJoin)
            {
                Console.WriteLine("{0} - {1}", employee.EmployeeName, employee.DepartmentName);
            }
            Console.WriteLine();


            var maxAge = employees.Max(emp => (DateTime.Now - emp.Birthday).Days);
            var minAge = employees.Min(emp => (DateTime.Now - emp.Birthday).Days);
            Console.WriteLine($"Max age:{Math.Round(maxAge / 365.25)}");
            Console.WriteLine($"Max age:{Math.Round(minAge / 365.25)}");
            Console.ReadLine();

        }
    }
}
