using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace Console_App
{
    class HrManagemnt : IHrManagement
    {
       private Departments[] _departments;
        public HrManagemnt()
        {
            _departments = new Departments[0];
        }
        public Departments[] departments => _departments;

        

        public void AddDepartments(string departmentName, int workerLimit, int dsalaryLimit)
        {
            foreach (Departments departments in _departments)
            {
                if (departmentName.ToUpper() == departments.DepartmentName.ToUpper())
                {
                    Console.WriteLine("Bu adda departament artiq movcuddur");
                    return;
                }
            }


            Departments department = new Departments()
            {
                DepartmentName = departmentName,
                WorkerLimit=workerLimit,
                DsalaryLimit=dsalaryLimit
             };
            
            
            Array.Resize(ref _departments, _departments.Length + 1);
            _departments[_departments.Length - 1] = department;
            

        }

        public void AddEmployees(string fullname, string position, int esalaryLimit, string edepartmentName)
        {
            Employees employee = new Employees(fullname, position, esalaryLimit, edepartmentName)
            {
                FullName = fullname,
                Position = position,
                EsalaryLimit = esalaryLimit,
                EdepartmentName = edepartmentName
            };

            foreach (Departments departments in _departments)
            {
                if (departments.DepartmentName.ToUpper() == edepartmentName.ToUpper())
                {
                    Array.Resize(ref departments.Employees, departments.Employees.Length + 1);
                    departments.Employees[departments.Employees.Length - 1] = employee;
                }
                else
                {
                    Console.WriteLine("bu adda department yoxdur");
                }
            }
        }

       

        public void EditDepartment(string departmentName, int workerlimit, int salarylimit)
        {
            Console.WriteLine("yeni adi daxil et");
            string newdepartmentName = Console.ReadLine();
           

            //int newsalarylimitnum = int.Parse(newsalarylimitstr);

            foreach (Departments departments in _departments)
            { 
                if (!(departments.DepartmentName==departmentName) || workerlimit<1 || workerlimit>10 || salarylimit<250)
                {
                    Console.WriteLine("Duzgun melumat daxil et");
                }
                else
                {
                    departments.DepartmentName = newdepartmentName;

                    departments.WorkerLimit = workerlimit;

                    departments.DsalaryLimit = salarylimit;
                }
            }
        }

        public void EditEployeeByNo(string no, int salary, string position)
        {
            foreach (Departments departments in _departments)
            {
                for (int i = 0; i < departments.Employees.Length; i++)
                {
                    if (departments.Employees[i].NO.ToUpper()==no.ToUpper())
                    {
                        departments.Employees[i].NO = no.ToUpper();
                        departments.Employees[i].EsalaryLimit = salary;
                        departments.Employees[i].Position= position;    


                    }
                    else
                    {
                        Console.WriteLine("Daxil etdiyiniz isci nomresine uygun isci yoxdur");
                        return;
                    }



                }



            }


        }

        public void GetDepartments()
        {
            foreach (Departments departments in _departments)
            {
                Console.WriteLine($"Departamentin adi:{departments.DepartmentName}\n Isci Limiti: {departments.WorkerLimit}\n Maas Limiti: {departments.DsalaryLimit}\n Iscilerin Sayi: {departments.Employees.Length}");
            }
        }

        public void GetEmployeeData()
        {
            foreach (Departments departments in _departments)
            {
                for (int i = 0; i < departments.Employees.Length; i++)
                {
                    Console.WriteLine($"Iscinin Nomresi: {departments.Employees[i].NO}\nIscinin ad ve soyadi: {departments.Employees[i].FullName}\nIscinin maasi: {departments.Employees[i].EsalaryLimit}\nIscinin vezifesi: {departments.Employees[i].Position}\nIscinin departamenti: {departments.Employees[i].EdepartmentName}");
                }


            }
        }

        public void GetEmployeesCount()
        {
            foreach (Departments departments in _departments)
            {
                Console.WriteLine(departments.Employees.Length);
            }
        }

        
    }

}
