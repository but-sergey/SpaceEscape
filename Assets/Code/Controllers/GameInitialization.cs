using UnityEngine;

namespace RollABall
{
    internal sealed class GameInitialization
    {
        public GameInitialization(Controllers controllers, Data data)
        {
            Camera camera = Camera.main;

            var inputInitialization = new InputInitialization();
            var playerModel = new PlayerModel(data.Player.Prefab, data.Player.Speed, data.Player.Position, data.Player.Name);
            var playerFactory = new PlayerFactory(playerModel);
            var playerInitialization = new PlayerInitialization(playerFactory, playerModel.Position);

            controllers.Add(inputInitialization);
            controllers.Add(playerInitialization);

            //controllers.Add(new MapController());
            controllers.Add(new CameraInitialization(camera.transform, playerModel.Position));
            controllers.Add(new LevelController(data.Level));
            controllers.Add(new InputController(playerInitialization.GetPlayer(), inputInitialization.GetInput()));
            controllers.Add(new MoveController(inputInitialization.GetInput(), playerInitialization.GetPlayer(), playerModel));
            controllers.Add(new CameraController(playerInitialization.GetPlayer(), camera.transform));
        }
    }
}
