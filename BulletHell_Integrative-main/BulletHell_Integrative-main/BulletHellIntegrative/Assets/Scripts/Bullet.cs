using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 firePoint;
    public float bulletSpeed;

    public float maxDistance;
    private GameObject boss;
    private GameObject enemy1;
    private GameObject enemy2;
    private GameObject enemy3;
    private GameObject enemy4;
    private GameObject enemy5;
    private GameObject enemy6;

    // Start is called before the first frame update
    void Start()
    {
        firePoint = transform.position;
        boss = GameObject.FindWithTag("Boss");
        enemy1 = GameObject.FindWithTag("Enemy1");
        enemy2 = GameObject.FindWithTag("Enemy2");
        enemy3 = GameObject.FindWithTag("Enemy3");
        enemy4 = GameObject.FindWithTag("Enemy4");
        enemy5 = GameObject.FindWithTag("Enemy5");
        enemy6 = GameObject.FindWithTag("Enemy6");
        Physics.IgnoreLayerCollision(6,8);
        
    }

    // Update is called once per frame
    void Update()
    {
        bulletMovement();
    }

    void bulletMovement()
    {
        if(Vector3.Distance(firePoint, transform.position) > maxDistance)
        {
            Destroy(this.gameObject);
        }
        else
        {
            transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Boss")
        {
            boss.GetComponent<BossBehab>().TakeDamage(1);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Enemy1")
        {
            enemy1.GetComponent<EnemyII>().TakeDamage(1);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Enemy2")
        {
            enemy2.GetComponent<EnemyID>().TakeDamage(1);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Enemy3")
        {
            enemy3.GetComponent<EnemySI>().TakeDamage(1);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Enemy4")
        {
            enemy4.GetComponent<EnemySD>().TakeDamage(1);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Enemy5")
        {
            enemy5.GetComponent<EnemyCC>().TakeDamage(1);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Enemy6")
        {
            enemy6.GetComponent<EnemyCS>().TakeDamage(1);
            Destroy(gameObject);
        }
    }
}
