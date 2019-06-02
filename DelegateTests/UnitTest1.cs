using NUnit.Framework;
using System;

namespace Tests
{
    public class MyArgs : EventArgs
    {

    }
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        void OnEvent(object sender,EventArgs e)
        {
            Console.WriteLine(e.GetType().ToString());
        }
        [Test]
        public void Passed()
        {
            Delegate @delegate = new EventHandler(OnEvent);
            @delegate.DynamicInvoke(this, new MyArgs());
        }
        [Test]
        public void Failed()
        {
            Delegate @delegate = new EventHandler(OnEvent);
            Assert.Throws<ArgumentException>(() => @delegate.DynamicInvoke(this, 1));
        }
    }
}