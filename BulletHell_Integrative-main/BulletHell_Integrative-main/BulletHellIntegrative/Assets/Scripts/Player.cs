using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Animator animator;

    [SerializeField]
    private float speed;

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    public float timeSpeed = 0.5f;

    private float bulletCounter;
    public TextMeshProUGUI counter;

    public GameObject finalBoss;
    public GameObject R1;
    public GameObject R2;
    public GameObject R3;
    public GameObject R4;

    public GameObject LosePanel;

    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        Physics.IgnoreLayerCollision(4, 6);
        Physics.IgnoreLayerCollision(4, 8);
    }
    void Update()
    {
        bulletCounter = GameObject.FindGameObjectsWithTag("Bullet").Length;
        counter.text = "Bullets: " + bulletCounter.ToString();

        MovementInput();
        Aim();
        Shoot();

        if (Input.GetKey(KeyCode.Space))
        {
            Time.timeScale = timeSpeed;
        }
        else if (Input.GetKeyUp(KeyCode.Space)) 
        {
            Time.timeScale = 1f;
        }
    }
    void MovementInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
    void Aim()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit))
        {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }
    }
    void Shoot()
    {
        if (Input.GetButton("Fire1"))
        {
            Gun.Instance.Shooting();
            animator.SetBool("isAttaking", true);
        }
        else
        {
            animator.SetBool("isAttaking", false);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if(currentHealth <= 0)
        {
            LosePanel.SetActive(true);
            Destroy(gameObject);
            Time.timeScale = 0.01f;
        }
    }
    public void OnEnable()
    {
        TimeManager.OnMinuteChanged += TimeCheck;
    }

    public void OnDisable()
    {
        TimeManager.OnMinuteChanged -= TimeCheck;
    }
    private void TimeCheck()
    {
        if (TimeManager.Hour == 00 && TimeManager.Minute == 51)
        {
            finalBoss.SetActive(true);
        }
        if (TimeManager.Hour == 00 && TimeManager.Minute == 09)
        {
            R1.SetActive(true);
        }
        if (TimeManager.Hour == 00 && TimeManager.Minute == 17)
        {
            R2.SetActive(true);
        }
        if (TimeManager.Hour == 00 && TimeManager.Minute == 25)
        {
            R3.SetActive(true);
        }
        if (TimeManager.Hour == 00 && TimeManager.Minute == 33)
        {
            R4.SetActive(true);
        }
    }
    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
