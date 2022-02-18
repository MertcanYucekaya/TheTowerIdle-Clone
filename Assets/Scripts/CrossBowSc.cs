using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossBowSc : MonoBehaviour
{
    public float speed;
    Vector2 target;
    Castle castle;
    public float damage;
    Vector2 vector;
    void Start()
    {
        castle = GameObject.Find("Castle").GetComponent<Castle>();
        target = castle.nearMethod().transform.position;
        targetLook(transform);

    }

    void Update()
    {
        vector = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        transform.position = vector;
        if (Mathf.Approximately(transform.position.x, target.x) && Mathf.Approximately(transform.position.y, target.y))
        {
            Destroy(gameObject, 0.5f);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            try
            {
                collision.GetComponent<EnemiesSc>().getDamage(damage);
                Destroy(gameObject);
            }
            catch
            {
                collision.GetComponent<ArrowEnemySc>().getDamage(damage);
                Destroy(gameObject);
            }
        }
    }
    private void OnDestroy()
    {
        castle.bowSpawnBool = true;
    }
    public void targetLook(Transform t)
    {
        t.up = target - new Vector2(t.position.x, t.position.y);
        t.rotation *= Quaternion.Euler(0, 0, 180);
    }
}
