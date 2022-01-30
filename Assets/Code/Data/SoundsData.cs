using UnityEngine;

[CreateAssetMenu(fileName = "SoundsData", menuName = "Data/Sounds/SoundsData")]
public class SoundsData : ScriptableObject
{
    [SerializeField] private AudioClip _laserSound;

    public AudioClip LaserSound => _laserSound;
}
