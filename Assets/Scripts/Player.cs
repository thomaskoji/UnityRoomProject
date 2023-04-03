using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other) 
    {
        Debug.Log("df;alkjd");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            if (other.tag == "Enemy")
            {
                var enemy = other.GetComponent<Enemy>();
                enemy.hp -= 10;
                Debug.Log(enemy.hp);
            }  
        }      
    }
}
