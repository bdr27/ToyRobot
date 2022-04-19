using ToyRobot;
using ToyRobotCLI;

RobotTable table = new RobotTable(6, 6);
Robot robot = new Robot(table);

Console.WriteLine("Welcome to the toy robot 1000");
Console.WriteLine($"Please enter one of the following commands{Environment.NewLine}" +
    $"\tPLACE{Environment.NewLine}\tMOVE{Environment.NewLine}\tLEFT{Environment.NewLine}\tRIGHT{Environment.NewLine}\tREPORT{Environment.NewLine}\tQuit to Exit");
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
                RobotDirection? robotDirection = PlaceHelper.GetRobotDirection("Please enter robot direction (NORHT, SOUTH, EAST, WEST, Empty to exit)");
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
        $"\tPLACE X, Y, DIRECTION(NORTH, SOUTH, EAST, WEST){Environment.NewLine}\tMOVE{Environment.NewLine}\tLEFT{Environment.NewLine}\tRIGHT{Environment.NewLine}\tREPORT{Environment.NewLine}");
    action = Console.ReadLine();
}
