using ToyRobot;

namespace ToyRobotCLI
{
    public class PlaceHelper
    {
        /// <summary>
        /// Converts the text from the console input to an int will return null if nothing is entered
        /// </summary>
        /// <param name="message">Message to be displayed</param>
        /// <returns></returns>
        public static int? GetNumber(string message)
        {
            Console.WriteLine(message);
            var input = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(input))
            {
                return null;
            }

            int number;
            //checks for valid number
            while (!int.TryParse(input, out number))
            {
                Console.WriteLine(message);
                input = Console.ReadLine();
                if (input == null)
                {
                    return null;
                }
            }
            return number;
        }

        /// <summary>
        /// Converts the text from the console input to a RobotDirection will return null if nothing is entered
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static RobotDirection? GetRobotDirection(string message)
        {
            RobotDirection robotDirection;
            Console.WriteLine(message);
            var input = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(input))
            {
                return null;
            }
            
            //Parses the north, south, east, west to the enum
            while (Enum.TryParse(input.ToLower(), out robotDirection))
            {
                Console.WriteLine(message);
                input = Console.ReadLine();
                if (input == null)
                {
                    return null;
                }
            }
            return robotDirection;
        }
    }
}
