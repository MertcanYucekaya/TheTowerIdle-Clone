using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IAPManager : MonoBehaviour
{

    public TextMeshProUGUI diamondText;
    public TextMeshProUGUI gameOutText;
    int gainDiamondsAmount;
    [Header("Unlock")]
    public GameObject destroyBowPrice;
    public GameObject destroyBigbulletPrice;
    public int unlockCrossBowPrice;
    public int bowUnlockPrice;
    public TextMeshProUGUI bowUnlockPriceText;
    public GameObject unlocBowButton;
    public TextMeshProUGUI crossPriceText;
    public TextMeshProUGUI bulletPriceText;
    public GameObject unlockBigBulletButton;
    public int unlockBigBulletPrice;
    public int bigBulletUnlockPrice;
    public TextMeshProUGUI bigBulletUnlockPriceText;
    [Header("Health")]
    public int addHealt;
    public int addHealthPrice;
    public int addHealthCoin;
    public TextMeshProUGUI addHealthCoinText;
    public TextMeshProUGUI healthPriceText;
    public TextMeshProUGUI addHealthText;
    [Header("HealthRegen")]
    public float addHealtRegen;
    public int addHealtRegenPrice;
    public int addHealthRegenCoin;
    public TextMeshProUGUI addHealthRegenCoinText;
    public TextMeshProUGUI healthRegenPriceText;
    public TextMeshProUGUI addHealthRegenText;
    [Header("BulletDamage")]
    public int addBulletDamage;
    public int addBulletDamagePrice;
    public int addBulletDamageCoin;
    public TextMeshProUGUI addBulletDamageText;
    public TextMeshProUGUI addBulletDamagePriceText;
    public TextMeshProUGUI addBulletDamageCoinText;
    [Header("BulletDamage")]
    public float addBulletSpeed;
    public int addBulletSpeedPrice;
    public int addBulletSpeedCoin;
    public TextMeshProUGUI addBulletSpeedText;
    public TextMeshProUGUI addBulletSpeedPriceText;
    public TextMeshProUGUI addBulletSpeedCoinText;
    [Header("CrossbowDamage")]
    public int addCrossDamage;
    public int addCrossDamagePrice;
    public int addCrossDamageCoin;
    public TextMeshProUGUI addCrossDamageText;
    public TextMeshProUGUI addCrossDamagePriceText;
    public TextMeshProUGUI addCrossDamageCoinText;
    [Header("CrossbowSpeed")]
    public float addCrossSpeed;
    public int addCrossSpeedPrice;
    public int addCrossSpeedCoin;
    public TextMeshProUGUI addCrossSpeedText;
    public TextMeshProUGUI addCrossSpeedPriceText;
    public TextMeshProUGUI addCrossSpeedCoinText;
    [Header("BigbulletDamage")]
    public int addBigbulletDamage;
    public int addBigbulletDamagePrice;
    public int addBigBulletDamageCoin;
    public TextMeshProUGUI addBigbulletDamageText;
    public TextMeshProUGUI addBigbulletDamagePriceText;
    public TextMeshProUGUI addBigBulletDamageCoinText;
    [Header("BigbulletSpeed")]
    public float addBigbulletSpeed;
    public int addBigbulletSpeedPrice;
    public int addBigBulletSpeedCoin;
    public TextMeshProUGUI addBigbulletSpeedText;
    public TextMeshProUGUI addBigbulletSpeedPriceText;
    public TextMeshProUGUI addBigBulletSpeedCoinText;
    [Header("UpgradeObject")]
    public GameObject crossBowButtons;
    public GameObject bigBulletButtons;
    private void Start()
    {
        
        setCoinText();
        setDiamondText();

        
        if (!PlayerPrefs.HasKey("addHealthCoin"))
        {
            PlayerPrefs.SetInt("addHealthCoin", PlayerPrefs.GetInt("addHealthCoin") + addHealthCoin);
        }
        if (!PlayerPrefs.HasKey("addHealthRegenCoin"))
        {
            PlayerPrefs.SetInt("addHealthRegenCoin", PlayerPrefs.GetInt("addHealthRegenCoin") + addHealthRegenCoin);
        }
        if (!PlayerPrefs.HasKey("addBulletDamageCoin"))
        {
            PlayerPrefs.SetInt("addBulletDamageCoin", PlayerPrefs.GetInt("addBulletDamageCoin") + addBulletDamageCoin);
        }
        if (!PlayerPrefs.HasKey("addBulletSpeedCoin"))
        {
            PlayerPrefs.SetInt("addBulletSpeedCoin", PlayerPrefs.GetInt("addBulletSpeedCoin") + addBulletSpeedCoin);
        }
        if (!PlayerPrefs.HasKey("addCrossDamageCoin"))
        {
            PlayerPrefs.SetInt("addCrossDamageCoin", PlayerPrefs.GetInt("addCrossDamageCoin") + addCrossDamageCoin);
        }
        if (!PlayerPrefs.HasKey("addCrossSpeedCoin"))
        {
            PlayerPrefs.SetInt("addCrossSpeedCoin", PlayerPrefs.GetInt("addCrossSpeedCoin") + addCrossSpeedCoin);
        }
        if (!PlayerPrefs.HasKey("addBigBulletDamageCoin"))
        {
            PlayerPrefs.SetInt("addBigBulletDamageCoin", PlayerPrefs.GetInt("addBigBulletDamageCoin") + addBigBulletDamageCoin);
        }
        if (!PlayerPrefs.HasKey("addBigBulletSpeedCoin"))
        {
            PlayerPrefs.SetInt("addBigBulletSpeedCoin", PlayerPrefs.GetInt("addBigBulletSpeedCoin") + addBigBulletSpeedCoin);
        }
        healthPriceText.text = addHealthPrice.ToString();
        addHealthCoinText.text = PlayerPrefs.GetInt("addHealthCoin").ToString();
        addHealthText.text = addHealt.ToString();

        healthRegenPriceText.text = addHealtRegenPrice.ToString();
        addHealthRegenCoinText.text = PlayerPrefs.GetInt("addHealthRegenCoin").ToString();
        addHealthRegenText.text = addHealtRegen.ToString()+"/Sc";

        addBulletDamageText.text = addBulletDamage.ToString();
        addBulletDamagePriceText.text = addBulletDamagePrice.ToString();
        addBulletDamageCoinText.text = PlayerPrefs.GetInt("addBulletDamageCoin").ToString();

        addBulletSpeedText.text = addBulletSpeed.ToString();
        addBulletSpeedPriceText.text = addBulletSpeedPrice.ToString();
        addBulletSpeedCoinText.text = PlayerPrefs.GetInt("addBulletSpeedCoin").ToString();

        addCrossDamageText.text = addCrossDamage.ToString();
        addCrossDamagePriceText.text = addCrossDamagePrice.ToString();
        addCrossDamageCoinText.text = PlayerPrefs.GetInt("addCrossDamageCoin").ToString();

        addCrossSpeedText.text = addCrossSpeed.ToString();
        addCrossSpeedPriceText.text = addCrossSpeedPrice.ToString();
        addCrossSpeedCoinText.text = PlayerPrefs.GetInt("addCrossSpeedCoin").ToString();

        addBigbulletDamageText.text = addBigbulletDamage.ToString();
        addBigbulletDamagePriceText.text = addBigbulletDamagePrice.ToString();
        addBigBulletDamageCoinText.text = PlayerPrefs.GetInt("addBigBulletDamageCoin").ToString();

        addBigbulletSpeedText.text = addBigbulletSpeed.ToString();
        addBigbulletSpeedPriceText.text = addBigbulletSpeedPrice.ToString();
        addBigBulletSpeedCoinText.text = PlayerPrefs.GetInt("addBigBulletSpeedCoin").ToString();

        if (PlayerPrefs.GetInt("unlockBow") == 1)
        {
            Destroy(destroyBowPrice);
            unlocBowButton.GetComponent<Image>().color = Color.green;
            unlocBowButton.GetComponent<Button>().enabled = false;
            crossBowButtons.SetActive(true);
            
        }
        if (PlayerPrefs.GetInt("unlockBigBullet") == 1)
        {
            Destroy(destroyBigbulletPrice);
            unlockBigBulletButton.GetComponent<Image>().color= Color.green;
            unlockBigBulletButton.GetComponent<Button>().enabled = false;
            bigBulletButtons.SetActive(true);
        }
        crossPriceText.text = unlockCrossBowPrice.ToString();
        bulletPriceText.text = unlockBigBulletPrice.ToString();

        bowUnlockPriceText.text = bowUnlockPrice.ToString();
        bigBulletUnlockPriceText.text = bigBulletUnlockPrice.ToString();
    }
    public void onCompletePurch(Product product)
    {
        
        PlayerPrefs.SetInt("Diamonds", PlayerPrefs.GetInt("Diamonds") + gainDiamondsAmount);
        setDiamondText();
    }
    public void onFailurePurhch(Product product,PurchaseFailureReason purchaseFailureReason)
    {
        Debug.Log("Fail");
    }
    public void unlocBowButtonMethod()
    {
        if (getWaveCoin() >= bowUnlockPrice)
        {
            setcoin(bowUnlockPrice);
            setCoinText();
            PlayerPrefs.SetInt("unlockBow", 1);
            Destroy(destroyBowPrice);
            unlocBowButton.GetComponent<Image>().color = Color.green;
            unlocBowButton.GetComponent<Button>().enabled = false;
            crossBowButtons.SetActive(true);
        }
        else if(PlayerPrefs.GetInt("Diamonds")>= unlockCrossBowPrice)
        {
            PlayerPrefs.SetInt("Diamonds", PlayerPrefs.GetInt("Diamonds") - unlockCrossBowPrice);
            setDiamondText();
            PlayerPrefs.SetInt("unlockBow", 1);
            Destroy(destroyBowPrice);
            unlocBowButton.GetComponent<Image>().color = Color.green;
            unlocBowButton.GetComponent<Button>().enabled = false;
            crossBowButtons.SetActive(true);
        }
       
    }
    public void unlocBigbulletButtonMethod()
    {
        if (getWaveCoin() >= bigBulletUnlockPrice)
        {
            setcoin(bigBulletUnlockPrice);
            setCoinText();
            PlayerPrefs.SetInt("unlockBigBullet", 1);
            Destroy(destroyBigbulletPrice);
            unlockBigBulletButton.GetComponent<Image>().color = Color.green;
            unlockBigBulletButton.GetComponent<Button>().enabled = false;
            bigBulletButtons.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("Diamonds") >= unlockBigBulletPrice)
        {
            PlayerPrefs.SetInt("Diamonds", PlayerPrefs.GetInt("Diamonds") - unlockBigBulletPrice);
            setDiamondText();
            PlayerPrefs.SetInt("unlockBigBullet", 1);
            Destroy(destroyBigbulletPrice);
            unlockBigBulletButton.GetComponent<Image>().color = Color.green;
            unlockBigBulletButton.GetComponent<Button>().enabled = false;
            bigBulletButtons.SetActive(true);
        }
        
    }
    public void addHealthButton()
    {
        if (getWaveCoin() >= PlayerPrefs.GetInt("addHealthCoin"))
        {
            setcoin(PlayerPrefs.GetInt("addHealthCoin"));
            setCoinText();
            PlayerPrefs.SetInt("addHealth", PlayerPrefs.GetInt("addHealth") + addHealt);
            PlayerPrefs.SetInt("addHealthCoin", PlayerPrefs.GetInt("addHealthCoin") + 1);
            addHealthCoinText.text = PlayerPrefs.GetInt("addHealthCoin").ToString();
        }
        else if (getDiamond() >= addHealthPrice)
        {
            setDiamond(addHealthPrice);
            setDiamondText();
            PlayerPrefs.SetInt("addHealth", PlayerPrefs.GetInt("addHealth") + addHealt);
            
           
        }
    }

    public void addHealthRegenButton()
    {
        if (getWaveCoin() >= PlayerPrefs.GetInt("addHealthRegenCoin"))
        {
            setcoin(PlayerPrefs.GetInt("addHealthRegenCoin"));
            setCoinText();
            PlayerPrefs.SetFloat("addHealthRegen", PlayerPrefs.GetFloat("addHealthRegen") + addHealtRegen);
            PlayerPrefs.SetInt("addHealthRegenCoin", PlayerPrefs.GetInt("addHealthRegenCoin") + 1);
            addHealthRegenCoinText.text = PlayerPrefs.GetInt("addHealthRegenCoin").ToString();
        }
        else if (getDiamond() >= addHealtRegenPrice)
        {
            setDiamond(addHealtRegenPrice);
            setDiamondText();
            PlayerPrefs.SetFloat("addHealthRegen", PlayerPrefs.GetFloat("addHealthRegen") + addHealtRegen);


        }
    }

    public void addBulletDamageButton()
    {
        if (getWaveCoin() >= PlayerPrefs.GetInt("addBulletDamageCoin"))
        {
            setcoin(PlayerPrefs.GetInt("addBulletDamageCoin"));
            setCoinText();
            PlayerPrefs.SetInt("addBulletDamage", PlayerPrefs.GetInt("addBulletDamage") + addBulletDamage);
            PlayerPrefs.SetInt("addBulletDamageCoin", PlayerPrefs.GetInt("addBulletDamageCoin") + 1);
            addBulletDamageCoinText.text = PlayerPrefs.GetInt("addBulletDamageCoin").ToString();
        }
        else if (getDiamond() >= addBulletDamagePrice)
        {
            setDiamond(addBulletDamagePrice);
            setDiamondText();
            PlayerPrefs.SetInt("addBulletDamage", PlayerPrefs.GetInt("addBulletDamage") + addBulletDamage);


        }
    }

    public void addBulletSpeedButton()
    {
        if (getWaveCoin() >= PlayerPrefs.GetInt("addBulletSpeedCoin"))
        {
            setcoin(PlayerPrefs.GetInt("addBulletSpeedCoin"));
            setCoinText();
            PlayerPrefs.SetFloat("addBulletSpeed", PlayerPrefs.GetFloat("addBulletSpeed") + addBulletSpeed);
            PlayerPrefs.SetInt("addBulletSpeedCoin", PlayerPrefs.GetInt("addBulletSpeedCoin") + 1);
            addBulletSpeedCoinText.text = PlayerPrefs.GetInt("addBulletSpeedCoin").ToString();
        }
        else if (getDiamond() >= addBulletDamagePrice)
        {
            setDiamond(addBulletDamagePrice);
            setDiamondText();
            PlayerPrefs.SetFloat("addBulletSpeed", PlayerPrefs.GetFloat("addBulletSpeed") + addBulletSpeed);
        }
    }

    public void addCrossDamageButton()
    {
        if (getWaveCoin() >= PlayerPrefs.GetInt("addCrossDamageCoin"))
        {
            setcoin(PlayerPrefs.GetInt("addCrossDamageCoin"));
            setCoinText();
            PlayerPrefs.SetInt("addCrossbowDamage", PlayerPrefs.GetInt("addCrossbowDamage") + addCrossDamage);
            PlayerPrefs.SetInt("addCrossDamageCoin", PlayerPrefs.GetInt("addCrossDamageCoin") + 1);
            addCrossDamageCoinText.text = PlayerPrefs.GetInt("addCrossDamageCoin").ToString();
        }
        else if (getDiamond() >= addCrossDamagePrice)
        {
            setDiamond(addCrossDamagePrice);
            setDiamondText();
            PlayerPrefs.SetInt("addCrossbowDamage", PlayerPrefs.GetInt("addCrossbowDamage") + addCrossDamage);
        }
    }

    public void addCrossSpeedButton()
    {
        if (getWaveCoin() >= PlayerPrefs.GetInt("addCrossSpeedCoin"))
        {
            setcoin(PlayerPrefs.GetInt("addCrossSpeedCoin"));
            setCoinText();
            PlayerPrefs.SetFloat("addCrossBowSpeed", PlayerPrefs.GetFloat("addCrossBowSpeed") + addCrossSpeed);
            PlayerPrefs.SetInt("addCrossSpeedCoin", PlayerPrefs.GetInt("addCrossSpeedCoin") + 1);
            addCrossSpeedCoinText.text = PlayerPrefs.GetInt("addCrossSpeedCoin").ToString();
        }
        else if (getDiamond() >= addCrossSpeedPrice)
        {
            setDiamond(addCrossSpeedPrice);
            setDiamondText();
            PlayerPrefs.SetFloat("addCrossBowSpeed", PlayerPrefs.GetFloat("addCrossBowSpeed") + addCrossSpeed);
        }
        Debug.Log(PlayerPrefs.GetFloat("addCrossBowSpeed"));
    }

    public void addBigbulletDamageButton()
    {
        if (getWaveCoin() >= PlayerPrefs.GetInt("addBigBulletDamageCoin"))
        {
            setcoin(PlayerPrefs.GetInt("addBigBulletDamageCoin"));
            setCoinText();
            PlayerPrefs.SetInt("addBigBulletDamage", PlayerPrefs.GetInt("addBigBulletDamage") + addBigbulletDamage);
            PlayerPrefs.SetInt("addBigBulletDamageCoin", PlayerPrefs.GetInt("addBigBulletDamageCoin") + 1);
            addBigBulletDamageCoinText.text = PlayerPrefs.GetInt("addBigBulletDamageCoin").ToString();
        }
        else if (getDiamond() >= addBigbulletDamagePrice)
        {
            setDiamond(addBigbulletDamagePrice);
            setDiamondText();
            PlayerPrefs.SetInt("addBigBulletDamage", PlayerPrefs.GetInt("addBigBulletDamage") + addBigbulletDamage);
        }
        Debug.Log(PlayerPrefs.GetInt("addBigBulletDamage"));
    }

    public void addBigbulletSpeedButton()
    {
        if (getWaveCoin() >= PlayerPrefs.GetInt("addBigBulletSpeedCoin"))
        {
            setcoin(PlayerPrefs.GetInt("addBigBulletSpeedCoin"));
            setCoinText();
            PlayerPrefs.SetFloat("addBigBulletSpeed", PlayerPrefs.GetFloat("addBigBulletSpeed") + addBigbulletSpeed);
            PlayerPrefs.SetInt("addBigBulletSpeedCoin", PlayerPrefs.GetInt("addBigBulletSpeedCoin") + 1);
            addBigBulletSpeedCoinText.text = PlayerPrefs.GetInt("addBigBulletSpeedCoin").ToString();
        }
        else if (getDiamond() >= addBigbulletSpeedPrice)
        {
            setDiamond(addBigbulletSpeedPrice);
            setDiamondText();
            PlayerPrefs.SetFloat("addBigBulletSpeed", PlayerPrefs.GetFloat("addBigBulletSpeed") + addBigbulletSpeed);
        }
        Debug.Log(PlayerPrefs.GetFloat("addBigBulletSpeed"));
    }
    void setDiamondText()
    {
        diamondText.text = (PlayerPrefs.GetInt("Diamonds")).ToString();
    }
    int getDiamond()
    {
        return PlayerPrefs.GetInt("Diamonds");
    }
    
    void setDiamond(int dia)
    {
        PlayerPrefs.SetInt("Diamonds", getDiamond() - dia);
    }
    int getWaveCoin()
    {
        return PlayerPrefs.GetInt("gameOutCoin");
    }
    void setcoin(int coin)
    {
        PlayerPrefs.SetInt("gameOutCoin", getWaveCoin() - coin);
    }
   
    void setCoinText()
    {
        gameOutText.text = PlayerPrefs.GetInt("gameOutCoin").ToString();
    }

    public void gameButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void menuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void cardsSceneButton()
    {
        SceneManager.LoadScene(3);
    }
    public void gain250Dia()
    {
        gainDiamondsAmount = 250;
    }
    public void gain500Dia()
    {
        gainDiamondsAmount = 500;
    }
    public void gain1000Dia()
    {
        gainDiamondsAmount = 1000;
    }
}
