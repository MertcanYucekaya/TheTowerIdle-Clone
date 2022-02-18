using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WindCard : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform transform;
    CanvasGroup canvasGroup;
    public RectTransform startTransform;
    [SerializeField]
    private Canvas canvas;
    public GameObject windPoint;
    GameObject windPointSc;
    Vector3 c;
    public GameObject windEffect;
    public GameObject windCol;
    public float duration;
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
        c = new Vector3(transform.anchoredPosition.x, transform.anchoredPosition.y, 10);
        c = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

        c = new Vector3(c.x, c.y, 10);
        transform.anchoredPosition = startTransform.anchoredPosition;
        if (c.y > -.6f)
        {
            cardPanel.GetComponent<CardsPanelSc>().windCdMethod();
            windEffect.SetActive(true);
            windCol.SetActive(true);
            Invoke("end", duration);
        }
    }
    private void Update()
    {

        if (windCol.GetComponent<CircleCollider2D>().radius < 2.3f && windCol.active == true)
        {
            windCol.GetComponent<CircleCollider2D>().radius += Time.deltaTime;
        }
    }
    void end()
    {
        windEffect.SetActive(false);
        windCol.SetActive(false);
        windCol.GetComponent<CircleCollider2D>().radius = 0.2f;
    }
}
