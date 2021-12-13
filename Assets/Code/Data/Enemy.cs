using UnityEngine;

public sealed class Enemy
{
    private GameObject _enemyPrefab;
    private float _enemyHealth;
    private float _enemyDamage;
    private float _enemySpeed;

    public Enemy(GameObject enemyPrefab, float enemyHealth, float enemyDamage, float enemySpeed)
    {

        _enemyPrefab = GameObject.Instantiate(enemyPrefab);
        _enemyHealth = enemyHealth;
        _enemyDamage = enemyDamage;
        _enemySpeed = enemySpeed;
        
    }
    public GameObject EnemyPrefab 
    { 
        get 
        {
            
            return _enemyPrefab; 
        } 
    }
    
    public float EnemyHealth
    {
        get
        {
            return _enemyHealth;
        }
        set
        {
            _enemyHealth = value;
        }
    }

    public float EnemyDamage
    {
        get
        {
            return _enemyDamage;
        }
        set
        {
            _enemyDamage = value;
        }
    }

    public float EnemySpeed
    {
        get
        {
            return _enemySpeed;
        }
        set
        {
            _enemySpeed = value;
        }
    }
    
}
