using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullets : MonoBehaviour
{
    private Vector3 firePoint;
    public float maxDistance;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        firePoint = transform.position;
        player = GameObject.FindWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        bulletMovement();
    }

    void bulletMovement()
    {
        if (Vector3.Distance(firePoint, transform.position) > maxDistance)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<Player>().TakeDamage(1);
            Destroy(gameObject);
        }
    }
}
