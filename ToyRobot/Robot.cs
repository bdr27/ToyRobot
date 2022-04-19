namespace ToyRobot
{
    public class Robot
    {
        private readonly RobotTable table;
        private RobotDirection direction;
        private int x;
        private int y;
        private bool robotPlaced;

        public Robot(RobotTable table)
        {
            this.table = table;
            robotPlaced = false;
        }

        /// <summary>
        /// Places Robot the table at location x and y with the current facing direction
        /// </summary>
        /// <param name="x">X location on table</param>
        /// <param name="y">Y location on table</param>
        /// <returns>true if robot can be placed on table. False if robot can't</returns>
        public bool Place(int x, int y)
        {
            if(!robotPlaced)
            {
                return false;
            }
            return Place(x, y, direction);
        }

        /// <summary>
        /// Places Robot the table at location x and y with the current facing direction
        /// </summary>
        /// <param name="x">X location on table</param>
        /// <param name="y">Y location on table</param>
        /// <param name="direction">direction the robot is facing</param>
        /// <returns>true if robot can be placed on table. False if robot can't</returns>
        public bool Place(int x, int y, RobotDirection direction)
        {
            if (table.ValidLocation(x, y))
            {
                this.x = x;
                this.y = y;
                this.direction = direction;
                robotPlaced = true;
            }
            else
            {
                robotPlaced = false;
            }
            return robotPlaced;
        }

        /// <summary>
        /// Moves the robot 1 position in the direction it is facing
        /// </summary>
        /// <returns>true if robot can move, false if robot can't move or hasn't been placed yet</returns>
        public bool Move()
        //Check if the robot has been placed in a valid location
        {
            if (robotPlaced)
            {
                int newX = x;
                int newY = y;
                //Updates the new x and y values
                switch (direction)
                {
                    case RobotDirection.NORTH:
                        newY++;
                        break;
                    case RobotDirection.SOUTH:
                        newY--;
                        break;
                    case RobotDirection.EAST:
                        newX++;
                        break;
                    case RobotDirection.WEST:
                        newX--;
                        break;
                }

                //Check if the new x and y exist on the table and update if they are
                if (table.ValidLocation(newX, newY))
                {
                    x = newX;
                    y = newY;
                    return true;
                }
            }
            return false;
        }

        public bool Left()
        {
            //Check if the robot has been placed in a valid location
            if (!robotPlaced)
            {
                return false;
            }
            //When facing north(0) need to rollback to west(3)
            if(direction == RobotDirection.NORTH)
            {
                direction = RobotDirection.WEST;
            }
            else
            {
                direction--;
            }
            return true;
        }

        public bool Right()
        {
            //Check if the robot has been placed in a valid location
            if (!robotPlaced)
            {
                return false;
            }

            //When facing west(3) need to rollover to norht(0)
            if(direction == RobotDirection.WEST)
            {
                direction = RobotDirection.NORTH;
            }
            else
            {
                direction++;
            }
            return true;
        }

        public bool Report()
        {
            //Check if the robot has been placed in a valid location
            if (robotPlaced)
            {
                Console.WriteLine($"{x},{y},{direction}");
                return true;
            }
            return false;
        }

        public bool IsRobotPlaced()
        {
            return robotPlaced;
        }

        public int GetX()
        {
            return x;
        }

        public int GetY()
        {
            return y;
        }

        public RobotDirection GetRobotDirection()
        {
            return direction;
        }
    }
}
