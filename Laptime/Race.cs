using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laptime
{
    public class Race
    {


        List<Rider> Riders = new List<Rider>();
        private List<Lap> laps = new List<Lap>();

        public string RaceName { get; set; }

        public void AddRider(Rider rider)
        {
            Riders.Add(rider); 
        }

        public string AddLap(int RiderNumber, DateTime StartTime, DateTime EndTime)
        {
            Lap currentLap = new Lap();
            currentLap.StartTime = StartTime;
            currentLap.EndTime = EndTime;
            int lapNumber = (laps.Count + 1);
            currentLap.LapNumber = lapNumber;
            currentLap.RiderNumber = RiderNumber;
            laps.Add(currentLap);
            return "Lap Added";
        }


        public List<Lap> GetLaps()
        {
            return laps;
        }


    }
}
