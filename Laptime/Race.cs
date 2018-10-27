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
        List<RacerResult> RaceResult = new List<RacerResult>();
        private List<Lap> laps = new List<Lap>();

        public string RaceName { get; set; }
        public DateTime RaceEnd { get; set; }

        public void AddRider(Rider rider)
        {
            Riders.Add(rider); 
        }

        public string AddLap(int RiderNumber, DateTime StartTime, DateTime EndTime)
        {
            Lap currentLap = new Lap();
            currentLap.StartTime = StartTime;
            currentLap.EndTime = EndTime;
            //count laps for given rider number
            int lapNumber = ((from x in laps where x.RiderNumber == RiderNumber select x).Count())+1;
            currentLap.LapNumber = lapNumber;
            currentLap.RiderNumber = RiderNumber;
            currentLap.CalculateLaptime();
            laps.Add(currentLap);
            return "Lap Added";
        }

        public void AddResult(int RiderNumber, int NumberOfLaps, TimeSpan RaceTime)
        {
            RacerResult currentResult = new RacerResult();
            currentResult.RiderNumber = RiderNumber;
            currentResult.NumberOfLaps = NumberOfLaps;
            currentResult.RaceTime = RaceTime;
            RaceResult.Add(currentResult);
            
        }

        public void CalculateRaceResults()
        {
            foreach(Rider r in Riders)
            {
                //count laps
                var Laps = (from x in laps where x.RiderNumber == r.RiderNumber select x);
                int NumberOfLaps = 0;
                foreach (Lap l in Laps)
                {
                    if (l.EndTime < RaceEnd) { NumberOfLaps++; }
                }


                //calaculate race time
                DateTime StartTime = Convert.ToDateTime((from x in laps where x.RiderNumber == r.RiderNumber select x.StartTime).Min());
                DateTime EndTime = Convert.ToDateTime((from x in laps where x.RiderNumber == r.RiderNumber select x.EndTime).Max());
                TimeSpan RaceTime = EndTime - StartTime;
                AddResult(r.RiderNumber, NumberOfLaps, RaceTime);

            }
            //Calculate postions
            int i = 1;
            foreach (RacerResult x in RaceResult.OrderByDescending(r => r.NumberOfLaps).ThenBy(r => r.RaceTime))
            {
                x.FinishingPosition = i;
                i++;
            };
           

        }
        public List<RacerResult> GetResults()
        {
            return RaceResult;
        }

        public List<Lap> GetLaps()
        {
            return laps;
        }


    }
}
