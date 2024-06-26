using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyGame;
using System;

namespace PruebaBearGame
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TransformToSetPosition()
        {
            var position = new Vector2(50,60);

            var scale = new Vector2(20, 210);

            var transform = new Transform(position, scale);

            var newPosition = new Vector2(4,90);

            transform.SetPosition(newPosition);

            var realResult = transform.Position;

            var expectedResult = new Vector2(position.x = newPosition.x, position.y = newPosition.y);

            Assert.AreEqual(realResult, expectedResult);
        }
    }
}
