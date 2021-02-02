using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthEnemy : MonoBehaviour
{
    public int maxHealth;
    private int health;
    Slider sliderHealth;
    bool dead;
    public GameObject deadParticles;
    GameObject canvas;

    private void Start()
    {
        health = maxHealth;
        //GetComponentInChildren busca un componente dentro de un objeto, en este caso
        //busca el Slider dentro de la nave enemiga.
        sliderHealth = GetComponentInChildren<Slider>();
        sliderHealth.maxValue = maxHealth;
        sliderHealth.value = maxHealth;
        canvas = transform.GetChild(0).gameObject;
        canvas.SetActive(false);
    }

    private void OnTriggerEnter(Collider impacto)
    {

        if (impacto.gameObject.tag.Equals("PlayerBullet"))
        {
            Destroy(impacto.gameObject);
            print(impacto.gameObject.name);
            health--;
            canvas.SetActive(true);
            sliderHealth.value = health;

            
            if (health <=0 && !dead)
            {
                if(gameObject.name.Equals("Death Star"))
                {
                    GetComponent<DeathStar>().panelVictory.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    
                }

                dead = true;
                GameManager.manager.UpdateScore(10);
                GameManager.manager.enemyNumber--;
                Instantiate(deadParticles, transform.position, transform.rotation);
                Destroy(gameObject);
            }

        }

    }


}
