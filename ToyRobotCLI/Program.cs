using ToyRobot;
using ToyRobotCLI;

RobotTable table = new RobotTable(6, 6);
Robot robot = new Robot(table);

Console.WriteLine("Welcome to the toy robot 1000");
Console.WriteLine($"Please enter one of the following commands{Environment.NewLine}" +
    $"\t- PLACE{Environment.NewLine}\t- MOVE{Environment.NewLine}\t- LEFT{Environment.NewLine}\t- RIGHT{Environment.NewLine}\t- REPORT{Environment.NewLine}\t- Quit to Exit");
var action = Console.ReadLine();

while(action?.ToLower() != "quit")
{
    if(action?.ToLower() == "place")
    {
        int? x = PlaceHelper.GetNumber("Please enter x location (Empty to exit):");
        //null returns to the menu
        if (x.HasValue)
        {
            int? y = PlaceHelper.GetNumber("Please enter y location (Empty to exit):");
            //null returns to the menu
            if (y.HasValue)
            {
                RobotDirection? robotDirection = PlaceHelper.GetRobotDirection($"Please enter robot direction ({RobotDirection.NORTH}, {RobotDirection.SOUTH}, {RobotDirection.EAST}, {RobotDirection.WEST}, Empty to exit)");
                //null returns to the menu
                if (robotDirection.HasValue)
                {
                    if(!robot.Place(x.Value, y.Value, robotDirection.Value))
                    {
                        Console.WriteLine($"Unable to place robot at ({x.Value},{y.Value},{robotDirection.Value}");
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
