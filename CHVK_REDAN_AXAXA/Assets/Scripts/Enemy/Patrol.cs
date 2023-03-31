using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Patrol : MonoBehaviour
{
    public float speed = 3f;
    public Transform target;
    public Transform You;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Detected();
    }
    void Detected()
    {
        if (You.GetComponent<Enemy>().health != You.GetComponent<Enemy>().maxhealth) 
        {
            transform.position = Vector3.Lerp(transform.position,target.position,speed * Time.deltaTime);
        }
    }
}
