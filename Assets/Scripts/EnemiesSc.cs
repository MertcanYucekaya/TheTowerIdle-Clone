using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSc : MonoBehaviour
{
    public float speed;
    float speedC;
    public Transform target;
    public float health;
    Castle castle;
    public float damage;
    public float damageRepeatTime;
    public int gainCoin;
    GameManager gameManager;
    SpawnerSc spawnerSc;
    bool speedMinus;
    public bool asidRain;
    public int score;
    void Start()
    {
        asidRain = false;
        speedMinus = true;
        speedC = speed;
        target = GameObject.Find("OverlapCircle").transform;
        castle = GameObject.Find("Castle").GetComponent<Castle>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        spawnerSc = GameObject.Find("SpawnerParent").GetComponent<SpawnerSc>();
        damage = damage + spawnerSc.currentWave*2;
        health = health + spawnerSc.currentWave*2;
    }

    
    void Update()
    {
        if (asidRain)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, Time.deltaTime * speed/2);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
        }
        
    }
    public void getDamage(float damage)
    {
        health = health - damage;
        if (health <= 0)
        {
            PlayerPrefs.SetInt("lastScore", PlayerPrefs.GetInt("lastScore") + score);
            Destroy(gameObject);
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Castle"))
        {
            InvokeRepeating("castleDamage", 0, damageRepeatTime);
        }
    }
    void castleDamage()
    {
        castle.castleDamage(damage);
    }
    private void OnDestroy()
    {
        spawnerSc.EnemiesSpawnAmountEnemiesCopy--;
        gameManager.EnemiesAmountMethod(spawnerSc.EnemiesSpawnAmountEnemiesCopy);
        gameManager.coinMethod(gainCoin);
        
    }
    public void minusSpeed()
    {
        if (speedMinus)
        {
            speed = speed / 2;
        }
    }
    public void thornSpeed()
    {
        speed = speedC;
    }
}
