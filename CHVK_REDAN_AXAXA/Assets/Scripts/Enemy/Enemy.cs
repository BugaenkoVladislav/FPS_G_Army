using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 1000;
    public float maxhealth = 1000;
    

    // Start is called before the first frame update
    void Start()
    {
        health = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RecountHP(float deltahealt)
    {
        health += deltahealt;

        if (health <= 0)
        {
            transform.gameObject.SetActive(false);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<Health>().UI(-1);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<Health>().UI(-1);
        }
    }
}
