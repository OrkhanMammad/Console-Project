using System;
using Console_App.Interfaces;
using Console_App.Services;


namespace Console_App
{
    class Program
    {
        static void Main(string[] args)
        {
            
            IHrManagement hrManagement = new HrManagemnt();

            do
            {
                Console.WriteLine(" ");
                Console.WriteLine("Etmek Istediyiniz Emeliyyati Secin");
                Console.WriteLine(" ");
                Console.WriteLine("1. Departamentlerin melumatlarini elde et");
                Console.WriteLine("2. Departament elave edin");
                Console.WriteLine("3. Departmenti deyisin");
                Console.WriteLine("4. Iscilerin melumatlarini elde et");
                Console.WriteLine("5. Departamentdeki iscilerin melumatlari");
                Console.WriteLine("6. Isci elave et");
                Console.WriteLine("7. Iscinin maas ve vezifesini deyisin");
                Console.WriteLine("8. Iscini departamentden sil");
                Console.WriteLine("");

                string answerstr = Console.ReadLine();
                int answernum;
                while (!int.TryParse(answerstr, out answernum) || answernum < 1 || answernum>8)
                {
                    Console.WriteLine("Duzgun deyer daxil et 1<<6");
                    answerstr = Console.ReadLine();
                }



                switch (answernum)
                {
                    case 1:

                        GetDepartments(ref hrManagement);
                                          
                        break;

                    case 2:

                        AddDepartment(ref hrManagement);
                        
                        break;

                    case 3:

                        EditDepartment(ref hrManagement);

                        break;
                    case 4:

                        GetAllEmployeeData(ref hrManagement);

                        break;
                    case 5:

                        GetEmployeeDataByDepartment(ref hrManagement);

                        break;
                    case 6:

                        AddEmployee(ref hrManagement);
 
                        break;
                    case 7:

                        EditEmployee(ref hrManagement);

                        break;
                    case 8:

                        DeleteEmployee(ref hrManagement);

                        break;

                }
            

            } while (true);
           

        }
        static void GetDepartments(ref IHrManagement hrManagement)
        {
            hrManagement.GetDepartments();

        }
        static void GetAllEmployeeData(ref IHrManagement hrManagement)
        {
            hrManagement.GetAllEmployeeData();
        }
        
        static void AddDepartment(ref IHrManagement hrManagement)
        {
            Console.WriteLine("Departament adi daxil et");
            string departmentnamestr = Console.ReadLine();
            while (departmentnamestr.Length < 2)
            {
                Console.WriteLine("Departament adi minimum 2 herfden ibaret olmalidir");
                departmentnamestr = Console.ReadLine();
            }
            Console.WriteLine("isci limiti daxil et");
            string workerlimitstr = Console.ReadLine();
            int workerlimitnum;
            while (!int.TryParse(workerlimitstr, out workerlimitnum) || workerlimitnum < 1 || workerlimitnum > 10)
            {
                Console.WriteLine("Isci limiti 1 ve 10 arasinda eded olmalidir");
                workerlimitstr = Console.ReadLine();
            }
            Console.WriteLine("maas limiti daxil et");
            string dsalarylimitstr = Console.ReadLine();
            int salarylimitfor1worker = 250;
            int dsalarylimitnum;
            while (!int.TryParse(dsalarylimitstr, out dsalarylimitnum) || dsalarylimitnum < workerlimitnum * salarylimitfor1worker)
            {
                Console.WriteLine("Maas 1 isci ucun minimum 250 olmalidir");
                dsalarylimitstr = Console.ReadLine();

            }
            hrManagement.AddDepartments(departmentnamestr, workerlimitnum, dsalarylimitnum);


        }

        static void AddEmployee(ref IHrManagement hrManagement)
        {
            Console.WriteLine("Iscinin ad ve soyadini daxil et");
            string fullnamestr = Console.ReadLine();
            Console.WriteLine("Iscinin vezifesini daxil et");
            string positionstr = Console.ReadLine();
            while (positionstr.Length < 2)
            {
                Console.WriteLine("Iscinin vezifesi en az 2 simvoldan ibaret olmalidir");
                positionstr = Console.ReadLine();
            }
            Console.WriteLine("Iscinin minimum maasini daxil et");
            Console.WriteLine(" ");
            string esalarylimitstr = Console.ReadLine();
            int esalarylimitnum;
            while (!int.TryParse(esalarylimitstr, out esalarylimitnum) || esalarylimitnum < 250)
            {
                Console.WriteLine("Minimum emek haqqi 250 olmalidir");
                esalarylimitstr = Console.ReadLine();
            }
            Console.WriteLine("Iscinin elave olunacagi departamenti siyahidan secib yazin");

            Console.WriteLine("Departamentlerin siyahisi");
            Console.WriteLine(" ");
            hrManagement.GetDepartments();
            Console.WriteLine(" ");
            string edepartmentname = Console.ReadLine();
            hrManagement.AddEmployees(fullnamestr, positionstr, esalarylimitnum, edepartmentname);
            hrManagement.GetEmployeesCount();
        }

        static void EditDepartment(ref IHrManagement hrManagement)
        {
           

            hrManagement.EditDepartment();

        }

        static void EditEmployee(ref IHrManagement hrManagement)
        {
           
            hrManagement.EditEployeeByNo();
        }
        static void GetEmployeeDataByDepartment(ref IHrManagement hrManagement)
        {
            Console.WriteLine("Departamentin adini yazin");
            string departNameForGettingEmployees = Console.ReadLine();
            hrManagement.GetEmployeeDataByDepartment(departNameForGettingEmployees);
        }
        static void DeleteEmployee(ref IHrManagement hrManagement)
        {

            hrManagement.DeleteEmployee();
        }

    }
}
