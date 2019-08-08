using BL.Casting;
using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class TestLogic
    {
        public static List<TestDTO> GetTests()
        {
            using (Entities e = new Entities())
            {
                return TestCasting.TestsToDTO(e.tests.ToList());
            }
        }
        public static TestDTO GetTestById(int id)
        {
            using (Entities e = new Entities())
            {
                try
                {
                    var test = e.tests.FirstOrDefault(t => t.test_id == id);
                    if (test != null)
                    {
                        return TestCasting.TestToDTO(test);
                    }
                    throw new Exception("test is not exists");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public static List<TestDTO> GetTestsForTeacher(int teacherId)
        {
            using (Entities e = new Entities())
            {
                try
                {
                    //var classes = e.classes.Where(c => c.teacher_id == teacherId);
                    //var tests = e.tests.Where(t => t.classes.FirstOrDefault(c=>c.class_id==classes.FirstOrDefault(cl => cl.class_id == )) == .class_id).ToList();
                    //if (tests != null)
                    //{
                    //    return TestCasting.TestsToDTO(tests);
                    //}
                    throw new Exception("no tests");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public static List<TestDTO> GetTestsForCategory(int categoryId)
        {
            using (Entities e = new Entities())
            {
                try
                {
                    var subCategory = e.sub_category.Where(s => s.category_id == categoryId).ToList();
                    var tests = e.tests.Where(t => t.sub_category.FirstOrDefault(s => s.category_id == categoryId).category_id == categoryId).ToList();
                    if (tests != null)
                    {
                        return TestCasting.TestsToDTO(tests);
                    }
                    throw new Exception("no tests");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public static TestDTO AddTest(TestDTO test)
        {
            using (Entities e = new Entities())
            {
                try
                {
                    var cls = e.classes.FirstOrDefault(c => c.class_id == test.class_id);
                    if (cls == null)
                    {
                        throw new Exception("class id is not exists");
                    }
                    var t = e.tests.Add(TestCasting.TestToDAL(test));
                    e.SaveChanges();
                    return TestCasting.TestToDTO(t);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public static void UpdateTest(TestDTO newTest)
        {
            using (Entities e = new Entities())
            {
            }
            //todo
        }
        public static void DeleteTest(int TestId)
        {
            using (Entities e = new Entities())
            {
                var test = e.tests.FirstOrDefault(t => t.test_id == TestId);
                if (test != null)
                {
                    e.tests.Remove(test);
                    e.SaveChanges();
                }
            }
        }
    }
}
