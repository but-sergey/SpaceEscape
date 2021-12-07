using System.Collections.Generic;

namespace RollABall
{
    internal sealed class Controllers : IInitialization, IExecute, ILateExecute, ICleanup
    {
        private readonly int _controllersInitCount = 10;
        private readonly List<IInitialization> _initializationControllers;
        private readonly List<IExecute> _executeControllers;
        private readonly List<ILateExecute> _lateControllers;
        private readonly List<ICleanup> _cleanupControllers;

        internal Controllers()
        {
            _initializationControllers = new List<IInitialization>(_controllersInitCount);
            _executeControllers = new List<IExecute>(_controllersInitCount);
            _lateControllers = new List<ILateExecute>(_controllersInitCount);
            _cleanupControllers = new List<ICleanup>(_controllersInitCount);
        }

        internal Controllers Add(IController controller)
        {
            if(controller is IInitialization initializeController)
            {
                _initializationControllers.Add(initializeController);
            }

            if(controller is IExecute executeController)
            {
                _executeControllers.Add(executeController);
            }

            if(controller is ILateExecute lateController)
            {
                _lateControllers.Add(lateController);
            }

            if(controller is ICleanup cleanupController)
            {
                _cleanupControllers.Add(cleanupController);
            }

            return this;
        }

        public void Initialization()
        {
            for(var index = 0; index < _initializationControllers.Count; ++index)
            {
                _initializationControllers[index].Initialization();
            }
        }

        public void Execute(float deltaTime)
        {
            for(var index = 0; index < _executeControllers.Count; ++index)
            {
                _executeControllers[index].Execute(deltaTime);
            }
        }

        public void LateExecute(float deltaTime)
        {
            for(var index = 0; index < _lateControllers.Count; ++index)
            {
                _lateControllers[index].LateExecute(deltaTime);
            }
        }

        public void Cleanup()
        {
            for(var index = 0; index < _cleanupControllers.Count; ++index)
            {
                _cleanupControllers[index].Cleanup();
            }
        }
    }
}
