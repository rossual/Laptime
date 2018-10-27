using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laptime
{
    public class RacerResult
    {
        public string FirstName;
        public string FamilyName;
        public int RiderNumber { get; set; }

        public int NumberOfLaps { get; set; }
        public TimeSpan RaceTime { get; set; }
        public int FinishingPosition { get; set; }

        
    }
}
