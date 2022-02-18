using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardsPanelSc : MonoBehaviour
{
    [Header("Meteor")]
    public GameObject meteorBar;
    public TextMeshProUGUI meteorCdText;
    public int meteorcd;
    [Header("Light")]
    public GameObject lightBar;
    public TextMeshProUGUI lightCdText;
    public int lightcd;
    [Header("Asid")]
    public GameObject asidBar;
    public TextMeshProUGUI asidCdText;
    public int asidcd;
    [Header("Thorn")]
    public GameObject thornBar;
    public TextMeshProUGUI thornCdText;
    public int thorncd;
    [Header("Trap")]
    public GameObject trapBar;
    public TextMeshProUGUI trapCdText;
    public int trapcd;
    [Header("Wind")]
    public GameObject windBar;
    public TextMeshProUGUI windCdText;
    public int windcd;
    [Header("Cards")]
    public GameObject meteor;
    public GameObject light;
    public GameObject asid;
    public GameObject thorn;
    public GameObject trap;
    public GameObject wind;
    private void Start()
    {
        if (PlayerPrefs.GetInt("MeteorUnlock") == 1)
        {
            meteor.SetActive(true);
        }
        if (PlayerPrefs.GetInt("windUnlock") == 1)
        {
            wind.SetActive(true);
        }
        if (PlayerPrefs.GetInt("lightUnlock") == 1)
        {
            light.SetActive(true);
        }
        if (PlayerPrefs.GetInt("thornUnlock") == 1)
        {
            thorn.SetActive(true);
        }
        if (PlayerPrefs.GetInt("asidUnlock") == 1)
        {
            asid.SetActive(true);
        }
        if (PlayerPrefs.GetInt("trapUnlock") == 1)
        {
            trap.SetActive(true);
        }
    }
    public void meteorCdMethod()
    {
        StartCoroutine(setText(meteorcd-PlayerPrefs.GetInt("meteorReduce"), meteorCdText,meteorBar));
    }
    public void lightCdMethod()
    {
        StartCoroutine(setText(lightcd - PlayerPrefs.GetInt("lightReduce"), lightCdText, lightBar));
    }
    public void asidCdMethod()
    {
        StartCoroutine(setText(asidcd - PlayerPrefs.GetInt("asidReduce"), asidCdText, asidBar));
    }
    public void thornCdMethod()
    {
        StartCoroutine(setText(thorncd - PlayerPrefs.GetInt("thornReduce"), thornCdText, thornBar));
    }
    public void trapCdMethod()
    {
        StartCoroutine(setText(trapcd - PlayerPrefs.GetInt("trapReduce"), trapCdText, trapBar));
    }
    public void windCdMethod()
    {
        StartCoroutine(setText(windcd - PlayerPrefs.GetInt("windReduce"), windCdText, windBar));
    }
    IEnumerator setText(int cd,TextMeshProUGUI text,GameObject bar)
    {
        bar.SetActive(true);
        while (cd>=0)
        {
            text.text = cd.ToString();
            yield return new WaitForSeconds(1f);
            cd--;
            if (cd == 0)
            {
                StopCoroutine("setText");
                bar.SetActive(false);
            }
            
        }
        
    }
}
