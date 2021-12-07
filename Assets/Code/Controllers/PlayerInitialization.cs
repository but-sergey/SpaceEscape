using UnityEngine;

namespace RollABall
{
    internal sealed class PlayerInitialization : IInitialization
    {
        private readonly IPlayerFactory _playerFactory;
        private Transform _player;

        public PlayerInitialization(IPlayerFactory playerFactory, Vector3 positionPlayer)
        {
            _playerFactory = playerFactory;
            _player = _playerFactory.CreatePlayer();
            _player.position = positionPlayer;
        }

        public void Initialization()
        {
        }

        public Transform GetPlayer()
        {
            return _player;
        }
    }
}
