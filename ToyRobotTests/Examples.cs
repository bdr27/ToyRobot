using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot;

namespace ToyRobotTests
{
    [TestClass]
    public class Examples
    {
        private readonly RobotTable table;

        public Examples()
        {
            table = new RobotTable(6,6);
        }
        [TestMethod]
        public void Example1()
        {
            Robot robot = new (table);
            robot.Place(0, 0, RobotDirection.NORTH);
            robot.Move();
            robot.Report();
            Assert.AreEqual(0, robot.GetX());
            Assert.AreEqual(1, robot.GetY());
            Assert.AreEqual(RobotDirection.NORTH, robot.GetRobotDirection());
        }


        [TestMethod]
        public void Example2()
        {
            Robot robot = new (table);
            robot.Place(0, 0, RobotDirection.NORTH);
            robot.Left();
            robot.Report();
            Assert.AreEqual(0, robot.GetX());
            Assert.AreEqual(0, robot.GetY());
            Assert.AreEqual(RobotDirection.WEST, robot.GetRobotDirection());
        }


        [TestMethod]
        public void Example3()
        {
            Robot robot = new (table);
            robot.Place(1, 2, RobotDirection.EAST);
            robot.Move();
            robot.Move();
            robot.Left();
            robot.Move();
            robot.Report();
            Assert.AreEqual(3, robot.GetX());
            Assert.AreEqual(3, robot.GetY());
            Assert.AreEqual(RobotDirection.NORTH, robot.GetRobotDirection());
        }


        [TestMethod]
        public void Example4()
        {
            Robot robot = new (table);
            robot.Place(1, 2, RobotDirection.EAST);
            robot.Move();
            robot.Left();
            robot.Move();
            robot.Place(3, 1);
            robot.Move();
            robot.Report();
            Assert.AreEqual(3, robot.GetX());
            Assert.AreEqual(2, robot.GetY());
            Assert.AreEqual(RobotDirection.NORTH, robot.GetRobotDirection());
        }
    }
}