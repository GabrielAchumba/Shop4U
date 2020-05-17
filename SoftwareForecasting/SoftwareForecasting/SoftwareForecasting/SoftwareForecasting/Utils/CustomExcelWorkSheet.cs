using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareForecasting.Utils
{
    public class CustomExcelWorkSheet
    {
        public ISheet excelWorksheet { get; set; }
        public string SheetName { get; set; }
        public CustomExcelWorkSheet(ISheet _excelWorksheet,string _SheetName)
        {
            excelWorksheet = _excelWorksheet;
            SheetName = _SheetName;
        }


    }
}
