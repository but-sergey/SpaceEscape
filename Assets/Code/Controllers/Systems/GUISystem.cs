namespace SpaceEscape
{
    internal sealed class GUISystem
    {
        public GUISystem(Controllers controllers, Data data, ScoreSystem scoreSystem)
        {
            var guiController = new GUIController(data.MainMenuData, scoreSystem.ScoreController);
            controllers.Add(guiController);
        }
    }
}
