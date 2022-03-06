using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLARNGGui
{
    public class Enums
    {
        public enum Weather
        {
            All,
            None,
            Sunny,
            Cloudy,
            Rain,
            Snow,
            Drought,
            Fog,
            Rainstorm,
            Snowstorm

        }
        public enum Time
        {
            Any,
            Dawn,
            Day,
            Dusk,
            Night
        }
        public enum Maps
        {
            None=0,
            ObsidianFieldlands = 1,
            CrimsonMirelands = 2,
            CobaltCoastlands = 3,
            CoronetHighlands = 4,
            AlabasterIcelands = 5
        }
    }
    
}
