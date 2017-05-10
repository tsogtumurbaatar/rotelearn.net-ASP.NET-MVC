using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rotelearn.Models
{
    public class Quiz
    {
        public string question { get; set; }
        public int question_id { get; set; }
        public string answer1 { get; set; }
        public int answer1_id { get; set; }
        public string answer2 { get; set; }
        public int answer2_id { get; set; }
        public string answer3 { get; set; }
        public int answer3_id { get; set; }
        public string answer4 { get; set; }
        public int answer4_id { get; set; }

    }
}