using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlFlowApp;

namespace TestProject
{
    internal class LoopTests
    {
        //object initialization
        //[TestCase(new List<int>(){-1,8,0}, 8)]
        //public void GivenList_HighestForEachLoop_ReturnsHighest(List<int> list, int highest)
        //{
        //    Assert.That(LoopTypes.HighestForEachLoop(list), Is.EqualTo(highest));
        //}

        #region Tests for Highest
        [Test]
        public void GivenMinus1and0and8_HighestForEachLoop_Returns8()
        {
            var list = new List<int> { -1, 0, 8 };
            Assert.That(LoopTypes.HighestForEachLoop(list), Is.EqualTo(8));
        }

        [Test]
        public void Given8and0andMinus1_HighestForEachLoop_Returns8()
        {
            var list = new List<int> { 8, 0, -1 };
            Assert.That(LoopTypes.HighestForEachLoop(list), Is.EqualTo(8));
        }

        [Test]
        public void GivenMinus1and0and8_HighestForLoop_Returns8()
        {
            var list = new List<int> { -1, 0, 8 };
            Assert.That(LoopTypes.HighestForLoop(list), Is.EqualTo(8));
        }

        [Test]
        public void Given8and0andMinus1_HighestForLoop_Returns8()
        {
            var list = new List<int> { 8, 0, -1 };
            Assert.That(LoopTypes.HighestForLoop(list), Is.EqualTo(8));
        }

        [Test]
        public void GivenMinus1and0and8_HighestWhileLoop_Returns8()
        {
            var list = new List<int> { -1, 0, 8 };
            Assert.That(LoopTypes.HighestWhileLoop(list), Is.EqualTo(8));
        }

        [Test]
        public void Given8and0andMinus1_HighestWhileLoop_Returns8()
        {
            var list = new List<int> { 8, 0, -1 };
            Assert.That(LoopTypes.HighestWhileLoop(list), Is.EqualTo(8));
        }

        [Test]
        public void GivenMinus1and0and8_HighestDoWhileLoop_Returns8()
        {
            var list = new List<int> { -1, 0, 8 };
            Assert.That(LoopTypes.HighestDoWhileLoop(list), Is.EqualTo(8));
        }

        [Test]
        public void Given8and0andMinus1_HighestDoWhileLoop_Returns8()
        {
            var list = new List<int> { 8, 0, -1 };
            Assert.That(LoopTypes.HighestDoWhileLoop(list), Is.EqualTo(8));
        }
        #endregion

        #region Tests for Lowest
        [Test]
        public void GivenMinus1and0and8_LowestForEachLoop_ReturnsMinus1()
        {
            var list = new List<int> { -1, 0, 8 };
            Assert.That(LoopTypes.LowestForEachLoop(list), Is.EqualTo(-1));
        }

        [Test]
        public void Given8and0andMinus1_LowestForEachLoop_ReturnsMinus1()
        {
            var list = new List<int> { 8, 0, -1 };
            Assert.That(LoopTypes.LowestForEachLoop(list), Is.EqualTo(-1));
        }

        [Test]
        public void GivenMinus1and0and8_LowestForLoop_ReturnsMinus1()
        {
            var list = new List<int> { -1, 0, 8 };
            Assert.That(LoopTypes.LowestForLoop(list), Is.EqualTo(-1));
        }

        [Test]
        public void Given8and0andMinus1_LowestForLoop_ReturnsMinus1()
        {
            var list = new List<int> { 8, 0, -1 };
            Assert.That(LoopTypes.LowestForLoop(list), Is.EqualTo(-1));
        }

        [Test]
        public void GivenMinus1and0and8_LowestWhileLoop_ReturnsMinus1()
        {
            var list = new List<int> { -1, 0, 8 };
            Assert.That(LoopTypes.LowestWhileLoop(list), Is.EqualTo(-1));
        }

        [Test]
        public void Given8and0andMinus1_LowestWhileLoop_ReturnsMinus1()
        {
            var list = new List<int> { 8, 0, -1 };
            Assert.That(LoopTypes.LowestWhileLoop(list), Is.EqualTo(-1));
        }

        [Test]
        public void GivenMinus1and0and8_LowestDoWhileLoop_ReturnsMinus1()
        {
            var list = new List<int> { -1, 0, 8 };
            Assert.That(LoopTypes.LowestDoWhileLoop(list), Is.EqualTo(-1));
        }

        [Test]
        public void Given8and0andMinus1_LowestDoWhileLoop_ReturnsMinus1()
        {
            var list = new List<int> { 8, 0, -1 };
            Assert.That(LoopTypes.LowestDoWhileLoop(list), Is.EqualTo(-1));
        }
        #endregion
    }
}
