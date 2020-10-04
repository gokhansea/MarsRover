using NUnit.Framework;
using System;

namespace MarsRover.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

            Rover rover = new Rover(10, 10);
            var result = rover.Move(2, 3, "N", "LLMLRMMM");
            if (!result.IsError)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail(result.Message);
            }

        }

        [Test]
        public void RoverPerformans()
        {

            Rover rover = new Rover(100000, 1000000);
            var result = rover.Move(2434, 32233, "N", "LLMLRMMMRRRLRMMMMMRRRRMMRRMMMMMRRLMMMMRRMMMMMRRLMMMLLMLRMMMRRRLRMMMMMRRRRMMRRLLMLRMMMRRRLRMMMMMRRRLRMMRRLLMLRMMMRRRLRMMMMMLRRRRMMRRLLMLRMMLMRRRLRMMMMMRRRRMMRRMM");
            if (!result.IsError)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail(result.Message);
            }

        }
    }
}