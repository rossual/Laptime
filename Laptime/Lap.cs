using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laptime
{
    public class Lap
    {
        private TimeSpan _lapTime;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int LapNumber { get; set; }
        public int RiderNumber { get; set; }
        public TimeSpan LapTime { get => _lapTime; }
        public void CalculateLaptime()
        {
            _lapTime = EndTime - StartTime;
        }

    }
}
