using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QueueUnitTest
{
    [TestClass]
    public class QueueUnitTestsClass
    {
        private Queue.Queue<int> _queue;

        [TestInitialize]
        public void Initialization()
        {
            _queue = new Queue.Queue<int>(3);
            for (int i = 0; i < 7; i++)
            {
                _queue.Push(i);
            }
        }

        [TestMethod]
        public void QueueCountTest()
        {
            Assert.IsTrue(_queue.Count == 7);
        }

        [TestMethod]
        public void QueuePopMethodTest()
        {
            _queue.Pop();
            _queue.Pop();            
            Assert.IsTrue(_queue.Pop() == 2);
        }

        [TestMethod]
        public void QueuePeekCountTest()
        {
            _queue.Peek();
            Assert.IsTrue(_queue.Count == 7);
        }

        [TestMethod]
        public void QueuePeekValueTest()
        {
            Assert.IsTrue(_queue.Peek() == 0);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void InvalidOperationExceptionTest()
        {
            for (int i = 0; i < 8; i++)
            {
                _queue.Pop();
            }
        }
    }
}
