using UnityEngine;

namespace SpaceEscape
{
    internal sealed class InputInitialization : IInitialization
    {
        private IUserInputProxy _pcInputHorizontal;
        private IUserInputProxy _pcInputVertical;
        private IUserKeyInputProxy _pcInputFire;

        public InputInitialization()
        {
            _pcInputHorizontal = new PCInputHorizontal();
            _pcInputVertical = new PCInputVertical();
            _pcInputFire = new PCInputFire();
        }

        public void Initialization()
        { 
        }

        public (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical, IUserKeyInputProxy inputFire) GetInput()
        {
            (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical, IUserKeyInputProxy inputFire) result = (_pcInputHorizontal, _pcInputVertical, _pcInputFire);
            return result;
        }
    }
}
