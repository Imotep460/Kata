//using System;
//using System.Text;
//using System.Collections.Generic;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace TestKata.Unittests
//{
    /// <summary>
    /// You are given a node that is the beginning of a linked list. This list always contains a tail and a loop.
    /// Your objective is to determine the length of the loop.
    /// For example in the following picture the tail's size is 3 and the loop size is 11.
    /// # Use the `next' method to get the following node.
    /// node.next
    /// </summary>
    //[TestClass]
    //public class GetLoopSize
    //{
    //    public static int GetLoopSize1(LoopDetector.Node startNode)
    //    {
    //        List<LoopDetector.Node> nodeList = new List<LoopDetector.Node>();
    //        while (startNode.next != null)
    //        {
    //            nodeList.Add(startNode);
    //            LoopDetector.Node last = startNode;
    //            startNode = startNode.next;
    //            last.next = null;
    //        }
    //        for (int i = 0; ; i++)
    //        {
    //            if (startNode == nodeList[nodeList.Count - 1])
    //            {
    //                return i;
    //            }
    //        }
    //    }

    //    public static int getLoopSize(LoopDetector.Node startNode)
    //    {
    //        int lenght = 1;
    //        LoopDetector.Node tortoise = startNode.next;
    //        LoopDetector.Node hare = startNode.next.next;

    //        // Find the cycle, the hare and the tortoise will encouter at the cycle start
    //        while (tortoise != hare)
    //        {
    //            tortoise = tortoise.next;
    //            hare = hare.next.next;
    //        }

    //        // Find the lenght of the cycle - count the number of step to return at the cycle beginning
    //        hare = tortoise.next;
    //        while (tortoise != hare)
    //        {
    //            hare = hare.next;
    //            lenght++;
    //        }
    //        return lenght;
    //    }

    //    public static int GetLoopSize2(LoopDetector.Node startNode)
    //    {
    //        var dict = new Dictionary<LoopDetector.Node, int>();
    //        int index = 0;
    //        while (true)
    //        {
    //            if (dict.ContainsKey(startNode))
    //                return index - dict[startNode];
    //            dict[startNode] = index++;
    //            startNode = startNode.next;
    //        }
    //        return 0;
    //    }
//    public void RandomLongChainNodesWithLoopSize1087()
//    {
//        var n1 = LoopDetector.createChain(3904, 1087);
//        Assert.AreEqual(1087, Kata.getLoopSize(n1));
//    }
//    [TestMethod]
//        public void TestMethod1()
//        {
//        public void FourNodesWithLoopSize3()
//        {
//            var n1 = new LoopDetector.Node();
//            var n2 = new LoopDetector.Node();
//            var n3 = new LoopDetector.Node();
//            var n4 = new LoopDetector.Node();
//            n1.next = n2;
//            n2.next = n3;
//            n3.next = n4;
//            n4.next = n2;
//            Assert.AreEqual(3, Kata.getLoopSize(n1));
//        }

//        public void RandomChainNodesWithLoopSize30()
//        {
//            var n1 = LoopDetector.createChain(3, 30);
//            Assert.AreEqual(30, Kata.getLoopSize(n1));
//        }


//    }
//}

