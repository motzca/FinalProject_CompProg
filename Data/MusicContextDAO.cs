using System.Collections.Generic;
using FinalProject_CompProg.Interfaces;
using FinalProject_CompProg.Models;
using System.Linq;
using System;

namespace FinalProject_CompProg.Data
{
    public class MusicContextDAO : IMusicContextDAO
    {
        private FinalProjectContext _context;
        public MusicContextDAO(FinalProjectContext context)
        {
            _context = context;
        }

        public List<Music> GetAllSongs()
        {
            return _context.Musicians.ToList();  //returns list of all songs
        }

        public Music GetById(int id)
        {
            return _context.Musicians.Where(x => x.id.Equals(id)).FirstOrDefault();  //returns song that has the same id as the id passed into the method
        }
        public int? RemoveSongById(int id)
        {
            var song = this.GetById(id); //attempts to get the song that has the id passed in
            if(song == null) return null;
            try
            {
                _context.Musicians.Remove(song); //Attempts to remove the song that has that id
                _context.SaveChanges();
                return 1;
            }
            catch(Exception)
            {
                return 0;
            }
            
        }
        
        public int? UpdateSong(Music song)
        {
            var songToUpdate = this.GetById(song.id); //attempts to get the song that has the id passed in
            if(songToUpdate == null) return null; //if it found no song to update

            songToUpdate.songTitle = song.songTitle; //setting the values of the found song to match the song passed into the method
            songToUpdate.artistName = song.artistName;
            songToUpdate.songYear = song.songYear;
            songToUpdate.musicGenre = song.musicGenre;
            try
            {
                _context.Musicians.Update(songToUpdate); //Attempts to update the song
                _context.SaveChanges();
                return 1;
            }
            catch(Exception)
            {
                return 0;
            }  
        }
        public int? Add(Music song)
        {
            //First finds out if a song with the same id already exists
            var songInfo = _context.Musicians
            .Where(x => x.artistName.Equals(song.artistName) && x.musicGenre.Equals(song.musicGenre))
            .FirstOrDefault();  
            
        if (songInfo != null) //If the id is already used
        {
            return null;
        }

            try
            {
                _context.Musicians.Add(song); //Attempt to add the song
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