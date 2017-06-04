using Microsoft.VisualStudio.TestTools.UnitTesting;
using sbs_hw1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sbs_hw1.Tests
{
    [TestClass()]
    public class GameStatsTests
    {
        [TestMethod()]
        public void getAvgWinTest()
        {
            //arrange
            GameStats stats = new GameStats();
            stats.listStats.Add(new Stats() { result = "Победа", userSign = "X", userSteps = 3, date = DateTime.Now });
            stats.listStats.Add(new Stats() { result = "Поражение", userSign = "X", userSteps = 3, date = DateTime.Now });
            stats.listStats.Add(new Stats() { result = "Победа", userSign = "0", userSteps = 3, date = DateTime.Now });

            double expected = 66;
            //act
            double actual = stats.getAvgWin();

            //assert
            Assert.AreEqual(expected, actual, 1);
        }
    }
}