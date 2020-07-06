using System;
using System.Collections.Generic;
using DevAdventCalendarCompetition.Repository.Models;

namespace DevAdventCalendarCompetition.Repository.Interfaces
{
    public interface IUserTestAnswersRepository
    {
        UserTestCorrectAnswer GetAnswerByTestId(int testId);

        UserTestCorrectAnswer GetTestAnswerByUserId(string userId, int testId);

        int GetCorrectAnswersCountForUser(string userId);

        IDictionary<string, int> GetCorrectAnswersPerUserForDateRange(DateTimeOffset dateFrom, DateTimeOffset dateTo);

        IDictionary<string, int> GetWrongAnswersPerUserForDateRange(DateTimeOffset dateFrom, DateTimeOffset dateTo);

        bool HasUserAnsweredTest(string userId, int testId);

        void UpdateAnswer(UserTestCorrectAnswer testAnswer);

        void AddAnswer(UserTestCorrectAnswer testAnswer);

        void AddWrongAnswer(UserTestWrongAnswer wrongAnswer);
    }
}