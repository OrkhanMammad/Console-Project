using System;

namespace Console_App
{
    class Program
    {
        static void Main(string[] args)
        {
            
            IHrManagement hrManagement = new HrManagemnt();

            do
            {
                Console.WriteLine("Etmek Istediyiniz Emeliyyati Secin");
                Console.WriteLine("1. Departament elave edin");
                Console.WriteLine("2. Isci elave et");
                Console.WriteLine("3. Departmenti deyisin");
                Console.WriteLine("4. Departamentlerin melumatlarini elde et");
                Console.WriteLine("5. Iscilerin melumatlarini elde et");
                Console.WriteLine("6. Iscinin maas ve vezifesini deyisin");
                Console.WriteLine("7. Departamentdeki iscilerin melumatlari");


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
                        AddDepartment(ref hrManagement);                   
                        break;

                    case 2:

                        AddEmployee(ref hrManagement);
                        break;
                    case 3:

                        EditDepartment(ref hrManagement);

                        break;
                    case 4:
                        //hrManagement.GetDepartments();
                        GetDepartments(ref hrManagement);

                        break;
                    case 5:
                        //hrManagement.GetEmployeeData();
                        GetAllEmployeeData(ref hrManagement);

                        break;
                    case 6:

                        EditEmployee(ref hrManagement);
                        break;
                    case 7:
                        GetEmployeeDataByDepartment(ref hrManagement);
                        //Console.WriteLine("Departamentin adini yazin");
                        //string departNameForGettingEmployees = Console.ReadLine();
                        //hrManagement.GetEmployeeDataByDepartment(departNameForGettingEmployees);

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
            string esalarylimitstr = Console.ReadLine();
            int esalarylimitnum;
            while (!int.TryParse(esalarylimitstr, out esalarylimitnum) || esalarylimitnum < 250)
            {
                Console.WriteLine("Minimum emek haqqi 250 olmalidir");
                esalarylimitstr = Console.ReadLine();
            }
            Console.WriteLine("Iscinin elave olunacagi departamenti siyahidan secib yazin");

            Console.WriteLine("Departamentlerin siyahisi");
            hrManagement.GetDepartments();
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
            Console.WriteLine("Deyismek istediyiniz iscinin nomresini daxil edin");
            string employeeNumber = Console.ReadLine();
            Console.WriteLine("Yeni maas elave edin");
            string newemployeesalary = Console.ReadLine();
            int newemployeesalarynum = int.Parse(newemployeesalary);
            Console.WriteLine("yeni vezife daxil edin");
            string newpositionofemployee = Console.ReadLine();
            hrManagement.EditEployeeByNo(employeeNumber, newemployeesalarynum, newpositionofemployee);
        }
        static void GetEmployeeDataByDepartment(ref IHrManagement hrManagement)
        {
            Console.WriteLine("Departamentin adini yazin");
            string departNameForGettingEmployees = Console.ReadLine();
            hrManagement.GetEmployeeDataByDepartment(departNameForGettingEmployees);
        }
    }
}
