namespace SpaceEscape
{
    internal sealed class InputSystem
    {
        private InputInitialization _inputInitialization;
        internal InputController InputController;

        public InputSystem(Controllers controllers)
        {
            _inputInitialization = new InputInitialization();
            controllers.Add(_inputInitialization);
            InputController = new InputController(_inputInitialization.GetInput());
            controllers.Add(InputController);
        }

        public InputData GetInput()
        {
            return _inputInitialization.GetInput();
        }
    }
}
