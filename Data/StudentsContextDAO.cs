using System.Collections.Generic;
using FinalProject_CompProg.Interfaces;
using FinalProject_CompProg.Models;
using System.Linq;
using System;

namespace FinalProject_CompProg.Data
{
    public class StudentsContextDAO : IStudentsContextDAO
    {
        private FinalProjectContext _context;
        public StudentsContextDAO(FinalProjectContext context)
        {
            _context = context;
        }

        public List<Student> GetAllStudents()
        {
            return _context.Students.ToList(); //Returns a list of all the students
        }

        public Student GetById(int id)
        {
            return _context.Students.Where(x => x.id.Equals(id)).FirstOrDefault(); //Returns the student that matches the id passed in to the method
        }
        public int? RemoveStudentById(int id)
        {
            var student = this.GetById(id); //Attempts to get a student with the id passed in
            if(student == null) return null; //If the student doesnt exist, return null
            try
            {
                _context.Students.Remove(student); //Attempts to remove that student
                _context.SaveChanges();
                return 1;
            }
            catch(Exception)
            {
                return 0;
            }
            
        }
        
        public int? UpdateStudent(Student student)
        {
            var studentToUpdate = this.GetById(student.id); //Attempts to get a student with the id passed in
            if(studentToUpdate == null) return null; //If the student doesnt exist, return null

            studentToUpdate.fullName = student.fullName;  //Sets the values of the found student to match the input student 
            studentToUpdate.birthDate = student.birthDate;
            studentToUpdate.collegeProgram = student.collegeProgram;
            studentToUpdate.collegeYear = student.collegeYear;
            try
            {
                _context.Students.Update(studentToUpdate); //Attempts to update the student
                _context.SaveChanges();
                return 1;
            }
            catch(Exception)
            {
                return 0;
            }  
        }
        public int? Add(Student student)
        {
            //First try to find if a student with the same id exists already
            var studentInfo = _context.Students
            .Where(x => x.fullName.Equals(student.fullName) && x.birthDate.Equals(student.birthDate)).FirstOrDefault();
            
        if (studentInfo != null) //If there is already a student
        {
            return null;
        }

            try
            {
                _context.Students.Add(student); //Attempts to add the student
                _context.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                    return 0;
            }
            
        }
    }
}