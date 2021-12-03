using System.Collections.Generic;
using FinalProject_CompProg.Interfaces;
using FinalProject_CompProg.Models;
using System.Linq;
using System;

namespace FinalProject_CompProg.Data
{
    public class RestaurantsContextDAO : IRestaurantsContextDAO
    {
        private FinalProjectContext _context;
        public RestaurantsContextDAO(FinalProjectContext context)
        {
            _context = context;
        }

        public List<Restaurant> GetAllRestaurants()
        {
            return _context.Restaurants.ToList(); //Returns list of all the restaurants
        }

        public Restaurant GetById(int id)
        {
            return _context.Restaurants.Where(x => x.id.Equals(id)).FirstOrDefault(); //returns restaurant that matches the it passed in
        }
        public int? RemoveRestaurantById(int id)
        {
            Restaurant restaurant = this.GetById(id); //Attempts to find a restaurant that has the id passed in
            if(restaurant != null) //If the restaurant with that ID exists
            {
                try
                {
                    _context.Restaurants.Remove(restaurant); //Attempt to remove that restaurant
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

        public int? UpdateRestaurant (Restaurant restaurant)
        {
            Restaurant restaurantToUpdate = this.GetById(restaurant.id); //Attempt to find restaraunt that matches the ID of the restaurant passed in
            if(restaurantToUpdate == null)  //if the restaurant passed in doesnt have a match
            {
                return null;
            }
            restaurantToUpdate.name = restaurant.name;  //sets the values of the restaurant found to match the restaurant passed in
            restaurantToUpdate.foodType = restaurant.foodType;
            restaurantToUpdate.founder = restaurant.founder;
            restaurantToUpdate.foundingYear = restaurant.foundingYear;

            try
            {
                _context.Restaurants.Update(restaurantToUpdate); //Attempts to update the restaurant
                _context.SaveChanges();
                return 1;
            } 
            catch(Exception)
            {
                return 0;
            }   
        }

        public int? Add(Restaurant restaurant)
        {
            //Tries to find a Restaurant that has the same ID
            Restaurant restaurantWithSameID = _context.Restaurants.Where(x => x.id.Equals(restaurant.id)).FirstOrDefault(); 

            if(restaurantWithSameID != null) //if there is already a restaurant with that id
            {
                return null;
            }

            try
            {
                _context.Restaurants.Add(restaurant); //Attempts to add the restaurant
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