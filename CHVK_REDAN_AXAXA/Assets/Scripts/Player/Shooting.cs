using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public GameObject prefabBullet;
    GameObject thisBullet;
    Ray ray = new Ray();
    public bool isShooting = false;
    public bool isReloading = false;
    RaycastHit hit;
    public GameObject enemy;
    public float damage = -10;
    public Canvas slowmo;
    List<GameObject> pool = new List<GameObject>();
    float bulletThis = 60;
    float bulletAll = 240;

    public Text bullets;
    public Text allBullets;

    // Start is called before the first frame update
    void Start()
    {
        slowmo.gameObject.SetActive(false);
        allBullets.text = bulletAll.ToString();
        bullets.text = bulletThis.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Cleaner();
    }
    void Slowmotion()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            Time.timeScale = 0.5f;
            slowmo.gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            slowmo.gameObject.SetActive(false);
        }
    }
    void CountBullet()
    {
        bulletThis--;
        bullets.text = bulletThis.ToString();
        if (bulletThis <= 0)
        {
            bulletThis = 30;           
            bulletAll -= bulletThis;
            allBullets.text = bulletAll.ToString();
        }
        else
        {
            isReloading = false;
        }
    }
    void Cleaner()
    {
        if (pool.Count > 50)
        {
            Destroy(pool[0]);
            pool.RemoveAt(0);
        }
        
    }
    private void FixedUpdate()
    {
        ray.direction = transform.forward;
        ray.origin = transform.position;
        if (Input.GetMouseButton(0)&& bulletAll>0)
        {
            CountBullet();
            isShooting = true;
            if (Physics.Raycast(ray, out hit))
            {               
                thisBullet = Instantiate(prefabBullet,hit.point, transform.rotation,hit.transform);//следы от пуль
                pool.Add(thisBullet);
                if (hit.transform.name == "Enemy" && !hit.collider.isTrigger)
                {                    
                    enemy.GetComponent<Enemy>().RecountHP(damage);
                }
                
            }
        }
        else
        {
            isShooting = false;
        }

        if (Input.GetKey(KeyCode.R))
        {
            isReloading = true;
        }
        else
        {
            isReloading = false;
        }
        Slowmotion();
        
    }
}
