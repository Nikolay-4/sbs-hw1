using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using sbs_hw1;


namespace sbs_hw1_tests
{
    [TestClass]
    public class GameLogicTest
    {

        bool arrStringsEqual(string[,] a, string[,] b)
        {
            if ((a.Rank != b.Rank) || (a.GetLength(0) != b.GetLength(0)))
                return false;
            for (int i = 0; i < a.Rank; i++)
                for (int j = 0; j < b.GetLength(0); j++)
                    if (a[i, j] != b[i, j])
                        return false;
            return true;
        }


        [TestMethod]
        public void checkTest()
        {
            //arrange
            FakeBoard board1 = new FakeBoard();
            FakeBoard board2= new FakeBoard();
            FakeBoard board3 = new FakeBoard();
            FakeBoard board4 = new FakeBoard();
            FakeBoard board5 = new FakeBoard();

            GameLogic game1, game2, game3, game4, game5;
            string aiSign = "0";
            string userSign = "X";
            board1._board = new string[,] { { "0", "0", "X" },
                                           { "X", "0", "0" },
                                           { "0", "X", "X" }
            };

            board2._board = new string[,] { { "0", "", "" },
                                           { "X", "0", "0" },
                                           { "0", "", "0" }
            };

            board3._board = new string[,] { { "0", "", "X" },
                                           { "X", "X", "0" },
                                           { "X", "", "X" }
            };

            board4._board = new string[,] { { "0", "", "" },
                                           { "X", "", "0" },
                                           { "X", "X", "X" }
            };

            board5._board = new string[,] { { "0", "0", "X" },
                                           { "X", "0", "0" },
                                           { "X", "X", "0" }
            };
            game1 = new GameLogic(board1, aiSign, userSign);
            game2 = new GameLogic(board2, aiSign, userSign);
            game3 = new GameLogic(board3, aiSign, userSign);
            game4 = new GameLogic(board4, aiSign, userSign);
            game5 = new GameLogic(board5, aiSign, userSign);

            //act
            game1.emptyCell = 0;
            game1.check();
            game2.check();
            game3.check();
            game4.check();
            game5.check();

            //assert
            Assert.AreEqual(game1.status, "Ничья");
            Assert.AreEqual(game2.status, "Поражение");
            Assert.AreEqual(game3.status, "Победа");
            Assert.AreEqual(game4.status, "Победа");
            Assert.AreEqual(game5.status, "Поражение");

        }


        [TestMethod]
        public void aiStepTest()
        {
            //arrange
            FakeBoard board = new FakeBoard();
            board._board = new string[,] { { "0", "", "" },
                                           { "X", "", "0" },
                                           { "0", "", "X" }
            };
            string aiSign = "0";
            string userSign = "X";
            string[,] expected =  { { "0", "0", "" },
                                    { "X", "", "0" },
                                    { "0", "", "X" }
            };
            string[,] expected1 =  { { "0", "0", "0" },
                                    { "X", "", "0" },
                                    { "0", "", "X" }
            };

            string[,] expected2 =  { { "0", "0", "0" },
                                    { "X", "0", "0" },
                                    { "0", "", "X" }
            };
            string[,] expected3 =  { { "0", "0", "0" },
                                    { "X", "0", "0" },
                                    { "0", "0", "X" }
            };

            //act
            GameLogic game = new GameLogic(board, aiSign, userSign);
            game.aiStep();
            string[,] condition = game.Board.Clone() as string[,];
            game.aiStep();
            string[,] condition1 = game.Board.Clone() as string[,];
            game.aiStep();
            string[,] condition2 = game.Board.Clone() as string[,];
            game.aiStep();
            string[,] condition3 = game.Board.Clone() as string[,];

            //assert
            Assert.IsTrue(arrStringsEqual(expected, condition));
            Assert.IsTrue(arrStringsEqual(expected1, condition1));
            Assert.IsTrue(arrStringsEqual(expected2, condition2));
            Assert.IsTrue(arrStringsEqual(expected3, condition3));

        }
    }
}
