using UnityEngine;

namespace RollABall
{
    public sealed class PlayerFactory : IPlayerFactory
    {
        private readonly IPlayerModel _playerData;

        public PlayerFactory(IPlayerModel playerData)
        {
            _playerData = playerData;
        }

        public Transform CreatePlayer()
        {
            return Object.Instantiate(_playerData.Prefab, _playerData.Position, Quaternion.identity).transform;
        }
    }
}
