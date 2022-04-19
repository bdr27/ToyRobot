using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot;

namespace ToyRobotTests
{

    [TestClass]
    public class LeftTests
    {
        private readonly RobotTable table;
        public LeftTests()
        {
            table = new RobotTable(6,6);
        }

        [TestMethod]
        public void LeftWithoutPlace()
        {
            Robot robot = new(table);
            Assert.IsFalse(robot.Left());
        }


        [TestMethod]
        public void LeftAroundTheWorld()
        {
            Robot robot = new(table);
            Assert.IsTrue(robot.Place(0, 0, RobotDirection.NORTH));
            Assert.AreEqual(RobotDirection.NORTH, robot.GetRobotDirection());
            Assert.IsTrue(robot.Left());
            Assert.AreEqual(RobotDirection.WEST, robot.GetRobotDirection());
            Assert.IsTrue(robot.Left());
            Assert.AreEqual(RobotDirection.SOUTH, robot.GetRobotDirection());
            Assert.IsTrue(robot.Left());
            Assert.AreEqual(RobotDirection.EAST, robot.GetRobotDirection());
            Assert.IsTrue(robot.Left());
            Assert.AreEqual(RobotDirection.NORTH, robot.GetRobotDirection());
        }
    }
}
