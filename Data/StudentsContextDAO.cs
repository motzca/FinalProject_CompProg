using System.Collections.Generic;
using FinalProject_CompProg.Interfaces;
using FinalProject_CompProg.Models;

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
    }
}