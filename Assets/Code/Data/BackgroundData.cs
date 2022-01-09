using System.Collections.Generic;
using UnityEngine;


namespace SpaceEscape
{
    [CreateAssetMenu(fileName = "BackgroundData", menuName = "Data/Background/BackgroundSettings")]
    public class BackgroundData : ScriptableObject
    {
        [Header("Stars")]
        [SerializeField] private List<GameObject> _backgroundStars;
        [Tooltip("Stars at screen in same time")] [SerializeField] private int _backgroundStarsDensity = 30;
        //[SerializeField] private float _backgroundStarsSpeed = 1.0f;
        
        [Header("Planets")]
        [SerializeField] private List<GameObject> _backgroundPlanets;
        [Tooltip("Max number of planets at screen in same time")] [SerializeField] private int _backgroundPlanetDensity = 2;
        [SerializeField] private int _backgroundPlanetsDelayMin = 10;
        [SerializeField] private int _backgroundPlanetsDelayMax = 20;
        
        
        [Header("Comets")]
        [SerializeField] private List<GameObject> _backgroundComets;
        [Tooltip("Comets at screen in same time")][SerializeField] private int _backgroundCometsDensity = 1;
        [Tooltip("Minimum delay between comets in seconds")] [SerializeField] private int _backgroundCometsDelayMin = 10;
        [Tooltip("Maximum delay between comets in seconds")] [SerializeField] private int _backgroundCometsDelayMax = 20;

        public List<GameObject> BackgroundStars => _backgroundStars;
        public int BackgroundStarsDensity => _backgroundStarsDensity;

        public List<GameObject> BackgroundPlanets => _backgroundPlanets;
        public int BackgroundPlanetsDensity => _backgroundPlanetDensity;
        public int BackgroundPlanetsDelayMin => _backgroundPlanetsDelayMin;
        public int BackgroundPlanetsDelayMax => _backgroundPlanetsDelayMax;

        public List<GameObject> BackgroundComets => _backgroundComets;
        public int BackgroundCometsDensity => _backgroundCometsDensity;
        public int BackgroundCometsDelayMin => _backgroundCometsDelayMin;
        public int BackgroundCometsDelayMax => _backgroundCometsDelayMax;
    }
}