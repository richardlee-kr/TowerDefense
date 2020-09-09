using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("EnemyStats")]
    public float startSpeed = 10f;

    [HideInInspector]
    public float speed;

    private WaveSpawner spawner;

    public float health = 100;
    public int worth = 50;


    public GameObject deathEffect;
    private void Start()
    {
        speed = startSpeed;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if(health<=0)
        {
            Die();
        }
    }

    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
    }

    void Die()
    {
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 3f);

        PlayerStats.Money += worth;
        Destroy(gameObject);
    }

}
