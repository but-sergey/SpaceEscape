using UnityEngine;

namespace SpaceEscape
{
    public sealed class InputController : IExecute
    {
        private readonly IUserInputProxy _horizontal;
        private readonly IUserInputProxy _vertical;
        private readonly IUserKeyInputProxy _fire;

        public InputController((IUserInputProxy inputHorizontal, IUserInputProxy inputVertical, IUserKeyInputProxy inputFire) input)
        {
            _horizontal = input.inputHorizontal;
            _vertical = input.inputVertical;
            _fire = input.inputFire;
        }

        public void Execute(float deltaTime)
        {
            _fire.GetKey();
            _horizontal.GetAxis();
            _vertical.GetAxis();
        }
    }
}
