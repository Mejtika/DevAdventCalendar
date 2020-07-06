using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DevAdventCalendarCompetition.Repository.Interfaces;
using DevAdventCalendarCompetition.Repository.Models;
using DevAdventCalendarCompetition.Services.Interfaces;
using DevAdventCalendarCompetition.Services.Models;

namespace DevAdventCalendarCompetition.Services
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;
        private readonly IUserTestAnswersRepository _userTestAnswersRepository;
        private readonly IMapper _mapper;
        private readonly StringHasher _stringHasher;

        public TestService(
            ITestRepository baseTestRepository,
            IUserTestAnswersRepository userTestAnswersRepository,
            IMapper mapper,
            StringHasher stringHasher)
        {
            this._testRepository = baseTestRepository;
            this._userTestAnswersRepository = userTestAnswersRepository;
            this._mapper = mapper;
            this._stringHasher = stringHasher;
        }

        public TestDto GetTestByNumber(int testNumber)
        {
            var test = this._testRepository.GetTestByNumber(testNumber);

            var testDto = this._mapper.Map<TestDto>(test);
            return testDto;
        }

        public void AddTestAnswer(int testId, string userId, DateTime testStartDate)
        {
            var currentTime = DateTime.Now;
            var answerTimeOffset = currentTime.Subtract(testStartDate);
            var maxAnswerTime = new TimeSpan(0, 23, 59, 59, 999);

            var testAnswer = new UserTestCorrectAnswer()
            {
                TestId = testId,
                UserId = userId,
                AnsweringTime = currentTime,
                AnsweringTimeOffset = answerTimeOffset > maxAnswerTime ? maxAnswerTime : answerTimeOffset
            };

            // TODO remove (for tests only)
            this._userTestAnswersRepository.AddAnswer(testAnswer);
        }

        public TestCorrectAnswerDto GetAnswerByTestId(int testId)
        {
            var testAnswer = this._userTestAnswersRepository.GetAnswerByTestId(testId);
            var testAnswerDto = this._mapper.Map<TestCorrectAnswerDto>(testAnswer);
            return testAnswerDto;
        }

        public bool HasUserAnsweredTest(string userId, int testNumber)
        {
            return this._userTestAnswersRepository.HasUserAnsweredTest(userId, testNumber);
        }

        public void AddTestWrongAnswer(string userId, int testId, string wrongAnswer, DateTime wrongAnswerDate)
        {
            var testWrongAnswer = new UserTestWrongAnswer()
            {
                UserId = userId,
                Time = wrongAnswerDate,
                Answer = wrongAnswer,
                TestId = testId
            };

            this._userTestAnswersRepository.AddWrongAnswer(testWrongAnswer);
        }

        public bool VerifyTestAnswer(string userAnswer, IEnumerable<string> correctAnswers)
        {
            return correctAnswers.Any(t => this._stringHasher.VerifyHash(userAnswer, t));
        }
    }
}