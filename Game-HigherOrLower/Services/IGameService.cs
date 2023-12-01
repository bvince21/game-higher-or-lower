using Game_HigherOrLower.Models;

namespace Game_HigherOrLower.Services
{
    public interface IGameService
    {
        GuessModel IsGameOver(int number, Enum.GuessDirection guessDirection);
        int GetNextNumber();
    }
}
