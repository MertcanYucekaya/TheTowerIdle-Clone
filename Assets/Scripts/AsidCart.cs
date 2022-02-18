using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AsidCart : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform transform;
    CanvasGroup canvasGroup;
    public RectTransform startTransform;
    [SerializeField]
    private Canvas canvas;
    Vector3 c;
    public GameObject asidRainEffect;
    GameObject[] enemies;
    public float damagePerSecond;
    public float duration;
    public GameObject cardPanel;


    private void Awake()
    {
        transform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        damagePerSecond += PlayerPrefs.GetInt("asidDamage");
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = .6f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.anchoredPosition += eventData.delta / canvas.scaleFactor;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1;
        c = new Vector3(transform.anchoredPosition.x, transform.anchoredPosition.y, 10);
        c = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        c = new Vector3(c.x, c.y, 10);
        transform.anchoredPosition = startTransform.anchoredPosition;
        if (c.y > -.6f)
        {
            cardPanel.GetComponent<CardsPanelSc>().asidCdMethod();
            asidRainEffect.SetActive(true);
            InvokeRepeating("enemiesDamage", 0.5f, 1);
            Invoke("end", duration);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
       
    }
    private void Update()
    {
        if (asidRainEffect.activeSelf == true)
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
        }
        
    }
    void enemiesDamage()
    {
        if (asidRainEffect.activeSelf == true)
        {
            foreach (GameObject g in enemies)
            {
                if (g != null)
                {
                    try
                    {
                        g.GetComponent<EnemiesSc>().getDamage(damagePerSecond);
                        g.GetComponent<EnemiesSc>().asidRain = true;
                    }
                    catch
                    {
                        g.GetComponent<ArrowEnemySc>().getDamage(damagePerSecond);
                        g.GetComponent<ArrowEnemySc>().asidRain = true;
                    }
                }
               
            }
        }
    }
    void end()
    {
        asidRainEffect.SetActive(false);
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject g in enemies)
        {
            try
            {
                g.GetComponent<EnemiesSc>().asidRain = false;
            }
            catch
            {
                g.GetComponent<ArrowEnemySc>().asidRain = false;
            }

        }
    }
}
