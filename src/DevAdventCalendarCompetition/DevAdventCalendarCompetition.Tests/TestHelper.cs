using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevAdventCalendarCompetition.Repository.Models;
using DevAdventCalendarCompetition.Services.Models;

namespace DevAdventCalendarCompetition.Tests
{
    public static class TestHelper
    {
        public static Test GetTest(int number = 2) => GetTestList().First(t => t.Number == number);

        public static List<Test> GetTestList() => new List<Test>()
        {
            new Test()
            {
                Id = 1,
                Number = 1,
                StartDate = new DateTime(2020, 12, 1, 20, 0, 0),
                EndDate = new DateTime(2020, 12, 24, 20, 0, 0),
                HashedAnswers = null
            },
            new Test()
            {
                Id = 2,
                Number = 2,
                StartDate = new DateTime(2020, 12, 8, 20, 0, 0),
                EndDate = new DateTime(2020, 12, 24, 20, 0, 0),
                HashedAnswers = null
            },
            new Test()
            {
                Id = 3,
                Number = 3,
                StartDate = new DateTime(2020, 12, 15, 20, 0, 0),
                EndDate = new DateTime(2020, 12, 24, 20, 0, 0),
                HashedAnswers = null
            },
            new Test()
            {
                Id = 4,
                Number = 4,
                StartDate = new DateTime(2020, 12, 23, 20, 0, 0),
                EndDate = new DateTime(2020, 12, 24, 20, 0, 0),
                HashedAnswers = null
            },
            new Test()
            {
                Id = 5,
                Number = 5,
                StartDate = new DateTime(2020, 12, 2, 20, 0, 0),
                EndDate = new DateTime(2020, 12, 24, 20, 0, 0),
                HashedAnswers = null
            },
        };

        public static TestDto GetTestDto(int number = 2) => GetTestDtoList().First(t => t.Number == number);

        public static List<TestDto> GetTestDtoList() => new List<TestDto>()
        {
            new TestDto()
            {
                Id = 1,
                Number = 1,
                StartDate = DateTime.Today.AddDays(-1).AddHours(12),
                EndDate = DateTime.Today.AddDays(-1).AddHours(23).AddMinutes(59),
                Answers = new List<TestAnswerDto>()
                {
                    new TestAnswerDto() { Answer = "Answer1" },
                    new TestAnswerDto() { Answer = "Answer3" }
                }
            },
            new TestDto()
            {
                Id = 2,
                Number = 2,
                StartDate = DateTime.Today.AddHours(12),
                EndDate = DateTime.Today.AddHours(23).AddMinutes(59),
                Answers = new List<TestAnswerDto>()
                {
                    new TestAnswerDto() { Answer = "Answer1" },
                    new TestAnswerDto() { Answer = "Answer2" },
                    new TestAnswerDto() { Answer = "Answer3" }
                }
            },
            new TestDto()
            {
                Id = 3,
                Number = 3,
                StartDate = DateTime.Today.AddDays(1).AddHours(12),
                EndDate = DateTime.Today.AddDays(1).AddHours(23).AddMinutes(59),
                Answers = new List<TestAnswerDto>()
                {
                    new TestAnswerDto() { Answer = "Answer1" }
                }
            },
            new TestDto()
            {
                Id = 4,
                Number = 4,
                StartDate = DateTime.Today.AddDays(2).AddHours(12),
                EndDate = DateTime.Today.AddDays(2).AddHours(23).AddMinutes(59),
                Answers = new List<TestAnswerDto>()
                {
                    new TestAnswerDto() { Answer = "Answer1" },
                    new TestAnswerDto() { Answer = "Answer2" },
                    new TestAnswerDto() { Answer = "Answer3" },
                    new TestAnswerDto() { Answer = "Answer4" }
                }
            }
        };

        public static UserTestCorrectAnswer GetTestAnswer() => new UserTestCorrectAnswer()
        {
            Id = 1,
            TestId = 2,
            UserId = "c611530e-bebd-41a9-ace2-951550edbfa0",
            AnsweringTimeOffset = TimeSpan.FromMinutes(2),
            AnsweringTime = DateTime.Now
        };

        public static ApplicationUser[] CreateTestUsers()
        {
            return new[]
            {
                new ApplicationUser
                {
                    UserName = "testUser",
                    Email = "test@mail.com"
                },
                new ApplicationUser
                {
                    UserName = "testUser1",
                    Email = "test1@mail.com"
                },
            };
        }
    }
}
