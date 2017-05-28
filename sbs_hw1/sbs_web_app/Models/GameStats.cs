using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace sbs_web_app.Models
{
    public class Stats{
        public DateTime date { get; set; }
        public string result { get; set; }
        public string userSign { get; set; }
        public int userSteps { get; set; }
        public Stats(DateTime _date, string _result, string _userSign, int _userSteps)
        {
            date = _date;
            result = _result;
            userSign = _userSign;
            userSteps = _userSteps;
        }
    }

    class GameStats
    {
        string jsonPath = @"E:\stats.json";

        public List<Stats> listStats;
        
        public GameStats()
        {
            listStats = new List<Stats>();
        }

        public void add(string _res, string _userSign, int _userSteps)
        {
            getAllStats();
            
            Stats st = new Stats(DateTime.Now, _res, _userSign, _userSteps);
            listStats.Add(st);
            using (StreamWriter ws = new StreamWriter(jsonPath))
            using (JsonWriter write = new JsonTextWriter(ws))
            {
                string json = JsonConvert.SerializeObject(listStats, Formatting.Indented);
                ws.Write(json);
            }
        }

        public void getAllStats()
        {
            using(StreamReader rs = new StreamReader(jsonPath))
            {                
                string json = rs.ReadToEnd();
                List<Stats> listStats_t = JsonConvert.DeserializeObject<List<Stats>>(json);
                listStats = listStats_t != null ? listStats_t : listStats;
            }
        }

        public double getAvgWin()
        {
            int sum = 0;
            foreach(Stats a in listStats)
            {
                sum += a.result == "Победа" ? 1 : 0;
            }
            return (double)sum / listStats.Count * 100;
        }

    }
}
