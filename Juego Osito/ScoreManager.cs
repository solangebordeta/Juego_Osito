using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class ScoreManager
    {
        private int score;

        public int Score => score;

        public ScoreManager()
        {
            score = 0;
        }

        public void IncreaseScore(int amount)
        {
            score += amount;
        }

        public void DecreaseScore(int amount)
        {
            score -= amount;
            if (score < 0)
            {
                score = 0;
            }
        }

        public void ResetScore()
        {
            score = 0;
        }
    }
}
