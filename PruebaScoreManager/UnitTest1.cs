using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyGame;
using System;

namespace PruebaBearGame
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ScoreManagerToResetScore()
        {
            var scoreManager = new ScoreManager();

            scoreManager.ResetScore();

            var realResult = scoreManager.Score;

            var expectedResult = 0;

            Assert.AreEqual(realResult, expectedResult);
        }
    }
}
