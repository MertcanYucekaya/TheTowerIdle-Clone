using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TrapCard : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform transform;
    CanvasGroup canvasGroup;
    public RectTransform startTransform;
    [SerializeField]
    private Canvas canvas;
    public GameObject trapPoint;
    GameObject trapPointSc;
    Vector3 c;
    public float radius;
    public LayerMask enemyLayer;
    public float damage;
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

        c = new Vector3(c.x, c.y , 10);
        transform.anchoredPosition = startTransform.anchoredPosition;
        if (c.y > -.6f)
        {
            cardPanel.GetComponent<CardsPanelSc>().trapCdMethod();
            trapPointSc = Instantiate(trapPoint, c, Quaternion.identity);
            Destroy(trapPointSc, .8f);
            Collider2D[] col = Physics2D.OverlapCircleAll(c, radius, enemyLayer);
            foreach (Collider2D c in col)
            {

                Vector2 vector = c.transform.localPosition;
                if (vector.y > 2.35)
                {
                    c.GetComponent<Rigidbody2D>().velocity = vector.normalized * 6;
                }
                else
                {
                    c.GetComponent<Rigidbody2D>().velocity = -vector.normalized * 6;
                }
                c.GetComponent<Collider2D>().enabled = false;
                StartCoroutine(velocDef(c));

            }

        }
    }
    IEnumerator velocDef(Collider2D c)
    {
        yield return new WaitForSeconds(.5F);
        if (c != null)
        {
            c.GetComponent<Collider2D>().enabled = true;
            c.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            try
            {
                c.GetComponent<EnemiesSc>().getDamage(damage);
            }
            catch
            {
                c.GetComponent<ArrowEnemySc>().getDamage(damage);
                c.GetComponent<ArrowEnemySc>().moveTo = true;
            }
        }
        

    }
}
