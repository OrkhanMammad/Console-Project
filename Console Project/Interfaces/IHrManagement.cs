using System;
using System.Collections.Generic;
using System.Text;
using Console_App.Services;
using Console_App.Interfaces;


namespace Console_App.Interfaces
{
    interface IHrManagement
    {
        Departments[] departments { get; }
        void AddDepartments(string departmentName, int workerLimit, int dsalaryLimit);
        void AddEmployees(string fullname, string position, int esalaryLimit, string edepartmentName);
        void GetDepartments();
        void GetEmployeesCount();
        void EditDepartment();
        void GetAllEmployeeData();
        void EditEployeeByNo();
        void GetEmployeeDataByDepartment(string departmentName);
        void DeleteEmployee();

    }
}
