using UnityEngine;

namespace SpaceEscape
{
    internal sealed class GameInitialization
    {
        public GameInitialization(Controllers controllers, Data data)
        {
            var mainCamera = Camera.main;

            var cameraController = new CameraController(mainCamera);
            var inputInitialization = new InputInitialization();
            var bulletModel = new BulletModel(data.Bullet);
            var playerModel = new PlayerModel(data.Player.PlayerPrefab, data.Player.Speed, data.Player.Position, data.Player.Name);
            var playerFactory = new PlayerFactory(playerModel);
            var bulletFactory = new BulletFactory(bulletModel);
            var playerInitialization = new PlayerInitialization(playerFactory, playerModel.Position);
            
            var bulletPullController = new BulletPullController(bulletFactory, playerInitialization.GetPlayer(), bulletModel.FirePointOffset);
            var bulletController = new BulletController(bulletPullController, cameraController);

            var enemyFactory = new EnemyFactory();
            var enemiesController = new EnemiesController(enemyFactory, data, bulletPullController);

            var scoreController = new ScoreController(enemiesController);

            var guiController = new GUIController(data.MainMenuData, scoreController);

            controllers.Add(cameraController);
            controllers.Add(inputInitialization);
            controllers.Add(playerInitialization);
            controllers.Add(bulletPullController);
            controllers.Add(bulletController);
            controllers.Add(enemiesController);

            controllers.Add(new InputController(inputInitialization.GetInput()));
            controllers.Add(new MoveController(inputInitialization.GetInput(), playerInitialization.GetPlayer(), playerModel, cameraController));
            controllers.Add(new FireController(inputInitialization.GetInput(), bulletPullController, bulletModel));
            controllers.Add(new CameraMoveController(mainCamera, playerInitialization.GetPlayer(), data.CameraMoveData));

            controllers.Add(scoreController);
            controllers.Add(guiController);

        }
    }
}
