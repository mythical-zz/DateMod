using System;
using NUnit.Framework;

namespace DateMod.Tests
{
    [TestFixture]
    public class DayTests
    {
        [Test]
        public void GetTodayShortReturnsShortDateString()
        {
            var today = Get.Today().Short();
            var expected = DateTime.Now.ToShortDateString();

            Assert.That(today, Is.EqualTo(expected));
        }

        [Test]
        public void GetTodayLongReturnsLongDateString()
        {
            var today = Get.Today().Long();
            var expected = DateTime.Now.ToLongDateString();

            Assert.That(today, Is.EqualTo(expected));
        }

        [Test]
        public void GetTodayDayReturnsDayOfWeekAsString()
        {
            var today = Get.Today().Day();
            var expected = DateTime.Now.DayOfWeek.ToString();

            Assert.That(today, Is.EqualTo(expected));
        }

        [Test]
        public void AddWeeksToTodayReturnsTodayNextWeek()
        {
            var nextWeek = Get.Today().AddWeeks(1).ToShortDateString();
            var expected = DateTime.Now.AddDays(7).ToShortDateString();

            Assert.That(nextWeek, Is.EqualTo(expected));
        }
    }
}