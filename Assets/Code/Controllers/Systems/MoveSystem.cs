using UnityEngine;

namespace SpaceEscape
{
    internal sealed class MoveSystem
    {
        public MoveSystem(Controllers controllers, InputSystem inputSystem, PlayerSystem playerSystem, CameraSystem cameraSystem)
        {
            controllers.Add(new MoveController(inputSystem.GetInput(), playerSystem.GetPlayer(), playerSystem.PlayerModel, cameraSystem.CameraController));
        }
    }
}
