//taking in combos
//Methods have 2 parameters: 1 for dice combos (two 1s, two 6s, etc), 1 for total (box cars, snake eyes, etc)
//static bool GoAgain()******************************************************

//user input

//in case user entered a string, or less than 1 side
bool sideInput = true;
while (sideInput)
{
    try
    {   //user input
        Console.WriteLine("How many sides should this pair of dice have?");
        int sides = int.Parse(Console.ReadLine());

        if (sides < 1)
        {

            throw new Exception("The dice must have at least 1 side! Please try again");
        }
        else
        { //in range             
            
            //loop back if user wants to roll again
            bool goAgain = true;
            while (goAgain)
            {       //random numbers
                Random rnd = new Random();
                int dice1 = (rnd.Next(1, sides + 1));
                int dice2 = (rnd.Next(1, sides + 1));
                int total = dice1 + dice2;

                Console.WriteLine($"You rolled a: {dice1} and a {dice2}.  ({total} total)");

                //if the dice have 6 sides
                if (sides == 6)
                {
                    Console.WriteLine(combinations(dice1, dice2));
                }
                //in case user entered the wrong input for y/n, doesn't roll again in that case
                while (true)
                {
                    Console.WriteLine("Do you want to go again(y/n)?");
                    string input = Console.ReadLine();
                    //input
                    try
                    {
                        if (input.ToLower().Trim() == "y")
                        {
                            break;
                            sideInput = false;
                        }
                        else if (input.ToLower().Trim() == "n")
                        {
                            Console.WriteLine("Thanks for playing!");
                            goAgain = false;
                            sideInput = false;
                            break;
                        }
                        else
                        {
                            throw new Exception("Not a valid option, please try again.");
                            sideInput = false;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }

            //method for combinations
            static string combinations(double x, double y)
            {
                string message = "";

                if (x == 1 && y == 1)
                {
                    return message = "Snake eyes\nCraps!";
                }
                else if (x + y == 3)
                {
                    return message = "Ace Deuce\nCraps!";
                }
                else if (x == 6 && y == 6)
                {
                    return message = "Box Cars\nCraps!";
                }
                else if (x + y == 7 || x + y == 11)
                {
                    return message = "Win!";
                }
                else
                {
                    return message;
                }
            }
        }
    }
    //dies have to have at least 1 side, has to be a number
    catch (FormatException e)
    {
        Console.WriteLine("Please enter a number, try again");
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}