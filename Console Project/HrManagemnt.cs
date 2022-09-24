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

        public object ToUpper { get; private set; }

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
            Employees employees = new Employees(fullname, position, esalaryLimit, edepartmentName)
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
                    departments.Employees[departments.Employees.Length - 1] = employees;
                }
            }
        }

        public void GetDepartmentsName()
        {
            foreach (Departments departments in _departments)
            {
                Console.WriteLine(departments.DepartmentName);
            }
        }
    }

}
