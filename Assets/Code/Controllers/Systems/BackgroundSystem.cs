namespace SpaceEscape
{
    internal sealed class BackgroundSystem
    {
        private BackgroundFactory _backgroundFactory;

        public BackgroundSystem(Controllers controllers, Data data)
        {
            _backgroundFactory = new BackgroundFactory();

            controllers.Add(new BackgroundController(data.BackgroundData, _backgroundFactory));
        }
    }
}
