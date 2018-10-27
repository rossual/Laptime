using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laptime
{
    class Program
    {
        static void Main(string[] args)
        {
            Race race1 = new Race();
            race1.RaceName = "Race 1";
            race1.RaceEnd = DateTime.Now.AddMinutes(139);


            Rider rider1 = new Rider();
            rider1.FamilyName = "Worth";
            rider1.FirstName = "Ross";
            rider1.RiderNumber = 305;
            race1.AddRider(rider1);

            Rider rider2 = new Rider();
            rider2.FamilyName = "Smith";
            rider2.FirstName = "Dave";
            rider2.RiderNumber = 3;
            race1.AddRider(rider2);

            race1.AddLap(rider1.RiderNumber, DateTime.Now, DateTime.Now.AddMinutes(10));
            race1.AddLap(rider2.RiderNumber, DateTime.Now, DateTime.Now.AddMinutes(11));
            race1.AddLap(rider1.RiderNumber, DateTime.Now.AddMinutes(10), DateTime.Now.AddMinutes(20));
            race1.AddLap(rider2.RiderNumber, DateTime.Now.AddMinutes(11), DateTime.Now.AddMinutes(21));
            race1.AddLap(rider1.RiderNumber, DateTime.Now.AddMinutes(20), DateTime.Now.AddMinutes(30));
            race1.AddLap(rider2.RiderNumber, DateTime.Now.AddMinutes(21), DateTime.Now.AddMinutes(30));
            race1.AddLap(rider2.RiderNumber, DateTime.Now.AddMinutes(31), DateTime.Now.AddMinutes(40));
            var laps = new List<Lap>();
            laps = race1.GetLaps();
            List<Lap> SortedLaps = laps.OrderBy(o => o.RiderNumber).ToList();

            foreach (Lap l in SortedLaps)
            {
                if (l.EndTime <= race1.RaceEnd)
                {
                    Console.WriteLine("Rider Number: " + l.RiderNumber + " Lap Number: " + l.LapNumber + " Start Time: " + l.StartTime + " End Time: " + l.EndTime + " Lap Time: " + l.LapTime.ToString(@"hh\:mm\:ss"));
                }
            }

            race1.CalculateRaceResults();
            List<RacerResult> RaceResults = race1.GetResults();
            foreach(RacerResult r in RaceResults.OrderBy(o => o.FinishingPosition))
            {
                Console.WriteLine(r.FinishingPosition +" - " + r.RiderNumber + " - " + r.NumberOfLaps + " - " + r.RaceTime.ToString(@"hh\:mm\:ss"));
            }

            Console.ReadLine();
        }
    }
}
