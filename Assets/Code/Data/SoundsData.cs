using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "SoundsData", menuName = "Data/Sounds/SoundsData")]
public class SoundsData : ScriptableObject
{
    [SerializeField] private AudioMixer _mainAudioMixer;
    [SerializeField] private AudioClip _laserSound;
    [SerializeField] private AudioClip _blastSound;


    public AudioMixer MainAudioMixer => _mainAudioMixer;
    public AudioClip LaserSound => _laserSound;
    public AudioClip BlastSound => _blastSound;
    
}
