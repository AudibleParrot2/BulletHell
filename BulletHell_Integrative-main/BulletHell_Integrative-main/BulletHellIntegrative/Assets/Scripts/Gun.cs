using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject bullet;
    public float shotSpeed;
    public static Gun Instance;
    private float cooldown = 0f;

    void Awake()
    {
        Instance = GetComponent<Gun>();
    }

    public void Shooting()
    {
        if(cooldown + shotSpeed <= Time.time)
        {
            cooldown = Time.time;
            Instantiate(bullet, FirePoint.position, FirePoint.rotation);
        }
    }
}
