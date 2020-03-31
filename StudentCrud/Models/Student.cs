using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentCrud.Models {

    public class Student {
        public int StudentId { get; set; }

        public string Studentname { get; set; }

        public int Age { get; set; }

        public Student() {
        }

        public Student(int studentId, string studentname, int age) {
            StudentId = studentId;
            Studentname = studentname;
            Age = age;
        }
    }
}