using BL.Casting;
using DAL;
//using DocumentFormat.OpenXml.Packaging;
//using DocumentFormat.OpenXml.Spreadsheet;
using DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using OfficeOpenXml;

namespace BL
{
    public class StudentLogic
    {
        public static List<StudentDTO> GetStudents()
        {
            using (Entities e = new Entities())
            {
                var students = e.students.ToList();
                return StudentCasting.StudentsToDTO(students);
            }
        }
        public static StudentDTO GetStudentByUserId(int userId)
        {
            using (Entities e = new Entities())
            {
                try
                {
                    var student = e.students.FirstOrDefault(s => s.userId == userId);
                    if (student != null)
                    {
                        return StudentCasting.StudentToDTO(student);
                    }
                    throw new Exception("UserId is not exists");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static void AddStudents(HttpPostedFile filePath, int classId)
        {
            using (var excel = new ExcelPackage(filePath.InputStream))
            {
                DataTable tbl = new DataTable();
                ExcelWorksheet ws = excel.Workbook.Worksheets[0];
                var hasHeader = true;  // adjust accordingly
                                       // add DataColumns to DataTable
                foreach (ExcelRangeBase firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
                    tbl.Columns.Add(hasHeader ? firstRowCell.Text
                        : string.Format("Column {0}", firstRowCell.Start.Column));

                // add DataRows to DataTable
                int startRow = hasHeader ? 2 : 1;
                for (int rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
                {
                    ExcelRange wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
                    DataRow row = tbl.NewRow();
                    foreach (ExcelRangeBase cell in wsRow)
                        row[cell.Start.Column - 1] = cell.Text;
                    tbl.Rows.Add(row);
                }
                var msg = string.Format("DataTable successfully created from excel-file. Colum-count:{0} Row-count:{1}",
                                        tbl.Columns.Count, tbl.Rows.Count);
                //UploadStatusLabel.Text = msg;
            }
            using (Entities e = new Entities())
            {
                //using (SpreadsheetDocument spreadSheetDocument = SpreadsheetDocument.Open(filePath, true))
                //{

                //    WorkbookPart workbookPart = spreadSheetDocument.WorkbookPart;
                //    IEnumerable<Sheet> sheets = spreadSheetDocument.WorkbookPart.Workbook.GetFirstChild<Sheets>().Elements<Sheet>();
                //    string relationshipId = sheets.First().Id.Value;
                //    WorksheetPart worksheetPart = (WorksheetPart)spreadSheetDocument.WorkbookPart.GetPartById(relationshipId);
                //    Worksheet workSheet = worksheetPart.Worksheet;
                //    SheetData sheetData = workSheet.GetFirstChild<SheetData>();
                //    IEnumerable<Row> rows = sheetData.Descendants<Row>();
                //    var ro = rows.ElementAt(0).Descendants<Cell>();
                //    //List<int> order = new List<int>();

                //    //for (int i = 0; i < 5; i++)
                //    //{

                //    //    var cl = ro.FirstOrDefault(r => r.ToString() == paramList[i].ToString()).ToString();
                //    //    order.Add(paramList.IndexOf(cl));
                //    //}

                //    foreach (Row row in rows) //this will also include your header row...
                //    {
                //        if (row == rows.ElementAt(0))
                //            continue;
                //        student student = new student()
                //        {
                //            user = new user()
                //        };
                //        //int r = row.Descendants<Cell>().Count();
                //        student.user.user_id_number = (row.Descendants<Cell>().ElementAt(1).InnerText);
                //        student.user.user_name = row.Descendants<Cell>().ElementAt(2).InnerText;
                //        student.user.user_mail = row.Descendants<Cell>().ElementAt(3).InnerText;
                //        student.user.user_password = row.Descendants<Cell>().ElementAt(4).InnerText;
                //        student.user.status = 2;
                //        //if (e.users.FirstOrDefault(u => u.user_name == student.user.user_name || u.user_id_number == student.user.user_id_number) != null)
                //        //{
                //        //    throw new Exception("user name is unique");
                //        //}
                //        e.users.Add(student.user);
                //        var us = e.users.FirstOrDefault(u => u.user_name == student.user.user_name && u.user_password == student.user.user_password);
                //        student.userId = us.user_id;
                //        student.class_id = classId;
                //        student.extra_time = bool.Parse(row.Descendants<Cell>().ElementAt(5).InnerText);
                //        e.students.Add(student);
                //        e.SaveChanges();
                //    }

            }
        }
        //public void AddStudent(StudentDTO student)
        //{
        //    student s = StudentCasting.StudentToDAL(student);
        //    e.students.Add(s);
        //    e.SaveChanges();
        //}
        public static void DeleteStudent(int id)
        {
            using (Entities e = new Entities())
            {
                var student = e.students.FirstOrDefault(s => s.userId == id);
                if (student != null)
                {
                    e.students.Remove(student);
                    e.users.Remove(student.user);
                    e.SaveChanges();
                }
            }
        }
        public static StudentDTO UpdateStudent(StudentDTO s)
        {
            using (Entities e = new Entities())
            {
                e.Entry(UserCasting.UserToDAL(s.user)).State = EntityState.Modified;
                e.Entry(StudentCasting.StudentToDAL(s)).State = EntityState.Modified;
                e.SaveChanges();
                var st = e.students.FirstOrDefault(ss => ss.userId == s.userId);
                return StudentCasting.StudentToDTO(st);
            }
        }
    }
}
