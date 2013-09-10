using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BowlingKata
{
    [TestFixture]
    public class BowlingTest
    {
        [Test]
        public void Missing_Pins_Adds_No_Score()
        {
            Bowling bowling = new Bowling();
            bowling.Roll(0);

            Assert.That(bowling.Score, Is.EqualTo(0));
        }

        [Test]
        [TestCase(6)]
        [TestCase(9)]
        public void Roll_Added_To_Score(int rollamount)
        {
            Bowling bowling = new Bowling();
            bowling.Roll(rollamount);

            Assert.That(bowling.Score, Is.EqualTo(rollamount));
        }

        [Test]
        [ExpectedException(typeof(InvalidRollException))]
        public void Can_not_roll_more_than_10()
        {
            Bowling bowling = new Bowling();
            bowling.Roll(11);
        }

        [Test]
        public void Multiple_Rolls_Added_To_Score()
        {
            Bowling bowling = new Bowling();
 
            bowling.Roll(5);
            bowling.Roll(5);

            Assert.That(bowling.Score, Is.EqualTo(10));
        }

        [Test]
        [ExpectedException(typeof(InvalidRollException))]
        public void Can_Not_Roll_More_Than_Ten_In_Two_Rolls()
        {
            Bowling bowling = new Bowling();

            bowling.Roll(6);
            bowling.Roll(5);
        }

        [Test]
        public void Can_Retrieve_Frame_Scores()
        {
            Bowling bowling = new Bowling();

            Assert.That(bowling.FrameScores, Is.Empty);
        }

        [Test]
        public void Frame_Scores_Updated_with_Score_after_first_roll()
        {
            Bowling bowling = new Bowling();

            bowling.Roll(7);

            Assert.That(bowling.FrameScores, Is.EqualTo(new [] {7}));
        
        }

        [Test]
        public void Frame_Scores_Updated_with_Score_After_Two_Rolls()
        {
            var bowling = new Bowling();

            bowling.Roll(6);
            bowling.Roll(3);

            Assert.That(bowling.FrameScores, Is.EqualTo(new [] {9}));
        }

        [Test]
        public void Frame_Scores_and_score_Updated_with_score_after_three_rolls()
        {
            var bowling = new Bowling();

            bowling.Roll(6);
            bowling.Roll(3);
            bowling.Roll(2);

            Assert.That(bowling.FrameScores, Is.EqualTo(new[] { 9, 2 }), "Frame score error");
            Assert.That(bowling.Score, Is.EqualTo(11), "Score error");
        }

        [Test]
        [ExpectedException(typeof(InvalidRollException))]
        public void Can_not_roll_more_than_ten_in_second_frame()
        {
            var bowling = new Bowling();

            bowling.Roll(6);
            bowling.Roll(3);
            bowling.Roll(9);
            bowling.Roll(3);
        }

        [Test]
        public void Frame_Scores_Updated_After_Strike_In_First_Roll()
        {
            var bowling = new Bowling();

            bowling.Roll(10);
            bowling.Roll(4);

            Assert.That(bowling.FrameScores, Is.EqualTo(new[] { 10, 4 }), "Frame score error");
            Assert.That(bowling.Score, Is.EqualTo(14), "Score error");
        }

        [Test]
        public void Strike_with_wasted_next_frame_gets_no_Bonus()
        {
            var bowling = new Bowling();

            bowling.Roll(10);
            bowling.Roll(0);
            bowling.Roll(0);

            Assert.That(bowling.FrameScores, Is.EqualTo(new[] { 10, 0 }), "Frame score error");
            Assert.That(bowling.Score, Is.EqualTo(10), "Score error");
        }

        [Test]
        public void Strike_adds_subsequent_frame_score()
        {
            var bowling = new Bowling();

            bowling.Roll(10);
            bowling.Roll(2);
            bowling.Roll(5);

            Assert.That(bowling.FrameScores, Is.EqualTo(new[] { 17, 7 }), "Frame score error");
            Assert.That(bowling.Score, Is.EqualTo(24), "Score error");
        }
    }
}
