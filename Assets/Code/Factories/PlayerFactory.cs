using UnityEngine;

namespace SpaceEscape
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
            GameObject player = Object.Instantiate(_playerData.PlayerPrefab);

            return player.transform;
        }
    }
}
