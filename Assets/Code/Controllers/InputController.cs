using UnityEngine;

namespace RollABall
{
    public sealed class InputController : IExecute
    {
        private readonly IUserInputProxy _horizontal;
        private readonly IUserInputProxy _vertical;
        private readonly ISaveDataRepository _saveDataRepository;
        private readonly Transform _player;

        public InputController(Transform player, (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) input)
        {
            _saveDataRepository = new SaveDataRepository();

            _player = player;

            _horizontal = input.inputHorizontal;
            _vertical = input.inputVertical;
        }

        public void Execute(float deltaTime)
        {
            if(Input.GetKeyDown(KeyManager.SAVE))
            {
                _saveDataRepository.Save(_player);
            }

            if (Input.GetKeyDown(KeyManager.LOAD))
            {
                _saveDataRepository.Load(_player);
            }

            _horizontal.GetAxis();
            _vertical.GetAxis();
        }
    }
}
