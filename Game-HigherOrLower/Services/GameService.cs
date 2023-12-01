using Game_HigherOrLower.Enum;
using Game_HigherOrLower.Helpers;
using Game_HigherOrLower.Models;

namespace Game_HigherOrLower.Services
{
    public class GameService : IGameService
    {
        private Random _randonNumber { get; set; }

        public GameService()
        {
            _randonNumber = new Random();
        }

        public GuessModel IsGameOver(int number, GuessDirection guessDirection)
        {
            var previousNumber = number;
            var nextNumber = GetNextNumber();
            var isGuessCorrect = false;

            if (guessDirection == GuessDirection.Lower)
            {
                isGuessCorrect = nextNumber <= previousNumber;
            }

            if (guessDirection == GuessDirection.Higher)
            {
                isGuessCorrect = nextNumber >= previousNumber;
            }

            return new GuessModel(isGuessCorrect, nextNumber);
        }

        public int GetNextNumber()
        {
            return _randonNumber.Next(GameParametersHelper.MinValue, GameParametersHelper.MaxValue);
        }
    }
}
