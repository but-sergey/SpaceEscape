using UnityEngine;

namespace SpaceEscape
{
    internal sealed class PlayerSystem
    {
        private PlayerInitialization _playerInitialization;
        private PlayerModel _playerModel;
        private PlayerFactory _playerFactory;

        public PlayerModel PlayerModel
        {
            get
            {
                return _playerModel;
            }
        }

        public PlayerSystem(Controllers controllers, Data data)
        {
            _playerModel = new PlayerModel(data.Player);
            _playerFactory = new PlayerFactory(_playerModel);
            _playerInitialization = new PlayerInitialization(_playerFactory, _playerModel.Position);
            controllers.Add(_playerInitialization);
        }

        public Transform GetPlayer()
        {
            return _playerInitialization.GetPlayer();
        }
    }
}
