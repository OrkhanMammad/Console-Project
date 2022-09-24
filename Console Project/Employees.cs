using System;
using System.Collections.Generic;
using System.Text;


namespace Console_App
{
   public class Employees
    {
        public string FullName;
        public string Position;
        public int EsalaryLimit;
        public string NO;
        public string EdepartmentName;
        private static int _no;
        static Employees()
        {
            _no = 1000;
        }
        public Employees(string fullname,string position, int esalarylimit, string edepartmentName)
        {
            FullName = fullname;
            Position = position;
            EsalaryLimit = esalarylimit;
            EdepartmentName = edepartmentName;
            _no++;
            NO = $"{edepartmentName[0].ToString().ToUpper()}{edepartmentName[1].ToString().ToUpper()}{_no}";
            
        }




    }
}
