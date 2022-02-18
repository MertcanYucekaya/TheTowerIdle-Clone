using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    Castle castle;
    public int gameInCoin=0;
    public TextMeshProUGUI gameInCoinText;
    public GameObject bulletObj;
    public GameObject crossBow;
    public GameObject bigBullet;
    BigBulletSc bigBulletSc;
    Bullet bullet;
    CrossBowSc crossBowSc;
    public TextMeshProUGUI gameOutCoinText;
    [Header("AttackPanelDamage")]
    public GameObject bowPanel;
    public GameObject bigBulletpanel;
    [Header("BulletDamage")]
    public TextMeshProUGUI bulletdamageText;
    public TextMeshProUGUI bulletdamagePriceText;
    public int bulletDamagePrice;
    public int bulletDamagePricePlus;
    public int bulletDamagePlus;
    [Header("BulletSpeed")]
    public TextMeshProUGUI bulletSpeedText;
    public TextMeshProUGUI bulletSpeedPriceText;
    public int bulletSpeedPrice;
    public int bulletSpeedPricePlus;
    public float bulletSpeedPlus;
    [Header("BowDamage")]
    public TextMeshProUGUI bowDamageText;
    public TextMeshProUGUI bowDamagePriceText;
    public int bowDamagePrice;
    public int bowDamagePricePlus;
    public int bowDamagePlus;
    [Header("BowSpeed")]
    public TextMeshProUGUI bowSpeedText;
    public TextMeshProUGUI bowSpeedPriceText;
    public int bowSpeedPrice;
    public int bowSpeedPricePlus;
    public float bowSpeedPlus;
    [Header("BigBulletDamage")]
    public TextMeshProUGUI bigBulletdamageText;
    public TextMeshProUGUI bigBulletdamagePriceText;
    public int bigBulletDamagePrice;
    public int bigBulletDamagePricePlus;
    public int bigBulletDamagePlus;
    [Header("BigBulletSpeed")]
    public TextMeshProUGUI bigBulletSpeedText;
    public TextMeshProUGUI bigBulletSpeedPriceText;
    public int bigBulletSpeedPrice;
    public int bigBulletSpeedPricePlus;
    public float bigBulletSpeedPlus;
    [Header ("CastleHealth")]
    public TextMeshProUGUI CastleHealhText;
    public TextMeshProUGUI CastleHealhPriceText;
    public int plusCastleHealth;
    public int baseCastleHealthPrice;
    public int plusBaseCastleHealthPrice;
    [Header("HealthRegen")]
    public TextMeshProUGUI healthRegenText;
    public TextMeshProUGUI healthRegenPriceText;
    public float baseHeatlhRegen;
    public float healthRegenPlus;
    public float baseHealthRegenPrice;
    public float HealthRegenPricePlus;
    [Header("WaveAndEnemiesPanel")]
    public TextMeshProUGUI enemiesAmountText;
    public TextMeshProUGUI currentWaveText;
    [Header("WaveAndEnemiesPanel")]
    public Image filledImage;
    float filled;
    [Header("PanelControl")]
    public GameObject attackPanel;
    public GameObject defancePanel;
    public GameObject cardsPanel;
    public TextMeshProUGUI buffInfoText;
    [Header("GameSpeed")]
    public TextMeshProUGUI currentGameSpeedText;
    int gameSpeed;
    [Header("Pause")]
    public GameObject pausePanel;
    public TextMeshProUGUI gamePauseMenuCoinText;
    [Header("GameOverPanel")]
    public TextMeshProUGUI currentDiaText;
    public TextMeshProUGUI currnetWaveCoinText;
    public GameObject gameOverPanel;
    SpawnerSc spawnerSc;
    public TextMeshProUGUI gainWaweCoinText;
    public int gameContinuePrice;
    public TextMeshProUGUI gameContinuePriceText;
    public TextMeshProUGUI menuWaweCoin;
    public GameObject adButton;
    public GameObject menuButtonCoin;
    [Header("Sound")]
    public Sprite soundOnImage;
    public Sprite soundOffImage;
    AudioSource audio;
    public Button soundButton;
   


    void Start()
    {

        PlayerPrefs.SetInt("lastScore", 0);
        audio = GetComponent<AudioSource>();
        gameSpeed = 1;
        gameOutCoinText.text = PlayerPrefs.GetInt("gameOutCoin").ToString();
        spawnerSc = GameObject.Find("SpawnerParent").GetComponent<SpawnerSc>();
        currentGameSpeedText.text = gameSpeed.ToString();
        castle = GameObject.Find("Castle").GetComponent<Castle>();
        bullet = bulletObj.GetComponent<Bullet>();
        crossBowSc = crossBow.GetComponent<CrossBowSc>();
        bigBulletSc = bigBullet.GetComponent<BigBulletSc>();
        castle.health += PlayerPrefs.GetInt("addHealth");
        baseHeatlhRegen += PlayerPrefs.GetFloat("addHealthRegen");
        CastleHealhText.text = castle.health.ToString();
        CastleHealhPriceText.text = baseCastleHealthPrice.ToString();
        healthRegenText.text = baseHeatlhRegen.ToString();
        healthRegenPriceText.text = baseHealthRegenPrice.ToString();

        if (PlayerPrefs.GetInt("bowPanel") == 1)
        {
            bowPanel.SetActive(true);
        }
        if (PlayerPrefs.GetInt("bigBulletPanel") == 1)
        {
            bigBulletpanel.SetActive(true);
        }


        if (!PlayerPrefs.HasKey("bulletBaseDamage"))
        {
            PlayerPrefs.SetFloat("bulletBaseDamage", bullet.damage);
            PlayerPrefs.SetFloat("bulletBaseSpeed", bullet.speed);
        }
        else
        {
            bullet.damage = PlayerPrefs.GetFloat("bulletBaseDamage")+ PlayerPrefs.GetInt("addBulletDamage");
            bullet.speed = PlayerPrefs.GetFloat("bulletBaseSpeed")+PlayerPrefs.GetFloat("addBulletSpeed");
        }


        if (!PlayerPrefs.HasKey("bowBaseDamage"))
        {
            PlayerPrefs.SetFloat("bowBaseDamage", crossBowSc.damage);
            PlayerPrefs.SetFloat("bowBaseSpeed", crossBowSc.speed);
        }
        else
        {
            crossBowSc.damage = PlayerPrefs.GetFloat("bowBaseDamage")+ PlayerPrefs.GetInt("addCrossbowDamage");
            crossBowSc.speed = PlayerPrefs.GetFloat("bowBaseSpeed")+ PlayerPrefs.GetFloat("addCrossBowSpeed");
        }

        if (!PlayerPrefs.HasKey("bigBulletBaseDamage"))
        {
            PlayerPrefs.SetFloat("bigBulletBaseDamage", bigBulletSc.damage);
            PlayerPrefs.SetFloat("bigBulletBaseSpeed", bigBulletSc.speed);
        }
        else
        {
            bigBulletSc.damage = PlayerPrefs.GetFloat("bigBulletBaseDamage")+ PlayerPrefs.GetInt("addBigBulletDamage");
            bigBulletSc.speed = PlayerPrefs.GetFloat("bigBulletBaseSpeed")+ PlayerPrefs.GetFloat("addBigBulletSpeed");
        }


        gameInCoinText.text = gameInCoin.ToString();

        bulletdamageText.text = bullet.damage.ToString();
        bulletdamagePriceText.text = bulletDamagePrice.ToString();
        bulletSpeedPriceText.text = bulletSpeedPrice.ToString();
        bulletSpeedText.text = bullet.speed.ToString();

        bowDamageText.text = crossBowSc.damage.ToString();
        bowDamagePriceText.text = bowDamagePrice.ToString();
        bowSpeedText.text = crossBowSc.speed.ToString();
        bowSpeedPriceText.text = bowSpeedPrice.ToString();

        bigBulletdamageText.text = bigBulletSc.damage.ToString();
        bigBulletdamagePriceText.text = bigBulletDamagePrice.ToString();
        bigBulletSpeedPriceText.text = bigBulletSpeedPrice.ToString();
        bigBulletSpeedText.text = bigBulletSc.speed.ToString();

    }
    void Update()
    {
        
    }

    public void soundMethod()
    {
        
        if (audio.mute == false)
        {
            audio.mute = true;
            soundButton.GetComponent<Image>().sprite = soundOffImage;
            Debug.Log("false");
        }
        else if (audio.mute == true)
        {
            audio.mute = false;
            soundButton.GetComponent<Image>().sprite = soundOnImage;
            Debug.Log("true");
        }
    }
    public void coinMethod(int coin)
    {
        gameInCoin = gameInCoin + coin;
        gameInCoinText.text = gameInCoin.ToString();
    }

    public void bullletAttackButton()
    {
        if (bulletDamagePrice <= gameInCoin)
        {
            gameInCoin = gameInCoin - bulletDamagePrice;
            gameInCoinText.text = gameInCoin.ToString();
            bulletDamagePrice = bulletDamagePrice + bulletDamagePricePlus;
            bullet.damage = bullet.damage + bulletDamagePlus;
            bulletdamageText.text = bullet.damage.ToString();
            bulletdamagePriceText.text = bulletDamagePrice.ToString();
        }
    }

    public void bulletSpeedButton()
    {
        if (bulletSpeedPrice <= gameInCoin)
        {
            gameInCoin = gameInCoin - bulletSpeedPrice;
            gameInCoinText.text = gameInCoin.ToString();
            bulletSpeedPrice = bulletSpeedPrice + bulletSpeedPricePlus;
            bullet.speed = bullet.speed + bulletSpeedPlus;
            float f = bullet.speed;
            bullet.speed = Mathf.Round(f * 100.0f) * 0.01f;
            bulletSpeedText.text = bullet.speed.ToString();
            bulletSpeedPriceText.text = bulletSpeedPrice.ToString();
        }
    }
    public void bowtAttackButton()
    {
        if (bowDamagePrice <= gameInCoin)
        {
            gameInCoin = gameInCoin - bowDamagePrice;
            gameInCoinText.text = gameInCoin.ToString();
            bowDamagePrice = bowDamagePrice + bowDamagePricePlus;
            crossBowSc.damage = crossBowSc.damage + bowDamagePlus;
            bowDamageText.text = crossBowSc.damage.ToString();
            bowDamagePriceText.text = bowDamagePrice.ToString();
        }
    }
    public void bowSpeedButton()
    {
        if (bowSpeedPrice <= gameInCoin)
        {
            gameInCoin = gameInCoin - bowSpeedPrice;
            gameInCoinText.text = gameInCoin.ToString();
            bowSpeedPrice = bowSpeedPrice + bowSpeedPricePlus;
            crossBowSc.speed = crossBowSc.speed + bowSpeedPlus;
            float f = crossBowSc.speed;
            crossBowSc.speed = Mathf.Round(f * 100.0f) * 0.01f;
            bowSpeedText.text = crossBowSc.speed.ToString();
            bowSpeedPriceText.text = bowSpeedPrice.ToString();
        }
    }

    public void bigBullletAttackButton()
    {
        if (bigBulletDamagePrice <= gameInCoin)
        {
            gameInCoin = gameInCoin - bigBulletDamagePrice;
            gameInCoinText.text = gameInCoin.ToString();
            bigBulletDamagePrice = bigBulletDamagePrice + bigBulletDamagePricePlus;
            bigBulletSc.damage = bigBulletSc.damage + bigBulletDamagePlus;
            bigBulletdamageText.text = bigBulletSc.damage.ToString();
            bigBulletdamagePriceText.text = bigBulletDamagePrice.ToString();
        }
    }

    public void bigBulletSpeedButton()
    {
        if (bigBulletSpeedPrice <= gameInCoin)
        {
            gameInCoin = gameInCoin - bigBulletSpeedPrice;
            gameInCoinText.text = gameInCoin.ToString();
            bigBulletSpeedPrice = bigBulletSpeedPrice + bigBulletSpeedPricePlus;
            bigBulletSc.speed = bigBulletSc.speed + bigBulletSpeedPlus;
            float f = bigBulletSc.speed;
            bigBulletSc.speed = Mathf.Round(f * 100.0f) * 0.01f;
            bigBulletSpeedText.text = bigBulletSc.speed.ToString();
            bigBulletSpeedPriceText.text = bigBulletSpeedPrice.ToString();
        }
    }

    public void currentWaveMethod(int wave)
    {
        currentWaveText.text = wave.ToString();
    }
    public void EnemiesAmountMethod(int enemies)
    {
        enemiesAmountText.text = enemies.ToString();
    }
    public void setFilledImage(float damagedHealth)
    {
        filled = castle.healthCopy / castle.health;
        filledImage.fillAmount = filled;
    }

    public void castleHealthMethod()
    {
        if (baseCastleHealthPrice <= gameInCoin)
        {
            gameInCoin = gameInCoin - baseCastleHealthPrice;
            castle.health = castle.health + plusCastleHealth;
            baseCastleHealthPrice = baseCastleHealthPrice + plusBaseCastleHealthPrice;
            CastleHealhPriceText.text = baseCastleHealthPrice.ToString();
            CastleHealhText.text = castle.health.ToString();
            castle.healthCopy = castle.healthCopy + plusCastleHealth;
            filled = castle.healthCopy / castle.health;
            filledImage.fillAmount = filled;
            gameInCoinText.text = gameInCoin.ToString();
        }
        
    }

    public void healthRegenMethod()
    {
        if (baseHealthRegenPrice <= gameInCoin)
        {
            gameInCoin =  gameInCoin - (int)baseHealthRegenPrice;
            baseHeatlhRegen = baseHeatlhRegen + healthRegenPlus;
            baseHealthRegenPrice = baseHealthRegenPrice + HealthRegenPricePlus;
            gameInCoinText.text = gameInCoin.ToString();
            healthRegenPriceText.text = baseHealthRegenPrice.ToString();
            float f = baseHeatlhRegen;
            baseHeatlhRegen = Mathf.Round(f * 100.0f) * 0.01f;
            healthRegenText.text = baseHeatlhRegen.ToString();
        }
    }

    public void attackPanelMethod()
    {
        if (attackPanel.activeSelf == false)
        {
            buffInfoText.text = "ATTACK UPGRADES";
            attackPanel.SetActive(true);
            defancePanel.SetActive(false);
            cardsPanel.SetActive(false);
        }
    }
    public void defancePanelMethod()
    {
        if (defancePanel.activeSelf == false)
        {
            buffInfoText.text = "DEFENCE UPGRADES";
            attackPanel.SetActive(false);
            defancePanel.SetActive(true);
            cardsPanel.SetActive(false);
        }
    }
    public void cardsPanelMethod()
    {
        if (cardsPanel.activeSelf == false)
        {
            buffInfoText.text = "CARDS";
            cardsPanel.SetActive(true);
            attackPanel.SetActive(false);
            defancePanel.SetActive(false);
        }
    }
    public void gameSpeedPlusMethod()
    {
        if (gameSpeed==2)
        {
            gameSpeed = gameSpeed + 2;
            Time.timeScale = gameSpeed;
            currentGameSpeedText.text = gameSpeed.ToString();
        }
        if (gameSpeed == 1)
        {
            gameSpeed = gameSpeed + 1;
            Time.timeScale = gameSpeed;
            currentGameSpeedText.text = gameSpeed.ToString();
        }
    }
    public void gameSpeedDecreaseMethod()
    {
        if (gameSpeed==2)
        {
            gameSpeed = gameSpeed -1;
            Time.timeScale = gameSpeed;
            currentGameSpeedText.text = gameSpeed.ToString();
        }
        if (gameSpeed == 4)
        {
            gameSpeed = gameSpeed - 2;
            Time.timeScale = gameSpeed;
            currentGameSpeedText.text = gameSpeed.ToString();
        }
    }
   
    public void pauseButton()
    {
        pausePanel.SetActive(true);
        gamePauseMenuCoinText.text = ((spawnerSc.currentWave - 1) * 3).ToString();
        Time.timeScale = 0;
    }
    public void pauseMenuButton()
    {
        PlayerPrefs.SetInt("gameOutCoin", PlayerPrefs.GetInt("gameOutCoin") + ((spawnerSc.currentWave - 1) * 3));
        SceneManager.LoadScene(0);
    }

    public void resumeButton()
    {
        pausePanel.SetActive(false);
        Time.timeScale = gameSpeed;
    }
    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }
    public void gameOver()
    {
        adButton.SetActive(true);
        menuButtonCoin.SetActive(true);
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        currentDiaText.text = PlayerPrefs.GetInt("Diamonds").ToString();
        currnetWaveCoinText.text = PlayerPrefs.GetInt("gameOutCoin").ToString();
        gainWaweCoinText.text = (((spawnerSc.currentWave - 1) * 3) * 2).ToString();
        gameContinuePriceText.text = gameContinuePrice.ToString();
        menuWaweCoin.text = ((spawnerSc.currentWave - 1) * 3).ToString();
    }
    public void adReward()
    {
        adButton.SetActive(false);
        PlayerPrefs.SetInt("gameOutCoin", PlayerPrefs.GetInt("gameOutCoin")+ ((spawnerSc.currentWave - 1) * 3) * 2);
        currnetWaveCoinText.text = PlayerPrefs.GetInt("gameOutCoin").ToString();
        menuButtonCoin.SetActive(false);
    }
    public void continueButton()
    {
        if (gameContinuePrice <= PlayerPrefs.GetInt("Diamonds"))
        {
            PlayerPrefs.SetInt("Diamonds", PlayerPrefs.GetInt("Diamonds") - gameContinuePrice);
            castle.healthCopy = castle.health;
            filledImage.fillAmount = 1;
            gameOverPanel.SetActive(false);
            Time.timeScale = gameSpeed;
            gameOutCoinText.text = PlayerPrefs.GetInt("gameOutCoin").ToString();
        }
    }
   
    public void gameOverMenuButton()
    {
        if (menuButtonCoin.activeSelf == true)
        {
            PlayerPrefs.SetInt("gameOutCoin", PlayerPrefs.GetInt("gameOutCoin") + ((spawnerSc.currentWave-1) * 3));
        }
        SceneManager.LoadScene(0);  
    }
}
