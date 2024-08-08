using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestKata.Unittests
{
    /// <summary>
    /// A famous casino is suddenly faced with a sharp decline of their revenues. They decide to offer Texas hold'em also online. Can you help them by writing an algorithm that can rank poker hands?
    /// 
    /// Task:
    /// Create a poker hand that has a constructor that accepts a string containing 5 cards:
    /// PokerHand hand = new PokerHand("KS 2H 5C JD TD");
    /// The characteristics of the string of cards are:
    /// A space is used as card seperator
    /// Each card consists of two characters
    /// The first character is the value of the card, valid characters are:
    /// `2, 3, 4, 5, 6, 7, 8, 9, T(en), J(ack), Q(ueen), K(ing), A(ce)`
    /// The second character represents the suit, valid characters are:
    /// `S(pades), H(earts), D(iamonds), C(lubs)`
    /// 
    /// The poker hands must be sortable by rank, the highest rank first:
    /// var hands = new List<PokerHand>
    /// {
    /// new PokerHand("KS 2H 5C JD TD"),
    /// new PokerHand("2C 3C AC 4C 5C")
    /// };
    /// 
    /// hands.Sort();
    /// Apply the Texas Hold'em rules for ranking the cards.
    /// There is no ranking for the suits.
    /// An ace can either rank high or rank low in a straight or straight flush.Example of a straight with a low ace:
    /// `"5C 4D 3C 2S AS"`
    /// 
    /// Link to Kata: https://www.codewars.com/kata/586423aa39c5abfcec0001e6/csharp
    /// </summary>
    [TestClass]
    public class PokerHandValidator : IComparable<PokerHandValidator>
    {
        private static readonly Dictionary<char, int> CardValue = new Dictionary<char, int>
    {
        {'2', 2}, {'3', 3}, {'4', 4}, {'5', 5}, {'6', 6},
        {'7', 7}, {'8', 8}, {'9', 9}, {'T', 10}, {'J', 11},
        {'Q', 12}, {'K', 13}, {'A', 14}
    };

        public string Hand { get; }
        public int Rank { get; private set; }
        public int[] SortedValues { get; private set; }

        public PokerHandValidator(string hand)
        {
            Hand = hand;
            EvaluateHand();
        }

        private void EvaluateHand()
        {
            var cards = Hand.Split(' ').Select(card => new { Value = card[0], Suit = card[1] }).ToList();
            var values = cards.Select(card => CardValue[card.Value]).OrderByDescending(v => v).ToArray();
            SortedValues = values;

            var isFlush = cards.All(card => card.Suit == cards[0].Suit);
            var isStraight = IsStraight(values);

            var valueCounts = values.GroupBy(v => v).ToDictionary(g => g.Key, g => g.Count());

            Rank = GetHandRank(isFlush, isStraight, valueCounts);
        }

        private bool IsStraight(int[] values)
        {
            // Handle A-2-3-4-5 straight
            if (values.SequenceEqual(new[] { 14, 5, 4, 3, 2 }))
            {
                SortedValues = new[] { 5, 4, 3, 2, 1 }; // treat Ace as 1
                return true;
            }

            for (int i = 1; i < values.Length; i++)
            {
                if (values[i] != values[i - 1] - 1)
                {
                    return false;
                }
            }
            return true;
        }

        private int GetHandRank(bool isFlush, bool isStraight, Dictionary<int, int> valueCounts)
        {
            if (isFlush && isStraight && SortedValues[0] == 14) return 10; // Royal Flush
            if (isFlush && isStraight) return 9; // Straight Flush
            if (valueCounts.Values.Contains(4)) return 8; // Four of a Kind
            if (valueCounts.Values.Contains(3) && valueCounts.Values.Contains(2)) return 7; // Full House
            if (isFlush) return 6; // Flush
            if (isStraight) return 5; // Straight
            if (valueCounts.Values.Contains(3)) return 4; // Three of a Kind
            if (valueCounts.Values.Count(v => v == 2) == 2) return 3; // Two Pair
            if (valueCounts.Values.Contains(2)) return 2; // One Pair
            return 1; // High Card
        }

        public int CompareTo(PokerHandValidator other)
        {
            if (Rank != other.Rank) return other.Rank.CompareTo(Rank); // Higher rank first
            for (int i = 0; i < SortedValues.Length; i++)
            {
                if (SortedValues[i] != other.SortedValues[i])
                    return other.SortedValues[i].CompareTo(SortedValues[i]); // Higher value first
            }
            return 0;
        }

        public override string ToString() => Hand;

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        //[TestMethod]
        //public void TestMethod1()
        //{
        //    // Arrange
        //    var expected = new List<PokerHandValidator> {
        //    new PokerHandValidator("KS AS TS QS JS"),
        //    new PokerHandValidator("2H 3H 4H 5H 6H"),
        //    new PokerHandValidator("AS AD AC AH JD"),
        //    new PokerHandValidator("JS JD JC JH 3D"),
        //    new PokerHandValidator("2S AH 2H AS AC"),
        //    new PokerHandValidator("AS 3S 4S 8S 2S"),
        //    new PokerHandValidator("2H 3H 5H 6H 7H"),
        //    new PokerHandValidator("2S 3H 4H 5S 6C"),
        //    new PokerHandValidator("2D AC 3H 4H 5S"),
        //    new PokerHandValidator("AH AC 5H 6H AS"),
        //    new PokerHandValidator("2S 2H 4H 5S 4C"),
        //    new PokerHandValidator("AH AC 5H 6H 7S"),
        //    new PokerHandValidator("AH AC 4H 6H 7S"),
        //    new PokerHandValidator("2S AH 4H 5S KC"),
        //    new PokerHandValidator("2S 3H 6H 7S 9C")
        //};
        //    var random = new Random((int)DateTime.Now.Ticks);
        //    var actual = expected.OrderBy(x => random.Next()).ToList();
        //    // Act
        //    actual.Sort();
        //    // Assert
        //    for (var i = 0; i < expected.Count; i++)
        //        Assert.AreEqual(expected[i], actual[i], "Unexpected sorting order at index {0}", i);
        //}
    }
}
