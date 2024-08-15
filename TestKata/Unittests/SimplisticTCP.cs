using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestKata.Unittests
{
    [TestClass]
    public class SimplisticTCP
    {
        public string TraverseStates0(string[] events)
        {
            string state = "CLOSED";

            foreach (string ev in events)
            {
                if (fsm[state].ContainsKey(ev))
                {
                    state = fsm[state][ev];
                }
                else
                {
                    return "ERROR";
                }
            }

            return state;
        }

        private readonly Dictionary<string, Dictionary<string, string>> fsm = new Dictionary<string, Dictionary<string, string>>
        {
            { "CLOSED", new Dictionary<string, string>
            {
                { "APP_PASSIVE_OPEN", "LISTEN" },
                { "APP_ACTIVE_OPEN", "SYN_SENT" }
            }
            },
            { "LISTEN", new Dictionary<string, string>
            {
                { "RCV_SYN", "SYN_RCVD" },
                { "APP_SEND", "SYN_SENT" },
                { "APP_CLOSE", "CLOSED" }
            }
            },
            { "SYN_RCVD", new Dictionary<string, string>
            {
                { "APP_CLOSE", "FIN_WAIT_1" },
                { "RCV_ACK", "ESTABLISHED" }
            }
            },
            { "SYN_SENT", new Dictionary<string, string>
            {
                { "RCV_SYN", "SYN_RCVD" },
                { "RCV_SYN_ACK", "ESTABLISHED" },
                { "APP_CLOSE", "CLOSED" }
            }
            },
            { "ESTABLISHED", new Dictionary<string, string>
            {
                { "APP_CLOSE", "FIN_WAIT_1" },
                { "RCV_FIN", "CLOSE_WAIT" }
            }
            },
            { "FIN_WAIT_1", new Dictionary<string, string>
            {
                { "RCV_FIN", "CLOSING" },
                { "RCV_FIN_ACK", "TIME_WAIT" },
                { "RCV_ACK", "FIN_WAIT_2" }
            }
            },
            { "CLOSING", new Dictionary<string, string>
            {
                { "RCV_ACK", "TIME_WAIT" }
            }
            },
            { "FIN_WAIT_2", new Dictionary<string, string>
            {
                { "RCV_FIN", "TIME_WAIT" }
            }
            },
            { "TIME_WAIT", new Dictionary<string, string>
            {
                { "APP_TIMEOUT", "CLOSED" }
            }
            },
            { "CLOSE_WAIT", new Dictionary<string, string>
            {
                { "APP_CLOSE", "LAST_ACK" }
            }
            },
            { "LAST_ACK", new Dictionary<string, string>
            {
                { "RCV_ACK", "CLOSED" }
            }
            }
        };

        /// <summary>
        /// Solution from Codewars
        /// </summary>
        public string TraverseStates1(string[] r)
        {
            var tome = new Dictionary<string, Dictionary<string, string>>()
            {
                {"CLOSED",new Dictionary<string,string>(){{"APP_PASSIVE_OPEN","LISTEN"},{"APP_ACTIVE_OPEN","SYN_SENT"}}},
                {"LISTEN",new Dictionary<string,string>(){{"RCV_SYN","SYN_RCVD"},{"APP_SEND","SYN_SENT"},{"APP_CLOSE","CLOSED"}}},
                {"SYN_SENT",new Dictionary<string,string>(){{"RCV_SYN","SYN_RCVD"},{"RCV_SYN_ACK","ESTABLISHED"},{"APP_CLOSE","CLOSED"}}},
                {"SYN_RCVD",new Dictionary<string,string>(){{"APP_CLOSE","FIN_WAIT_1"},{"RCV_ACK","ESTABLISHED"}}},
                {"ESTABLISHED",new Dictionary<string,string>(){{"APP_CLOSE","FIN_WAIT_1"},{"RCV_FIN","CLOSE_WAIT"}}},
                {"CLOSE_WAIT",new Dictionary<string,string>(){{"APP_CLOSE","LAST_ACK"}}},
                {"LAST_ACK",new Dictionary<string,string>(){{"RCV_ACK","CLOSED"}}},
                {"FIN_WAIT_1",new Dictionary<string,string>(){{"RCV_FIN","CLOSING"},{"RCV_FIN_ACK","TIME_WAIT"},{"RCV_ACK","FIN_WAIT_2"}}},
                {"FIN_WAIT_2",new Dictionary<string,string>(){{"RCV_FIN","TIME_WAIT"}}},
                {"CLOSING",new Dictionary<string,string>(){{"RCV_ACK","TIME_WAIT"}}},
                {"TIME_WAIT",new Dictionary<string,string>(){{"APP_TIMEOUT","CLOSED"}}}
            };
            
            var state = "CLOSED";
            
            foreach (var s in r)
            {
                if (tome[state].ContainsKey(s))
                {
                    state = tome[state][s];
                }
                else
                {
                    return "ERROR";
                }
            }

            return state;
        }

        public Dictionary<string, string> transitions = new Dictionary<string, string>()
        {
            // Key = <CurrentState> <Event>   Value = <NextEvent>
            ["CLOSED APP_PASSIVE_OPEN"] = "LISTEN",
            ["CLOSED APP_ACTIVE_OPEN"] = "SYN_SENT",
            ["LISTEN RCV_SYN"] = "SYN_RCVD",
            ["LISTEN APP_SEND"] = "SYN_SENT",
            ["LISTEN APP_CLOSE"] = "CLOSED",
            ["SYN_RCVD APP_CLOSE"] = "FIN_WAIT_1",
            ["SYN_RCVD RCV_ACK"] = "ESTABLISHED",
            ["SYN_SENT RCV_SYN"] = "SYN_RCVD",
            ["SYN_SENT RCV_SYN_ACK"] = "ESTABLISHED",
            ["SYN_SENT APP_CLOSE"] = "CLOSED",
            ["ESTABLISHED APP_CLOSE"] = "FIN_WAIT_1",
            ["ESTABLISHED RCV_FIN"] = "CLOSE_WAIT",
            ["FIN_WAIT_1 RCV_FIN"] = "CLOSING",
            ["FIN_WAIT_1 RCV_FIN_ACK"] = "TIME_WAIT",
            ["FIN_WAIT_1 RCV_ACK"] = "FIN_WAIT_2",
            ["CLOSING RCV_ACK"] = "TIME_WAIT",
            ["FIN_WAIT_2 RCV_FIN"] = "TIME_WAIT",
            ["TIME_WAIT APP_TIMEOUT"] = "CLOSED",
            ["CLOSE_WAIT APP_CLOSE"] = "LAST_ACK",
            ["LAST_ACK RCV_ACK"] = "CLOSED"
        };

        /// <summary>
        /// Solution from Codewars
        /// </summary>
        public string TraverseStates2(string[] events)
        {
            var state = "CLOSED";

            foreach (var currentEvent in events)
            {
                var key = state + " " + currentEvent;
                if (!transitions.ContainsKey(key)) return "ERROR";
                state = transitions[key];
            }

            return state;
        }

        [TestMethod]
        public void TestMethod0()
        {
            Assert.AreEqual("CLOSE_WAIT", TraverseStates0(new[] { "APP_ACTIVE_OPEN", "RCV_SYN_ACK", "RCV_FIN" }));
            Assert.AreEqual("ESTABLISHED", TraverseStates0(new[] { "APP_PASSIVE_OPEN", "RCV_SYN", "RCV_ACK" }));
            Assert.AreEqual("LAST_ACK", TraverseStates0(new[] { "APP_ACTIVE_OPEN", "RCV_SYN_ACK", "RCV_FIN", "APP_CLOSE" }));
            Assert.AreEqual("SYN_SENT", TraverseStates0(new[] { "APP_ACTIVE_OPEN" }));
            Assert.AreEqual("ERROR", TraverseStates0(new[] { "APP_PASSIVE_OPEN", "RCV_SYN", "RCV_ACK", "APP_CLOSE", "APP_SEND" }));
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual("CLOSE_WAIT", TraverseStates1(new[] { "APP_ACTIVE_OPEN", "RCV_SYN_ACK", "RCV_FIN" }));
            Assert.AreEqual("ESTABLISHED", TraverseStates1(new[] { "APP_PASSIVE_OPEN", "RCV_SYN", "RCV_ACK" }));
            Assert.AreEqual("LAST_ACK", TraverseStates1(new[] { "APP_ACTIVE_OPEN", "RCV_SYN_ACK", "RCV_FIN", "APP_CLOSE" }));
            Assert.AreEqual("SYN_SENT", TraverseStates1(new[] { "APP_ACTIVE_OPEN" }));
            Assert.AreEqual("ERROR", TraverseStates1(new[] { "APP_PASSIVE_OPEN", "RCV_SYN", "RCV_ACK", "APP_CLOSE", "APP_SEND" }));
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual("CLOSE_WAIT", TraverseStates2(new[] { "APP_ACTIVE_OPEN", "RCV_SYN_ACK", "RCV_FIN" }));
            Assert.AreEqual("ESTABLISHED", TraverseStates2(new[] { "APP_PASSIVE_OPEN", "RCV_SYN", "RCV_ACK" }));
            Assert.AreEqual("LAST_ACK", TraverseStates2(new[] { "APP_ACTIVE_OPEN", "RCV_SYN_ACK", "RCV_FIN", "APP_CLOSE" }));
            Assert.AreEqual("SYN_SENT", TraverseStates2(new[] { "APP_ACTIVE_OPEN" }));
            Assert.AreEqual("ERROR", TraverseStates2(new[] { "APP_PASSIVE_OPEN", "RCV_SYN", "RCV_ACK", "APP_CLOSE", "APP_SEND" }));
        }
    }
}
