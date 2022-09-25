using System;
using System.Collections.Generic;
using System.Text;


namespace Console_App
{
    interface IHrManagement
    {
        Departments[] departments { get; }
        void AddDepartments(string departmentName, int workerLimit, int dsalaryLimit);
        void AddEmployees(string fullname, string position, int esalaryLimit, string edepartmentName);
        void GetDepartments();
        void GetEmployeesCount();
        void EditDepartment(string departmentName, int workerlimit, int salarylimit);
        void GetEmployeeData();
        void EditEployeeByNo(string no, int salary, string position);
    }
}
