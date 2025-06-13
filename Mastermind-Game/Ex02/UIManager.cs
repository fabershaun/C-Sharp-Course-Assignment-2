
namespace Ex02
{
    internal class UIManager
    {
        private StartForm m_StartForm = new StartForm();
        private GameLogic m_GameLogic = new GameLogic();
        private GameForm m_GameForm;

        public void Run()
        {
            m_StartForm.ShowDialog();

            m_GameLogic.SetNumberOfTries(m_StartForm.TotalNumberOfTries); // Do it without this function
            m_GameLogic.StartGame();

            m_GameForm = new GameForm(m_GameLogic.TotalNumberOfTries);
            //m_GameForm = new GameForm1(m_GameLogic.TotalNumberOfTries, Code.CodeLength);
            m_GameForm.ShowDialog();
        }
    }
}
