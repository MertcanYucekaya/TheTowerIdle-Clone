using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    GameObject target;
    public float arrowSpeed;
    Castle castle;
    public float damage;
    SpawnerSc spawnerSc;
    void Start()
    {
        spawnerSc = GameObject.Find("SpawnerParent").GetComponent<SpawnerSc>();
        target = GameObject.Find("Castle");
        castle = target.GetComponent<Castle>();
        transform.up = target.transform.position - transform.position;
        transform.rotation *= Quaternion.Euler(0,0,180);
        damage = damage + spawnerSc.currentWave * 2;
    }

    
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, Time.deltaTime* arrowSpeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name.Equals("Castle"))
        {
            castle.castleDamage(damage);
            Destroy(gameObject);
        }
        
    }
}
