using SoftUni.Data;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
       public  static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();

            string result = GetEmployeesFullInformation(context);
            Console.WriteLine(result);


        }
       //3. Employees Full Information
        public static string GetEmployeesFullInformation(SoftUniContext context)
       {
           StringBuilder sb = new StringBuilder();

           var employees = context
               .Employees
               .OrderBy(e => e.EmployeeId)
               .Select(e => new
               {
                   e.FirstName, 
                   e.LastName,
                   e.MiddleName,
                   e.JobTitle,
                   e.Salary 
               });

           foreach (var e in employees)
           {
               sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}");
           }

           return sb.ToString().TrimEnd();

       }
    }
    
 
}
