using System;
using System.Collections.Generic;
using System.Linq;
using DevAdventCalendarCompetition.Repository.Context;
using DevAdventCalendarCompetition.Repository.Interfaces;
using DevAdventCalendarCompetition.Repository.Models;

namespace DevAdventCalendarCompetition.Repository
{
    public class UserTestAnswersRepository : IUserTestAnswersRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserTestAnswersRepository(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void AddAnswer(UserTestCorrectAnswer testAnswer)
        {
            this._dbContext.Set<UserTestCorrectAnswer>().Add(testAnswer);
            this._dbContext.SaveChanges();
        }

        public void AddWrongAnswer(UserTestWrongAnswer wrongAnswer)
        {
            this._dbContext.Set<UserTestWrongAnswer>().Add(wrongAnswer);
            this._dbContext.SaveChanges();
        }

        public void UpdateAnswer(UserTestCorrectAnswer testAnswer)
        {
            this._dbContext.Set<UserTestCorrectAnswer>().Update(testAnswer);
            this._dbContext.SaveChanges();
        }

        public UserTestCorrectAnswer GetAnswerByTestId(int testId)
        {
            return this._dbContext.Set<UserTestCorrectAnswer>().FirstOrDefault(el => el.TestId == testId);
        }

        public UserTestCorrectAnswer GetTestAnswerByUserId(string userId, int testId)
        {
            return this._dbContext.Set<UserTestCorrectAnswer>().FirstOrDefault(el => el.UserId == userId && el.TestId == testId);
        }

        public bool HasUserAnsweredTest(string userId, int testId)
        {
            return this._dbContext.Set<UserTestCorrectAnswer>().FirstOrDefault(el => el.TestId == testId && el.UserId == userId) != null;
        }

        public int GetCorrectAnswersCountForUser(string userId)
        {
            return this._dbContext.Set<UserTestCorrectAnswer>()
                .Where(a => a.UserId == userId)
                .AsEnumerable()
                .GroupBy(t => t.TestId)
                .Count();
        }

        public IDictionary<string, int> GetCorrectAnswersPerUserForDateRange(DateTimeOffset dateFrom, DateTimeOffset dateTo)
        {
            return this._dbContext
                .TestCorrectAnswers
                .Where(a => a.AnsweringTime.CompareTo(dateFrom.DateTime) >= 0 &&
                            a.AnsweringTime.CompareTo(dateTo.DateTime) < 0)
                .AsEnumerable()
                .GroupBy(a => a.UserId)
                .Select(ug => new KeyValuePair<string, int>(ug.Key, ug.Count()))
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }

        public IDictionary<string, int> GetWrongAnswersPerUserForDateRange(DateTimeOffset dateFrom, DateTimeOffset dateTo)
        {
            return this._dbContext
                .TestWrongAnswers
                .Where(a => a.Time.CompareTo(dateFrom.DateTime) >= 0 &&
                            a.Time.CompareTo(dateTo.DateTime) < 0)
                .AsEnumerable()
                .GroupBy(a => a.UserId)
                .Select(ug => new KeyValuePair<string, int>(ug.Key, ug.Count()))
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }
    }
}
