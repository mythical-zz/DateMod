using System;
using NUnit.Framework;

namespace DateMod.Tests
{
    [TestFixture]
    public class RangeTests
    {
        [Test]
        public void QueryReturnsDateRange()
        {
            var today = Get.Today().Query();

            Assert.That(today, Is.InstanceOf<DateRange>());
        }

        [Test]
        public void TodayQueryStartsAtMidnightToday()
        {
            var today = Get.Today().Query();
            var now = DateTime.Now;
            var expected = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);

            Assert.That(today.StartDate, Is.EqualTo(expected));
        }

        [Test]
        public void TodayQueryEndsAtMidnightTomorrow()
        {
            var today = Get.Today().Query();
            var now = DateTime.Now;
            var expected = new DateTime(now.Year, now.Month, now.Day + 1, 0, 0, 0);

            Assert.That(today.EndDate, Is.EqualTo(expected));
        }

        [Test]
        public void YesterdayQueryStartsAtMidnightYesterday()
        {
            var yesterday = Get.Yesterday().Query();
            var now = DateTime.Now.AddDays(-1);
            var expected = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);

            Assert.That(yesterday.StartDate, Is.EqualTo(expected));
        }

        [Test]
        public void YesterdayQueryEndsAtMidnightToday()
        {
            var yesterday = Get.Yesterday().Query();
            var now = DateTime.Now;
            var expected = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);

            Assert.That(yesterday.EndDate, Is.EqualTo(expected));
        }
    }
}