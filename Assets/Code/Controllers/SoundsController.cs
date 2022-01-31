using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace SpaceEscape
{
    internal sealed class SoundsController : IInitialization, ICleanup
    {
        private IUserKeyInputProxy _fireInputProxy;
        private AudioSource _playerAudioSource;
        private Transform _playerTransform;
        private AudioMixer _mainAudioMixer;
        private float _masterVolume;
        private AudioClip _laserSound;
        private AudioClip _blastSound;
        private EnemySystem _enemySystem;
        private EnemiesController _enemiesController;
        

        public SoundsController(InputData input, Data data, PlayerSystem player, EnemySystem enemies)
        {
            _fireInputProxy = input.InputFire;
            _playerTransform = player.GetPlayer();
            _mainAudioMixer = data.SoundsData.MainAudioMixer;
            _laserSound = data.SoundsData.LaserSound;
            _blastSound = data.SoundsData.BlastSound;
            _enemySystem = enemies;
        }
        public void Initialization()
        {
            _fireInputProxy.KeyOnChange += OnFireButtonPressed;
            _playerTransform.gameObject.TryGetComponent<AudioSource>(out _playerAudioSource);
            _enemiesController = _enemySystem.EnemiesController;
            _enemiesController.ScoreWasChanged += AsteroidWasBlasted;
            float volume;
            _mainAudioMixer.GetFloat("MasterVolume", out volume);
            Debug.Log(volume);
                        
        }

        public void Cleanup()
        {
            _fireInputProxy.KeyOnChange -= OnFireButtonPressed;
            _enemiesController.ScoreWasChanged -= AsteroidWasBlasted;
        }

        void AsteroidWasBlasted(int newScore)
        {
            _playerAudioSource.PlayOneShot(_blastSound);
        }

        void OnFireButtonPressed(bool val)
        {
            if (val)
            {
                _playerAudioSource.PlayOneShot(_laserSound);
            }
        }
    }
}