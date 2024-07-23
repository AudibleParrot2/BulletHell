using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public List<GameObject> ai;
    public GameObject[] spawn;



    private void Start()
    {
        var res = Resources.LoadAll<GameObject>("ai/");

        foreach (GameObject obj in res)
        {
            ai.Add(obj);
        }


        for (int x = 0; x < 2; x++)
        {
            //I am currently using this kind of format since this is what I know for now.
            Instantiate(ai[x], spawn[x].transform.position, spawn[x].transform.rotation);
        }
    }
}
