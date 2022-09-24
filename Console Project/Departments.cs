using System;
using System.Collections.Generic;
using System.Text;

namespace Console_App
{
    class Departments
    {
        public string DepartmentName;
        public int WorkerLimit;
        public int DsalaryLimit;
        public Employees[] Employees;

        public Departments()
        {
            Employees = new Employees[0];   
        }

        public Departments(string departmentName, int workerLimit, int dsalaryLimit)
        {
            DepartmentName = departmentName;
            WorkerLimit = workerLimit;
            DsalaryLimit = dsalaryLimit;
        }
        
    }
}
