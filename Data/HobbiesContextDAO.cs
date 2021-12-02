using System.Collections.Generic;
using FinalProject_CompProg.Interfaces;
using FinalProject_CompProg.Models;
using System.Linq;
using System;

namespace FinalProject_CompProg.Data
{
    public class HobbiesContextDAO : IHobbiesContextDAO
    {
        private HobbiesContext _context;
        public HobbiesContextDAO(HobbiesContext context)
        {
            _context = context;
        }

        public List<Hobbies> GetAllHobbies()
        {
            return _context.Hobbies.ToList();
        }

        public Hobbies GetById(int id)
        {
            return _context.Hobbies.Where(x => x.id.Equals(id)).FirstOrDefault();
        }
        public int? RemoveHobbiesById(int id)
        {
            Hobbies hobbies = this.GetById(id);
            if(hobbies != null)
            {
                try
                {
                    _context.Hobbies.Remove(hobbies);
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
            Hobbies hobbiesToUpdate = this.GetById(hobbies.id);
            if(hobbiesToUpdate == null) 
            {
                return null;
            }

            try
            {
                hobbiesToUpdate.name = hobbies.name;
                hobbiesToUpdate.activityType = hobbies.activityType;
                hobbiesToUpdate.mainInterest = hobbies.mainInterest;
                hobbiesToUpdate.avgTimeSpent = hobbies.avgTimeSpent;

                _context.Hobbies.Update(hobbiesToUpdate);
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
            Hobbies hobbiesWithSameID = _context.Hobbies.
            Where(x => x.activityType.Equals(hobbies.activityType) && x.name.Equals(hobbies.name))
            .FirstOrDefault();

            if(hobbiesWithSameID != null)
            {
                return null;
            }

            try
            {
                _context.Hobbies.Add(hobbies);
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
