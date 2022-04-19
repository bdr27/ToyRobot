using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot;

namespace ToyRobotTests
{

    [TestClass]
    public class PlaceTests
    {
        private readonly RobotTable table;
        public PlaceTests()
        {
            table = new RobotTable(6,6);
        }

        [TestMethod]
        public void PlaceValidLocation()
        {
            Robot robot = new(table);
            Assert.IsTrue(robot.Place(0, 4, RobotDirection.NORTH));
            Assert.AreEqual(0, robot.GetX());
            Assert.AreEqual(4, robot.GetY());
            Assert.AreEqual(RobotDirection.NORTH, robot.GetRobotDirection());
            Assert.IsTrue(robot.IsRobotPlaced());
        }


        [TestMethod]
        public void PlaceInvalidLocation()
        {
            Robot robot = new(table);
            Assert.IsFalse(robot.Place(78, 96, RobotDirection.NORTH));
            Assert.IsFalse(robot.IsRobotPlaced());
        }

        [TestMethod]
        public void PlaceInvalidLocationX()
        {
            Robot robot = new(table);
            Assert.IsFalse(robot.Place(98, 4, RobotDirection.NORTH));
            Assert.IsFalse(robot.IsRobotPlaced());
        }

        [TestMethod]
        public void PlaceInvalidLocationY()
        {
            Robot robot = new(table);
            Assert.IsFalse(robot.Place(0, 96, RobotDirection.NORTH));
            Assert.IsFalse(robot.IsRobotPlaced());
        }

        [TestMethod]
        public void PlaceWithoutDirection()
        {
            Robot robot = new(table);
            Assert.IsFalse(robot.Place(0, 4));
            Assert.IsFalse(robot.IsRobotPlaced());
        }

        [TestMethod]
        public void RePlaceValidLocation()
        {
            Robot robot = new(table);
            Assert.IsTrue(robot.Place(0, 4, RobotDirection.NORTH));
            Assert.AreEqual(0, robot.GetX());
            Assert.AreEqual(4, robot.GetY());
            Assert.AreEqual(RobotDirection.NORTH, robot.GetRobotDirection());
            Assert.IsTrue(robot.IsRobotPlaced());
            Assert.IsTrue(robot.Place(3, 3));
            Assert.AreEqual(3, robot.GetX());
            Assert.AreEqual(3, robot.GetY());
            Assert.AreEqual(RobotDirection.NORTH, robot.GetRobotDirection());
        }

        [TestMethod]
        public void RePlaceInvalidLocation()
        {
            Robot robot = new(table);
            Assert.IsTrue(robot.Place(0, 4, RobotDirection.NORTH));
            Assert.IsTrue(robot.IsRobotPlaced());
            Assert.AreEqual(RobotDirection.NORTH, robot.GetRobotDirection());
            Assert.AreEqual(0, robot.GetX());
            Assert.AreEqual(4, robot.GetY());
            Assert.IsFalse(robot.Place(96, 98));
            Assert.IsFalse(robot.IsRobotPlaced());
            Assert.AreEqual(0, robot.GetX());
            Assert.AreEqual(4, robot.GetY());
            Assert.AreEqual(RobotDirection.NORTH, robot.GetRobotDirection());
        }

        [TestMethod]
        public void RePlaceInvalidLocationX()
        {
            Robot robot = new(table);
            Assert.IsTrue(robot.Place(0, 4, RobotDirection.NORTH));
            Assert.IsTrue(robot.IsRobotPlaced());
            Assert.AreEqual(RobotDirection.NORTH, robot.GetRobotDirection());
            Assert.AreEqual(0, robot.GetX());
            Assert.AreEqual(4, robot.GetY());
            Assert.IsFalse(robot.Place(96, 4));
            Assert.IsFalse(robot.IsRobotPlaced());
            Assert.AreEqual(0, robot.GetX());
            Assert.AreEqual(4, robot.GetY());
            Assert.AreEqual(RobotDirection.NORTH, robot.GetRobotDirection());
        }

        [TestMethod]
        public void RePlaceInvalidLocationY()
        {
            Robot robot = new(table);
            Assert.IsTrue(robot.Place(0, 4, RobotDirection.NORTH));
            Assert.IsTrue(robot.IsRobotPlaced());
            Assert.AreEqual(RobotDirection.NORTH, robot.GetRobotDirection());
            Assert.AreEqual(0, robot.GetX());
            Assert.AreEqual(4, robot.GetY());
            Assert.IsFalse(robot.Place(0, 98));
            Assert.IsFalse(robot.IsRobotPlaced());
            Assert.AreEqual(0, robot.GetX());
            Assert.AreEqual(4, robot.GetY());
            Assert.AreEqual(RobotDirection.NORTH, robot.GetRobotDirection());
        }
    }
}
