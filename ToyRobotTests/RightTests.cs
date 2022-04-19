using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot;

namespace ToyRobotTests
{

    [TestClass]
    public class RightTests
    {
        private readonly RobotTable table;
        public RightTests()
        {
            table = new RobotTable(6,6);
        }

        [TestMethod]
        public void RightWithoutPlace()
        {
            Robot robot = new(table);
            Assert.IsFalse(robot.Right());
        }


        [TestMethod]
        public void RightAroundTheWorld()
        {
            Robot robot = new(table);
            Assert.IsTrue(robot.Place(0, 0, RobotDirection.NORTH));
            Assert.AreEqual(RobotDirection.NORTH, robot.GetRobotDirection());
            Assert.IsTrue(robot.Right());
            Assert.AreEqual(RobotDirection.EAST, robot.GetRobotDirection());
            Assert.IsTrue(robot.Right());
            Assert.AreEqual(RobotDirection.SOUTH, robot.GetRobotDirection());
            Assert.IsTrue(robot.Right());
            Assert.AreEqual(RobotDirection.WEST, robot.GetRobotDirection());
            Assert.IsTrue(robot.Right());
            Assert.AreEqual(RobotDirection.NORTH, robot.GetRobotDirection());
        }
    }
}
