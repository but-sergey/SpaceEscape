using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceEscape
{

    public class BackgroundController : IInitialization, IExecute, ICleanup
    {
        private BackgroundData _backgroundData;
        private BackgroundFactory _backgroundFactory;
        private Collider2D _colliderObserber;

        private float _colliderObserverPosition;

        private List<BackgroundObject> _backgroundObjectStarsPool;
        private List<BackgroundObject> _backgroundObjectsStarsOnScreen;

        private List<BackgroundObject> _backgroundObjectPlanetsPool;
        private List<BackgroundObject> _backgroundObjectCometsPool;


        private float _spawnCoordsXmin = -9.5f;
        private float _spawnCoordsXmax = 9.5f;
        private float _initSpawnCoordsYmin = -6f;
        private float _initSpawnCoordsYmax = 6f;

        private float _respawnCoordsYmin = 6f;
        private float _respawnCoordsYmax = 12f;

        public BackgroundController(BackgroundData bgData, BackgroundFactory bgFactory)
        {
            _backgroundData = bgData;
            _backgroundFactory = bgFactory;
            
        }

        public void Initialization()
        {
            _colliderObserber = Camera.main.GetComponentInChildren<ColliderObserver>().GetComponent<Collider2D>();
            _colliderObserverPosition = _colliderObserber.bounds.center.y - _colliderObserber.bounds.extents.y;

            _backgroundObjectStarsPool = new List<BackgroundObject>();
            _backgroundObjectsStarsOnScreen = new List<BackgroundObject>();
            for (int i = 0; i < _backgroundData.BackgroundStarsDensity; i++)
            {
                BackgroundObject bgObject = _backgroundFactory.CreateBackgroundObject(_backgroundData.BackgroundStars[Random.Range(0, _backgroundData.BackgroundStars.Count)], -3);
                bgObject.BackgroundObjectPrefafab.SetActive(false);
                _backgroundObjectStarsPool.Add(bgObject);
                Vector2 spawnCoords = new Vector2(Random.Range(_spawnCoordsXmin, _spawnCoordsXmax), Random.Range(_initSpawnCoordsYmin, _initSpawnCoordsYmax));
                GetFromPool(bgObject, _backgroundObjectStarsPool, _backgroundObjectsStarsOnScreen, spawnCoords);
            }
        }

        public void Execute(float deltaTime)
        {
            for(int i = 0; i < _backgroundObjectsStarsOnScreen.Count; i++)
            {
                _backgroundObjectsStarsOnScreen[i].BackgroundObjectPrefafab.transform.position -= new Vector3(0, 0.1f, 0) * deltaTime;
                if(_backgroundObjectsStarsOnScreen[i].BackgroundObjectPrefafab.transform.position.y < _colliderObserverPosition)
                {
                    PoolRelease(_backgroundObjectsStarsOnScreen[i], _backgroundObjectsStarsOnScreen, _backgroundObjectStarsPool);
                }
            }
            if(_backgroundObjectsStarsOnScreen.Count < _backgroundData.BackgroundStarsDensity)
            {
                Vector2 newCoords = new Vector2(Random.Range(_spawnCoordsXmin, _spawnCoordsXmax), Random.Range(_respawnCoordsYmin, _respawnCoordsYmax));
                GetFromPool(_backgroundObjectStarsPool[0], _backgroundObjectStarsPool, _backgroundObjectsStarsOnScreen, newCoords);
            }
        }

        private void GetFromPool(BackgroundObject currentObject, List<BackgroundObject> commonPool, List<BackgroundObject> onScreenPool, Vector2 spawnCoords)
        {
            commonPool.Remove(currentObject);
            currentObject.BackgroundObjectPrefafab.transform.position = spawnCoords;
            float objScalefactor = Random.Range(0.1f, 0.5f);
            currentObject.BackgroundObjectPrefafab.transform.localScale = new Vector3(objScalefactor, objScalefactor);
            onScreenPool.Add(currentObject);
            currentObject.BackgroundObjectPrefafab.SetActive(true);
        }

        private void PoolRelease(BackgroundObject currentObject, List<BackgroundObject> onScreenPool, List<BackgroundObject> commonPool)
        {
            currentObject.BackgroundObjectPrefafab.SetActive(false);
            onScreenPool.Remove(currentObject);
            currentObject.BackgroundObjectPrefafab.transform.position = new Vector2(_spawnCoordsXmin, _respawnCoordsYmax);
            currentObject.BackgroundObjectPrefafab.transform.localScale = Vector2.one;
            commonPool.Add(currentObject);
        }

        public void Cleanup()
        {
        }

    }
}