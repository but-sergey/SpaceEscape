using UnityEngine;


namespace SpaceEscape
{
    internal sealed class SoundsController : IInitialization, ICleanup
    {
        private IUserKeyInputProxy _fireInputProxy;
        private AudioSource _playerAudioSource;
        private AudioClip _laserSound;

        public SoundsController(InputData input, Data data, PlayerSystem player)
        {
            _fireInputProxy = input.InputFire;
            _playerAudioSource = player.PlayerModel.PlayerPrefab.GetComponent<AudioSource>();
            _laserSound = data.SoundsData.LaserSound;
        }
        public void Initialization()
        {
            _fireInputProxy.KeyOnChange += OnFireButtonPressed;
        }

        public void Cleanup()
        {
            _fireInputProxy.KeyOnChange -= OnFireButtonPressed;
        }

        void OnFireButtonPressed(bool val)
        {
            _playerAudioSource.PlayOneShot(_laserSound);
        }
    }
}