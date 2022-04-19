using ToyRobot;

namespace ToyRobotCLI
{
    public class PlaceHelper
    {
        /// <summary>
        /// Converts the text from the number input (EG 3,) to an int will return null if unable to parse
        /// </summary>
        /// <param name="message">Message to be displayed</param>
        /// <returns></returns>
        public static int? GetNumber(string numberInput)
        {
            numberInput = new string(numberInput.Where(c => !char.IsPunctuation(c)).ToArray());
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
        /// <param name="message"></param>
        /// <returns></returns>
        public static RobotDirection? GetRobotDirection(string directionInput)
        {
            directionInput = directionInput.Trim();
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
