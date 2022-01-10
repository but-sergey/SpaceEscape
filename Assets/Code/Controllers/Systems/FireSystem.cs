using UnityEngine;

namespace SpaceEscape
{
    internal sealed class FireSystem
    {
        public FireSystem(Controllers controllers, InputSystem inputSystem, BulletSystem bulletSystem)
        {
            controllers.Add(new FireController(inputSystem.GetInput(), bulletSystem.BulletPullController, bulletSystem.BulletModel));
        }
    }
}
