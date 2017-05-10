using rotelearn.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace rotelearn.Controllers
{
    public class QuizController : Controller
    {
        // GET: Quiz
        private englishDBEntities db = new englishDBEntities();

        public ActionResult Index(String jsval1, String jsval2, String quiztype, String quiznumbers)
        {
            int jsval1_value, jsval2_value, quiz_count_value, quiz_type_value;

            if (jsval1 != "")
                jsval1_value = Convert.ToInt32(jsval1);
            else
                jsval1_value = 0;

            if (jsval2 != "")
                jsval2_value = Convert.ToInt32(jsval2);
            else
                jsval2_value = 30;

            if(jsval1_value == 0) jsval1_value = 1;

            quiz_count_value = Convert.ToInt32(quiznumbers);
            quiz_type_value = Convert.ToInt32(quiztype);


            if ((jsval2_value - jsval1_value) < quiz_count_value)
                quiz_count_value = 10;

            var verbs = from verb in db.verbs
                        where verb.id > jsval1_value && verb.id <= jsval2_value
                        select verb;

            int verbs_count = jsval2_value - jsval1_value;

         
           

            Random r = new Random();
            ArrayList quizLists = new ArrayList();

            for (int i=0; i<quiz_count_value; i++)
            {
                int num, num1, num2, num3, num4;
                num = r.Next(jsval1_value, jsval2_value);
                int luckyone = r.Next(1, 5);

                if (luckyone == 1)
                    num1 = num;
                else
                    num1 = r.Next(jsval1_value, jsval2_value);


                if (luckyone == 2)
                    num2 = num;
                else num2 = r.Next(jsval1_value, jsval2_value);

                if(num1 == num2)
                    num2 = r.Next(jsval1_value, jsval2_value);

                if (luckyone == 3)
                    num3 = num;
                else
                    num3 = r.Next(jsval1_value, jsval2_value);

                if ((num1 == num3) || (num2 == num3))
                    num3 = r.Next(jsval1_value, jsval2_value);

                if (luckyone == 4)
                    num4 = num;
                else
                    num4 = r.Next(jsval1_value, jsval2_value);

                if ((num1 == num4) || (num2 == num4) || (num3 == num4))
                    num4 = r.Next(jsval1_value, jsval2_value);


                Quiz q1 = new Quiz();
                q1.question = (from verb in verbs
                               where verb.id == num
                               select  verb.verb1).FirstOrDefault();
                q1.question_id =num;
                q1.answer1_id = num1;
                q1.answer2_id = num2;
                q1.answer3_id = num3;
                q1.answer4_id = num4;

                string tmp123 = num + "," + num1 + "," + num2 + "," + num3 + "," + num4;
                ViewBag.tmp = tmp123;

                q1.answer1 = (from verb in verbs
                               where verb.id == num1
                               select verb.verb_desc).FirstOrDefault();
                q1.answer2 = (from verb in verbs
                               where verb.id == num2
                               select verb.verb_desc).FirstOrDefault();
                q1.answer3 = (from verb in verbs
                               where verb.id == num3
                               select verb.verb_desc).FirstOrDefault();
                q1.answer4 = (from verb in verbs
                               where verb.id == num4
                               select verb.verb_desc).FirstOrDefault();
                quizLists.Add(q1);

            }

          
            ViewBag.quiz_count = quiz_count_value;
            ViewBag.verbs_count = verbs_count;
            ViewBag.quiz_type = quiz_type_value;
            ViewBag.quizs = quizLists;

            return View();
        }

        public ActionResult Result()
        {
            int quiz_count = Convert.ToInt32(Request["quiz_count"]);

            ViewBag.answer = "";
            String passvalue = "";

            var verbs = from verb in db.verbs
                    select verb;

            for (int i=0; i< quiz_count; i++ )
            {
                string tmp_answer = "";
                tmp_answer = Request["radio_" + i];
                if (tmp_answer == "")
                    tmp_answer = "0";


                int question_id = Convert.ToInt32(Request["question_id_" + i]);
                int answer_id = Convert.ToInt32(tmp_answer);
                if(question_id == answer_id)
                {
                    passvalue = passvalue + (i + 1) + ". correct <i class='glyphicon glyphicon-ok text-primary'></i> </br>";
                }
                else
                {
                   passvalue = passvalue +(i + 1) + ". not correct <i class='glyphicon glyphicon-remove text-danger'></i></br>";

                    String verb_desc = (from verb in verbs
                                        where verb.id == question_id
                                        select verb.verb_desc).FirstOrDefault();

                    passvalue = passvalue + "&nbsp;&nbsp;&nbsp;("+ Request["question_" + i] + ") => " + verb_desc + "</br>";
                }
                
            }

            ViewBag.quiz_count = Request["quiz_count"];
            ViewBag.verbs_count = Request["verbs_count"];
            ViewBag.quiz_type = Convert.ToInt32(Request["quiz_type"]);
            ViewBag.answer = passvalue;

            return View();
        }
    }
}