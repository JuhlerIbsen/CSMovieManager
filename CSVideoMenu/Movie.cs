using System;
using System.Collections.Generic;
using System.Text;

namespace CSVideoMenu
{
    class Movie
    {
        
        // Enums should probably not be in the same class as the entity.
        // Did it anyway.. (Mwhaha)
        internal enum Genre
        {
            NoGenre,
            Comedy,
            Horror,
            Romantique
        }

        internal enum FileType
        {
            MP4,
            MKV,
            AVI
        }

        private static int _id = 0;

        public Movie()
        {
            _id ++;
            Id = _id;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public FileType Extention { get; set; }
        public Genre MovieGenre { get; set; }
        public long Duration { get; set; }

    }
}
