namespace SpaceEscape
{
    internal sealed class SoundSystem
    {
        public SoundSystem(Controllers controllers, InputData input, Data data, PlayerSystem player)
        {
            var soundSystem = new SoundsController(input, data, player);
            controllers.Add(soundSystem);
        }
    }
}