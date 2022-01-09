namespace SpaceEscape
{
    internal sealed class InputSystem
    {
        private InputInitialization _inputInitialization;

        public InputSystem(Controllers controllers)
        {
            _inputInitialization = new InputInitialization();
            controllers.Add(_inputInitialization);
            controllers.Add(new InputController(_inputInitialization.GetInput()));
        }

        public InputData GetInput()
        {
            return _inputInitialization.GetInput();
        }
    }
}
