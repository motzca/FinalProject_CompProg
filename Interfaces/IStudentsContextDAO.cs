using System.Collections.Generic;
using FinalProject_CompProg.Models;

namespace FinalProject_CompProg.Interfaces
{
    public interface IStudentsContextDAO
    {
        List<Student> GetAllStudents();

        Student GetById(int id);

        int? RemoveStudentById(int id);

        int? UpdateStudent (Student student);
    }
}