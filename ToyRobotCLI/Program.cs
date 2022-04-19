using ToyRobot;
using ToyRobotCLI;

RobotTable table = new RobotTable(6, 6);
Robot robot = new Robot(table);

Console.WriteLine("Welcome to the toy robot 1000");
Console.WriteLine($"Please enter one of the following commands{Environment.NewLine}" +
    $"\t- PLACE X, Y, DIRECTION({RobotDirection.NORTH}, {RobotDirection.SOUTH}, {RobotDirection.EAST}, {RobotDirection.WEST}){Environment.NewLine}\t- MOVE{Environment.NewLine}\t- LEFT{Environment.NewLine}\t- RIGHT{Environment.NewLine}\t- REPORT{Environment.NewLine}\t- Quit to Exit");
var action = Console.ReadLine();

while(action?.ToLower() != "quit")
{
    if(action?.ToLower().StartsWith("place") == true)
    {
        //place requires spaces betweeen values to work
        var placeValues = action.Split(' ');
        //Can have 3 inputs EG (PLACE 3, 1) or 4 inputs (EG. PLACE 3, 1, NORTH)
        if(placeValues.Length == 3 || placeValues.Length == 4)
        {
            //4 inputs also updates the robot direction
            bool updateRobotDirection = placeValues.Length == 4;
            int? x = PlaceHelper.GetNumber(placeValues[1]);
            int? y = PlaceHelper.GetNumber(placeValues[2]);
            RobotDirection? robotDirection = null;
            if(updateRobotDirection)
            {
                robotDirection = PlaceHelper.GetRobotDirection(placeValues[3]);
            }

            if(x.HasValue && y.HasValue)
            {
                if(updateRobotDirection)
                {
                    if(!robotDirection.HasValue || !robot.Place(x.Value, y.Value, robotDirection.Value))
                    {
                        Console.WriteLine($"Unable to place robot at ({x.Value},{y.Value},{robotDirection.Value}");
                    }
                }
                else
                {
                    if(!robot.Place(x.Value, y.Value))
                    {
                        Console.WriteLine($"Unable to place robot at ({x.Value},{y.Value})");                        
                    }
                }
            }
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
