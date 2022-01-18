using System;

namespace CamelLeviBenes
{
    class Program
    {
        static void Main(string[] args)
        {
            // RNG
            var rand = new Random();

            // Variables
            int moveCount = 0;

            int milesTraveled = 0;
            int nativeTraveled = -20;
            int destination = 200;

            int thirst = 0;
            int canteenDrinks = 3;

            int camelTired = 0;
            bool camelCollapsed = false;

            int oasisChance;
            bool oasisFound = false;

            // Introductory message
            Console.WriteLine("Welcome to Camel!");
            Console.WriteLine("You have stolen a camel to make your way across the great");
            Console.WriteLine("Mobi desert. The natives want their camel back and are ");
            Console.WriteLine("chasing you down! Survive your desert trek and outrun the natives.");

            // Main game loop
            bool done = false;
            while (!done)
            {
                // Check if natives are getting close
                if ((milesTraveled - nativeTraveled) <= 15)
                {
                    Console.WriteLine("The natives are right on your tail! Better get moving!");
                }

                // Check thirst levels
                if (thirst >= 2 && thirst < 4)
                {
                    Console.WriteLine("You are beginning to feel a bit parched.");
                }
                else if (thirst == 4)
                {
                    Console.WriteLine("You are extremely thirsty.");
                }
                else if (thirst == 5 || thirst == 6)
                {
                    Console.WriteLine("You are going to die of thirst if you don't drink some water.");
                }

                // Check camel tiredness
                if (camelTired == 5 || camelTired == 6)
                {
                    Console.WriteLine("Your camel is looking a bit tired.");
                }
                else if (camelTired == 7 || camelTired == 8) {
                    Console.WriteLine("Your camel is on the brink of exhaustion.");
                }
                else if (camelTired > 8)
                {
                    Console.WriteLine("Your camel has collapsed.");
                    camelCollapsed = true;
                }

                // Move number and space for clarity
                moveCount++;
                Console.WriteLine();
                Console.WriteLine("Move number " + moveCount);

                // Print commands
                Console.WriteLine();
                Console.WriteLine("A. Drink from your canteen.");
                Console.WriteLine("B. Ahead moderate speed.");
                Console.WriteLine("C. Ahead full speed.");
                Console.WriteLine("D. Stop and rest.");
                Console.WriteLine("E. Status check.");
                Console.WriteLine("Q. Quit.");

                // Get user command
                Console.WriteLine("What will you do? ");
                string userCommand = Console.ReadLine().ToUpper();
                Console.WriteLine();

                // Process user command

                // Drinking from canteen
                if (userCommand == "A" && canteenDrinks > 0)
                {
                    Console.WriteLine("You drank from the canteen and replenished your thirst.");
                    thirst = 0;
                    canteenDrinks--;
                }

                // Attempting to drink from canteen with no drinks left
                else if (userCommand == "A" && canteenDrinks == 0)
                {
                    Console.WriteLine("You have no more drinks!");
                }

                // Moving forward at moderate speed
                else if (userCommand == "B" && camelCollapsed == false)
                {
                    Console.WriteLine("You move forward at a moderate speed.");
                    camelTired++;
                    thirst++;
                    milesTraveled += rand.Next(5, 12);

                    // Check for oasis
                    oasisChance = rand.Next(0, 20);
                    if (oasisFound == false && oasisChance == 10)
                    {
                        Console.WriteLine("You found an oasis! Your thirst has been quenched, your canteen filled, and your camel rested.");
                        oasisFound = true;
                        thirst = 0;
                        camelTired = 0;
                        canteenDrinks = 3;
                    }

                    // Natives move forward
                    nativeTraveled += rand.Next(7, 14);
                }

                // Attempting to move forward at moderate speed when camel is collapsed
                else if (userCommand == "B" && camelCollapsed == true)
                {
                    Console.WriteLine("Your camel is collapsed and not going to move without some rest.");
                }

                // Moving forward at full speed
                else if (userCommand == "C" && camelCollapsed == false)
                {
                    Console.WriteLine("You move forward at full speed!");
                    camelTired += rand.Next(1, 3);
                    thirst++;
                    milesTraveled += rand.Next(10, 20);

                    // Check for oasis
                    oasisChance = rand.Next(0, 20);
                    if (oasisFound == false && oasisChance == 10)
                    {
                        Console.WriteLine("You found an oasis! Your thirst has been quenched, your canteen filled, and your camel rested.");
                        oasisFound = true;
                        thirst = 0;
                        camelTired = 0;
                        canteenDrinks = 3;
                    }

                    // Natives move forward
                    nativeTraveled += rand.Next(7, 14);
                }

                // Attempting to move forward at full speed when camel is collapsed
                else if (userCommand == "C" && camelCollapsed == true)
                {
                    Console.WriteLine("Your camel is collapsed and not going to move without some rest.");
                }

                // Resting
                else if (userCommand == "D")
                {
                    Console.WriteLine("You decided to stop and rest for awhile. Your camel is rested and raring to go.");
                    camelTired = 0;
                    camelCollapsed = false;
                    thirst++;

                    // Natives move forward
                    nativeTraveled += rand.Next(7, 14);
                }

                // Status check
                else if (userCommand == "E")
                {
                    Console.WriteLine("Miles traveled: " + milesTraveled);
                    Console.WriteLine("Drinks in canteen: " + canteenDrinks);
                    Console.WriteLine("The natives are " + (milesTraveled - nativeTraveled) + " miles behind you.");
                }

                // Quit
                else if (userCommand == "Q")
                {
                    Console.WriteLine("Goodbye!");
                    done = true;
                }

                // Invalid command entered
                else
                {
                    Console.WriteLine("Unknown command.");
                }

                // Check if destination is reached
                if (milesTraveled >= destination)
                {
                    Console.WriteLine("Congratulations! You escaped the natives and got out of the desert!");
                    done = true;
                }

                // Check if natives have reached player
                if (nativeTraveled >= milesTraveled)
                {
                    Console.WriteLine("The natives caught you and retrieved their stolen camel.");
                    Console.WriteLine("Good luck getting out of the desert now! You lose!");
                    done = true;
                }

                // Check if died of thirst
                if (thirst > 6)
                {
                    Console.WriteLine("You have died of thirst. You lose!");
                    done = true;
                }

            }
        }
    }
}
