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
                string answerstr = Console.ReadLine();
                int answernum;
                while (!int.TryParse(answerstr, out answernum) || answernum < 1 || answernum>6)
                {
                    Console.WriteLine("Duzgun deyer daxil et 1<<6");
                    answerstr = Console.ReadLine();
                }
                switch (answernum)
                {
                    case 1:
                        Console.WriteLine("Departament adi daxil et");
                        string departmentnamestr = Console.ReadLine();
                        while (departmentnamestr.Length<2)
                        {
                            Console.WriteLine("Departament adi minimum 2 herfden ibaret olmalidir");
                            departmentnamestr = Console.ReadLine();
                        }
                        Console.WriteLine("isci limiti daxil et");
                        string workerlimitstr = Console.ReadLine();
                        int workerlimitnum;
                        while (!int.TryParse(workerlimitstr, out workerlimitnum) || workerlimitnum<1 || workerlimitnum>10)
                        {
                            Console.WriteLine("Isci limiti 1 ve 10 arasinda eded olmalidir");
                            workerlimitstr = Console.ReadLine();
                        }
                        Console.WriteLine("maas limiti daxil et");
                        string dsalarylimitstr = Console.ReadLine();
                        int salarylimitfor1worker = 250;
                        int dsalarylimitnum;
                        while (!int.TryParse(dsalarylimitstr, out dsalarylimitnum) || dsalarylimitnum<workerlimitnum*salarylimitfor1worker)
                        {
                            Console.WriteLine("Maas 1 isci ucun minimum 250 olmalidir");
                            dsalarylimitstr = Console.ReadLine();

                        }
                        hrManagement.AddDepartments(departmentnamestr, workerlimitnum, dsalarylimitnum);
                        Console.WriteLine(hrManagement.departments.Length);

                        foreach (Departments item in hrManagement.departments)
                        {
                            //Console.WriteLine(item.DepartmentName);
                            Console.WriteLine($"Departament adi:{item.DepartmentName}\nIsci limiti:{item.WorkerLimit}\nMaas limiti:{item.DsalaryLimit}");

                        }
                        break;

                    case 2:
                        Console.WriteLine("Iscinin ad ve soyadini daxil et");
                        string fullnamestr = Console.ReadLine();
                        Console.WriteLine("Iscinin vezifesini daxil et");
                        string positionstr = Console.ReadLine();
                        while (positionstr.Length<2)
                        {
                            Console.WriteLine("Iscinin vezifesi en az 2 simvoldan ibaret olmalidir");
                            positionstr = Console.ReadLine();
                        }
                        Console.WriteLine("Iscinin minimum maasini daxil et");
                        string esalarylimitstr = Console.ReadLine();
                        int esalarylimitnum;
                        while (!int.TryParse(esalarylimitstr, out esalarylimitnum) || esalarylimitnum<250)
                        {
                            Console.WriteLine("Minimum emek haqqi 250 olmalidir");
                            esalarylimitstr = Console.ReadLine();
                        }
                        Console.WriteLine("Iscinin elave olunacagi departamenti siyahidan secib yazin");

                        Console.WriteLine("Departamentlerin siyahisi");
                        hrManagement.GetDepartmentsName();
                        string edepartmentname = Console.ReadLine();
                        hrManagement.AddEmployees(fullnamestr,positionstr,esalarylimitnum,edepartmentname);
                        hrManagement.GetEmployeesCount();

                        break;
                    case 3:
                        Console.WriteLine("Deyismek istediyiniz departmenti secin");
                        string departmentname1= Console.ReadLine();
                       
                        
                        Console.WriteLine("Yeni isci limiti daxil et");
                        string newworkerlimitstr = Console.ReadLine();
                        int newworkerlimitnum=int.Parse(newworkerlimitstr);
                        Console.WriteLine("yeni maas limiti daxil et");
                        string newsalarylimitstr=Console.ReadLine();
                        int newsalarylimitnum=int.Parse(newsalarylimitstr);

                        hrManagement.EditDepartment(departmentname1,newworkerlimitnum,newsalarylimitnum);








                        break;
                       

                }
               









            } while (true);
            




        }
    }
}
