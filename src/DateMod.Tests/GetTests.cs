using System;
using NUnit.Framework;

namespace DateMod.Tests
{
    [TestFixture]
    public class GetTests
    {
        [Test]
        public void GetTodayReturnsToday()
        {
            var today = Get.Today().ToShortDateString();
            var expected = DateTime.Now.ToShortDateString();

            Assert.That(today, Is.EqualTo(expected));
        }

        [Test]
        public void GetTomorrowReturnsTomorrow()
        {
            var tomorrow = Get.Tomorrow().ToShortDateString();
            var expected = DateTime.Now.AddDays(1).ToShortDateString();

            Assert.That(tomorrow, Is.EqualTo(expected));
        }

        [Test]
        public void GetYesterdayReturnsYesterday()
        {
            var yesterday = Get.Yesterday().ToShortDateString();
            var expected = DateTime.Now.AddDays(-1).ToShortDateString();

            Assert.That(yesterday, Is.EqualTo(expected));
        }
    }
}