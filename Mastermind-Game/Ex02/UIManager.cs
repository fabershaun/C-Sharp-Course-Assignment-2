
namespace Ex02
{
    internal class UIManager
    {
        StartForm startForm = new StartForm();
        GameForm gameForm = new GameForm();
        GameLogic gameLogic = new GameLogic();

        public void Run()
        {
            startForm.ShowDialog();

            gameLogic.SetNumberOfTries(startForm.TotalNumberOfTries);
            gameLogic.StartGame(); // לאתחל את הקוד הסודי, איפוס ניסיונות וכו וכו

            gameForm.ShowDialog();
        }
    }
}
