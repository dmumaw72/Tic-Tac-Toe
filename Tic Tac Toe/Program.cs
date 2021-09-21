using System;
using System.Linq;

namespace Tic_Tac_Toe
{
    class Program
    {
        /*----------------------------------------------------FUNCTIONS--------------------------------------------------------------------------*/
        /*The DrawBoard function draws the Tic Tac Toe board*/
        public static void DrawBoard(char[,] playField)
        {
            Console.WriteLine("   |   |   ");
            Console.WriteLine(" {0} | {1} | {2}", playField[0,0], playField[0,1], playField[0,2]);
            Console.WriteLine("___|___|___");
            Console.WriteLine("   |   |   ");
            Console.WriteLine(" {0} | {1} | {2}",playField[1,0], playField[1,1], playField[1,2]);
            Console.WriteLine("___|___|___");
            Console.WriteLine("   |   |   ");
            Console.WriteLine(" {0} | {1} | {2}",playField[2,0], playField[2,1], playField[2,2]);
            Console.WriteLine("   |   |   ");
            Console.WriteLine();
        }


        /*This function verifies that a number was input by the user, and also verifiies that the squear picked hasn't already been picked before.*/
        public static int PickField (string UserInput, char[,] gameBoard, int[] alreadySelected)
        {
            bool validInput = false;
            int answer;

            validInput = int.TryParse(UserInput, out answer);

            //check that user input is a number, is not a previously selected number, or is a number that is less 0 or greater than 9
            while (validInput == false || alreadySelected.Contains(answer) || (answer < 0 || answer > 9))
            {
                if (validInput == false)
                {
                    Console.WriteLine("Incorrect Input! Please enter a number of the field you would like.");
                    UserInput = Console.ReadLine();
                    validInput = int.TryParse(UserInput, out answer);
                }
                //check that field selected by the user hasn't already been chosen           
                else if(alreadySelected.Contains(answer))
                {
                    Console.WriteLine("That square has already been selected.  Please select another square");
                    UserInput = Console.ReadLine();
                    validInput = int.TryParse(UserInput, out answer);
                }
                else if (answer < 0 || answer > 9)
                {
                    Console.WriteLine("Enter a number between 0 and 9");
                    UserInput = Console.ReadLine();
                    validInput = int.TryParse(UserInput, out answer);
                }
                
            }

            return answer;
        }

        public static bool isWinner(int playerNumber, char[,] gameBoard)
        {
            int count = 0;

            if (playerNumber == 1)
            {
                //check check each row for 3 in a row
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (gameBoard[i, j] == 'O')
                        {
                            count++;
                        }
                    }
                    //check if count = 3 and if so then declare player the winner
                    if (count == 3)
                    {
                        return true;
                    }
                    else
                    {
                        count = 0;
                    }
                }

                //check each column for 3 in a row
                for (int i=0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (gameBoard[j,i] == 'O')
                        {
                            count++;
                        }
                    }
                    //check if count = 3 and if so then declare player the winner.
                    if (count == 3)
                    {
                        return true;
                    }
                    else
                    {
                        count = 0;
                    }
                }

                //check diagonals for 3 in a row
                if (gameBoard[0, 0] == 'O' && gameBoard[1, 1] == 'O' && gameBoard[2, 2] == 'O')
                {
                    return true;
                }
                else if (gameBoard[0, 2] == 'O' && gameBoard[1, 1] == 'O' && gameBoard[2, 0] == 'O')
                {
                    return true;
                }
                
