using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using NPOI.HSSF.UserModel;
using NPOI.OpenXml4Net.OPC;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using SoftwareForecasting.Forecast;
using SoftwareForecasting.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SoftwareForecasting.Utils
{
    public class Util
    {
        public  const string DllPath
            = @"C:\Users\Gabriel Achumba\Documents\SoftwareForecasting\SoftwareForecasting\SoftwareForecasting\Libraries\MATHSLIB.dll";
        public static double ToDouble(string x)
        {
            double result = 0;
            bool check = double.TryParse(x, out result);
            if (check == true) return result;
            return result;
        }
        public static List<InputDeck> GetInputDecks(string[] lines)
        {
            List<InputDeck> InputDecks = new List<InputDeck>();
            var inputDeckId = Guid.NewGuid();

            for (int i = 1; i < lines.Length; i++)
            {
                var line = lines[i].Split("\t");

                InputDecks.Add(new InputDeck
                {
                    Version_Name = line[0],
                    Asset_Team = line[1],
                    Field = line[2],
                    Reservoir = line[3],
                    Drainage_Point = line[4],
                    Production_String = line[5],
                    Module = line[6],
                    PEEP_Project = line[7],
                    Activity_Entity = line[8],
                    Flow_station = line[9],
                    Hydrocarbon_Stream = line[10],
                    Resource_Class = line[11],
                    Change_Category = line[12],
                    Technique_1P = line[13],
                    URo_1P_1C = ToDouble(line[14]),
                    URo_Low = ToDouble(line[15]),
                    URo_2P_2C = ToDouble(line[16]),
                    URo_3P_3C = ToDouble(line[17]),
                    Np = ToDouble(line[18]),
                    URg_1P_1C = ToDouble(line[19]),
                    URg_Low = ToDouble(line[20]),
                    URg_2P_2C = ToDouble(line[21]),
                    URg_3P_3C = ToDouble(line[22]),
                    Gp = ToDouble(line[23]),
                    Init_Oil_Gas_Rate_1P_1C = ToDouble(line[24]),
                    Init_Oil_Gas_Rate_Low = ToDouble(line[25]),
                    Init_Oil_Gas_Rate_2P_2C = ToDouble(line[26]),
                    Init_Oil_Gas_Rate_3P_3C = ToDouble(line[27]),
                    Aband_Oil_Gas_Rate_1P_1C = ToDouble(line[28]),
                    Aband_Oil_Gas_Rate_2P_2C = ToDouble(line[29]),
                    Aband_Oil_Gas_Rate_3P_3C = ToDouble(line[30]),
                    Init_BSW_WGR = ToDouble(line[31]),
                    Aband_BSW_WGR_1P_1C = ToDouble(line[32]),
                    Aband_BSW_WGR_2P_2C = ToDouble(line[33]),
                    Aband_BSW_WGR_3P_3C = ToDouble(line[34]),
                    Init_GOR_CGR = ToDouble(line[35]),
                    Aband_GOR_CGR_1P_1C = ToDouble(line[36]),
                    Aband_GOR_CGR_2P_2C = ToDouble(line[37]),
                    Aband_GOR_CGR_3P_3C = ToDouble(line[38]),
                    lift_Gas_Rate = ToDouble(line[39]),
                    Plateau_Oil_Gas = ToDouble(line[40]),
                    In_year_Booking = line[41],
                    LE_LV = line[41],
                    PRCS = line[42],
                    On_stream_Date_1P_1C = line[43],
                    On_stream_Date_2P_2C = line[44],
                    On_stream_Date_3P_3C = line[45],
                    Remarks = line[46],
                    TRANCHE = line[47],
                    InputDeckId = inputDeckId
                });

            }

            return InputDecks;
        }


        public static List<string> ReadExcel(IHostingEnvironment hostingEnvironment, string FileName, string directoryName = "Upload")
        {
            List<CustomExcelWorkSheet> customeworksheets = new List<CustomExcelWorkSheet>();

            string sWebRootFolder = hostingEnvironment.WebRootPath;


            string directorypath = Path.Combine(sWebRootFolder, directoryName);

            var filepath = Path.Combine(directorypath, Path.GetFileName(FileName));



            XSSFWorkbook wb = null;


            try
            {
                OPCPackage pkg = OPCPackage.Open(filepath);
                wb = new XSSFWorkbook(pkg);
            }
            catch (Exception ex)
            {


            }


            int NumberOfWorkSheets = wb.NumberOfSheets;

            List<string> sheetNames = new List<string>();

            for (int i = 0; i < NumberOfWorkSheets; i++)
            {
                ISheet worksheet = wb.GetSheetAt(i);
                customeworksheets.Add(new CustomExcelWorkSheet(worksheet, worksheet.SheetName));
                sheetNames.Add(worksheet.SheetName);
            }

            return sheetNames;
        }

        public static List<string> GetVariableNames(IHostingEnvironment hostingEnvironment, string SheetName, string FileName,
            string directoryName = "Upload")
        {
            List<CustomExcelWorkSheet> customeworksheets = new List<CustomExcelWorkSheet>();

            string sWebRootFolder = hostingEnvironment.WebRootPath;

            string directorypath = Path.Combine(sWebRootFolder, directoryName);

            var filepath = Path.Combine(directorypath, Path.GetFileName(FileName));

            OPCPackage pkg = OPCPackage.Open(filepath);

            XSSFWorkbook wb = null;


            try
            {
                wb = new XSSFWorkbook(pkg);
            }
            catch (Exception ex)
            {


            }


            int NumberOfWorkSheets = wb.NumberOfSheets;

            List<string> VariablesNames = new List<string>();

            for (int i = 0; i < NumberOfWorkSheets; i++)
            {
                ISheet worksheet = wb.GetSheetAt(i);

                if (SheetName == worksheet.SheetName)
                {
                    IRow row = worksheet.GetRow(0);

                    foreach (ICell cell in row.Cells)
                    {
                        VariablesNames.Add(cell.StringCellValue);
                    }
                }

            }

            return VariablesNames;
        }

        public static MappedData AutoMapper(List<string> ColumnHeadersNames, PropertyInfo[] props)
        {
            MappedData mappedData = new MappedData();

            List<string> ColumnHeadersCopy = new List<string>(ColumnHeadersNames);

            Dictionary<string, string> MappedDictionary = new Dictionary<string, string>();

            List<string> VariablesNames = new List<string>();

            Regex regex = null;

            foreach (var columHeaderName in ColumnHeadersNames)
            {
                foreach (var prop in props)
                {
                    string pattern = $"^{prop.Name}$";
                    regex = new Regex(pattern);
                    if (regex.IsMatch(columHeaderName))
                    {
                        ColumnHeadersCopy.Remove(columHeaderName);
                        MappedDictionary.Add(columHeaderName, prop.Name); ;
                        break;
                    }
                }
            }

            mappedData.ColumnHeadersCopy = ColumnHeadersCopy;
            mappedData.MappedDictionary = MappedDictionary;
            return mappedData;


        }

        public static List<ExtendedInputDeck> GetCrossCheckedDecks(Dictionary<string, string> MappedDictionary,
                                                                    IHostingEnvironment hostingEnvironment,
                                                                    string SheetName, string FileName,
                                                                    int StartRow, int EndRow)
        {

            List<CustomExcelWorkSheet> customeworksheets = new List<CustomExcelWorkSheet>();

            string sWebRootFolder = hostingEnvironment.WebRootPath;

            string directoryName = "Upload";

            string directorypath = Path.Combine(sWebRootFolder, directoryName);

            var filepath = Path.Combine(directorypath, Path.GetFileName(FileName));

            OPCPackage pkg = OPCPackage.Open(filepath);

            XSSFWorkbook wb = null;


            try
            {
                wb = new XSSFWorkbook(pkg);
            }
            catch (Exception ex)
            {


            }


            int NumberOfWorkSheets = wb.NumberOfSheets;
            List<ExtendedInputDeck> extendedInputDecks = new List<ExtendedInputDeck>();
            var props = typeof(InputDeck).GetProperties();

            for (int i = 0; i < NumberOfWorkSheets; i++)
            {
                ISheet worksheet = wb.GetSheetAt(i);

                if (SheetName == worksheet.SheetName)
                {
                    IRow firstrow = worksheet.GetRow(0);

                    for (int rowIndex = 1; rowIndex <= worksheet.LastRowNum; rowIndex++)
                    {

                        IRow row = worksheet.GetRow(rowIndex);
                        ExtendedInputDeck extendedInputDeck = new ExtendedInputDeck();
                        int j = -1;
                        foreach (ICell cell in row.Cells)
                        {
                            try
                            {
                                j++;
                                string cellHeader = firstrow.Cells[j].StringCellValue;
                                if (MappedDictionary.ContainsKey(cellHeader))
                                {
                                    try
                                    {


                                        switch (MappedDictionary[cellHeader])
                                        {
                                            case "Version_Name":
                                                extendedInputDeck.Version_Name = cell.StringCellValue;
                                                break;
                                            case "Asset_Team":
                                                extendedInputDeck.Asset_Team = cell.StringCellValue;
                                                break;
                                            case "Field":
                                                extendedInputDeck.Field = cell.StringCellValue;
                                                break;
                                            case "Reservoir":
                                                extendedInputDeck.Reservoir = cell.StringCellValue;
                                                break;
                                            case "Drainage_Point":
                                                extendedInputDeck.Drainage_Point = cell.StringCellValue;
                                                break;
                                            case "Production_String":
                                                extendedInputDeck.Production_String = cell.StringCellValue;
                                                break;
                                            case "Module":
                                                extendedInputDeck.Module = cell.StringCellValue;
                                                break;
                                            case "PEEP_Project":
                                                extendedInputDeck.PEEP_Project = cell.StringCellValue;
                                                break;
                                            case "Activity_Entity":
                                                extendedInputDeck.Activity_Entity = cell.StringCellValue;
                                                break;
                                            case "Flow_station":
                                                extendedInputDeck.Flow_station = cell.StringCellValue;
                                                break;
                                            case "Hydrocarbon_Stream":
                                                extendedInputDeck.Hydrocarbon_Stream = cell.StringCellValue;
                                                break;
                                            case "Resource_Class":
                                                extendedInputDeck.Resource_Class = cell.StringCellValue;
                                                break;
                                            case "Change_Category":
                                                extendedInputDeck.Change_Category = cell.StringCellValue;
                                                break;
                                            case "Technique_1P":
                                                extendedInputDeck.Technique_1P = cell.StringCellValue;
                                                break;
                                            case "URo_1P_1C":
                                                extendedInputDeck.URo_1P_1C = cell.NumericCellValue;
                                                break;
                                            case "URo_Low":
                                                extendedInputDeck.URo_Low = cell.NumericCellValue;
                                                break;
                                            case "URo_2P_2C":
                                                extendedInputDeck.URo_2P_2C = cell.NumericCellValue;
                                                break;
                                            case "URo_3P_3C":
                                                extendedInputDeck.URo_3P_3C = cell.NumericCellValue;
                                                break;
                                            case "Np":
                                                extendedInputDeck.Np = cell.NumericCellValue;
                                                break;
                                            case "URg_1P_1C":
                                                extendedInputDeck.URg_1P_1C = cell.NumericCellValue;
                                                break;
                                            case "URg_Low":
                                                extendedInputDeck.URg_Low = cell.NumericCellValue;
                                                break;
                                            case "URg_2P_2C":
                                                extendedInputDeck.URg_2P_2C = cell.NumericCellValue;
                                                break;
                                            case "URg_3P_3C":
                                                extendedInputDeck.URg_3P_3C = cell.NumericCellValue;
                                                break;
                                            case "Gp":
                                                extendedInputDeck.Gp = cell.NumericCellValue;
                                                break;
                                            case "Init_Oil_Gas_Rate_1P_1C":
                                                extendedInputDeck.Init_Oil_Gas_Rate_1P_1C = cell.NumericCellValue;
                                                break;
                                            case "Init_Oil_Gas_Rate_Low":
                                                extendedInputDeck.Init_Oil_Gas_Rate_Low = cell.NumericCellValue;
                                                break;
                                            case "Init_Oil_Gas_Rate_2P_2C":
                                                extendedInputDeck.Init_Oil_Gas_Rate_2P_2C = cell.NumericCellValue;
                                                break;
                                            case "Init_Oil_Gas_Rate_3P_3C":
                                                extendedInputDeck.Init_Oil_Gas_Rate_3P_3C = cell.NumericCellValue;
                                                break;
                                            case "Aband_Oil_Gas_Rate_1P_1C":
                                                extendedInputDeck.Aband_Oil_Gas_Rate_1P_1C = cell.NumericCellValue;
                                                break;
                                            case "Aband_Oil_Gas_Rate_2P_2C":
                                                extendedInputDeck.Aband_Oil_Gas_Rate_2P_2C = cell.NumericCellValue;
                                                break;
                                            case "Aband_Oil_Gas_Rate_3P_3C":
                                                extendedInputDeck.Aband_Oil_Gas_Rate_3P_3C = cell.NumericCellValue;
                                                break;
                                            case "Init_BSW_WGR":
                                                extendedInputDeck.Init_BSW_WGR = cell.NumericCellValue;
                                                break;
                                            case "Aband_BSW_WGR_1P_1C":
                                                extendedInputDeck.Aband_BSW_WGR_1P_1C = cell.NumericCellValue;
                                                break;
                                            case "Aband_BSW_WGR_2P_2C":
                                                extendedInputDeck.Aband_BSW_WGR_2P_2C = cell.NumericCellValue;
                                                break;
                                            case "Aband_BSW_WGR_3P_3C":
                                                extendedInputDeck.Aband_BSW_WGR_3P_3C = cell.NumericCellValue;
                                                break;
                                            case "Init_GOR_CGR":
                                                extendedInputDeck.Init_GOR_CGR = cell.NumericCellValue;
                                                break;
                                            case "Aband_GOR_CGR_1P_1C":
                                                extendedInputDeck.Aband_GOR_CGR_1P_1C = cell.NumericCellValue;
                                                break;
                                            case "Aband_GOR_CGR_2P_2C":
                                                extendedInputDeck.Aband_GOR_CGR_2P_2C = cell.NumericCellValue;
                                                break;
                                            case "Aband_GOR_CGR_3P_3C":
                                                extendedInputDeck.Aband_GOR_CGR_3P_3C = cell.NumericCellValue;
                                                break;
                                            case "lift_Gas_Rate":
                                                extendedInputDeck.lift_Gas_Rate = cell.NumericCellValue;
                                                break;
                                            case "Plateau_Oil_Gas":
                                                extendedInputDeck.Plateau_Oil_Gas = cell.NumericCellValue;
                                                break;
                                            case "In_year_Booking":
                                                extendedInputDeck.In_year_Booking = cell.StringCellValue;
                                                break;
                                            case "LE_LV":
                                                extendedInputDeck.LE_LV = cell.StringCellValue;
                                                break;
                                            case "PRCS":
                                                extendedInputDeck.PRCS = cell.StringCellValue;
                                                break;
                                            case "On_stream_Date_1P_1C":
                                                extendedInputDeck.On_stream_Date_1P_1C = cell.StringCellValue;
                                                extendedInputDeck.On_Stream_Date_1P_1C = Convert.ToDateTime(cell.StringCellValue);
                                                break;
                                            case "On_stream_Date_2P_2C":
                                                extendedInputDeck.On_stream_Date_2P_2C = cell.StringCellValue;
                                                extendedInputDeck.On_Stream_Date_2P_2C = Convert.ToDateTime(cell.StringCellValue);
                                                break;
                                            case "On_stream_Date_3P_3C":
                                                extendedInputDeck.On_stream_Date_3P_3C = cell.StringCellValue;
                                                extendedInputDeck.On_Stream_Date_3P_3C = Convert.ToDateTime(cell.StringCellValue);
                                                break;
                                            case "Remarks":
                                                extendedInputDeck.Remarks = cell.StringCellValue;
                                                break;
                                            case "TRANCHE":
                                                extendedInputDeck.TRANCHE = cell.StringCellValue;
                                                break;
                                        }

                                    }
                                    catch (Exception ex)
                                    {


                                    }
                                }

                            }
                            catch (Exception ex)
                            {

                            }

                        }

                        ValidateDeck(ref extendedInputDeck);
                        extendedInputDecks.Add(extendedInputDeck);
                    }
                }

            }




            return extendedInputDecks;

        }


        private static void ValidateDeck(ref ExtendedInputDeck extendedInputDeck)
        {
            string Description = "";
            string newline = "\n";

            if (extendedInputDeck.Hydrocarbon_Stream == null)
            {
                Description = Description + "Hydrocarbon stream cannot be undefined" + newline;
                extendedInputDeck.Description = Description;
                return;
            }

            bool check_DGOR_CGR_1P1C = false;
            bool check_DGOR_CGR_2P2C = false;
            bool check_DGOR_CGR_3P3C = false;
            bool check_DBSW_WGR_1P1C = false;
            bool check_DBSW_WGR_2P2C = false;
            bool check_DBSW_WGR_3P3C = false;
            bool check_Rate_1P1C = false;
            bool check_Rate_2P2C = false;
            bool check_Rate_3P3C = false;

            if (extendedInputDeck.Hydrocarbon_Stream.ToLower() == "oil")
            {
                if (extendedInputDeck.Init_Oil_Gas_Rate_1P_1C <= 0)
                {
                    check_Rate_1P1C = true;
                    Description = Description + "Initial oil rate cannot be less than or equal zero (1P/1C)" + newline;
                }

                if (extendedInputDeck.Init_Oil_Gas_Rate_2P_2C <= 0)
                {
                    check_Rate_2P2C = true;
                    Description = Description + "Initial oil rate cannot be less than or equal zero (2P/2C)" + newline;
                }

                if (extendedInputDeck.Init_Oil_Gas_Rate_3P_3C <= 0)
                {
                    check_Rate_2P2C = true;
                    Description = Description + "Initial oil rate cannot be less than or equal zero (3P/3C)" + newline;
                }

                if (extendedInputDeck.Init_Oil_Gas_Rate_1P_1C <= extendedInputDeck.Aband_Oil_Gas_Rate_1P_1C)
                {
                    check_Rate_1P1C = true;
                    Description = Description + "Initial oil rate cannot be less than or equal abandonment oil rate (1P/1C)" + newline;
                }

                if (extendedInputDeck.Init_Oil_Gas_Rate_2P_2C <= extendedInputDeck.Aband_Oil_Gas_Rate_2P_2C)
                {
                    check_Rate_2P2C = true;
                    Description = Description + "Initial oil rate cannot be less than or equal abandonment oil rate (2P/2C)" + newline;
                }

                if (extendedInputDeck.Init_Oil_Gas_Rate_3P_3C <= extendedInputDeck.Aband_Oil_Gas_Rate_3P_3C)
                {
                    check_Rate_3P3C = true;
                    Description = Description + "Initial oil rate cannot be less than or equal abandonment oil rate (3P/3C)" + newline;
                }

                if (extendedInputDeck.Np >= extendedInputDeck.URo_1P_1C)
                {
                    check_DGOR_CGR_1P1C = true;
                    check_DBSW_WGR_1P1C = true;
                    Description = Description + "Cumulative oil in place cannot be greater than or equal to ulimate oil recovery (1P/1C)" + newline;
                }
                if (extendedInputDeck.Np >= extendedInputDeck.URo_2P_2C)
                {
                    check_DBSW_WGR_2P2C = true;
                    check_DGOR_CGR_2P2C = true;
                    Description = Description + "Cumulative oil in place cannot be greater than or equal to ulimate oil recovery (2P/2C)" + newline;
                }
                if (extendedInputDeck.Np >= extendedInputDeck.URo_3P_3C)
                {
                    check_DBSW_WGR_3P3C = true;
                    check_DGOR_CGR_3P3C = true;
                    Description = Description + "Cumulative oil in place cannot be greater than or equal to ulimate oil recovery (3P/3C)" + newline;
                }

                if (extendedInputDeck.Init_BSW_WGR >= extendedInputDeck.Aband_BSW_WGR_1P_1C)
                {
                    check_DBSW_WGR_1P1C = true;
                    Description = Description + "Initial BSW cannot be greater than or equal to abandonment BSW (1P/1C)" + newline;

                }
                if (extendedInputDeck.Init_BSW_WGR >= extendedInputDeck.Aband_BSW_WGR_2P_2C)
                {
                    check_DBSW_WGR_2P2C = true;
                    Description = Description + "Initial BSW cannot be greater than or equal to abandonment BSW (2P/2C)" + newline;
                }
                if (extendedInputDeck.Init_BSW_WGR >= extendedInputDeck.Aband_BSW_WGR_3P_3C)
                {
                    check_DBSW_WGR_3P3C = true;
                    Description = Description + "Initial BSW cannot be greater than or equal to abandonment BSW (3P/3C)" + newline;
                }

                if (extendedInputDeck.Init_GOR_CGR >= extendedInputDeck.Aband_GOR_CGR_1P_1C)
                {
                    check_DGOR_CGR_1P1C = true;
                    Description = Description + "Initial GOR cannot be greater than or equal to abandonment GOR (1P/1C)" + newline;
                }
                if (extendedInputDeck.Init_GOR_CGR >= extendedInputDeck.Aband_GOR_CGR_2P_2C)
                {
                    check_DGOR_CGR_2P2C = true;
                    Description = Description + "Initial GOR cannot be greater than or equal to abandonment GOR (2P/2C)" + newline;
                }
                if (extendedInputDeck.Init_GOR_CGR >= extendedInputDeck.Aband_GOR_CGR_3P_3C)
                {
                    check_DGOR_CGR_3P3C = true;
                    Description = Description + "Initial GOR cannot be greater than or equal to abandonment GOR (3P/3C)" + newline;
                }
            }

            if (extendedInputDeck.Hydrocarbon_Stream.ToLower() == "gas")
            {
                if (extendedInputDeck.Init_Oil_Gas_Rate_1P_1C <= 0)
                {
                    check_Rate_1P1C = true;
                    Description = Description + "Initial gas rate cannot be less than or equal zero (1P/1C)" + newline;
                }

                if (extendedInputDeck.Init_Oil_Gas_Rate_2P_2C <= 0)
                {
                    check_Rate_2P2C = true;
                    Description = Description + "Initial gas rate cannot be less than or equal zero (2P/2C)" + newline;
                }

                if (extendedInputDeck.Init_Oil_Gas_Rate_3P_3C <= 0)
                {
                    check_Rate_3P3C = true;
                    Description = Description + "Initial gas rate cannot be less than or equal zero (3P/3C)" + newline;
                }

                if (extendedInputDeck.Init_Oil_Gas_Rate_1P_1C <= extendedInputDeck.Aband_Oil_Gas_Rate_1P_1C)
                {
                    check_Rate_1P1C = true;
                    Description = Description + "Initial gas rate cannot be less than or equal abandonment gas rate (1P/1C)" + newline;
                }

                if (extendedInputDeck.Init_Oil_Gas_Rate_2P_2C <= extendedInputDeck.Aband_Oil_Gas_Rate_2P_2C)
                {
                    check_Rate_2P2C = true;
                    Description = Description + "Initial gas rate cannot be less than or equal abandonment gas rate (2P/2C)" + newline;
                }

                if (extendedInputDeck.Init_Oil_Gas_Rate_3P_3C <= extendedInputDeck.Aband_Oil_Gas_Rate_3P_3C)
                {
                    check_Rate_3P3C = true;
                    Description = Description + "Initial gas rate cannot be less than or equal abandonment gas rate (3P/3C)" + newline;
                }

                if (extendedInputDeck.Gp >= extendedInputDeck.URg_1P_1C)
                {
                    check_DGOR_CGR_1P1C = true;
                    check_DBSW_WGR_1P1C = true;
                    Description = Description + "Cumulative gas in place cannot be greater than or equal to ulimate gas recovery (1P/1C)" + newline;
                }
                if (extendedInputDeck.Gp >= extendedInputDeck.URg_2P_2C)
                {
                    check_DBSW_WGR_2P2C = true;
                    check_DGOR_CGR_2P2C = true;
                    Description = Description + "Cumulative gas in place cannot be greater than or equal to ulimate gas recovery (2P/2C)" + newline;
                }
                if (extendedInputDeck.Gp >= extendedInputDeck.URg_3P_3C)
                {
                    check_DBSW_WGR_3P3C = true;
                    check_DGOR_CGR_3P3C = true;
                    Description = Description + "Cumulative gas in place cannot be greater than or equal to ulimate gas recovery (3P/3C)" + newline;
                }


                if (extendedInputDeck.Init_BSW_WGR >= extendedInputDeck.Aband_BSW_WGR_1P_1C)
                {
                    check_DBSW_WGR_1P1C = true;
                    Description = Description + "Initial WGR cannot be greater than or equal to abandonment WGR (1P/1C)" + newline;
                }
                if (extendedInputDeck.Init_BSW_WGR >= extendedInputDeck.Aband_BSW_WGR_2P_2C)
                {
                    check_DBSW_WGR_2P2C = true;
                    Description = Description + "Initial WGR cannot be greater than or equal to abandonment WGR (2P/2C)" + newline;
                }
                if (extendedInputDeck.Init_BSW_WGR >= extendedInputDeck.Aband_BSW_WGR_3P_3C)
                {
                    check_DBSW_WGR_3P3C = true;
                    Description = Description + "Initial WGR cannot be greater than or equal to abandonment WGR (3P/3C)" + newline;
                }

                if (extendedInputDeck.Init_GOR_CGR <= extendedInputDeck.Aband_GOR_CGR_1P_1C)
                {
                    check_DGOR_CGR_1P1C = true;
                    Description = Description + "Initial CGR cannot be less than or equal to abandonment CGR (1P/1C)" + newline;
                }
                if (extendedInputDeck.Init_GOR_CGR <= extendedInputDeck.Aband_GOR_CGR_2P_2C)
                {
                    check_DGOR_CGR_2P2C = true;
                    Description = Description + "Initial CGR cannot be less than or equal to abandonment CGR (2P/2C)" + newline;
                }
                if (extendedInputDeck.Init_GOR_CGR <= extendedInputDeck.Aband_GOR_CGR_3P_3C)
                {
                    check_DGOR_CGR_3P3C = true;
                    Description = Description + "Initial CGR cannot be less than or equal to abandonment CGR (3P/3C)" + newline;
                }
            }

            extendedInputDeck.Description = Description;

            if (extendedInputDeck.Hydrocarbon_Stream.ToLower() == "oil")
            {
                if (check_DBSW_WGR_1P1C == false)
                {
                    extendedInputDeck.Rate_Of_Rate_BSW_WGR_1P1C = FractionalFlow.Get_Fractional_Rate_Of_Change_Exponential(
                      extendedInputDeck.Np, extendedInputDeck.URo_1P_1C, extendedInputDeck.Init_BSW_WGR,
                      extendedInputDeck.Aband_BSW_WGR_1P_1C);
                }
                if (check_DBSW_WGR_2P2C == false)
                {
                    extendedInputDeck.Rate_Of_Rate_BSW_WGR_2P2C = FractionalFlow.Get_Fractional_Rate_Of_Change_Exponential(
                      extendedInputDeck.Np, extendedInputDeck.URo_2P_2C, extendedInputDeck.Init_BSW_WGR,
                      extendedInputDeck.Aband_BSW_WGR_2P_2C);
                }
                if (check_DBSW_WGR_3P3C == false)
                {
                    extendedInputDeck.Rate_Of_Rate_BSW_WGR_3P3C = FractionalFlow.Get_Fractional_Rate_Of_Change_Exponential(
                      extendedInputDeck.Np, extendedInputDeck.URo_3P_3C, extendedInputDeck.Init_BSW_WGR,
                      extendedInputDeck.Aband_BSW_WGR_3P_3C);
                }

                if (check_DGOR_CGR_1P1C == false)
                {
                    extendedInputDeck.Rate_Of_Rate_GOR_CGR_1P1C = FractionalFlow.Get_Fractional_Rate_Of_Change_Exponential(
                      extendedInputDeck.Np, extendedInputDeck.URo_1P_1C, extendedInputDeck.Init_GOR_CGR,
                      extendedInputDeck.Aband_GOR_CGR_1P_1C);
                }
                if (check_DGOR_CGR_2P2C == false)
                {
                    extendedInputDeck.Rate_Of_Rate_GOR_CGR_2P2C = FractionalFlow.Get_Fractional_Rate_Of_Change_Exponential(
                      extendedInputDeck.Np, extendedInputDeck.URo_2P_2C, extendedInputDeck.Init_GOR_CGR,
                      extendedInputDeck.Aband_GOR_CGR_2P_2C);
                }
                if (check_DGOR_CGR_3P3C == false)
                {
                    extendedInputDeck.Rate_Of_Rate_GOR_CGR_3P3C = FractionalFlow.Get_Fractional_Rate_Of_Change_Exponential(
                      extendedInputDeck.Np, extendedInputDeck.URo_3P_3C, extendedInputDeck.Init_GOR_CGR,
                      extendedInputDeck.Aband_GOR_CGR_3P_3C);
                }

                if (check_Rate_1P1C == false)
                {
                    extendedInputDeck.Rate_of_Change_Rate_1P_1C = Decline_Curve_Analysis.Get_DeclineFactor_Exponential(
                       extendedInputDeck.Init_Oil_Gas_Rate_1P_1C, extendedInputDeck.Aband_Oil_Gas_Rate_1P_1C,
                       extendedInputDeck.Np, extendedInputDeck.URo_1P_1C);
                }
                if (check_Rate_2P2C == false)
                {
                    extendedInputDeck.Rate_of_Change_Rate_2P_2C = Decline_Curve_Analysis.Get_DeclineFactor_Exponential(
                       extendedInputDeck.Init_Oil_Gas_Rate_2P_2C, extendedInputDeck.Aband_Oil_Gas_Rate_2P_2C,
                       extendedInputDeck.Np, extendedInputDeck.URo_2P_2C);
                }
                if (check_Rate_3P3C == false)
                {
                    extendedInputDeck.Rate_of_Change_Rate_3P_3C = Decline_Curve_Analysis.Get_DeclineFactor_Exponential(
                       extendedInputDeck.Init_Oil_Gas_Rate_3P_3C, extendedInputDeck.Aband_Oil_Gas_Rate_3P_3C,
                       extendedInputDeck.Np, extendedInputDeck.URo_3P_3C);
                }
            }

            if (extendedInputDeck.Hydrocarbon_Stream.ToLower() == "gas")
            {
                if (check_DBSW_WGR_1P1C == false)
                {
                    extendedInputDeck.Rate_Of_Rate_BSW_WGR_1P1C = FractionalFlow.Get_Fractional_Rate_Of_Change_Exponential(
                      extendedInputDeck.Gp, extendedInputDeck.URg_1P_1C, extendedInputDeck.Init_BSW_WGR,
                      extendedInputDeck.Aband_BSW_WGR_1P_1C);
                }
                if (check_DBSW_WGR_2P2C == false)
                {
                    extendedInputDeck.Rate_Of_Rate_BSW_WGR_2P2C = FractionalFlow.Get_Fractional_Rate_Of_Change_Exponential(
                      extendedInputDeck.Gp, extendedInputDeck.URg_2P_2C, extendedInputDeck.Init_BSW_WGR,
                      extendedInputDeck.Aband_BSW_WGR_2P_2C);
                }
                if (check_DBSW_WGR_3P3C == false)
                {
                    extendedInputDeck.Rate_Of_Rate_BSW_WGR_3P3C = FractionalFlow.Get_Fractional_Rate_Of_Change_Exponential(
                      extendedInputDeck.Gp, extendedInputDeck.URg_3P_3C, extendedInputDeck.Init_BSW_WGR,
                      extendedInputDeck.Aband_BSW_WGR_3P_3C);
                }

                if (check_DGOR_CGR_1P1C == false)
                {
                    extendedInputDeck.Rate_Of_Rate_GOR_CGR_1P1C = FractionalFlow.Get_Fractional_Rate_Of_Change_Exponential(
                      extendedInputDeck.Gp, extendedInputDeck.URo_1P_1C, extendedInputDeck.Init_GOR_CGR,
                      extendedInputDeck.Aband_GOR_CGR_1P_1C);
                }
                if (check_DGOR_CGR_2P2C == false)
                {
                    extendedInputDeck.Rate_Of_Rate_GOR_CGR_2P2C = FractionalFlow.Get_Fractional_Rate_Of_Change_Exponential(
                      extendedInputDeck.Gp, extendedInputDeck.URg_2P_2C, extendedInputDeck.Init_GOR_CGR,
                      extendedInputDeck.Aband_GOR_CGR_2P_2C);
                }
                if (check_DGOR_CGR_3P3C == false)
                {
                    extendedInputDeck.Rate_Of_Rate_GOR_CGR_3P3C = FractionalFlow.Get_Fractional_Rate_Of_Change_Exponential(
                      extendedInputDeck.Gp, extendedInputDeck.URg_3P_3C, extendedInputDeck.Init_GOR_CGR,
                      extendedInputDeck.Aband_GOR_CGR_3P_3C);
                }

                if (check_Rate_1P1C == false)
                {
                    extendedInputDeck.Rate_of_Change_Rate_1P_1C = Decline_Curve_Analysis.Get_DeclineFactor_Exponential(
                       extendedInputDeck.Init_Oil_Gas_Rate_1P_1C, extendedInputDeck.Aband_Oil_Gas_Rate_1P_1C,
                       extendedInputDeck.Gp, extendedInputDeck.URg_1P_1C);
                }
                if (check_Rate_2P2C == false)
                {
                    extendedInputDeck.Rate_of_Change_Rate_2P_2C = Decline_Curve_Analysis.Get_DeclineFactor_Exponential(
                       extendedInputDeck.Init_Oil_Gas_Rate_2P_2C, extendedInputDeck.Aband_Oil_Gas_Rate_2P_2C,
                       extendedInputDeck.Gp, extendedInputDeck.URg_2P_2C);
                }
                if (check_Rate_3P3C == false)
                {
                    extendedInputDeck.Rate_of_Change_Rate_3P_3C = Decline_Curve_Analysis.Get_DeclineFactor_Exponential(
                       extendedInputDeck.Init_Oil_Gas_Rate_3P_3C, extendedInputDeck.Aband_Oil_Gas_Rate_3P_3C,
                       extendedInputDeck.Gp, extendedInputDeck.URg_3P_3C);
                }
            }



        }

        public static List<ExtendedFacilityDeck> GetCrossCheckedFacilityDecks(Dictionary<string, string> MappedDictionary,
                                                                   IHostingEnvironment hostingEnvironment,
                                                                   string SheetName, string FileName)
        {

            List<CustomExcelWorkSheet> customeworksheets = new List<CustomExcelWorkSheet>();

            string sWebRootFolder = hostingEnvironment.WebRootPath;

            string directoryName = "Facility";

            string directorypath = Path.Combine(sWebRootFolder, directoryName);

            var filepath = Path.Combine(directorypath, Path.GetFileName(FileName));

            OPCPackage pkg = OPCPackage.Open(filepath);

            XSSFWorkbook wb = null;


            try
            {
                wb = new XSSFWorkbook(pkg);
            }
            catch (Exception ex)
            {


            }


            int NumberOfWorkSheets = wb.NumberOfSheets;
            List<ExtendedFacilityDeck> extendedFacilityDecks = new List<ExtendedFacilityDeck>();
            var props = typeof(FacilityDeck).GetProperties();

            for (int i = 0; i < NumberOfWorkSheets; i++)
            {
                ISheet worksheet = wb.GetSheetAt(i);

                if (SheetName == worksheet.SheetName)
                {
                    IRow firstrow = worksheet.GetRow(0);

                    for (int rowIndex = 1; rowIndex <= worksheet.LastRowNum; rowIndex++)
                    {

                        IRow row = worksheet.GetRow(rowIndex);
                        ExtendedFacilityDeck extendedFacilityDeck = new ExtendedFacilityDeck();
                        int j = -1;
                        foreach (ICell cell in row.Cells)
                        {
                            try
                            {
                                j++;
                                string cellHeader = firstrow.Cells[j].StringCellValue;
                                if (MappedDictionary.ContainsKey(cellHeader))
                                {
                                    try
                                    {


                                        switch (MappedDictionary[cellHeader])
                                        {
                                            case "Primary_Facility":
                                                extendedFacilityDeck.Primary_Facility = cell.StringCellValue;
                                                break;
                                            case "Asset_Team":
                                                extendedFacilityDeck.Secondary_Facility = cell.StringCellValue;
                                                break;
                                            case "Field":
                                                extendedFacilityDeck.Liquid_Capacity = cell.NumericCellValue;
                                                break;
                                            case "Reservoir":
                                                extendedFacilityDeck.Gas_Capacity = cell.NumericCellValue;
                                                break;
                                            case "Drainage_Point":
                                                extendedFacilityDeck.Scheduled_Deferment = cell.NumericCellValue;
                                                break;
                                            case "Production_String":
                                                extendedFacilityDeck.Unscheduled_Deferment = cell.NumericCellValue;
                                                break;
                                            case "Module":
                                                extendedFacilityDeck.Thirdparty_Deferment = cell.NumericCellValue;
                                                break;
                                            case "PEEP_Project":
                                                extendedFacilityDeck.Crudeoil_Lossess = cell.NumericCellValue;
                                                break;

                                        }

                                    }
                                    catch (Exception ex)
                                    {


                                    }
                                }

                            }
                            catch (Exception ex)
                            {

                            }

                        }

                        extendedFacilityDecks.Add(extendedFacilityDeck);
                    }
                }

            }




            return extendedFacilityDecks;

        }

    }

    [Serializable]
    public class ExtendedInputDeck : InputDeck
    {
        public string Description { get; set; }

        public double Rate_Of_Rate_GOR_CGR_1P1C { get; set; }
        public double Rate_Of_Rate_GOR_CGR_2P2C { get; set; }
        public double Rate_Of_Rate_GOR_CGR_3P3C { get; set; }
        public double Rate_Of_Rate_BSW_WGR_1P1C { get; set; }
        public double Rate_Of_Rate_BSW_WGR_2P2C { get; set; }
        public double Rate_Of_Rate_BSW_WGR_3P3C { get; set; }

        public double Rate_of_Change_Rate_1P_1C { get; set; }
        public double Rate_of_Change_Rate_2P_2C { get; set; }
        public double Rate_of_Change_Rate_3P_3C { get; set; }

        public DateTime On_Stream_Date_1P_1C { get; set; }
        public DateTime On_Stream_Date_2P_2C { get; set; }
        public DateTime On_Stream_Date_3P_3C { get; set; }
        public override string ToString()
        {
            return Module;
        }
    }

    public class ExtendedFacilityDeck : FacilityDeck
    {
        public string Description { get; set; }



        public override string ToString()
        {
            return Primary_Facility;
        }
    }

    public class MappedData
    {
        public MappedData()
        {
            ColumnHeadersCopy = new List<string>();
            MappedDictionary = new Dictionary<string, string>();
        }

        public int StartRow { get; set; }
        public int EndRow { get; set; }

        public List<string> ColumnHeadersCopy { get; set; }
        public Dictionary<string, string> MappedDictionary { get; set; }

        public string SheetName { get; set; }
        public string FileName { get; set; }
    }

    public class ReadonlyNames
    {

        public static string ExtendedInputDecks { get; set; } = "ExtendedInputDecks";
        public static string ExtendedFacilityDecks { get; set; } = "ExtendedFacilityDecks";
    }


}
