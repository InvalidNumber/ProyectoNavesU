using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathStar : MonoBehaviour
{
    public Transform generationPoint;
    public GameObject enemy;
    public int maxEnemies = 10;
    public float timeBetweenEnemies;

    public GameObject panelVictory;

    private void Start()
    {
        GenerateEnemy();
        panelVictory = GameObject.Find("PanelVictory");
        panelVictory.SetActive(false);
    }

    private void Update()
    {
        if(GameManager.manager.enemyNumber <= 0 && maxEnemies <= 0)
        {
            GetComponent<SphereCollider>().enabled = true;
        }
    }

    public void GenerateEnemy()
    {
        Instantiate(enemy, generationPoint.position, generationPoint.rotation);
        GameManager.manager.enemyNumber++;
        maxEnemies--;
        if(maxEnemies > 0)
        {
            Invoke("GenerateEnemy", timeBetweenEnemies);
        }
    }
}
