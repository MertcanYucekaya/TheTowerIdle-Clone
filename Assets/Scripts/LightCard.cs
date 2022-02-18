using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LightCard : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform transform;
    CanvasGroup canvasGroup;
    public RectTransform startTransform;
    [SerializeField]
    private Canvas canvas;
    public GameObject lightPoint;
    GameObject lightPointSc;
    Vector3 c;
    public LayerMask enemyLayer;
    public float lightRadius;
    public GameObject lightEffect;
    GameObject lightEffectSc;
    public GameObject enemyLightEffeckt;
    GameObject enemyLightEffecktSc;
    public float damage;
    public GameObject cardPanel;


    private void Awake()
    {
        transform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        damage += PlayerPrefs.GetInt("lightDamage");
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
        c = new Vector3(c.x, c.y,10);
        transform.anchoredPosition = startTransform.anchoredPosition;
        Debug.Log(c);
        if (c.y > -.6f)
        {
            cardPanel.GetComponent<CardsPanelSc>().lightCdMethod();
            lightPointSc = Instantiate(lightPoint, c,Quaternion.identity);
            lightEffectSc = Instantiate(lightEffect, new Vector2(c.x, 4.71f),Quaternion.identity);
            Destroy(lightEffectSc, 2f);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }
    private void Update()
    {
        if (lightPointSc != null)
        {
            Collider2D[] col = Physics2D.OverlapCircleAll(lightPointSc.transform.position,lightRadius,enemyLayer);
            foreach(Collider2D c in col)
            {
                try
                {
                    c.GetComponent<EnemiesSc>().getDamage(damage);
                    enemyLightEffecktSc = Instantiate(enemyLightEffeckt, c.transform.position, Quaternion.identity);
                    Destroy(enemyLightEffecktSc, 2);

                }
                catch
                {
                    c.GetComponent<ArrowEnemySc>().getDamage(damage);
                    enemyLightEffecktSc = Instantiate(enemyLightEffeckt, c.transform.position, Quaternion.identity);
                    Destroy(enemyLightEffecktSc, 2);
                }
            }
            Destroy(lightPointSc);
        }
    }

}
