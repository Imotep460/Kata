using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestKata.Unittests
{
    [TestClass]
    public class SumOfOddNum
    {
        // Okay, here's how I derived the mathmatical formula to solve this kata.
        // It was a fun journey, even though it feels like I took the long way. 
        // Eventually ending up at the perfect solution was well worth it!
        //
        // 1 |         1
        // 2 |       3   5
        // 3 |     7   9  11
        // 4 |   13  15  17  19
        // 5 | 21  23  25  27  29
        // ...
        //
        // An important thing to know is the number that the requested row [n]
        // starts with. That provides a great anchor point for computing the
        // sum of the row. So finding that number is what I started out with.
        //
        // Given for example [n] = 4, rows 1, 2 and 3 must be skipped.
        // Those contain respectively 1, 2 and 3 odd numbers, which means that in
        // total 6 odd numbers must be skipped, in order to get to the starting
        // odd number 13 for row 4.
        // 
        // The number of odd numbers to skip can be computed, based on the row
        // number [n]. For [n] = 4, look again at the part of the triangle that has
        // to be skipped, only formatted a bit differently:
        //
        //   | .
        //   |   .
        // 1 |  1   .
        // 2 |  3  5   . 
        // 3 |  7  9  11  .
        //   +--------------
        //
        // Is can in fact be represented as a simple triange. Let's extend it into a rectangle.
        //
        //   | .x  x  x      ^     The rectangle has height [n] and width [n] - 1
        //   |   . x  x      |
        // 1 |  1   . x     [n]
        // 2 |  3  5   .     |
        // 3 |  7  9  11  .  v
        //   +--------------
        //   <-- [n]-1 -->
        //
        // This makes it clear how we can compute the surface of the triangle,
        // which represents the number of odds to skip! It's half the surface of
        // the above rectangle:
        //
        //   [skip] = ([n] - 1) * [n] / 2
        //
        // Given that we start at odd number 1 and have [skip] odds to skip, the
        // following formula delivers us the starting number for row [n]:
        //
        //   [start] = 1 + [skip] * 2 
        //
        // Okay, this is going very well. We know the odd number that the
        // requested row starts with. Let's see if this indeed works out as intended...
        //
        //   given [n] = 4
        //   [skip] = (4 - 1) * 4 / 2 = 6
        //   [start] = 1 + 6 * 2 = 13
        //
        // Hurray! Row 4 does start with 13, so we're on track. Now we have to find a
        // way to compute the total for row 4, which looks like:
        //
        //   13 + 15 + 17 + 19
        //
        // We might be tempted to simply write a loop here, which produces the values
        // of the row, after which they are added up to find the row sum. Let's no go
        // that way. Instead, we can also split this problem into two separate computations:
        //
        //   13 + 13 + 13 + 13
        //         2 +  4 +  6 + 
        //   -----------------
        //                  64
        //
        // See what I did there? I basically split the computation into two
        // surface computations: a rectangular one and a triangular one.
        // These two can be added up to get to the total for row 4.
        //
        // The surface of the rectangular part can simply be computed using:
        //
        //   [rectangle surface] = [n] * [start]
        //
        // For the triangular part, we have a triangle that can be represented like this:
        //    .
        //   1  . x x x   ^
        //   1  . x x x   |
        //   1 1  . x x   2 * ([n] - 1)
        //   1 1  . x x   |
        //   1 1 1  . x   |
        //   1 1 1  . x   v
        //   <---[n]--> 
        //
        // So the surface of the triangular part can be computed using:
        //
        //   [triangle surface] = [n] * (2 * ([n] - 1)) / 2
        //                      = [n] * ([n] - 1)
        //
        // Combining the rectangular en triangular parts brings us:
        //
        //   [sum of row] = [rectangle surface] + [triangle surface] 
        //                = [n] * [start] + [n] * ([n] - 1)
        //                = [n] * [start] + [n]^2 - [n]
        //
        // Substituting [start]:
        // 
        //   [sum of row] = [n] * (1 + [skip] * 2) + [n]^2 - [n]
        //
        // Substituting [skip]:
        //
        //   [sum of row] = [n] * (1 + (([n] - 1) * [n] / 2) * 2) + [n]^2 - [n]
        //
        // Okay, wow, man, hold on... this must be simplified.
        //
        //   [sum of row] = [n] * (1 + ([n] - 1) * [n]) + [n]^2 - [n]
        //                = [n] * (1 + [n]^2 - [n]) + [n]^2 - [n]
        //                = [n] + [n]^3 - [n]^2 + [n]^2 - [n]
        //                = [n]^3
        //
        // That's what I call simplified!!
        // So the final outcome of my journey, is the following formula:
        //
        //   Given row number [n] in the triangle of consecutive odd numbers,
        //   the row sum is [n]^3
        //
        // Okay, let's write up some code to make that work...

        public long SumOfOddNum1(long n)
        {
            return n * n * n;
        }
        // Done! :-)

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(1, SumOfOddNum1(1));
            Assert.AreEqual(74088, SumOfOddNum1(42));
        }
    }
}
