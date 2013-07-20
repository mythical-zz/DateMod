using System;
using NUnit.Framework;

namespace DateMod.Tests
{
    [TestFixture]
    public class RangeTests
    {
        [Test]
        public void RangeReturnsDateRange()
        {
            var range = Get.Today().Range();

            Assert.That(range, Is.InstanceOf<DateRange>());
        }

        [Test]
        public void RangeDefaultsToToday()
        {
            var range = new DateTime().Range();
            var today = Get.Today();

            Assert.That(AreEqual(range, today), Is.True);
        }

        [Test]
        public void TodayRangeStartsAtMidnightToday()
        {
            var range = Get.Today().Range();
            var today = Get.Today();
            var expected = new DateTime(today.Year, today.Month, today.Day, 0, 0, 0);

            Assert.That(range.StartDate, Is.EqualTo(expected));
        }

        [Test]
        public void TodayRangeEndsLastSecondToday()
        {
            var range = Get.Today().Range();
            var today = Get.Today();
            var expected = new DateTime(today.Year, today.Month, today.Day, 23, 59, 59);

            Assert.That(range.EndDate, Is.EqualTo(expected));
        }

        [Test]
        public void QueryReturnsDateRange()
        {
            var today = Get.Today().Query();

            Assert.That(today, Is.InstanceOf<DateRange>());
        }

        [Test]
        public void QueryDefaultsToToday()
        {
            var query = new DateTime().Query();
            var today = Get.Today();

            Assert.That(AreEqual(query, today, isRange: false), Is.True);
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

        [Test]
        public void AddDaysToRangeAddsDayToStartDate()
        {
            var tomorrow = Get.Today().Query().AddDays(1);
            var now = DateTime.Now.AddDays(1);
            var expected = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);

            Assert.That(tomorrow.StartDate, Is.EqualTo(expected));
        }

        [Test]
        public void AddDaysToRangeAddsDayToEndDate()
        {
            var tomorrow = Get.Today().Query().AddDays(1);
            var now = DateTime.Now.AddDays(1);
            var expected = new DateTime(now.Year, now.Month, now.Day + 1, 0, 0, 0);

            Assert.That(tomorrow.EndDate, Is.EqualTo(expected));
        }

        [Test]
        public void AddWeeksToRangeAddsWeekToStartDate()
        {
            var nextWeek = Get.Today().Query().AddWeeks(1);
            var now = DateTime.Now.AddDays(7);
            var expected = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);

            Assert.That(nextWeek.StartDate, Is.EqualTo(expected));
        }

        [Test]
        public void AddWeeksToRangeAddsWeekToEndDate()
        {
            var nextWeek = Get.Today().Query().AddWeeks(1);
            var now = DateTime.Now.AddDays(7);
            var expected = new DateTime(now.Year, now.Month, now.Day + 1, 0, 0, 0);

            Assert.That(nextWeek.EndDate, Is.EqualTo(expected));
        }

        [Test]
        public void AddMonthsToRangeAddsMonthToStartDate()
        {
            var nextMonth = Get.Today().Query().AddMonths(1);
            var now = DateTime.Now.AddMonths(1);
            var expected = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);

            Assert.That(nextMonth.StartDate, Is.EqualTo(expected));
        }

        [Test]
        public void AddMonthsToRangeAddsMonthToEndDate()
        {
            var nextMonth = Get.Today().Query().AddMonths(1);
            var now = DateTime.Now.AddMonths(1).AddDays(1);
            var expected = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);

            Assert.That(nextMonth.EndDate, Is.EqualTo(expected));
        }

        [Test]
        public void AddYearsToRangeAddsYearToStartDate()
        {
            var nextYear = Get.Today().Query().AddYears(1);
            var now = DateTime.Now.AddYears(1);
            var expected = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);

            Assert.That(nextYear.StartDate, Is.EqualTo(expected));
        }

        [Test]
        public void AddYearsToRangeAddsYearToEndDate()
        {
            var nextYear = Get.Today().Query().AddYears(1);
            var now = DateTime.Now.AddYears(1).AddDays(1);
            var expected = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);

            Assert.That(nextYear.EndDate, Is.EqualTo(expected));
        }

        // Utilities
        private bool AreEqual(DateRange range, DateTime date, bool isRange = true)
        {
            var start = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
            var end =
                isRange
                    ? new DateTime(date.Year, date.Month, date.Day, 23, 59, 59)
                    : new DateTime(date.Year, date.Month, date.Day + 1, 0, 0, 0);

            return (range.StartDate == start && range.EndDate == end);
        }
    }
}