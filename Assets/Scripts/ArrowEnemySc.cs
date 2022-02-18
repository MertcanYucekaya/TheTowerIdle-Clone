using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowEnemySc : MonoBehaviour
{
    public float speed;
    float speedC;
    Transform target;
    public float health;
    public bool moveTo = true;
    public float arrowRange;
    Collider2D[] overlapArray;
    public GameObject arrow;
    public float arrowRepeatTime;
    public int gainCoin;
    GameManager gameManager;
    SpawnerSc spawnerSc;
    bool speedMinus;
    bool isVelo = true;
    public bool asidRain;
    public int score;
    void Start()
    {
        asidRain = false;
        speedMinus = true;
        speedC = speed;
        target = GameObject.Find("OverlapCircle").transform;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        spawnerSc = GameObject.Find("SpawnerParent").GetComponent<SpawnerSc>();
        health = health + spawnerSc.currentWave * 2;
    }
    void Update()
    {
        if (moveTo)
        {
            overlapArray = Physics2D.OverlapCircleAll(transform.position, arrowRange);
            foreach (Collider2D c in overlapArray)
            {
                if (c.transform.name.Equals("Castle"))
                {
                    moveTo = false;
                    InvokeRepeating("arrowSpawn", 0, arrowRepeatTime);
                }
            }
            if (asidRain)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, Time.deltaTime * speed/2);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
            }
            
        }
        
    }
    public void getDamage(float damage)
    {
        health = health - damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            PlayerPrefs.SetInt("lastScore", PlayerPrefs.GetInt("lastScore") + score);
        }
    }
    void arrowSpawn()
    {
        if (moveTo == false&&isVelo)
        {
            Instantiate(arrow, transform.position, Quaternion.identity);
        }
        
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
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("WindCol"))
        {
            
            isVelo = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("WindCol"))
        {
            moveTo = true;
            isVelo = true;
        }
    }
}
