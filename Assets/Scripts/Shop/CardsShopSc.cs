using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CardsShopSc : MonoBehaviour
{
    public TextMeshProUGUI diamondText;
    public TextMeshProUGUI waveCoinText;
    [Header("Meteor")]
    public GameObject meteorUnlock;
    public TextMeshProUGUI meteorPriceText;
    public TextMeshProUGUI meteorWavePriceText;
    public int meteorPrice;
    public GameObject meteorUpgrade;
    public int meteorReducePrice;
    public TextMeshProUGUI meteorReducePriceText;
    [Header("Wind")]
    public GameObject windUnlock;
    public TextMeshProUGUI windPriceText;
    public TextMeshProUGUI windWavePriceText;
    public int windPrice;
    public GameObject windUpgrade;
    public int windReducePrice;
    public TextMeshProUGUI windReducePriceText;
    [Header("Light")]
    public GameObject lightUnlock;
    public TextMeshProUGUI lightPriceText;
    public TextMeshProUGUI lightWavePriceText;
    public int lightPrice;
    public GameObject lightUpgrade;
    public int lightReducePrice;
    public TextMeshProUGUI lightReducePriceText;
    public TextMeshProUGUI lightDamageText;
    public TextMeshProUGUI lightDamagePriceText;
    public int lightDamagePrice;
    public int lightDamagePlus;
    [Header("Thron")]
    public GameObject thornUnlock;
    public TextMeshProUGUI thornPriceText;
    public TextMeshProUGUI thornWavePriceText;
    public int thornPrice;
    public GameObject thornUpgrade;
    public int thornReducePrice;
    public TextMeshProUGUI thornReducePriceText;
    public TextMeshProUGUI thornDamageText;
    public TextMeshProUGUI thornDamagePriceText;
    public int thornDamagePrice;
    public int thornDamagePlus;
    [Header("Asid")]
    public GameObject asidUnlock;
    public TextMeshProUGUI asidPriceText;
    public TextMeshProUGUI asidWavePriceText;
    public int asidPrice;
    public GameObject asidUpgrade;
    public int asidReducePrice;
    public TextMeshProUGUI asidReducePriceText;
    public TextMeshProUGUI asidDamageText;
    public TextMeshProUGUI asidDamagePriceText;
    public int asidDamagePrice;
    public int asidDamagePlus;
    [Header("Trap")]
    public GameObject trapUnlock;
    public TextMeshProUGUI trapPriceText;
    public TextMeshProUGUI trapWavePriceText;
    public int trapPrice;
    public GameObject trapUpgrade;
    public int trapReducePrice;
    public TextMeshProUGUI trapReducePriceText;
    public TextMeshProUGUI trapDamageText;
    public TextMeshProUGUI trapDamagePriceText;
    public int trapDamagePrice;
    public int trapDamagePlus;
    void Start()
    {
        meteorReducePrice = (PlayerPrefs.GetInt("meteorReduce")* 5)+20;
        windReducePrice = (PlayerPrefs.GetInt("windReduce") * 5)+20;
        lightReducePrice = (PlayerPrefs.GetInt("lightReduce") * 5)+20;
        lightDamagePrice = (PlayerPrefs.GetInt("lightDamage") + 20);
        thornReducePrice = (PlayerPrefs.GetInt("thornReduce") * 5) + 20;
        thornDamagePrice = PlayerPrefs.GetInt("thornDamage") + 20;
        asidReducePrice = (PlayerPrefs.GetInt("asidReduce") * 5) + 20;
        asidDamagePrice = (PlayerPrefs.GetInt("asidDamage") * 5) + 20;
        trapReducePrice = (PlayerPrefs.GetInt("trapReduce") * 5) + 20;
        trapDamagePrice = (PlayerPrefs.GetInt("trapDamage") + 20);
        diamondText.text = getDiamond().ToString();
        waveCoinText.text = getWaveCoin().ToString();

        meteorPriceText.text = meteorPrice.ToString();
        meteorWavePriceText.text = meteorPrice.ToString();
        meteorReducePriceText.text = meteorReducePrice.ToString();

        windPriceText.text = windPrice.ToString();
        windWavePriceText.text = windPrice.ToString();
        windReducePriceText.text = windReducePrice.ToString();

        lightPriceText.text = lightPrice.ToString();
        lightWavePriceText.text = lightPrice.ToString();
        lightReducePriceText.text = lightReducePrice.ToString();
        lightDamageText.text = "+" + lightDamagePlus.ToString();
        lightDamagePriceText.text = lightDamagePrice.ToString();

        thornPriceText.text = thornPrice.ToString();
        thornWavePriceText.text = thornPrice.ToString();
        thornReducePriceText.text = thornReducePrice.ToString();
        thornDamageText.text = "+" + thornDamagePlus.ToString();
        thornDamagePriceText.text = thornDamagePrice.ToString();

        asidPriceText.text = asidPrice.ToString();
        asidWavePriceText.text = asidPrice.ToString();
        asidReducePriceText.text = asidReducePrice.ToString();
        asidDamageText.text = "+" + asidDamagePlus.ToString();
        asidDamagePriceText.text = asidDamagePrice.ToString();

        trapPriceText.text = trapPrice.ToString();
        trapWavePriceText.text = trapPrice.ToString();
        trapReducePriceText.text = trapReducePrice.ToString();
        trapDamageText.text = "+" + trapDamagePlus.ToString();
        trapDamagePriceText.text = trapDamagePrice.ToString();
        if (PlayerPrefs.GetInt("MeteorUnlock") == 1)
        {
            Destroy(meteorUnlock);
            meteorUpgrade.SetActive(true);
        }
        if (PlayerPrefs.GetInt("windUnlock") == 1)
        {
            Destroy(windUnlock);
            windUpgrade.SetActive(true);
        }
        if (PlayerPrefs.GetInt("lightUnlock") == 1)
        {
            Destroy(lightUnlock);
            lightUpgrade.SetActive(true);
        }
        if (PlayerPrefs.GetInt("thornUnlock") == 1)
        {
            Destroy(thornUnlock);
            thornUpgrade.SetActive(true);
        }
        if (PlayerPrefs.GetInt("asidUnlock") == 1)
        {
            Destroy(asidUnlock);
            asidUpgrade.SetActive(true);
        }
        if (PlayerPrefs.GetInt("trapUnlock") == 1)
        {
            Destroy(trapUnlock);
            trapUpgrade.SetActive(true);
        }
    }
    // METEOR
    public void meteorUnlockButton()
    {
        if (meteorPrice<=getWaveCoin())
        {
            setcoin(meteorPrice);
            setCoinText();
            PlayerPrefs.SetInt("MeteorUnlock", 1);
            Destroy(meteorUnlock);
            meteorUpgrade.SetActive(true);
        }
        else if (meteorPrice <= getDiamond())
        {
            setDiamond(meteorPrice);
            setDiamondText();
            PlayerPrefs.SetInt("MeteorUnlock", 1);
            Destroy(meteorUnlock);
            meteorUpgrade.SetActive(true);
        }
    }
    public void meteorTimeReduceButton()
    {
        if (meteorReducePrice <= getDiamond()&& PlayerPrefs.GetInt("meteorReduce")>=0)
        {
            setDiamond(meteorReducePrice);
            setDiamondText();
            
            PlayerPrefs.SetInt("meteorReduce",PlayerPrefs.GetInt("meteorReduce")+1);
            meteorReducePrice = (PlayerPrefs.GetInt("meteorReduce")* 5)+20;
            meteorReducePriceText.text = meteorReducePrice.ToString();
            Debug.Log("meteorReduce : " + PlayerPrefs.GetInt("meteorReduce"));
        }
    }
    // WIND
    public void windUnlockButton()
    {
        if (windPrice<=getWaveCoin())
        {
            setcoin(windPrice);
            setCoinText();
            PlayerPrefs.SetInt("windUnlock", 1);
            Destroy(windUnlock);
            windUpgrade.SetActive(true);
        }
        else if (windPrice <= getDiamond())
        {
            setDiamond(windPrice);
            setDiamondText();
            PlayerPrefs.SetInt("windUnlock", 1);
            Destroy(windUnlock);
            windUpgrade.SetActive(true);
        }
    }
    public void windTimeReduceButton()
    {
        if (windReducePrice <= getDiamond()&& PlayerPrefs.GetInt("windReduce") >= 0)
        {
            
            setDiamond(windReducePrice);
            setDiamondText();
            PlayerPrefs.SetInt("windReduce", PlayerPrefs.GetInt("windReduce") + 1);
            windReducePrice = (PlayerPrefs.GetInt("windReduce")* 5)+20;
            windReducePriceText.text = windReducePrice.ToString();
            Debug.Log("windReduce : " + PlayerPrefs.GetInt("windReduce"));
        }
    }
    // LIGHT
    public void lightUnlockButton()
    {
        if (lightPrice <= getWaveCoin())
        {
            setcoin(lightPrice);
            setCoinText();
            PlayerPrefs.SetInt("lightUnlock", 1);
            Destroy(lightUnlock);
            lightUpgrade.SetActive(true);
        }
        else if (lightPrice <= getDiamond())
        {
            setDiamond(lightPrice);
            setDiamondText();
            PlayerPrefs.SetInt("lightUnlock", 1);
            Destroy(lightUnlock);
            lightUpgrade.SetActive(true);
        }
    }
    public void lightTimeReduceButton()
    {
       if (lightReducePrice <= getDiamond()&& PlayerPrefs.GetInt("lightReduce") >= 0)
        {
            setDiamond(lightReducePrice);
            setDiamondText();
            PlayerPrefs.SetInt("lightReduce", PlayerPrefs.GetInt("lightReduce") + 1);
            lightReducePrice = (PlayerPrefs.GetInt("lightReduce")* 5)+20;
            lightReducePriceText.text = lightReducePrice.ToString();
            Debug.Log(PlayerPrefs.GetInt("lightReduce"));
        }
    }
    public void lightDamageButton()
    {
        if (lightDamagePrice <= getDiamond())
        {
            setDiamond(lightDamagePrice);
            setDiamondText();
            PlayerPrefs.SetInt("lightDamage", PlayerPrefs.GetInt("lightDamage") + lightDamagePlus);
            lightDamagePrice = PlayerPrefs.GetInt("lightDamage") + 20;
            lightDamagePriceText.text = lightDamagePrice.ToString();
            Debug.Log(PlayerPrefs.GetInt("lightDamage"));
        }
    }
    // THRON
    public void thornUnlockButton()
    {
        if (thornPrice <= getWaveCoin())
        {
            setcoin(thornPrice);
            setCoinText();
            PlayerPrefs.SetInt("thornUnlock", 1);
            Destroy(thornUnlock);
            thornUpgrade.SetActive(true);
        }
        else if (thornPrice <= getDiamond())
        {
            setDiamond(thornPrice);
            setDiamondText();
            PlayerPrefs.SetInt("thornUnlock", 1);
            Destroy(thornUnlock);
            thornUpgrade.SetActive(true);
        }
    }
    public void thornTimeReduceButton()
    {
        if (thornReducePrice <= getDiamond()&& PlayerPrefs.GetInt("thornReduce") >= 0)
        {
            setDiamond(thornReducePrice);
            setDiamondText();
            PlayerPrefs.SetInt("thornReduce", PlayerPrefs.GetInt("thornReduce") + 1);
            thornReducePrice = (PlayerPrefs.GetInt("thornReduce") * 5) + 20;
            thornReducePriceText.text = thornReducePrice.ToString();
            Debug.Log("thorn reduce : " + PlayerPrefs.GetInt("thornReduce"));
        }
    }
    public void thornDamageButton()
    {
       if (thornDamagePrice <= getDiamond())
        {
            setDiamond(thornDamagePrice);
            setDiamondText();
            PlayerPrefs.SetInt("thornDamage", PlayerPrefs.GetInt("thornDamage") + thornDamagePlus);
            thornDamagePrice = PlayerPrefs.GetInt("thornDamage") + 20;
            thornDamagePriceText.text = thornDamagePrice.ToString();
            Debug.Log("thorn damage : " + PlayerPrefs.GetInt("thornDamage"));
        }
    }
    // ASID
    public void asidUnlockButton()
    {
        if (asidPrice <= getWaveCoin())
        {
            setcoin(asidPrice);
            setCoinText();
            PlayerPrefs.SetInt("asidUnlock", 1);
            Destroy(asidUnlock);
            asidUpgrade.SetActive(true);
        }
        else if (asidPrice <= getDiamond())
        {
            setDiamond(asidPrice);
            setDiamondText();
            PlayerPrefs.SetInt("asidUnlock", 1);
            Destroy(asidUnlock);
            asidUpgrade.SetActive(true);
        }
    }
    public void asidTimeReduceButton()
    {
        if (asidReducePrice <= getDiamond()&& PlayerPrefs.GetInt("asidReduce") <=90)
        {
            setDiamond(asidReducePrice);
            setDiamondText();
            PlayerPrefs.SetInt("asidReduce", PlayerPrefs.GetInt("asidReduce") + 1);
            asidReducePrice = (PlayerPrefs.GetInt("asidReduce") * 5) + 20;
            asidReducePriceText.text = asidReducePrice.ToString();
            Debug.Log(PlayerPrefs.GetInt("asidReduce"));
        }
    }
    public void asidDamageButton()
    {
        if (asidDamagePrice <= getDiamond())
        {
            setDiamond(asidDamagePrice);
            setDiamondText();
            PlayerPrefs.SetInt("asidDamage", PlayerPrefs.GetInt("asidDamage") + asidDamagePlus);
            asidDamagePrice = (PlayerPrefs.GetInt("asidDamage") * 5) + 20;
            asidDamagePriceText.text = asidDamagePrice.ToString();
            Debug.Log(PlayerPrefs.GetInt("asidDamage"));
        }
    }

    // Trap
    public void trapUnlockButton()
    {
        if (trapPrice <= getWaveCoin())
        {
            setcoin(trapPrice);
            setCoinText();
            PlayerPrefs.SetInt("trapUnlock", 1);
            Destroy(trapUnlock);
            trapUpgrade.SetActive(true);
        }
        else if (trapPrice <= getDiamond())
        {
            setDiamond(trapPrice);
            setDiamondText();
            PlayerPrefs.SetInt("trapUnlock", 1);
            Destroy(trapUnlock);
            trapUpgrade.SetActive(true);
        }
    }
    public void trapTimeReduceButton()
    {
        if (trapReducePrice <= getDiamond()&& PlayerPrefs.GetInt("trapReduce")<=90)
        {
            setDiamond(trapReducePrice);
            setDiamondText();
            PlayerPrefs.SetInt("trapReduce", PlayerPrefs.GetInt("trapReduce") + 1);
            trapReducePrice = (PlayerPrefs.GetInt("trapReduce") * 5) + 20;
            trapReducePriceText.text = trapReducePrice.ToString();
            Debug.Log(PlayerPrefs.GetInt("trapReduce"));
        }
    }
    public void trapDamageButton()
    {
        if (trapDamagePrice <= getDiamond())
        {
            setDiamond(trapDamagePrice);
            setDiamondText();
            PlayerPrefs.SetInt("trapDamage", PlayerPrefs.GetInt("trapDamage") + trapDamagePlus);
            trapDamagePrice = (PlayerPrefs.GetInt("trapDamage") + 20);
            trapDamagePriceText.text = trapDamagePrice.ToString();
            Debug.Log(PlayerPrefs.GetInt("trapDamage"));
        }
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
        waveCoinText.text = PlayerPrefs.GetInt("gameOutCoin").ToString();
    }
    public void backButton()
    {
        SceneManager.LoadScene(2);
    }
    public void menuButton()
    {
        SceneManager.LoadScene(0);
    }
}
