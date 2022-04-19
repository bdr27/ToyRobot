using ToyRobot;

namespace ToyRobotCLI
{
    public class PlaceHelper
    {
        /// <summary>
        /// Converts the text from the number input (EG 3) to an int will return null if unable to parse
        /// </summary>
        /// <param name="numberInput">Message to be displayed</param>
        /// <returns></returns>
        public static int? GetNumber(string numberInput)
        {
            int? result = null;
            if(int.TryParse(numberInput, out int val))
            {
                result = val;
            }
            return result;
        }

        /// <summary>
        /// Converts the text from the direction input (EG NORTH) to a RobotDirection will return null if unable to parse
        /// </summary>
        /// <param name="directionInput"></param>
        /// <returns></returns>
        public static RobotDirection? GetRobotDirection(string directionInput)
        {
            RobotDirection? robotDirection = null;
            
            //Parses the north, south, east, west to the enum
            if (Enum.TryParse(directionInput.ToUpper(), out RobotDirection val))
            {
                robotDirection = val;
            }
            return robotDirection;
        }
    }
}
