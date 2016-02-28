using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MeetUpApi
{
    public class Venue
    {
        public string country { get; set; }
        public string localized_country_name { get; set; }
        public string city { get; set; }
        public string address_1 { get; set; }
        public string name { get; set; }
        public double lon { get; set; }
        public int id { get; set; }
        public double lat { get; set; }
        public bool repinned { get; set; }
    }

    public class Group
    {
        public string join_mode { get; set; }
        public long created { get; set; }
        public string name { get; set; }
        public double group_lon { get; set; }
        public int id { get; set; }
        public string urlname { get; set; }
        public double group_lat { get; set; }
        public string who { get; set; }
    }

    public class Result
    {
        public int utc_offset { get; set; }
        public Venue venue { get; set; }
        public int headcount { get; set; }
        public string visibility { get; set; }
        public int waitlist_count { get; set; }
        public long created { get; set; }
        public int maybe_rsvp_count { get; set; }
        public string description { get; set; }
        public string event_url { get; set; }
        public int yes_rsvp_count { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        public long time { get; set; }
        public long updated { get; set; }
        public Group group { get; set; }
        public string status { get; set; }
    }

    public class Meta
    {
        public string next { get; set; }
        public string method { get; set; }
        public int total_count { get; set; }
        public string link { get; set; }
        public int count { get; set; }
        public string description { get; set; }
        public string lon { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string signed_url { get; set; }
        public string id { get; set; }
        public long updated { get; set; }
        public string lat { get; set; }
    }

    public class RootObject
    {
        public List<Result> results { get; set; }
        public Meta meta { get; set; }
    }

    class Program
    {



        static void Main(string[] args)
        {

            string BaseUrl = "https://api.meetup.com/";

            string APIKey;

            string endpointAPIKey = "2/events?key=";

            string Sign = "&sign=true";
            string Path;

            string GroupPath = "&group_urlname=";

            string GroupURL;



            APIKey = "YourOwnMeetupAPIKey";
            //replace   YourOwnMeetupAPIKey             with your Meetup AIP key
            //get your key https://secure.meetup.com/meetup_api/key/ (you have to be logged in at Meetup)

            GroupURL = "ny-tech";
            GroupURL = "Internet-of-Things-Utrecht";


            string url = BaseUrl + endpointAPIKey + APIKey + GroupPath + GroupURL + Sign;

            //this is the automatic generated json class
            //of course you have to rename the classes into decent names
            RootObject Meetup;

            WebClient wc = new WebClient();

            try
            {
                var rawdata = wc.DownloadString(url);


                //simply write the result to the console
                JsonTextReader reader = new JsonTextReader(new StringReader(rawdata));
                while (reader.Read())
                {
                    if (reader.Value != null)
                    {
                        Console.WriteLine("Token: {0}, Value: {1}", reader.TokenType, reader.Value);
                    }
                    else
                    {
                        Console.WriteLine("Token: {0}", reader.TokenType);
                    }
                }

                //the first time
                //after reading the meetup in rawdata in the debugging mode
                //show rawdata in html format and copy result to http://json2csharp.com/
                //now declare the 'generated' classes above

                //now you can use the classes to store the result of the jsonconvert()

                Meetup = JsonConvert.DeserializeObject<RootObject>(rawdata);
                //the result is stored in object Meetup and is ready for use

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }

            Console.ReadLine();



        }
    }
}
