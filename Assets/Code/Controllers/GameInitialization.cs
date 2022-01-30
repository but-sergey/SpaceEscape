namespace SpaceEscape
{
    internal sealed class GameInitialization
    {
        public GameInitialization(Controllers controllers, Data data)
        {
            var inputSystem  = new InputSystem(controllers);
            var playerSystem = new PlayerSystem(controllers, data);
            var soundsData = new SoundSystem(controllers, inputSystem.GetInput(), data, playerSystem);
            var cameraSystem = new CameraSystem(controllers, data, playerSystem);
            var moveSystem   = new MoveSystem(controllers, inputSystem, playerSystem, cameraSystem);
            var bulletSystem = new BulletSystem(controllers, data, playerSystem, cameraSystem);
            var fireSystem   = new FireSystem(controllers, inputSystem, bulletSystem);
            var enemySystem  = new EnemySystem(controllers, data, bulletSystem, playerSystem);
            var scoreSystem  = new ScoreSystem(controllers, enemySystem);
            var guiSystem    = new GUISystem(controllers, data, scoreSystem);
            var backgroundSystem = new BackgroundSystem(controllers, data);
        }
    }
}
