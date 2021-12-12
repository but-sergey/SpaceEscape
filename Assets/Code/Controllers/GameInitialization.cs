using UnityEngine;

namespace SpaceEscape
{
    internal sealed class GameInitialization
    {
        public GameInitialization(Controllers controllers, Data data)
        {
            var inputInitialization = new InputInitialization();
            var playerModel = new PlayerModel(data.Player.PlayerSprite, data.Player.Speed, data.Player.Position, data.Player.Name);
            var bulletModel = new BulletModel(data.Bullet.BulletSprite, data.Bullet.Name, data.Bullet.FirePointOffset, data.Bullet.Speed, data.Bullet.Force);
            var playerFactory = new PlayerFactory(playerModel);
            var bulletFactory = new BulletFactory(bulletModel);
            var playerInitialization = new PlayerInitialization(playerFactory, playerModel.Position);
            var bulletController = new BulletController(bulletFactory, playerInitialization.GetPlayer(), bulletModel.FirePointOffset);
            var fireController = new FireController(bulletController, bulletModel);

            controllers.Add(inputInitialization);
            controllers.Add(playerInitialization);
            controllers.Add(bulletController);
            controllers.Add(fireController);

            controllers.Add(new InputController(playerInitialization.GetPlayer(), inputInitialization.GetInput(), fireController));
            controllers.Add(new MoveController(inputInitialization.GetInput(), playerInitialization.GetPlayer(), playerModel));
        }
    }
}
