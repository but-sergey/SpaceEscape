using UnityEngine;

public sealed class Enemy
{
    private GameObject _enemyPrefab;
    private int _enemyHealth;
    private int _enemyDamage;
    private float _enemySpeed;
    private int _enemyScore;

    internal int EnemyCurrentHealth;

    public Enemy(GameObject enemyPrefab, int enemyHealth, int enemyDamage, float enemySpeed, int enemyScore)
    {

        _enemyPrefab = GameObject.Instantiate(enemyPrefab);
        _enemyHealth = enemyHealth;
        _enemyDamage = enemyDamage;
        _enemySpeed = enemySpeed;
        _enemyScore = enemyScore;

    }
    public GameObject EnemyPrefab
    {
        get
        {

            return _enemyPrefab;
        }
    }

    public int EnemyMaxHealth
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

    public int EnemyDamage
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

    public int EnemyScore
    {
        get
        {
            return _enemyScore;
        }
        set
        {
            _enemyScore = value;
        }
    }
    
    
    
}
