
using System;
using System.Collections.Generic;
using System.Linq;



namespace Kattis_Problem_Secure_Doors
{
    class Program
    {
        static void Main(string[] args)
        {

            int number = Convert.ToInt32(Console.ReadLine());

            List<Employee> employees = new List<Employee>();

            while (number > 0)
            {
                string line = Console.ReadLine(); 


                string[] arrayOfLine = line.Split(" ");


                Employee employee = new Employee { Name = arrayOfLine[1] };


                if (arrayOfLine[0] == "entry")
                {
                    employee.Entry = "entry";
                }
                else
                {
                    employee.Exit = "exit";
                }

                employees.Add(employee);

                number--;
            }



            for (int i = 0; i < employees.Count; i++)
            {

               
                List<Employee> employees1 = new List<Employee>();



                for (int f = 0; f < i; f++)
                {

                    employees1.Add(employees[f]);

                }

                Employee employee = employees1.Where(x => x.Name == employees[i].Name).LastOrDefault();


                if (employee == null || i == 0)
                {
                    if (employees[i].Entry != null)
                    {
                        Console.WriteLine(employees[i].Name + " " + "entered");
                    }
                    else
                    {
                        Console.WriteLine(employees[i].Name + " " + "exited" + " (ANOMALY)");
                    }
                }
                else
                {
                    if (employees[i].Name == employee.Name)
                    {
                        if (employee.Entry != null)
                        {
                            if (employees[i].Entry != null)
                            {
                                Console.WriteLine(employees[i].Name + " " + "entered" + " (ANOMALY)");
                            }
                            else
                            {
                                Console.WriteLine(employees[i].Name + " " + "exited");
                            }
                        }

                        if (employee.Exit != null)
                        {
                            if (employees[i].Exit != null)
                            {
                                Console.WriteLine(employees[i].Name + " " + "exited" + " (ANOMALY)");
                            }
                            else
                            {
                                Console.WriteLine(employees[i].Name + " " + "entered");
                            }
                        }
                    }
                }
            }
        }
    }

    public class Employee
    {
        public string Name { get; set; }
        public string Entry { get; set; }
        public string Exit { get; set; }
    }
}