using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPlayer : MonoBehaviour
{
    public int maxHealth;
    private int health;
    public Slider sliderHealth;
    public Text textHealth;

    public GameObject panelGameOver;

    private void Start()
    {
        health = maxHealth;
        sliderHealth.maxValue = maxHealth;
        sliderHealth.value = maxHealth;
        textHealth.text = ((health * 100) / maxHealth) + "%";
        panelGameOver = GameObject.Find("PanelGameOver");
        panelGameOver.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnTriggerEnter(Collider impacto)
    {
        if(impacto.gameObject.tag.Equals("EnemyBullet"))
        {
            print(impacto.gameObject.name);
            health--;
            sliderHealth.value = health;
            textHealth.text = ((health * 100) / maxHealth) + "%";
            print(health);
            Destroy(impacto.gameObject);

            if (health <= 0)
            {
                panelGameOver.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Camera.main.transform.SetParent(null);
                Destroy(gameObject);
            }
        }
        
    }

    
}
