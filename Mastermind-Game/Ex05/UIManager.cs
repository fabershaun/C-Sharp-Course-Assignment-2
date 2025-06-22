namespace Ex05
{
    internal class UIManager
    {
        private readonly StartForm r_StartForm = new StartForm();

        private GameForm m_GameForm;

        public void Run()
        {
            r_StartForm.ShowDialog();
            m_GameForm = new GameForm(r_StartForm.TotalNumberOfTries);
            m_GameForm.ShowDialog();
        }
    }
}