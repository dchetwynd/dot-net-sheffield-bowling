using System.Collections.Generic;
using System.Linq;

namespace BowlingKata
{
    public class Bowling
    {
        private readonly IList<int> _framescores;
        private bool _isFirstRollInFrame = true;

        public Bowling()
        {
            _framescores = new List<int>();
        }

        public void Roll(int rollValue)
        {
            if (rollValue > 10)
                throw new InvalidRollException("Single roll cannot exceed 10");

            UpdateFrameScore(rollValue);

            if(!IsStrike(rollValue))
                _isFirstRollInFrame = !_isFirstRollInFrame;
        }

        private bool IsStrike(int rollValue)
        {
            return _isFirstRollInFrame && rollValue == 10;
        }

        private void UpdateFrameScore(int rollValue)
        {
            if (_isFirstRollInFrame)
                _framescores.Add(rollValue);
            else
                UpdateLastFrameWithRoll(rollValue);
        }

        private void UpdateLastFrameWithRoll(int rollValue)
        {
            var frameScore = _framescores[_framescores.Count - 1] + rollValue;

            if (frameScore > 10)
                throw new InvalidRollException("Multiple rolls cannot exceed 10");

            _framescores[_framescores.Count - 1] = frameScore;
        }

        public int Score
        {
            get { return _framescores.Sum(); } 
        }

        public IEnumerable<int> FrameScores
        {
            get { return _framescores; }
        }
    }
}