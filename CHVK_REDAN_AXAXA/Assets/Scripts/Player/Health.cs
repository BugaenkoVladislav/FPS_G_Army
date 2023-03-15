using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Camera player_Cam;
    float health = 0;
    float maxHealth = 100;
    public Text health_text;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        UI(0);
    }

    // Update is called once per frame
    void Update()
    {
        health_text.text = health.ToString();
    }
     public void UI(float deltahealth)
    {
        health += deltahealth;
        if (health <= 0)
        {
            //play death
            playerDeath();
        }        
    }
    void playerDeath()
    {
        player_Cam.GetComponent<Menu>().DeathScreen();
    }
}
