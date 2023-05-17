using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace FootballSpentEarned
{
    public class FootballRevenue
    {
        private List<FootballMarket> premierLeague;
        public List<FootballMarket> PremierLeague
        {
            get { return premierLeague; }
            set
            {
                premierLeague = value;
            }
        }

        public List<FootballMarket> FlagCollection { get; set; }

        private List<FootballMarket> liga;
        public List<FootballMarket> Liga
        {
            get { return liga; }
            set
            {
                liga = value;
            }
        }

        private List<FootballMarket> ligue1;
        public List<FootballMarket> Ligue1
        {
            get { return ligue1; }
            set
            {
                ligue1 = value;
            }
        }

        private List<FootballMarket> bundesliga;
        public List<FootballMarket> Bundesliga
        {
            get { return bundesliga; }
            set
            {
                bundesliga = value;
            }
        }

        private List<FootballMarket> serieA;
        public List<FootballMarket> SerieA
        {
            get { return serieA; }
            set
            {
                serieA = value;
            }
        }

        private List<FootballMarket> data;
        public List<FootballMarket> Data
        {
            get { return data; }
            set
            {
                data = value;
            }
        }

        public FootballRevenue()
        {
            Assembly executingAssembly = typeof(App).GetTypeInfo().Assembly;
            using (var stream = executingAssembly.GetManifestResourceStream("FootballSpentEarned.Resources.data.json"))
            using (TextReader textStream = new StreamReader(stream))
            {
                var data = textStream.ReadToEnd();
                data = data.Trim();
                Data = JsonConvert.DeserializeObject<List<FootballMarket>>(data);
                PremierLeague = Data.Where(d => d.LeagueCode == "ENG").ToList();
                Bundesliga = Data.Where(d => d.LeagueCode == "GER").ToList();
                Liga = Data.Where(d => d.LeagueCode == "ESP").ToList();
                Ligue1 = Data.Where(d => d.LeagueCode == "FRA").ToList();
                SerieA = Data.Where(d => d.LeagueCode == "ITA").ToList();
            }
        }
    }
}
