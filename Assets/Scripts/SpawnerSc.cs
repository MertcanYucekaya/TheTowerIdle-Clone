using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnerSc : MonoBehaviour
{
    Transform[] spawnPoint;
    public GameObject[] enemies;
    public int EnemiesSpawnAmount;
    public int EnemiesSpawnnerAmountCopy;
    public int EnemiesSpawnAmountEnemiesCopy;
    public int currentWave;
    public int EnemiesSpawnDuration;
    public int waveEnemiesPlus;
    bool isSpawn = true;
    int[] spawnChoose = new int[100];
    [Header("Percent")]
    public int soldier1Percent;
    public int soldierSpeedPercent;
    public int soldier2Percent;
    public int soldierBowPercent;
    public int soldierBossPercent;
    GameManager gameManager;
    [Header("EnemyHitInfo")]
    public TextMeshProUGUI enemyHitPointText;
    public TextMeshProUGUI enemyDamageText;

    void Start()
    {
        enemyDamageText.text = 21.ToString();
        enemyHitPointText.text = 21.ToString();
        EnemiesSpawnAmountEnemiesCopy = EnemiesSpawnAmount;
        EnemiesSpawnnerAmountCopy = EnemiesSpawnAmount;
        spawnPoint = GetComponentsInChildren<Transform>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        currentWave = 1;
        gameManager.currentWaveMethod(currentWave);
        gameManager.EnemiesAmountMethod(EnemiesSpawnAmountEnemiesCopy);
        for (int i = 0; i <= 100; i++)
        {
           
            if (i <= soldier1Percent)
            {
                spawnChoose[i] = 1;
               
            }
            else if (i <= soldierSpeedPercent+ soldier1Percent)
            {
                spawnChoose[i] = 2;
                
            }
            else if (i <= soldier1Percent + soldierSpeedPercent+ soldier2Percent)
            {
                spawnChoose[i] = 3;
                
            }
            else if (i <= soldier1Percent + soldierSpeedPercent + soldier2Percent+ soldierBowPercent)
            {
                spawnChoose[i] = 4;
               
            }
            else if (i <= soldier1Percent + soldierSpeedPercent + soldier2Percent + soldierBowPercent+ soldierBossPercent)
            {
                spawnChoose[i] = 5;
               

            }
        }
        InvokeRepeating("spawnMethod", 0, EnemiesSpawnDuration / EnemiesSpawnAmount);
    }


    void Update()
    {
    }

    void spawnMethod()
    {
        if (isSpawn)
        {
            
            int random = Random.Range(0, spawnChoose.Length);
            int randomSpawn = Random.Range(1, spawnPoint.Length);

            if (spawnChoose[random] == 1)
            { 
                Instantiate(enemies[0], vector2To3(spawnPoint[randomSpawn]), Quaternion.identity);
            }
            if (spawnChoose[random] == 2)
            {
                Instantiate(enemies[1], vector2To3(spawnPoint[randomSpawn]), Quaternion.identity);
            }
            if (spawnChoose[random] == 3)
            {
                Instantiate(enemies[2], vector2To3(spawnPoint[randomSpawn]), Quaternion.identity);
            }
            if (spawnChoose[random] == 4)
            {
                Instantiate(enemies[3], vector2To3(spawnPoint[randomSpawn]), Quaternion.identity);
            }
            if (spawnChoose[random] == 5)
            {
                Instantiate(enemies[4], vector2To3(spawnPoint[randomSpawn]), Quaternion.identity);
            }
            EnemiesSpawnnerAmountCopy--;
            if (EnemiesSpawnnerAmountCopy == 0)
            {
                isSpawn = false;
            }
        }
        if (EnemiesSpawnAmountEnemiesCopy == 0)
        {
            currentWave++;
            enemyDamageText.text = (20+currentWave).ToString();
            enemyHitPointText.text = (20 + currentWave).ToString();
            gameManager.currentWaveMethod(currentWave);
            EnemiesSpawnAmount = waveEnemiesPlus+ EnemiesSpawnAmount;
            EnemiesSpawnnerAmountCopy = EnemiesSpawnAmount;
            EnemiesSpawnAmountEnemiesCopy = EnemiesSpawnAmount;
            gameManager.EnemiesAmountMethod(EnemiesSpawnAmountEnemiesCopy);
            isSpawn = true;
        }
    }
    Vector3 vector2To3(Transform vector)
    {
        return new Vector3(vector.position.x, vector.position.y, 0);
    }

}

