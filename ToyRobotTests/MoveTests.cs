using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot;

namespace ToyRobotTests
{

    [TestClass]
    public class MoveTests
    {
        private readonly RobotTable table;
        public MoveTests()
        {
            table = new RobotTable(6,6);
        }

        [TestMethod]
        public void MoveTestsNorthTests()
        {
            Robot robot = new(table);
            robot.Place(0, 4, RobotDirection.NORTH);
            Assert.IsTrue(robot.Move());
            Assert.AreEqual(5, robot.GetY());
            Assert.IsFalse(robot.Move());
            Assert.AreEqual(5, robot.GetY());
        }


        [TestMethod]
        public void MoveTestsSouthTests()
        {
            Robot robot = new(table);
            robot.Place(0, 1, RobotDirection.SOUTH);
            Assert.IsTrue(robot.Move());
            Assert.AreEqual(0, robot.GetY());
            Assert.IsFalse(robot.Move());
            Assert.AreEqual(0, robot.GetY());
        }


        [TestMethod]
        public void MoveTestsEastTests()
        {
            Robot robot = new(table);
            robot.Place(4, 4, RobotDirection.EAST);
            Assert.IsTrue(robot.Move());
            Assert.AreEqual(5, robot.GetX());
            Assert.IsFalse(robot.Move());
            Assert.AreEqual(5, robot.GetX());
        }


        [TestMethod]
        public void MoveTestsWestTests()
        {
            Robot robot = new(table);
            robot.Place(1, 4, RobotDirection.WEST);
            Assert.IsTrue(robot.Move());
            Assert.AreEqual(0, robot.GetX());
            Assert.IsFalse(robot.Move());
            Assert.AreEqual(0, robot.GetX());
        }

        [TestMethod]
        public void MoveBeforePlace()
        {
            Robot robot = new(table);
            Assert.IsFalse(robot.Move());
        }

        [TestMethod]
        public void MoveBeforePlaceThenPlace()
        {
            Robot robot = new(table);
            Assert.IsFalse(robot.Move());
            robot.Place(1, 4, RobotDirection.WEST);
            Assert.IsTrue(robot.Move());
            Assert.AreEqual(0, robot.GetX());
            Assert.IsFalse(robot.Move());
            Assert.AreEqual(0, robot.GetX());
        }
    }
}
