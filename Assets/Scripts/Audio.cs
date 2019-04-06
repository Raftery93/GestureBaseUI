using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Assets.Scripts
{
    public static class Audio
    {
        /*
        This class is a simple abstraction of all of the audio source names.
        Any time an audio source is added or changes, simply add it to this class
        and gain global reference to it.
         */
        public const string Life = "life"; 
        public const string Pop = "pop";
        public const string Shoot = "shoot";
        public const string Theme = "theme";
        public const string Ouch = "ouch";
    }

}