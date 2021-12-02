using System.Collections.Generic;
using FinalProject_CompProg.Models;

namespace FinalProject_CompProg.Interfaces
{
    public interface IMusicContextDAO
    {
        List<Music> GetAllSongs();

        Music GetById(int id);

        int? RemoveSongById(int id);

        int? UpdateSong (Music song);

        int? Add(Music song);
    }
}