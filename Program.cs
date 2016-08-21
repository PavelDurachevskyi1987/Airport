using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    class Program
    {
        public enum FlightStatus
        {
            Checkin,
            GateClosed,
            Arrived,
            DepartedAt,
            Unknow,
            Canceled,
        }

        public struct Flight
        {
            public DateTime Arrival;
            public int Number;
            public string City;
            public string AirLine;
            public int Terminal;
            public FlightStatus FlightStatus;
            public Flight(DateTime arrival, int number, string city, string airline,
                                         int terminal, FlightStatus flightStatus)
            {
                Arrival = arrival;
                Number = number;
                City = city;
                AirLine = airline;
                Terminal = terminal;
                FlightStatus = flightStatus;
            }
            public override string ToString()
            {
                string mytostring = @"Time: " + Arrival + "\nFlight number: " + Number +
                   "\nCity: " + City + "\nAirLine: " + AirLine + "\nTerminal: " + Terminal +
                   "\nFlight Status: " + FlightStatus + "\n" + new string('_', 30);
                return mytostring;
            }

        }

        static void Main(string[] args)


        {
            DateTime now = DateTime.Now;
            now = DateTime.Parse("20,08,2016 08:00:00");

            Flight[] flight = new Flight[]
            {

                new Flight(DateTime.Parse("20,08,2016 08:00:00"),1,"Kiev","MAU",2,FlightStatus.Arrived),
                new Flight(DateTime.Parse("20,08,2016 09:30:00"),2,"Kharkov","MAU",1,FlightStatus.Canceled),
                new Flight(DateTime.Parse("20,08,2016 10:30:00"),3,"Madrid","MAU",3,FlightStatus.DepartedAt),
                new Flight(DateTime.Parse("20,08,2016 12:30:00"),4,"Paris","Aerostar",1,FlightStatus.Arrived),
                new Flight(DateTime.Parse("20,08,2016 13:30:00"),5,"Vena","Aerostar",2,FlightStatus.Checkin),
                new Flight(DateTime.Parse("20,08,2016 14:00:00"),6,"New York","Aerostar",03,FlightStatus.GateClosed),
                new Flight(DateTime.Parse("20,08,2016 19:30:00"),7,"Vena","Aerostar",02,FlightStatus.Canceled),
                new Flight(DateTime.Parse("20,08,2016 08:00:00"),8,"Kiev","Aerostar",2,FlightStatus.Checkin),
            };
            int userEnter;
            do
            {
                Console.Clear();
                Console.WriteLine("Welcom to Airport:");
                Console.WriteLine("Select an action:");
                Console.WriteLine(@"1.Edit information
2.Hide with flight status - canceled
3.Information about all flights
4.Search by number
5.Search by time 
6.Search by city
7.Search all flights in this hours
8.Quit");


                bool userEnterIsInt = int.TryParse(Console.ReadLine(), out userEnter);
                switch (userEnter)
                {
                    case 1:
                        Console.Clear();
                        foreach (var item in flight)
                        {
                            Console.WriteLine(item);
                        }
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Enter the flight number to edit: ");
                        Console.ResetColor();
                        int editNumber;
                        bool isIntNumber = int.TryParse(Console.ReadLine(), out editNumber);
                        if (editNumber <= flight.Length)
                        {
                            int position = -1;
                            char yesOrNot;
                            Console.Clear();
                            for (int i = 0; i < flight.Length; i++)
                            {
                                if (editNumber == flight[i].Number)
                                {
                                    position = i;
                                    Console.WriteLine(flight[i]);
                                }
                            }
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(@"
Are you sure you want to edit this flight? 
if Yes - press y 
if No - press n");
                            Console.ResetColor();
                            yesOrNot = char.Parse(Console.ReadLine());
                            if (yesOrNot == 'n')
                                break;
                            Console.Clear();
                            Console.WriteLine("Enter value of date and time of Arrive(dd,mm,yyyy hh:mm:ss):");
                            flight[position].Arrival = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("Enter value of Flight number:");
                            flight[position].Number = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter a city:");
                            flight[position].City = Console.ReadLine();
                            Console.WriteLine("Enter a name of Airline:");
                            flight[position].AirLine = Console.ReadLine();
                            Console.WriteLine("Enter a Terminal:");
                            flight[position].Terminal = int.Parse(Console.ReadLine());
                            Console.WriteLine(@"Select a Flight status: 
1.Checkin
2.GateClosed
3.Arrived
4.DepartedAt
5.Unknow 
6.Canceled");
                            int status;
                            bool isIntStatus = int.TryParse(Console.ReadLine(), out status);
                            do
                            {
                                switch (status)
                                {
                                    case 1:
                                        flight[position].FlightStatus = FlightStatus.Checkin;
                                        break;
                                    case 2:
                                        flight[position].FlightStatus = FlightStatus.GateClosed;
                                        break;
                                    case 3:
                                        flight[position].FlightStatus = FlightStatus.Arrived;
                                        break;
                                    case 4:
                                        flight[position].FlightStatus = FlightStatus.DepartedAt;
                                        break;
                                    case 5:
                                        flight[position].FlightStatus = FlightStatus.Unknow;
                                        break;
                                    case 6:
                                        flight[position].FlightStatus = FlightStatus.Canceled;
                                        break;
                                    default:
                                        Console.WriteLine("Enter a number from 1 to 6");
                                        break;
                                }
                            } while (status >= 7);
                            Console.Clear();
                            Console.WriteLine(flight[position]);
                            char yesOrNot2;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(@"Replace flight ?
if Yes - press y 
if No - press n");
                            Console.ResetColor();
                            yesOrNot2 = char.Parse(Console.ReadLine());
                            if (yesOrNot2 == 'n')
                                break;
                            for (int i = 0; i < flight.Length; i++)
                            {
                                if (i == position)
                                {
                                    flight[i] = flight[position];
                                }
                            }
                            Console.Clear();
                            foreach (var item in flight)
                            {
                                Console.WriteLine(item);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Number does not exist");
                        }
                        Console.ReadLine();

                        break;
                    case 2:
                        Console.Clear();
                        foreach (var item in flight)
                        {
                            bool b = false;
                            if (item.FlightStatus == FlightStatus.Canceled)
                            {
                                b = true;
                            }
                            if (!b) Console.WriteLine(item);
                        }
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.Clear();
                        foreach (var item in flight)
                        {
                            Console.WriteLine(item);
                        }
                        Console.ReadLine();
                        break;
                    case 4:
                        int countNumber = 0;
                        int countFlight = 0;
                        Console.Clear();
                        Console.WriteLine("Enter Flight number:");
                        int UserNumber;
                        bool isInt = int.TryParse(Console.ReadLine(), out UserNumber);
                        Console.Clear();
                        foreach (var item in flight)
                        {
                            if (item.Number == UserNumber && UserNumber != 0)
                            {
                                countNumber++;
                                countFlight = countNumber;
                                Console.WriteLine(item);
                            }
                        }
                        Console.WriteLine($"Found {countFlight} flights !");
                        if (countFlight == 0)
                        {
                            Console.WriteLine("Number does not exist");
                        }
                        Console.ReadLine();
                        break;
                    case 5:
                        int countNumberTime = 0;
                        int countFlightTime = 0;
                        Console.Clear();
                        Console.WriteLine("Enter search date and time arrival from (dd,mm,yyyy hh:mm:ss)");
                        DateTime dateStart = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Enter search date and time arrival to (dd,mm,yyyy hh:mm:ss)");
                        DateTime dateFinish = DateTime.Parse(Console.ReadLine());
                        Console.Clear();
                        foreach (var item in flight)
                        {
                            if (item.Arrival >= dateStart && item.Arrival <= dateFinish)
                            {
                                countNumberTime++;
                                countFlightTime = countNumberTime;
                                Console.WriteLine(item);
                            }
                        }
                        Console.WriteLine($"Found {countFlightTime} flights !");
                        if (countFlightTime == 0)
                        {
                            Console.WriteLine("Number does not exist");
                        }
                        Console.ReadLine();

                        break;
                    case 6:
                        int count = 0;
                        int countCity = 0;
                        Console.Clear();
                        Console.WriteLine("Enter City:");
                        string UserCity = Console.ReadLine();
                        Console.Clear();
                        foreach (var item in flight)
                        {
                            if (item.City == UserCity && UserCity != null)
                            {
                                count++;
                                countCity = count;
                                Console.WriteLine(item);
                            }
                        }
                        Console.WriteLine($"Found {countCity} flights !");
                        if (countCity == 0)
                        {
                            Console.WriteLine($"Flight with city {UserCity} not found");
                        }
                        Console.ReadLine();
                        break;
                    case 7:
                        int countNumberNowTime = 0;
                        int countFlightNowTime = 0;
                        Console.Clear();
                        foreach (var item in flight)
                        {
                            if (item.Arrival == now)
                            {
                                countNumberNowTime++;
                                countFlightNowTime = countNumberNowTime;
                                Console.WriteLine(item);
                            }
                        }
                        Console.WriteLine($"Found {countFlightNowTime} flights !");
                        if (countFlightNowTime == 0)
                        {
                            Console.WriteLine("Number does not exist");
                        }
                        Console.ReadLine();
                        break;
                }
            } while (userEnter < 8);
            //public static void returnMenu()
            //{
            //    Console.BackgroundColor = ConsoleColor.White;
            //    Console.ForegroundColor = ConsoleColor.DarkRed;
            //    Console.WriteLine("\n\nTo return to the menu press enter !!!");
            //    Console.ReadLine();
            //    Console.ResetColor();         
            //}
        }
    }   
 }