using System.Collections.Generic;
using System.Web.Mvc;
using TestScore.Models;
using TestScore.Repository;

namespace TestScore.Controllers
{
    public class ScoreCardController : Controller
    {
        private IScoreCardService _scoreCardService;

        public ScoreCardController()
        {
            _scoreCardService = new ScoreCardService();
        }
        // GET: ScoreCard
        public ActionResult Index()
        {
            var scoreCardList = new List<ScoreCardViewModel>();
            scoreCardList = _scoreCardService.GetScoreCardList();           
            return View(scoreCardList);
        }
    }
}