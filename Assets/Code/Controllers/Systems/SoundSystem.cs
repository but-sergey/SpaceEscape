namespace SpaceEscape
{
    internal sealed class SoundSystem
    {
        public SoundSystem(Controllers controllers, InputData input, Data data, PlayerSystem player, EnemySystem enemies)
        {
            var soundSystem = new SoundsController(input, data, player, enemies);
            controllers.Add(soundSystem);
        }
    }
}