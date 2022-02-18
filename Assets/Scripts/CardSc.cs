using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class CardSc : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform transform;
    CanvasGroup canvasGroup;
    public RectTransform startTransform;
    [SerializeField]
    private Canvas canvas;
    public GameObject obje;
    GameObject instant;
    Vector3 c;
    public float meteoraRdius;
    public float meteorSpeed;
    public LayerMask enemyLayer;
    public GameObject meteorEffect;
    GameObject effect;
    public GameObject cardPanel;


    private void Awake()
    {
        transform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        
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
        c = new Vector3(transform.anchoredPosition.x, transform.anchoredPosition.y,10);
        c = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        c = new Vector3(c.x, c.y, 10);
        transform.anchoredPosition = startTransform.anchoredPosition;
        if (c.y > -.6f)
        {
            instant = Instantiate(obje, new Vector3(c.x, 5.5f, 0), Quaternion.identity);
            cardPanel.GetComponent<CardsPanelSc>().meteorCdMethod();
        }
        
       
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }
    private void Update()
    {
        if (instant != null)
        {
            instant.transform.position = Vector2.MoveTowards(instant.transform.position, new Vector2(c.x, c.y), Time.deltaTime* meteorSpeed);
            if (Mathf.Approximately(instant.transform.position.x, c.x) && Mathf.Approximately(instant.transform.position.y, c.y))
            {
                GameObject effect =  Instantiate(meteorEffect, instant.transform.position, Quaternion.identity);
                Collider2D[] a = Physics2D.OverlapCircleAll(instant.transform.position, meteoraRdius,enemyLayer);
                foreach(Collider2D b in a)
                {
                    Destroy(b.gameObject);
                }
                Destroy(instant);
                Destroy(effect,0.2f);
            }
        }
        
    }
}
