using Game_HigherOrLower.Enum;
using Game_HigherOrLower.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Game_HigherOrLower.Pages
{
    public class GameModel : PageModel
    {
        private readonly IGameService _gameService;

        [BindProperty]
        public int Number { get; set; }

        [TempData]
        public int NextNumber { get; set; }

        [TempData]
        public bool IsGameOver { get; set; }

        public GameModel(IGameService gameService)
        {
            _gameService = gameService;
        }

        public void OnGet()
        {
            if (TempData["IsGameOver"] == null)
            {
                Number = _gameService.GetNextNumber();
            }

            //Replace TempData for Session
            //https://www.learnrazorpages.com/razor-pages/session-state

            object nextNumber = TempData["NextNumber"];
            if (Convert.ToInt32(nextNumber) > 0)
            {
                Number = Convert.ToInt32(nextNumber);
                TempData["NextNumber"].
            }
        }

        public IActionResult OnPostHigher()
        {
            var guessResponse = _gameService.IsGameOver(Number, GuessDirection.Higher);

            if (guessResponse.IsGuessCorrect)
            {
                TempData["NextNumber"] = guessResponse.NextNumber;
                return RedirectToPage("Game");
            }
            else
            {
                TempData["IsGameOver"] = true;
                return Redirect("/Index");
            }
        }

        public IActionResult OnPostLower()
        {
            var guessResponse = _gameService.IsGameOver(Number, GuessDirection.Lower);

            if (guessResponse.IsGuessCorrect)
            {
                TempData["NextNumber"] = guessResponse.NextNumber;
                return RedirectToPage("Game");
            }
            else
            {
                TempData["IsGameOver"] = true;
                return Redirect("/Index");
            }
        }
    }
}