                //no winner found
                return false;

            }
            else if (playerNumber == 2)
            {
                //check each row for 3 in a row
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (gameBoard[i, j] == 'X')
                        {
                            count++;
                        }
                    }
                    //check if count = 3 and if declare player the winner if it does
                    if (count == 3)
                    {
                       return true;
                    }
                    else
                    {
                        count = 0;
                    }
                }

                //check each column for 3 in a row
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (gameBoard[j, i] == 'X')
                        {
                            count++;
                        }
                    }
                    //check if count = 3 and if so then declare player the winner.
                    if (count == 3)
                    {
                       return true;
                    }
                    else
                    {
                        count = 0;
                    }
                }

                //check diagonals for 3 in a row
                if (gameBoard[0, 0] == 'X' && gameBoard[1, 1] == 'X' && gameBoard[2, 2] == 'X')
                {
                    return true;
                }
                else if (gameBoard[0, 2] == 'X' && gameBoard[1, 1] == 'X' && gameBoard[2, 0] == 'X')
                {
                    return true;
                }
            }
            //no winner found
            return false;
        }

        //resets the Tic Tac Toe playfield array
        public static void resetPlayField(char[,] playField)
        {
            char[] fieldValues = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            int index = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    playField[i, j] = fieldValues[index];
                    index++;
                }
            }
        }

        
        /*----------------------------------------MAIN PROGRAM--------------------------------------------------------------------------*/

        static void Main(string[] args)
        {
            //variables
            char[,] playField = new char[,] { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };
            int playerNumber = 1;
            string UserInput = "";
            int[] alreadySelected = new int[9];
            int counter = 0;
            int userSelection = 0;

            //Draw the board
            DrawBoard(playField);

            while (UserInput != "exit")
            {
                

                //Check which player's turn it is and prompt user for square selection
                if (playerNumber == 1)
                { 
                    Console.WriteLine("Player 1: Choose your field!");
                    UserInput = Console.ReadLine();
                    //validate user input
                    userSelection = PickField(UserInput, playField, alreadySelected); 
                
                    
                    switch (userSelection)
                    {
                        case 1:
                            playField[0, 0] = 'O';
                            alreadySelected[counter] = 1;
                            Console.Clear();
                            DrawBoard(playField);
                            counter++;
                            break;
                        case 2:
                            playField[0, 1] = 'O';
                            alreadySelected[counter] = 2;
                            Console.Clear();
                            DrawBoard(playField);
                            counter++;
                            break;
                        case 3:
                            playField[0, 2] = 'O';
                            alreadySelected[counter] = 3;
                            Console.Clear();
                            DrawBoard(playField);
                            counter++;
                            break;
                        case 4:
                            playField[1, 0] = 'O';
                            alreadySelected[counter] = 4;
                            Console.Clear();
                            DrawBoard(playField);
                            counter++;
                            break;
                        case 5:
                            playField[1, 1] = 'O';
                            alreadySelected[counter] = 5;
                            Console.Clear();
                            DrawBoard(playField);
                            counter++;
                            break;
                        case 6:
                            playField[1, 2] = 'O';
                            alreadySelected[counter] = 6;
                            Console.Clear();
                            DrawBoard(playField);
                            counter++;
                            break;
                        case 7:
                            playField[2, 0] = 'O';
                            alreadySelected[counter] = 7;
                            Console.Clear();
                            DrawBoard(playField);
                            counter++;
                            break;
                        case 8:
                            playField[2, 1] = 'O';
                            alreadySelected[counter] = 8;
                            Console.Clear();
                            DrawBoard(playField);
                            counter++;
                            break;
                        case 9:
                            playField[2, 2] = 'O';
                            alreadySelected[counter] = 9;
                            Console.Clear();
                            DrawBoard(playField);
                            counter++;
                            break;
                    }
                    
                    //if counter >= 4 start checking for the winner
                    if(counter >= 4)
                    {
                        if(isWinner(playerNumber, playField))
                        {
                            Console.WriteLine("Player {0} is the winner!", playerNumber);
                            Console.WriteLine("Press any key to play again or type \"exit\" to quit?");
                            UserInput = Console.ReadLine();

                            //reset the variables and game board if the user doesn't type exit
                            if(UserInput.ToLower() != "exit")
                            {
                                resetPlayField(playField);
                                Console.Clear();
                                DrawBoard(playField);
                                playerNumber = 1;
                                Array.Clear(alreadySelected, 0, alreadySelected.Length);
                                counter = 0;
                                userSelection = 0;
                                continue;
                            }

                        }
                        //check for a draw game
                        else if (counter == 9)
                        {
                            Console.WriteLine("It is a draw.");
                            Console.WriteLine("Press any key to play again or type \"exit\" to quit?");
                            UserInput = Console.ReadLine();
                            //reset the game board and variables if the user doesn't type exit
                            if (UserInput.ToLower() != "exit")
                            {
                                resetPlayField(playField);
                                Console.Clear();
                                DrawBoard(playField);
                                playerNumber = 1;
                                Array.Clear(alreadySelected, 0, alreadySelected.Length);
                                counter = 0;
                                userSelection = 0;
                                continue;
                            }
                        }

                    }

                    playerNumber = 2;
                }
                else
                {                    
                        Console.WriteLine("Player 2: Choose your field!");
                        UserInput = Console.ReadLine();
                        userSelection = PickField(UserInput, playField, alreadySelected); 
                  
                    switch (userSelection)
                    {
                        case 1:
                            playField[0, 0] = 'X';
                            alreadySelected[counter] = 1;
                            Console.Clear();
                            DrawBoard(playField);
                            counter++;
                            break;
                        case 2:
                            playField[0, 1] = 'X';
                            alreadySelected[counter] = 2;
                            Console.Clear();
                            DrawBoard(playField);
                            counter++;
                            break;
                        case 3:
                            playField[0, 2] = 'X';
                            alreadySelected[counter] = 3;
                            Console.Clear();
                            DrawBoard(playField);
                            counter++;
                            break;
                        case 4:
                            playField[1, 0] = 'X';
                            alreadySelected[counter] = 4;
                            Console.Clear();
                            DrawBoard(playField);
                            counter++;
                            break;
                        case 5:
                            playField[1, 1] = 'X';
                            alreadySelected[counter] = 5;
                            Console.Clear();
                            DrawBoard(playField);
                            counter++;
                            break;
                        case 6:
                            playField[1, 2] = 'X';
                            alreadySelected[counter] = 6;
                            Console.Clear();
                            DrawBoard(playField);
                            counter++;
                            break;
                        case 7:
                            playField[2, 0] = 'X';
                            alreadySelected[counter] = 7;
                            Console.Clear();
                            DrawBoard(playField);
                            counter++;
                            break;
                        case 8:
                            playField[2, 1] = 'X';
                            alreadySelected[counter] = 8;
                            Console.Clear();
                            DrawBoard(playField);
                            counter++;
                            break;
                        case 9:
                            playField[2, 2] = 'X';
                            alreadySelected[counter] = 9;
                            Console.Clear();
                            DrawBoard(playField);
                            counter++;
                            break;
                    }

                    //if counter >= 4 start checking for the winner
                    if (counter >= 4)
                    {
                        if (isWinner(playerNumber, playField))
                        {
                            Console.WriteLine("Player {0} is the winner!", playerNumber);
                            Console.WriteLine("Press any key to play again or type \"exit\" to quit?");
                            UserInput = Console.ReadLine();
                            //reset the game board and variables if the user doesn't type exit
                            if (UserInput.ToLower() != "exit")
                            {
                                resetPlayField(playField);
                                Console.Clear();
                                DrawBoard(playField);
                                playerNumber = 1;
                                Array.Clear(alreadySelected, 0, alreadySelected.Length);
                                counter = 0;
                                userSelection = 0;
                                continue;
                            }

                        }
                        //check for a draw game
                        else if (counter == 9)
                        {
                            Console.WriteLine("It is a draw.");
                            Console.WriteLine("Press any key to play again or type \"exit\" to quit?");
                            UserInput = Console.ReadLine();
                            //reset the game board and variables if the user doesn't type exit
                            if (UserInput.ToLower() != "exit")
                            {
                                resetPlayField(playField);
                                Console.Clear();
                                DrawBoard(playField);
                                playerNumber = 1;
                                Array.Clear(alreadySelected, 0, alreadySelected.Length);
                                counter = 0;
                                userSelection = 0;
                                continue;
                            }
                        }
                    }

                    playerNumber = 1;
                    
                }
                
            }
           
        }
    }
}
