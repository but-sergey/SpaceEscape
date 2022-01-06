using UnityEngine;

namespace SpaceEscape
{
    public sealed class InputController : IExecute
    {
        private readonly IUserInputProxy _horizontal;
        private readonly IUserInputProxy _vertical;
        private readonly IUserKeyInputProxy _fire;

        public InputController(InputData input)
        {
            _horizontal = input.InputHorizontal;
            _vertical = input.InputVertical;
            _fire = input.InputFire;
        }

        public void Execute(float deltaTime)
        {
            _fire.GetKey();
            _horizontal.GetAxis();
            _vertical.GetAxis();
        }
    }
}
