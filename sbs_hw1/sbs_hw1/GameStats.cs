using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;


namespace sbs_hw1
{

    public class GameStats
    {

        GameStatsModelContainer context;

        public List<Stats> listStats;
        
        public GameStats()
        {
            listStats = new List<Stats>();
            context = new GameStatsModelContainer();
        }

        public void add(string _res, string _userSign, int _userSteps)
        {
            
            Stats st = new Stats();
            st.date = DateTime.Now;
            st.result = _res;
            st.userSign = _userSign;
            st.userSteps = _userSteps;
            //listStats.Add(st);
            context.StatsSet.Add(st);
            context.SaveChanges();
        }

        
        public void getAllStats()
        {
            listStats = context.StatsSet.ToList<Stats>();
        }

        public double getAvgWin()
        {
            int sum = 0;
            foreach (Stats a in listStats)
            {
                sum += a.result == "Победа" ? 1 : 0;
            }
            return (double)sum / listStats.Count * 100;
        }
    }
}
