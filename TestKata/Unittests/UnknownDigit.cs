using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TestKata.Unittests
{
    /// <summary>
    /// To give credit where credit is due:
    /// This problem was taken from the ACMICPC-Northwest Regional Programming Contest.
    /// Thank you problem writers.
    /// 
    /// You are helping an archaeologist decipher some runes.
    /// He knows that this ancient society used a Base 10 system,
    /// and that they never start a number with a leading zero.
    /// 
    /// He's figured out most of the digits as well as a few operators,
    /// but he needs your help to figure out the rest.
    /// 
    /// The professor will give you a simple math expression, of the form:
    /// 
    /// [number][op][number]= [number]
    /// 
    /// He has converted all of the runes he knows into digits.
    /// The only operators he knows are addition (+),subtraction(-), and multiplication(*),
    /// so those are the only ones that will appear.Each number will be in the range from -1000000 to 1000000,
    /// and will consist of only the digits 0-9, possibly a leading -, and maybe a few ? s.If there are ?s in an expression,
    /// they represent a digit rune that the professor doesn't know (never an operator, and never a leading -).
    /// 
    /// All of the ?s in an expression will represent the same digit (0-9), and it won't be one of the other given digits in the expression.
    /// No number will begin with a 0 unless the number itself is 0, therefore 00 would not be a valid number.
    /// 
    /// Given an expression, figure out the value of the rune represented by the question mark.
    /// 
    /// If more than one digit works, give the lowest one.
    /// If no digit works, well, that's bad news for the professor - it means that he's got some of his runes wrong.output -1 in that case.
    /// 
    /// Complete the method to solve the expression to find the value of the unknown rune.
    /// The method takes a string as a paramater repressenting the expression and will return an int value representing the unknown rune or -1 if no such rune exists.
    /// 
    /// Link to Kata: https://www.codewars.com/kata/546d15cebed2e10334000ed9
    /// </summary>
        [TestFixture]
    public class UnknownDigit
    {
        public int SolveExpression0(string expression)
        {
            // Split the expression into parts
            var match = Regex.Match(expression, @"([\-?0-9*+]+)=([\-?0-9]+)");
            if (!match.Success)
            {
                return -1;
            }

            string left = match.Groups[1].Value;
            string result = match.Groups[2].Value;

            string operand1 = "", operand2 = "", operatorSymbol = "";

            // Find the operator
            foreach (char op in new char[] { '+', '-', '*' })
            {
                if (left.Contains(op))
                {
                    var parts = left.Split(op);
                    if (parts.Length == 2)
                    {
                        operand1 = parts[0];
                        operand2 = parts[1];
                        operatorSymbol = op.ToString();
                        break;
                    }
                }
            }

            if (string.IsNullOrEmpty(operatorSymbol))
            {
                return -1; // Invalid expression
            }

            // Function to validate numbers (no leading zero unless the number is "0")
            bool IsValidNumber(string num)
            {
                return !(num.Length > 1 && num[0] == '0');
            }

            // Replace '?' with possible digits and test the equation
            var digitsInExpression = new HashSet<char>(expression.Replace("?", ""));

            for (char digit = '0'; digit <= '9'; digit++)
            {
                if (digitsInExpression.Contains(digit))
                {
                    continue; // Skip digits already in the expression
                }

                // Replace '?' with the current digit
                string operand1Test = operand1.Replace('?', digit);
                string operand2Test = operand2.Replace('?', digit);
                string resultTest = result.Replace('?', digit);

                // Validate all numbers
                if (!IsValidNumber(operand1Test) || !IsValidNumber(operand2Test) || !IsValidNumber(resultTest))
                {
                    continue;
                }

                // Convert to integers
                if (!int.TryParse(operand1Test, out int operand1Val) ||
                    !int.TryParse(operand2Test, out int operand2Val) ||
                    !int.TryParse(resultTest, out int resultVal))
                {
                    continue;
                }

                // Check if the equation holds
                bool equationHolds = false;
                if (operatorSymbol == "+")
                {
                    equationHolds = operand1Val + operand2Val == resultVal;
                }
                else if (operatorSymbol == "-")
                {
                    equationHolds = operand1Val - operand2Val == resultVal;
                }
                else if (operatorSymbol == "*")
                {
                    equationHolds = operand1Val * operand2Val == resultVal;
                }

                if (equationHolds)
                {
                    return digit - '0'; // Return the digit as an integer
                }
            }

            return -1; // No valid digit found
        }

        [Test]
        public void testSample()
        {
            Assert.That(SolveExpression0("1+1=?"), Is.EqualTo(2), "Answer for expression '1+1=?' ");
            Assert.That(SolveExpression0("123*45?=5?088"), Is.EqualTo(6), "Answer for expression '123*45?=5?088' ");
            Assert.That(SolveExpression0("-5?*-1=5?"), Is.EqualTo(0), "Answer for expression '-5?*-1=5?' ");
            Assert.That(SolveExpression0("19--45=5?"), Is.EqualTo(-1), "Answer for expression '19--45=5?' ");
            Assert.That(SolveExpression0("??*??=302?"), Is.EqualTo(5), "Answer for expression '??*??=302?' ");
            Assert.That(SolveExpression0("?*11=??"), Is.EqualTo(2), "Answer for expression '?*11=??' ");
            Assert.That(SolveExpression0("??*1=??"), Is.EqualTo(2), "Answer for expression '??*1=??' ");
            Assert.That(SolveExpression0("??+??=??"), Is.EqualTo(-1), "Answer for expression '??+??=??' ");
        }
    }
}
