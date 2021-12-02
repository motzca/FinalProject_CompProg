using System.Collections.Generic;
using FinalProject_CompProg.Interfaces;
using FinalProject_CompProg.Models;
using System.Linq;
using System;

namespace FinalProject_CompProg.Data
{
    public class MusicContextDAO : IMusicContextDAO
    {
        private MusicContext _context;
        public MusicContextDAO(MusicContext context)
        {
            _context = context;
        }

        public List<Music> GetAllSongs()
        {
            return _context.Musicians.ToList();
        }

        public Music GetById(int id)
        {
            return _context.Musicians.Where(x => x.id.Equals(id)).FirstOrDefault();
        }
        public int? RemoveSongById(int id)
        {
            var song = this.GetById(id);
            if(song == null) return null;
            try
            {
                _context.Musicians.Remove(song);
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
            var songToUpdate = this.GetById(song.id);
            if(songToUpdate == null) return null;

            songToUpdate.songTitle = song.songTitle;
            songToUpdate.artistName = song.artistName;
            songToUpdate.musicGenre = song.musicGenre;
            try
            {
                _context.Musicians.Update(songToUpdate);
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
                var songInfo = _context.Musicians
                .Where(x => x.artistName.Equals(song.artistName) && x.musicGenre.Equals(song.musicGenre))
                .FirstOrDefault();
                
            if (songInfo != null)
            {
                return null;
            }

                try
                {
                    _context.Musicians.Add(song);
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