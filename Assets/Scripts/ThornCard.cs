using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ThornCard : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform transform;
    CanvasGroup canvasGroup;
    public RectTransform startTransform;
    [SerializeField]
    private Canvas canvas;
    public GameObject thornPoint;
    GameObject thornPointSc;
    public GameObject thornAnim;
    GameObject thornAnimSc;
    Vector3 c;
    public float damage;
    public LayerMask enemyLayer;
    public GameObject cardPanel;


    private void Awake()
    {
        transform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        damage += PlayerPrefs.GetInt("trapDamage");
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
        //c = new Vector3(c.x+0.35f, c.y + 3.2f, 0);
        c = new Vector3(c.x, c.y, 10);
        Debug.Log(c.y);
        transform.anchoredPosition = startTransform.anchoredPosition;
        if (c.y > -.6f)
        {
            cardPanel.GetComponent<CardsPanelSc>().thornCdMethod();
            thornAnimSc = Instantiate(thornAnim, c, Quaternion.identity);
            Destroy(thornAnimSc, 1.4f);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }
    private void Update()
    {
        if (thornAnimSc != null)
        {
            Collider2D[] c = Physics2D.OverlapBoxAll(thornAnimSc.transform.position, new Vector3(1.2F, 3.15f),0, enemyLayer);
            foreach(Collider2D col in c)
            {
                try
                {
                    col.GetComponent<EnemiesSc>().speed = 0;
                    col.GetComponent<EnemiesSc>().getDamage(damage*Time.deltaTime);
                    StartCoroutine(enemySpeedChange(col));
                }
                catch
                {
                    col.GetComponent<ArrowEnemySc>().speed = 0;
                    col.GetComponent<ArrowEnemySc>().getDamage(damage * Time.deltaTime);
                    StartCoroutine(enemySpeedChange(col));
                }
            }
        }
    }
    IEnumerator enemySpeedChange(Collider2D c)
    {
            yield return new WaitForSeconds(1.4f);
        if (c != null)
        {
            try
            {
                c.GetComponent<EnemiesSc>().thornSpeed();
            }
            catch
            {
                c.GetComponent<ArrowEnemySc>().thornSpeed();
            }
        }
           
        
    }
}
