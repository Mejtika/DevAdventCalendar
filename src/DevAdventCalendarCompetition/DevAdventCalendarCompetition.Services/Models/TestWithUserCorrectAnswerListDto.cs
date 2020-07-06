using System;
using System.Collections.Generic;
using DevAdventCalendarCompetition.Repository.Migrations;

namespace DevAdventCalendarCompetition.Services.Models
{
    public class TestWithUserCorrectAnswerListDto
    {
        public int TestId { get; set; }

        public int Number { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public ICollection<TestCorrectAnswerDto> UserCorrectAnswers { get; internal set; }

        public ICollection<TestWrongAnswerDto> UserWrongAnswers { get; internal set; }

        public bool HasEnded { get; set; }
    }
}