using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public GameObject prefabBullet;
    public GameObject enemy;
    public Canvas slowmo;
    public Text bullets;
    GameObject thisBullet;
    Ray ray = new Ray();
    List<GameObject> pool = new List<GameObject>();
    bool isShooting = false;
    bool isReloading = false;
    public bool IsReloading
    {
        get 
        { 
            return isReloading; 
        }

    }
    public bool IsShooting
    {
        get
        {
            return isShooting;
        }
        
    }
    RaycastHit hit;    
    float damage = -10;      
    float bulletThis = 60;
    

    // Start is called before the first frame update
    void Start()
    {
        slowmo.gameObject.SetActive(false);
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
        isShooting = true;
        bullets.text = bulletThis.ToString();
        if (bulletThis <= 0)
        {
            bulletThis = 60;           
        }
        else
        {
            isReloading = false;
        }
    }
    void Cleaner()//чистит наш пул
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
        if (Input.GetMouseButton(0))
        {
            CountBullet();            
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
