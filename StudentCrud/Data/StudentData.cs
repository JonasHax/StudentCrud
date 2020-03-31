using System;
using System.Collections.Generic;
using System.Linq;
using StudentCrud.Models;

namespace StudentCrud.Data {

    public class StudentData {
        private static IEnumerable<Student> studentList;

        public static IEnumerable<Student> StudentList {
            get {
                IEnumerable<Student> foundStudents = studentList;
                if (studentList == null || studentList.Count() < 1) {
                    SetStudentData();
                }
                return studentList;
            }
        }

        public static Student GetStudentById(int targetId) {
            Student foundStudent = new Student(-1, "NoName", -1);

            if (studentList != null) {
                foreach (Student stud in studentList) {
                    if (stud.StudentId == targetId) {
                        foundStudent = stud;
                        break;
                    }
                }
            }

            return foundStudent;
        }

        public static void InsertStudent(Student newStudent) {
            if (studentList != null) {
                Student insertStudent = new Student(newStudent.StudentId, newStudent.Studentname, newStudent.Age);
                ((List<Student>)studentList).Add(insertStudent);
            }
        }

        public static void UpdateStudent(Student redStudent) {
            if (studentList != null) {
                foreach (Student stud in studentList) {
                    if (stud.StudentId == redStudent.StudentId) {
                        stud.Studentname = redStudent.Studentname;
                        stud.Age = redStudent.Age;
                        break;
                    }
                }
            }
        }

        private static void SetStudentData() {
            studentList = new List<Student>{
                            new Student() { StudentId = 1, Studentname = "John", Age = 18 } ,
                            new Student() { StudentId = 2, Studentname = "Steve",  Age = 21 } ,
                            new Student() { StudentId = 3, Studentname = "Bill",  Age = 25 } ,
                            new Student() { StudentId = 4, Studentname = "Ram" , Age = 20 } ,
                            new Student() { StudentId = 5, Studentname = "Ron" , Age = 31 } ,
                            new Student() { StudentId = 4, Studentname = "Chris" , Age = 17 } ,
                            new Student() { StudentId = 4, Studentname = "Rob" , Age = 19 }
                        };
        }

        public static void DeleteStudent(int id) {
            //StudentList.Remove(studentToDelete);
            //studentList.
            //List<Student> studentList = StudentList;
            //studentList.Remove(studentToDelete);
            StudentList.ToList().Remove(GetStudentById(id));
        }
    }
}