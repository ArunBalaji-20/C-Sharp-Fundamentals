using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic_Management_System.Models;
using Clinic_Management_System.UIComponents;
using Aspose.Cells;

namespace Clinic_Management_System.Services
{
    public class ReportGeneration
    {
        public static void ConvertToCsv(string Filename)
        {
            var workbook = new Workbook(Filename);
            workbook.Save($"{Filename.Substring(0,Filename.Length-5)}.csv");
             
            //return true;
        }
    }
}
