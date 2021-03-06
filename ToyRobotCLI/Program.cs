using ToyRobot;
using ToyRobotCLI;
int placeDirectionCommandCount = 3;
int placeWithoutDirectionCommandCount = 2;
RobotTable table = new (6, 6);
Robot robot = new (table);

Console.WriteLine("Welcome to the toy robot 1000");
Console.WriteLine($"Please enter one of the following commands{Environment.NewLine}" +
    $"\t- PLACE X,Y,DIRECTION({RobotDirection.NORTH}, {RobotDirection.SOUTH}, {RobotDirection.EAST}, {RobotDirection.WEST}){Environment.NewLine}\t- MOVE{Environment.NewLine}\t- LEFT{Environment.NewLine}\t- RIGHT{Environment.NewLine}\t- REPORT{Environment.NewLine}\t- Quit to Exit");
var action = Console.ReadLine();

while(action?.ToLower() != "quit")
{
    if(action?.ToLower().StartsWith("place") == true)
    {
        var commandValues = action.Split(' ');
        if(commandValues.Length == 2)
        {
            var placeValues = commandValues[1].Split(',');
            if (placeValues.Length == placeWithoutDirectionCommandCount || placeValues.Length == placeDirectionCommandCount)
            {
                //4 inputs also updates the robot direction
                bool updateRobotDirection = placeValues.Length == placeDirectionCommandCount;
                int? x = PlaceHelper.GetNumber(placeValues[0]);
                int? y = PlaceHelper.GetNumber(placeValues[1]); 
                string robotDirectionString = "";
                RobotDirection? robotDirection = null;
                if (updateRobotDirection)
                {
                    robotDirectionString = placeValues[2];
                    robotDirection = PlaceHelper.GetRobotDirection(robotDirectionString);
                }

                if (x.HasValue && y.HasValue)
                {
                    if (updateRobotDirection)
                    {
                        if (!robotDirection.HasValue || !robot.Place(x.Value, y.Value, robotDirection.Value))
                        {
                            string robotDir = robotDirection.HasValue ? robotDirection.Value.ToString() : robotDirectionString;
                            Console.WriteLine($"Unable to place robot at ({x.Value},{y.Value},{robotDir})");
                        }
                    }
                    else
                    {
                        if (!robot.Place(x.Value, y.Value))
                        {
                            Console.WriteLine($"Unable to place robot at ({x.Value},{y.Value})");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Place Command");
                }
            }
            else
            {
                Console.WriteLine("Invalid Place Command");
            }
        }
        else
        {
            Console.WriteLine("Invalid Place Command");
        }
        
    }
    if (action?.ToLower() == "move")
    {
        if (!robot.Move())
        {
            if (robot.IsRobotPlaced())
            {
                Console.WriteLine("Robot cannot move");
            }
            else
            {
                Console.WriteLine("Please place robot before moving");
            }
        }
    }
    if (action?.ToLower() == "left")
    {
        if (!robot.Left())
        {
            Console.WriteLine("Please place robot beforing turning left");
        }
    }
    if (action?.ToLower() == "right")
    {
        if (!robot.Right())
        {
            Console.WriteLine("Please place robot before turning right");
        }
    }
    if (action?.ToLower() == "report")
    {
        if (!robot.Report())
        {
            Console.WriteLine("Please place robot before reporting");
        }
    }

    Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}Please enter one of the following commands{Environment.NewLine}" +
    $"\t- PLACE{Environment.NewLine}\t- MOVE{Environment.NewLine}\t- LEFT{Environment.NewLine}\t- RIGHT{Environment.NewLine}\t- REPORT{Environment.NewLine}\t- Quit to Exit");
    action = Console.ReadLine();
}
