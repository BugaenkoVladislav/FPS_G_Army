using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    Ray ray = new Ray();
    public bool isShooting = false;
    public bool isReloading = false;
    RaycastHit hit;
    public GameObject enemy;
    public float damage = -10;
    public Canvas slowmo;

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
