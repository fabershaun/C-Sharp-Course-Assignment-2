
namespace Ex02
{
    internal class UIManager
    {
        private StartForm m_StartForm = new StartForm();

        private GameForm m_GameForm;

        public void Run()
        {
            m_StartForm.ShowDialog();

            //int numberOfTry = 4; //get from m_StartForm
            //m_GameLogic.SetNumberOfTries(m_StartForm.TotalNumberOfTries); // Do it without this function
            //m_GameLogic.InitializeGame();

            m_GameForm = new GameForm(m_StartForm.TotalNumberOfTries);
            m_GameForm.ShowDialog();
        }
    }
}
