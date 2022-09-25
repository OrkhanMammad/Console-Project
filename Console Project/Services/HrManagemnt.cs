using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Net.Http.Headers;
using Console_App.Interfaces;
using Console_App.Services;

namespace Console_App.Services
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
                WorkerLimit = workerLimit,
                DsalaryLimit = dsalaryLimit
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



        public void EditDepartment()
        {
            Console.WriteLine("Deyismek istediyiniz departamentin adini daxil edin");
            string olddepartmentName = Console.ReadLine();

            foreach (Departments departments in _departments)
            {
                if (!(departments.DepartmentName.ToUpper() == olddepartmentName.ToUpper()))
                {
                    Console.WriteLine("Bu Adda Departament Yoxdur");
                }
                else
                {
                    Console.WriteLine("yeni departament adi daxil et");
                    string newdepartmentname = Console.ReadLine();
                    Console.WriteLine("yeni isci limiti daxil edin");
                    string newworkerlimitfornewdep = Console.ReadLine();
                    int newworkerlimitfornewdepnum = int.Parse(newworkerlimitfornewdep);
                    if (newworkerlimitfornewdepnum > departments.WorkerLimit)
                    {
                        Console.WriteLine("yeni limit evvelkinden boyuk ola bilmez");
                    }
                    else
                    {
                        Console.WriteLine("Yeni Maas limiti daxil et");
                        string newsalarylimitfornewdep = Console.ReadLine();
                        int newsalarylimitfornewdepnum = int.Parse(newsalarylimitfornewdep);
                        departments.DepartmentName = newdepartmentname;
                        departments.WorkerLimit = newworkerlimitfornewdepnum;
                        departments.DsalaryLimit = newsalarylimitfornewdepnum;

                    }


                }
            }
        }

        public void EditEployeeByNo()
        {
            Console.WriteLine("Iscinin nomresini daxil et");
            string oldemployenumber = Console.ReadLine();

            foreach (Departments departments in _departments)
            {
                for (int i = 0; i < departments.Employees.Length; i++)
                {
                    if (!(departments.Employees[i].NO.ToUpper() == oldemployenumber.ToUpper()))
                    {
                        Console.WriteLine("Bu nomreli isci movcud deyil");

                    }
                    else
                    {
                        Console.WriteLine($"Iscinin Nomresi: {departments.Employees[i].NO}\nIscinin ad ve soyadi: {departments.Employees[i].FullName}\nIscinin maasi: {departments.Employees[i].EsalaryLimit}\nIscinin vezifesi: {departments.Employees[i].Position}\nIscinin departamenti: {departments.Employees[i].EdepartmentName}");
                        Console.WriteLine("iscinin yeni maasini daxil et");
                        string newsalaryfornewemployee = Console.ReadLine();
                        int newsalaryfornewemployeenum = int.Parse(newsalaryfornewemployee);
                        Console.WriteLine("iscinin yeni vezifesini daxil et");
                        string newpositionfornewemployee = Console.ReadLine();
                        departments.Employees[i].EsalaryLimit = newsalaryfornewemployeenum;
                        departments.Employees[i].Position = newpositionfornewemployee;
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

        public void GetAllEmployeeData()
        {
            foreach (Departments departments in _departments)
            {
                for (int i = 0; i < departments.Employees.Length; i++)
                {
                    if (departments.Employees[0] == null)
                    {
                        Console.WriteLine("isci yoxdur");
                    }
                    else
                    {
                        Console.WriteLine($"Iscinin Nomresi: {departments.Employees[i].NO}\nIscinin ad ve soyadi: {departments.Employees[i].FullName}\nIscinin maasi: {departments.Employees[i].EsalaryLimit}\nIscinin vezifesi: {departments.Employees[i].Position}\nIscinin departamenti: {departments.Employees[i].EdepartmentName}");
                    }

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

        public void GetEmployeeDataByDepartment(string departmentName)
        {
            foreach (Departments departments in _departments)
            {

                for (int i = 0; i < departments.Employees.Length; i++)
                {
                    if (departmentName.ToUpper() == departments.DepartmentName.ToUpper())
                    {
                        Console.WriteLine($"Iscinin nomresi: {departments.Employees[i].NO}\nAd ve soyadi:{departments.Employees[i].FullName}\nMaasi: {departments.Employees[i].EsalaryLimit}\nVezifesi:{departments.Employees[i].Position}");
                    }

                }

            }



        }

        public void DeleteEmployee()
        {
            Console.WriteLine("Hansi departamentden isci silmek isteyirsiniz");
            string deleteEmployeeInDepertment = Console.ReadLine();

            foreach (Departments departments in _departments)
            {
                if (!(departments.DepartmentName == deleteEmployeeInDepertment))
                {
                    Console.WriteLine("bu adda departament yoxdur");
                }
                else
                {
                    Console.WriteLine("Silmek istediyiniz iscinin nomresini daxil et");
                    string deleteEmployeeBynumber = Console.ReadLine();
                    for (int i = 0; i < departments.Employees.Length; i++)
                    {
                        if (!(deleteEmployeeBynumber.ToUpper() == departments.Employees[i].NO.ToUpper()))
                        {
                            Console.WriteLine("bu nomreli isci movcud deyil");
                        }
                        else
                        {
                            departments.Employees[i] = null;
                        }
                    }
                }


            }
        }
    }

}
