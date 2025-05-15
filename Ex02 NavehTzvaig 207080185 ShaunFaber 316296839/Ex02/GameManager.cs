using System;

namespace Ex02
{
    internal class GameManager
    {
        private const int k_MaxPossibleTries = 10;
        private const int k_MinPossibleTries = 4;
        private const string k_QuitChar = "Q";
        private static int s_TotalNumberOfTries;
        private static int s_CurrentNumberOfTry = 1;
        private static bool s_WonTheGame = false;
        private static bool s_AnotherGame = false;
        private static bool s_ExitGame = false;
        private Code m_SecretCode;
        private GuessResult m_GuessResult;
        private Board m_Board;

        public void StartGame()
        {
            do
            {
                startOver();
                gameLoop(s_TotalNumberOfTries);
            }
            while(s_AnotherGame);
        }

        private void startOver()
        {
            m_SecretCode = new Code();    // Generate code
            m_GuessResult = new GuessResult();
            s_TotalNumberOfTries = getAndValidateNumberOfTries();
            m_Board = new Board(s_TotalNumberOfTries);  // Initialize board
            ConsoleUI.PrintBoard(m_Board);
            s_CurrentNumberOfTry = 1;
            s_WonTheGame = false;
            s_AnotherGame = false;
            s_ExitGame = false;
        }
        
        private void gameLoop(int i_TotalNumberOfTries)
        {
            while (!s_ExitGame)
            {
                string newGuessString = getAndValidateNewGuess();

                if (newGuessString == k_QuitChar)
                {
                    s_ExitGame = true;
                    break;
                }

                Code newGuess = new Code(newGuessString);
                m_SecretCode.CompareGuessToCode(newGuess, m_GuessResult);
                Code.SpacingPin(newGuess.CodeLetters);
                m_Board.UpdateBoard(newGuess, m_GuessResult, s_CurrentNumberOfTry);
                ConsoleUI.PrintBoard(m_Board);
                updateIfWin(m_GuessResult);
                endOfRound();
            }
        }

        private void updateIfWin(GuessResult i_GuessResult)
        {
            if (i_GuessResult.NumOfV == Code.CodeLength)
            {
                s_WonTheGame = true;
            }
        }

        private static int getAndValidateNumberOfTries()
        {
            int numberOfTriesInt;
            bool validInput = true;

            do
            {
                string inputNumberOfTriesString = ConsoleUI.GetMaxTriesFromUser();
                /*                validInput = int.TryParse(inputNumberOfTriesString, out numberOfTriesInt) && 
                                             numberOfTriesInt <= k_MaxPossibleTries && numberOfTriesInt >= k_MinPossibleTries;*/

                if(!(int.TryParse(inputNumberOfTriesString, out numberOfTriesInt)))
                {
                    validInput = false;
                    ConsoleUI.PrintGenericMessage("Wrong syntax input. ");
                }
                else if(!(numberOfTriesInt <= k_MaxPossibleTries && numberOfTriesInt >= k_MinPossibleTries))
                {
                    validInput = false;
                    ConsoleUI.PrintGenericMessage("Wrong logic input. ");
                }
                else
                {
                    validInput = true;
                }
            }
            while (!validInput);

            return numberOfTriesInt;
        }

        private static string getAndValidateNewGuess()
        {
            string newGuessFromUser;
            bool validGuess = false;
            do
            {
                newGuessFromUser = ConsoleUI.GetNewGuess();

                validGuess = Code.CheckIrrelevantGuessInput(newGuessFromUser) && Code.CheckInputGuessSyntax(newGuessFromUser);

            } while (!validGuess);

            return newGuessFromUser;
        }


        private void endOfRound()
        {
            if (s_WonTheGame)
            {
                winGame();
            }
            else if (s_CurrentNumberOfTry == s_TotalNumberOfTries)
            {
                gameOver();
            }

            s_CurrentNumberOfTry++;
        }

        private void winGame()
        {
            s_ExitGame = true;
            m_Board.RevealSecretCodeOnBoard(m_SecretCode.CodeLetters);
            ConsoleUI.PrintBoard(m_Board);
            ConsoleUI.WinGame(s_CurrentNumberOfTry);
            playAgain();
        }

        private void gameOver()
        {
            s_ExitGame = true;
            m_Board.RevealSecretCodeOnBoard(m_SecretCode.CodeLetters);
            ConsoleUI.PrintBoard(m_Board);
            ConsoleUI.LostGame();
            playAgain();
        }

        private void playAgain()
        {
            bool validInput = false;

            do
            {
                string playAgain = ConsoleUI.AnotherGame().ToUpper();

                switch (playAgain)
                {
                    case "Y":
                        ConsoleUI.ClearScreen();
                        validInput = true;
                        s_AnotherGame = true;
                        break;
                    case "N":
                        ConsoleUI.ClearScreen();
                        validInput = true;
                        s_AnotherGame = false;
                        break;
                    default:
                        ConsoleUI.PrintGenericMessage("Wrong Input. Press 'Y' to start a new game or 'N' to exit");
                        validInput = false;
                        break;
                }
            }
            while (!validInput);
        }
    }
}
