using System;
using NUnit.Framework;

namespace DateMod.Tests
{
    [TestFixture]
    public class QueryTests
    {
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

            Assert.That(AreEqual(query, today), Is.True);
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
        public void AddDaysToQueryAddsDayToStartDate()
        {
            var tomorrow = Get.Today().Query().AddDays(1);
            var now = DateTime.Now.AddDays(1);
            var expected = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);

            Assert.That(tomorrow.StartDate, Is.EqualTo(expected));
        }

        [Test]
        public void AddDaysToQueryAddsDayToEndDate()
        {
            var tomorrow = Get.Today().Query().AddDays(1);
            var now = DateTime.Now.AddDays(1);
            var expected = new DateTime(now.Year, now.Month, now.Day + 1, 0, 0, 0);

            Assert.That(tomorrow.EndDate, Is.EqualTo(expected));
        }

        [Test]
        public void AddWeeksToQueryAddsWeekToStartDate()
        {
            var nextWeek = Get.Today().Query().AddWeeks(1);
            var now = DateTime.Now.AddDays(7);
            var expected = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);

            Assert.That(nextWeek.StartDate, Is.EqualTo(expected));
        }

        [Test]
        public void AddWeeksToQueryAddsWeekToEndDate()
        {
            var nextWeek = Get.Today().Query().AddWeeks(1);
            var now = DateTime.Now.AddDays(8);
            var expected = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);

            Assert.That(nextWeek.EndDate, Is.EqualTo(expected));
        }

        [Test]
        public void AddMonthsToQueryAddsMonthToStartDate()
        {
            var nextMonth = Get.Today().Query().AddMonths(1);
            var now = DateTime.Now.AddMonths(1);
            var expected = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);

            Assert.That(nextMonth.StartDate, Is.EqualTo(expected));
        }

        [Test]
        public void AddMonthsToQueryAddsMonthToEndDate()
        {
            var nextMonth = Get.Today().Query().AddMonths(1);
            var now = DateTime.Now.AddMonths(1).AddDays(1);
            var expected = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);

            Assert.That(nextMonth.EndDate, Is.EqualTo(expected));
        }

        [Test]
        public void AddYearsToQueryAddsYearToStartDate()
        {
            var nextYear = Get.Today().Query().AddYears(1);
            var now = DateTime.Now.AddYears(1);
            var expected = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);

            Assert.That(nextYear.StartDate, Is.EqualTo(expected));
        }

        [Test]
        public void AddYearsToQueryAddsYearToEndDate()
        {
            var nextYear = Get.Today().Query().AddYears(1);
            var now = DateTime.Now.AddYears(1).AddDays(1);
            var expected = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);

            Assert.That(nextYear.EndDate, Is.EqualTo(expected));
        }

        [Test]
        public void QueryOnRangeMovesEndDateToMidnightNextDay()
        {
            var range = Get.Today().Range();
            var expected = range.EndDate.AddSeconds(1);

            var query = range.Query();
            Assert.That(query.EndDate, Is.EqualTo(expected));
        }

        [Test]
        public void QueryOnRangePreservesProperStartDate()
        {
            var range = Get.ThisWeek();
            var query = range.Query();

            Assert.That(query.StartDate, Is.EqualTo(range.StartDate));
        }

        [Test]
        public void QueryOnRangePreservesProperEndDate()
        {
            var range = Get.ThisWeek();
            var query = Get.ThisWeek().Query();

            var expected = range.EndDate.AddSeconds(1);

            Assert.That(query.EndDate, Is.EqualTo(expected));
        }

        [Test]
        public void QueryOnQueryDoesNotChangeEndDate()
        {
            var query = Get.Today().Query();
            var expected = query.EndDate;

            query = query.Query();
            Assert.That(query.EndDate, Is.EqualTo(expected));
        }

        // Utilities
        private bool AreEqual(DateRange range, DateTime date)
        {
            var start = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
            var end = start.AddDays(1);

            return (range.StartDate == start && range.EndDate == end);
        }
    }
}