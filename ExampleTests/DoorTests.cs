using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleGameUnderTests;

namespace ExampleTests
{
    [TestClass]
    public class DoorTests
    {
        [TestMethod]
        public void Open_DoorWillBeOpened()
        {
            var door = new Door(1);

            door.Open();

            Assert.AreEqual(true, door.IsOpened);
        }

        [TestMethod]
        public void Open_DoorWillBeClosed()
        {
            var timeProvider = new TestDateTimeProvider();
            var door = new Door(1, timeProvider);

            door.Open();

            timeProvider.CurreTime = timeProvider.CurreTime.AddSeconds(1);

            Assert.AreEqual(false, door.IsOpened);
        }

        [TestMethod]
        public void Open_DoorWillOpening()
        {
            var timeProvider = new TestDateTimeProvider();
            var door = new Door(1, timeProvider);

            door.Open();

            timeProvider.CurreTime = timeProvider.CurreTime.AddMilliseconds(0.5f);

            Assert.AreEqual(true, door.IsOpened);
        }

        class TestDateTimeProvider : Door.IDateTimeProvider
        {
            public DateTime CurreTime = DateTime.Now;

            public DateTime Now => CurreTime;
        }
    }
}
