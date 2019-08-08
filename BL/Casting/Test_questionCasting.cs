using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Casting
{
    public class Test_questionCasting
    {
        public static test_question Test_questionToDAL(Test_questionDTO tq)
        {
            return new test_question()
            {
                //question = e.questions.FirstOrDefault(q => q.question_id == tq.question_id),
                question_id = tq.question_id,
                question_test_id = tq.question_test_id,
                //student_answer = e.student_answer.Where(sa => sa.question_test_id == tq.question_test_id).ToList(),
                //test = e.tests.FirstOrDefault(t => t.test_id == tq.test_id),
                test_id = tq.test_id
            };
        }
        public static Test_questionDTO Test_questionToDTO(test_question tq)
        {
            return new Test_questionDTO()
            {
                question_id = tq.question_id,
                question_test_id = tq.question_test_id,
                test_id = tq.test_id
            };
        }
        public static List<test_question> Test_questionsToDAL(List<Test_questionDTO> questionsDTO)
        {
            List<test_question> questions = new List<test_question>();
            questionsDTO.ToList().ForEach(q => questions.Add(Test_questionToDAL(q)));
            return questions;
        }
        public static List<Test_questionDTO> Test_questionsToDTO(List<test_question> questions)
        {
            List<Test_questionDTO> questionsDTO = new List<Test_questionDTO>();
            questions.ToList().ForEach(t => questionsDTO.Add(Test_questionToDTO(t)));
            return questionsDTO;
        }
    }
}
