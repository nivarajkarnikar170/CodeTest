using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestScore.Models;

namespace TestScore.Repository
{
    public interface IScoreCardService
    {
        List<ScoreCardViewModel> GetScoreCardList();
        
    }
}
