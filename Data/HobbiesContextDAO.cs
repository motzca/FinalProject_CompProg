using System.Collections.Generic;
using FinalProject_CompProg.Interfaces;
using FinalProject_CompProg.Models;
using System.Linq;
using System;

namespace FinalProject_CompProg.Data
{
    public class HobbiesContextDAO : IHobbiesContextDAO
    {
        private FinalProjectContext _context;
        public HobbiesContextDAO(FinalProjectContext context)
        {
            _context = context;
        }

        public List<Hobbies> GetAllHobbies()
        {
            return _context.Hobbies.ToList(); //returns the list of hobbies
        }

        public Hobbies GetById(int id)
        {
            return _context.Hobbies.Where(x => x.id.Equals(id)).FirstOrDefault();  //Returns the hobby that matches the id using Linq
        }
        public int? RemoveHobbiesById(int id)
        {
            Hobbies hobbies = this.GetById(id); //attempts to get the hobby using the GetByID method
            if(hobbies != null)  //If the above method returned a hobby
            {
                try
                {
                    _context.Hobbies.Remove(hobbies);  //remove the found hobby
                    _context.SaveChanges();
                    return 1;
                }
                catch(Exception)
                {
                    return 0;
                }
            }
            return null;
        }

        public int? UpdateHobbies(Hobbies hobbies)
        {
            var hobbiesToUpdate = this.GetById(hobbies.id);  //attempts to get the hobby using the GetByID method
            if(hobbiesToUpdate == null) //if the hobby was not found
            {
                return null;
            }
            hobbiesToUpdate.name = hobbies.name; //sets the hobby that was found to match the hobby passed into the method
                hobbiesToUpdate.activityType = hobbies.activityType;
                hobbiesToUpdate.mainInterest = hobbies.mainInterest;
                hobbiesToUpdate.avgTimeSpent = hobbies.avgTimeSpent;
            try
            {
                _context.Hobbies.Update(hobbiesToUpdate); //updates the hobby
                _context.SaveChanges();
                return 1;
            } 
            catch(Exception)
            {
                return 0;
            }   
        }

        public int? Add(Hobbies hobbies)
        {
            //first find out if a hobby exists with that id already
            var hobbiesWithSameID = _context.Hobbies.
            Where(x => x.activityType.Equals(hobbies.activityType) && x.name.Equals(hobbies.name))
            .FirstOrDefault();

            if(hobbiesWithSameID != null) //if there is a hobby with that id already
            {
                return null;
            }

            try
            {
                _context.Hobbies.Add(hobbies); //add the hobby
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
