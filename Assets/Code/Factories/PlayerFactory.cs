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
            return new GameObject(_playerData.Name)
                .AddSprite(_playerData.PlayerSprite)
                .AddCircleCollider2D()
                .transform;
        }
    }
}
