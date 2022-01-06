using UnityEngine;

public sealed class Enemy
{
    public int EnemyMaxHealth;
    public int EnemyDamage;
    public float EnemySpeed;
    public int EnemyScore;

    internal int EnemyCurrentHealth;

    private GameObject _enemyPrefab;

    public Enemy(GameObject enemyPrefab, int enemyHealth, int enemyDamage, float enemySpeed, int enemyScore)
    {

        _enemyPrefab = GameObject.Instantiate(enemyPrefab);
        EnemyMaxHealth = enemyHealth;
        EnemyDamage = enemyDamage;
        EnemySpeed = enemySpeed;
        EnemyScore = enemyScore;

    }
    public GameObject EnemyPrefab
    {
        get
        {
            return _enemyPrefab;
        }
    }
}
