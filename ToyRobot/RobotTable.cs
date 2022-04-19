namespace ToyRobot
{
    public class RobotTable
    {
        private readonly int height;
        private readonly int width;

        public RobotTable(int height, int width)
        {
            this.height = height;
            this.width = width;
        }

        /// <summary>
        /// Checks if x and y are valid locations on the table for the robot
        /// </summary>
        /// <param name="x">x location</param>
        /// <param name="y">y location</param>
        /// <returns>true robot can be put on the table, false it cannot</returns>
        public bool ValidLocation(int robotX, int robotY)
        {
            if(robotX >= 0 && robotY >= 0 && robotX < width && robotY < height)
            {
                return true;
            }
            return false;
        }

        public int GetHeight()
        {
            return height;
        }

        public int GetWidth()
        {
            return width;
        }
    }
}
