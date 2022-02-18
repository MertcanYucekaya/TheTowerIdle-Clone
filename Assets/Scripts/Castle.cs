using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Castle : MonoBehaviour
{
    Collider2D[] enemy;
    public GameObject overlapCentral;
    public float overlapRadius;
    public LayerMask enemyLayer;

    public Transform bulletInstantCenter;
    public GameObject bullet;
    public bool bulletSpawnBool;

    public Transform bowInstantCenter;
    public GameObject bow;
    public bool bowSpawnBool;

    public Transform bigBulletInstantCenter;
    public GameObject bigBullet;
    public bool bigBulletSpawnBool;

    public float health;
    public float healthCopy;
    GameManager gameManager;
    bool firstBulletSpawn;
    bool firstBowSpawn;
    public GameObject bowPanel;
    bool firstBigBulletSpawn;
    public GameObject bigBulletPanel;
    void Start()
    {
        firstBulletSpawn = true;
        firstBowSpawn = false;
        firstBigBulletSpawn = false;
        if (PlayerPrefs.GetInt("unlockBow") == 1)
        {
            firstBowSpawn = true;
        }
        if (PlayerPrefs.GetInt("unlockBigBullet") == 1)
        {
            firstBigBulletSpawn = true;
        }
        if (firstBowSpawn == true)
        {
            bowInstantCenter.GetComponent<SpriteRenderer>().enabled = true;
            bowPanel.SetActive(true);
        }
        if (firstBigBulletSpawn == true)
        {
            bigBulletInstantCenter.GetComponent<SpriteRenderer>().enabled = true;
            bigBulletPanel.SetActive(true);
        }

        bulletSpawnBool = false;
        bowSpawnBool = false;
        bigBulletSpawnBool = false;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        healthCopy = health;
        InvokeRepeating("healthRegenMethod", 0f, 1.0f);
    }
    void Update()
    {
        enemy = Physics2D.OverlapCircleAll(overlapCentral.transform.position, overlapRadius, enemyLayer);
        if (getEnemyLenght() > 0 && bulletSpawnBool)
        {
            bulletSpawn();
            bulletSpawnBool = false;
        }
        if (getEnemyLenght() > 0 && firstBulletSpawn)
        {
            bulletSpawn();
            firstBulletSpawn = false;
        }

        if (getEnemyLenght() > 0 && bowSpawnBool)
        {
            bowSpawn();
            bowSpawnBool = false;
        }
        if (getEnemyLenght() > 0 && firstBowSpawn)
        {
            bowSpawn();
            firstBowSpawn = false;
        }

        if (getEnemyLenght() > 0 && bigBulletSpawnBool)
        {
            bigBulletSpawn();
            bigBulletSpawnBool = false;
        }
        if (getEnemyLenght() > 0 && firstBigBulletSpawn)
        {
            bigBulletSpawn();
            firstBigBulletSpawn = false;
        }
    }
    public Collider2D nearMethod()
    {
        int iC=0;
        float distance=float.MaxValue;
        float distanceC= 0;
        Collider2D near= enemy[0];
        for(int i =0;i < enemy.Length; i++)
        {
            distanceC = Vector2.Distance(enemy[i].transform.position, overlapCentral.transform.position);
            if (distanceC < distance)
            {
                iC = i;
                distance = distanceC;
            }
        }
        return enemy[iC];
    }
    void bulletInstant(Transform bulletCnter,GameObject bullet)
    {
        Instantiate(bullet, bulletCnter.position, Quaternion.identity);
    }
    void bulletSpawn()
    {
        bulletInstant(bulletInstantCenter, bullet);
    }
    void bowSpawn()
    {
        bulletInstant(bowInstantCenter, bow);
        bowInstantCenter.transform.up = new Vector2(nearMethod().transform.position.x,nearMethod().transform.position.y) 
            - new Vector2(bowInstantCenter.transform.position.x, bowInstantCenter.transform.position.y);
        bowInstantCenter.transform.rotation *= Quaternion.Euler(0, 0, 180);
    }

    void bigBulletSpawn()
    {
        bulletInstant(bigBulletInstantCenter, bigBullet);
    }
    public int getEnemyLenght()
    {
        return enemy.Length;
    }
    public void castleDamage(float damage)
    {
        healthCopy = healthCopy - damage;
        
        gameManager.setFilledImage(damage);
        if (healthCopy <= 0)
        {
            gameManager.gameOver(); 
        }
    }
    public void healthRegenMethod()
    {
        if(healthCopy + gameManager.baseHeatlhRegen <= health)
        {
            healthCopy = healthCopy + gameManager.baseHeatlhRegen;
            gameManager.setFilledImage(health);
        }
        else
        {
            healthCopy = health;
            
        }
    }
}

