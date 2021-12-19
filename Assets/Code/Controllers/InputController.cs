using UnityEngine;

namespace SpaceEscape
{
    public sealed class InputController : IExecute
    {
        private readonly IUserInputProxy _horizontal;
        private readonly IUserInputProxy _vertical;
        private readonly IFireController _fireController;
        private readonly Transform _player;

        public InputController(Transform player, (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) input, IFireController fireController)
        {
            _player = player;
            _fireController = fireController;

            _horizontal = input.inputHorizontal;
            _vertical = input.inputVertical;
        }

        public void Execute(float deltaTime)
        {
            if (Input.GetKeyDown(KeyManager.FIRE))
            {
                _fireController.Fire();
            }

            _horizontal.GetAxis();
            _vertical.GetAxis();
        }
    }
}
