namespace Game_HigherOrLower.Models
{
    public class GuessModel
    {
        public bool IsGuessCorrect { get; set; }
        public int NextNumber { get; set; }

        public GuessModel(bool isGuessCorrect, int nextNumber)
        {
            IsGuessCorrect = isGuessCorrect;
            NextNumber = nextNumber;
        }
    }
}
