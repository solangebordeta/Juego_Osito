using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class DynamicPoolFish
    {
        private List<Fish> fishInUse = new List<Fish>();
        private List<Fish> fishAvailable = new List<Fish>();

        public Fish CatchFish()
        {
            Fish newFish = null;

            if (fishAvailable.Count > 0)
            {
                newFish = fishAvailable[0];
                fishAvailable.RemoveAt(0);
            }
            else
            {
                newFish = new Fish(new Vector2(480, 100), this);
            }

            fishInUse.Add(newFish);
            return newFish;
        }

        public void ReleaseFish(Fish fish)
        {
            if (fishInUse.Remove(fish))
            {
                fish.ResetPositionToRandom();
                fishAvailable.Add(fish);
            }
        }

        public void ReleaseAllFish()
        {
            foreach (var fish in fishInUse)
            {
                fish.ResetPositionToRandom();
                fishAvailable.Add(fish);
            }
            fishInUse.Clear();
        }
    }
}
