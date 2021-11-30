using System.Collections.Generic;
using FinalProject_CompProg.Models;

namespace FinalProject_CompProg.Interfaces
{
    public interface IHobbiesContextDAO
    {
        List<Hobbies> GetAllHobbies();
        Hobbies GetById(int id);
        int? RemoveHobbiesById(int id);
        int? UpdateHobbies (Hobbies hobbies);
        int? Add(Hobbies hobbies);
    }
}