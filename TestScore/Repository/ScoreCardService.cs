using System;
using System.Collections.Generic;
using System.Linq;
using TestScore.Data;
using TestScore.Models;

namespace TestScore.Repository
{
    public class ScoreCardService : IScoreCardService
    {
        public List<ScoreCardViewModel> GetScoreCardList() {

            using (var context = new ExamDbEntities1())
            {
                var query = context.ScoreCards.Select(s => new ScoreCardViewModel
                {
                    Name = s.Name,
                    Score = s.Score,
                    TestDate = s.TestDate,
                    MissedQuestions = s.MissedQuestions
                }).ToList();

                return query;
            }
        }
    }
}