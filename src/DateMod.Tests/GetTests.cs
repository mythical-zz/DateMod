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
            var today = Get.Today();
            var now = DateTime.Now;

            var expected = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);

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

        [Test]
        public void GetThisWeekReturnsDateRange()
        {
            var week = Get.ThisWeek();

            Assert.That(week, Is.InstanceOf<DateRange>());
        }

        [Test]
        public void GetThisWeekStartsOnMonday()
        {
            var week = Get.ThisWeek();
            var day = week.StartDate.DayOfWeek;

            Assert.That(day, Is.EqualTo(DayOfWeek.Monday));
        }

        [Test]
        public void GetThisWeekEndsOnSunday()
        {
            var week = Get.ThisWeek();
            var day = week.EndDate.DayOfWeek;

            Assert.That(day, Is.EqualTo(DayOfWeek.Sunday));
        }

        [Test]
        public void GetThisWeekReturnsThisWeek()
        {
            var week = Get.ThisWeek();
            var today = Get.Today();
            var start = new DateTime(today.Year, today.Month, today.Day, 0, 0, 0);

            var startDay = (int)today.DayOfWeek;
            start = start.AddDays(-(startDay - 1));

            var sunday = start.AddDays(6);
            var end = new DateTime(sunday.Year, sunday.Month, sunday.Day, 23, 59, 59);

            Assert.That(week.StartDate, Is.EqualTo(start));
            Assert.That(week.EndDate, Is.EqualTo(end));
        }
    }
}