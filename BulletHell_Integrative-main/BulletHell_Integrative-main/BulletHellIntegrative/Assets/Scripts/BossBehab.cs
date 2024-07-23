using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BossBehab : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    public GameObject[] flagsToCrossOne;
    public GameObject[] flagsToCrossTwo;
    public GameObject[] flagsToCrossThree;
    int currentFlag = 0;
    public float speed;
    float flagRadius = 1f;
    private float alphaTime = 0;

    private int nBullets;
    private float speedBullets;
    public GameObject enemyBullets;
    private Vector3 startPoint;
    private const float radius = 1f;

    private float elapsedCooldown = 0f;
    private float cooldown1 = 0.01f;
    private float cooldown2 = 0.5f;
    private float cooldown3 = 1.5f;

    public float endAngle = 360;
    public float startAngle = 0;

    public GameObject WinPanel;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        Physics.IgnoreLayerCollision(7, 8);
        Physics.IgnoreLayerCollision(8, 8);
    }

    // Update is called once per frame
    void Update()
    {
        alphaTime += Time.deltaTime;
        if(alphaTime < 10)
        {
            elapsedCooldown += Time.deltaTime;
            if (elapsedCooldown >= cooldown1)
            {
                startPoint = transform.position;
                elapsedCooldown = elapsedCooldown % cooldown1;
                FirstCoreo();
            }
            
            MoveBossOne();
        }
        else if(alphaTime > 10 && alphaTime <20)
        {
            elapsedCooldown += Time.deltaTime;
            if (elapsedCooldown >= cooldown2)
            {
                startPoint = transform.position;
                elapsedCooldown = elapsedCooldown % cooldown2;
                SecondCoreo();
            }
            MoveBossTwo();
        }
        else
        {
            elapsedCooldown += Time.deltaTime;
            if (elapsedCooldown >= cooldown3)
            {
                startPoint = transform.position;
                elapsedCooldown = elapsedCooldown % cooldown3;
                ThirdCoreo();
            }
            MoveBossThree();
        }
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if(currentHealth <= 0)
        {
            WinPanel.SetActive(true);
            Destroy(gameObject);
            Time.timeScale = 0.01f;
        }
    }

    void MoveBossOne()
    {
        if (Vector3.Distance(flagsToCrossOne[currentFlag].transform.position, transform.position) < flagRadius)
        {
            currentFlag++;
            if(currentFlag >= flagsToCrossOne.Length)
            {
                currentFlag = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, flagsToCrossOne[currentFlag].transform.position, Time.deltaTime * speed);
    }
    void FirstCoreo()
    {
        nBullets = 1;
        speedBullets = 20;
        float angleStep = (endAngle-startAngle) / nBullets;
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
            endAngle += 8;
            startAngle += 8;
        }
    }

    void MoveBossTwo()
    {
        if (Vector3.Distance(flagsToCrossTwo[currentFlag].transform.position, transform.position) < flagRadius)
        {
            currentFlag++;
            if (currentFlag >= flagsToCrossTwo.Length)
            {
                currentFlag = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, flagsToCrossTwo[currentFlag].transform.position, Time.deltaTime * speed);
    }
    void SecondCoreo()
    {
        nBullets = 15;
        speedBullets = 3;
        float angleStep = 360f / nBullets;
        float angle = 0f;
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
    void MoveBossThree()
    {
        if (Vector3.Distance(flagsToCrossThree[currentFlag].transform.position, transform.position) < flagRadius)
        {
            currentFlag++;
            if (currentFlag >= flagsToCrossThree.Length)
            {
                currentFlag = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, flagsToCrossThree[currentFlag].transform.position, Time.deltaTime * speed);
    }
    void ThirdCoreo()
    {
        nBullets = 25;
        speedBullets = 40;
        float angleStep = 360f / nBullets;
        float angle = 0f;
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
