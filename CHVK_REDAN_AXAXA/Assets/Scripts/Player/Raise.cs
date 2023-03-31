using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raise : MonoBehaviour
{
    public Sprite Hoody;
    public Sprite Trousers;
    public Image armourUp;
    public Image armourDown;
    RaycastHit hit;
    Ray ray = new Ray();
    public GameObject player;
    bool is_Raising = false;
    string in_hands; //object which we raised
    int count_Vape = 0;
    public Image vapeSlot;
    public Text countVape;
    public Sprite Vape;
    public float vape_Heel = 50;
    void Start()
    {
        vapeSlot.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ray.direction = transform.forward;
        ray.origin = transform.position;
        is_Raising = Input.GetKey(KeyCode.E);
        if (is_Raising == true)
        {
            Raising();
        }
        if(Input.GetKey(KeyCode.Tab)) 
        {
            InventoryCall("Vape", count_Vape);
            
        }
        else
        {
            vapeSlot.gameObject.SetActive(false);
        }
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (count_Vape > 0)
            {
                player.GetComponent<Health>().UI(vape_Heel);
                count_Vape-=1;
            }
            
        }
        
        

    }
    void Raising()
    {
        //hit.transform.parent = transform;- прив€зывает компонент к камере
        if (is_Raising == true && Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag == "Object" && hit.distance<=2)
            {                
                hit.collider.gameObject.SetActive(false);//deliting object from scene
                in_hands = hit.transform.name;                             
                CountInventory(in_hands);
            }
        }
    }
    void CountInventory(string holds)//присваивает €чейкам подн€тые объекты
    {
        if (in_hands.Contains("Vape"))
        {
            hit.collider.gameObject.SetActive(false);
            count_Vape++;
                       
        }
        if (holds.Contains("Hoody"))
        {
            armourUp.color = Color.white;
            armourUp.sprite = Hoody;
                       
            
        }
        if (holds.Contains("Trousers"))
        {
            armourDown.color = Color.white;
            armourDown.sprite = Trousers;
            
        }
    }
    void InventoryCall(string Object, int count)
    {

        if (Object.Contains("Vape"))
        {
            vapeSlot.gameObject.SetActive(true);
            countVape.text = Convert.ToString(count);
            vapeSlot.sprite = Vape;
            
        }
        
        
    }
}


