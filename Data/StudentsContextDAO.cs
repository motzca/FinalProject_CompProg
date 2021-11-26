using System.Collections.Generic;
using FinalProject_CompProg.Interfaces;
using FinalProject_CompProg.Models;
using System.Linq;
using System;

namespace FinalProject_CompProg.Data
{
    public class StudentsContextDAO : IStudentsContextDAO
    {
        private StudentsContext _context;
        public StudentsContextDAO(StudentsContext context)
        {
            _context = context;
        }

        public List<Student> GetAllStudents()
        {
            return _context.Student.ToList();
        }

        public Student GetById(int id)
        {
            return _context.Student.Where(x => x.id.Equals(id)).FirstOrDefault();
        }
        public int? RemoveStudentById(int id)
        {
            var student = this.GetById(id);
            if(student == null) return null;
            try
            {
                _context.Student.Remove(student);
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
            var studentToUpdate = this.GetById(student.id);
            if(studentToUpdate == null) return null;

            studentToUpdate.fullName = student.fullName;
            studentToUpdate.birthDate = student.birthDate;
            studentToUpdate.collegeProgram = student.collegeProgram;
            studentToUpdate.collegeYear = student.collegeYear;
            try
            {
                _context.Student.Update(studentToUpdate);
                _context.SaveChanges();
                return 1;
            }
            catch(Exception)
            {
                return 0;
            }
            
        }
    }
}