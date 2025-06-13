using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex02.Code;

namespace Ex02
{
    internal class ConsoleUI
    {
        /*        private static readonly string sr_NewGameMessage = "Would you like to start a new game? (Y/N)";
                private static readonly char sr_QuitChar = 'Q';

               internal static char QuitChar
                {
                    get { return sr_QuitChar; }
                }

                internal static void PrintBoard(Board i_Board)
                {
                    StringBuilder[] board = i_Board.GetBoard;

                    ClearScreen();
                    Console.WriteLine("Current board status:");
                    Console.WriteLine();

                    foreach (StringBuilder line in board)
                    {
                        Console.WriteLine(line.ToString());
                    }
                }

                internal static void ClearScreen()
                {
                    //Ex02.ConsoleUtils.Screen.Clear();
                }

                internal static string GetNewGuess()
                {
                    Console.WriteLine($"Please type your next guess <ABCD> or {sr_QuitChar} to quit:");
                    return Console.ReadLine();
                }

                internal static string GetMaxTriesFromUser()
                {
                    Console.WriteLine("Please type the number of guess in this game:");
                    return Console.ReadLine();
                }

                internal static void WinGame(int i_CurrentNumberOfTry)
                {
                    Console.WriteLine($"You guessed after {i_CurrentNumberOfTry} steps!");
                }

                internal static void LostGame()
                {
                    Console.WriteLine("No more guesses allowed. You lost.");
                }

                internal static void AnotherGame(ref bool o_ValidInput, ref bool o_AnotherGame)
                {

                    Console.WriteLine(sr_NewGameMessage);
                    string playAgain = Console.ReadLine().ToUpper();

                    switch (playAgain)
                    {
                        case "Y":
                            ClearScreen();
                            o_ValidInput = true;
                            o_AnotherGame = true;
                            break;
                        case "N":
                            ClearScreen();
                            o_ValidInput = true;
                            o_AnotherGame = false;
                            break;
                        default:
                            PrintGenericMessage("Wrong Input. Press 'Y' to start a new game or 'N' to exit");
                            o_ValidInput = false;
                            break;
                    }

                }
                internal static void PrintGenericMessage(string i_Message)
                {
                    Console.WriteLine(i_Message);
                }

                internal static bool CheckIfQuit(string i_UserInput)
                {
                    bool result = false;

                    if (i_UserInput == sr_QuitChar.ToString())
                    {
                        result = true;
                    }

                    return result;
                }

                internal static void PrintGuessValidationError(eGuessValidation i_ValidationResult)
                {
                    string message;

                    switch (i_ValidationResult)
                    {
                        case eGuessValidation.EmptyInput:
                            message = $"Input is empty. Please enter your guess or {sr_QuitChar} to quit.";
                            break;
                        case eGuessValidation.NotUppercase:
                            message = "Input must be uppercase letters only (A-H). Please try again.";
                            break;
                        case eGuessValidation.WrongLength:
                            message = "Input must be 4 letters long. Please try again.";
                            break;
                        case eGuessValidation.DuplicateLetters:
                            message = "Input must not contain duplicate letters. Please try again.";
                            break;
                        case eGuessValidation.IllegalCharacters:
                            message = "Wrong syntax input. Input must contain letters (A-H). Please try again.";
                            break;
                        case eGuessValidation.OutOfRangeLetter:
                            message = "Input contains letters outside the allowed range (A–H). Please try again.";
                            break;
                        default:
                            message = ""; // Do nothing on Ok
                            break;
                    }

                    if (!string.IsNullOrEmpty(message))
                    {
                        Console.WriteLine(message);
                    }
                }

                internal static int GetAndValidateNumberOfTries(int i_MinPossibleTries, int i_MaxPossibleTries)
                {
                    int numberOfTriesInt = 0;
                    bool validInput = false;

                    do
                    {
                        string inputNumberOfTriesString = GetMaxTriesFromUser();

                        if (!(int.TryParse(inputNumberOfTriesString, out numberOfTriesInt)))
                        {
                            PrintGenericMessage("Wrong syntax input. ");
                        }
                        else if (numberOfTriesInt > i_MaxPossibleTries || numberOfTriesInt < i_MinPossibleTries)
                        {
                            PrintGenericMessage($"Wrong logic input. Enter a number between {i_MinPossibleTries} and {i_MaxPossibleTries}.");
                        }
                        else
                        {
                            validInput = true;
                        }
                    }
                    while (!validInput);

                    return numberOfTriesInt;
                }

        *//*        internal static string GetAndValidateNewGuess(ref bool o_ExitGame)
                {
                    string newGuessFromUser = string.Empty;
                    bool validGuess = false;

                    do
                    {
                        newGuessFromUser = GetNewGuess();

                        Code.eGuessValidation syntaxValidation = Code.CheckInputGuessSyntax(newGuessFromUser);
                        Code.eGuessValidation logicValidation = Code.eGuessValidation.Ok;

                        if (syntaxValidation == Code.eGuessValidation.Ok)
                        {
                            logicValidation = Code.CheckIrrelevantGuessInput(newGuessFromUser);
                        }

                        validGuess = Code.IsValidGuess(syntaxValidation, logicValidation);

                        if (!validGuess)
                        {
                            printGuessErrors(syntaxValidation, logicValidation);
                        }

                        o_ExitGame = CheckIfQuit(newGuessFromUser);

                    } while (!validGuess && !o_ExitGame);

                    return newGuessFromUser;
                }*//*

                private static void printGuessErrors(Code.eGuessValidation i_Syntax, Code.eGuessValidation i_Logic)
                {
                    if (i_Logic != Code.eGuessValidation.Ok)
                    {
                        PrintGuessValidationError(i_Logic);
                    }
                    else if (i_Syntax != Code.eGuessValidation.Ok)
                    {
                        PrintGuessValidationError(i_Syntax);
                    }
                }*/
    }
}
