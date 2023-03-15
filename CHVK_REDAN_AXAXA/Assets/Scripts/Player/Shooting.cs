using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    Ray ray = new Ray();
    public bool isShooting = false;
    public bool isReloading = false;
    RaycastHit hit;
    public GameObject enemy;
    public float damage = -10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ray.direction = transform.forward;
        ray.origin = transform.position;
        if (Input.GetMouseButton(0))
        {
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

    }
    private void FixedUpdate()
    {
        
    }
}
