using NUnit.Framework;
using System;
using MyQADLL.src;

namespace MyQADLL.test
{
    [TestFixture()]
    public class CounterTest
    {
        [Test()]
        public void CounterInitTest()
        {
            Counter counter = new Counter();
            Assert.AreEqual(0, counter.Value);
        }

        [Test()]
        public void IncrementTest()
        {
            Counter counter = new Counter();
            counter.Increment();
            Assert.AreEqual(1, counter.Value);
        }

        [Test()]
        public void ResetTest()
        {
            Counter counter = new Counter();
            counter.Increment();
            counter.Reset();
            Assert.AreEqual(0, counter.Value);
        }

        [Test()]
        public void PositiveDecreaseTest()
        {
            Counter counter = new Counter();
            counter.Increment();
            counter.Increment();
            counter.Decrease();
            Assert.AreEqual(1, counter.Value);
        }

        [Test()]
        public void NegativeDecreaseTest()
        {
            Counter counter = new Counter();
            counter.Decrease();
            Assert.AreEqual(0, counter.Value);
        }
    }
}
