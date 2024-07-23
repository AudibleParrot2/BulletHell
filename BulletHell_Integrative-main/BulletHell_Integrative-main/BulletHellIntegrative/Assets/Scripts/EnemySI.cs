using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySI : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public int nBullets;
    public float speedBullets;
    public GameObject enemyBullets;
    private Vector3 startPoint;
    private const float radius = 1f;

    private float elapsedCooldown = 0f;
    public float cooldown1 = 0.1f;

    public float endAngle = 360;
    public float startAngle = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        Physics.IgnoreLayerCollision(7, 8);
        Physics.IgnoreLayerCollision(8, 8);
    }

    // Update is called once per frame
    void Update()
    {
        elapsedCooldown += Time.deltaTime;
        if (elapsedCooldown >= cooldown1)
        {
            startPoint = transform.position;
            elapsedCooldown = elapsedCooldown % cooldown1;
            FirstCoreo();
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void FirstCoreo()
    {
        float angleStep = (endAngle - startAngle) / nBullets;
        float angle = startAngle;
        for (int i = 0; i <= nBullets - 1; i++)
        {
            float DirX = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float DirY = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            Vector3 bulletVector = new Vector3(DirX, DirY, 0);
            Vector3 bulletMove = (bulletVector - startPoint).normalized * speedBullets;

            GameObject tmpObj = Instantiate(enemyBullets, startPoint, Quaternion.identity);
            tmpObj.GetComponent<Rigidbody>().velocity = new Vector3(bulletMove.x, 0, bulletMove.y);

            angle += angleStep;
        }
    }
}
