using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    Vector3 destiny;
    public float enemySpeed;
    Transform player;

    public Transform shootPoint;
    public GameObject bullet;
    float timeLastShoot;
    public float cadency;

    private void Start()
    {
        if (GameObject.Find("Player"))
        {
            player = GameObject.Find("Player").transform;
        }
        ChooseDestiny();
    }

    private void Update()
    {
        if (player != null && Vector3.Distance(transform.position,player.position) < 40)
        {
            transform.LookAt(player);
            if (Time.time - timeLastShoot > cadency)
                Shoot();
        }
        else
        {
            transform.LookAt(destiny);
            transform.Translate(Vector3.forward * enemySpeed);
            if (Vector3.Distance(destiny, transform.position) < 2)
            {
                ChooseDestiny();
            }
        }
    }

    void ChooseDestiny()
    {
        destiny = new Vector3(Random.Range(-100, 100), 
        Random.Range(-100,100), Random.Range(0, 300));
    }

    void Shoot()
    {
        timeLastShoot = Time.time;
        Destroy(Instantiate(bullet, shootPoint.position, shootPoint.rotation), 5);
        
    }
}
