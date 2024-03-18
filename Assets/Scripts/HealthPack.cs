using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    public float healAmount = 25;
    
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
      var plaerHealth = other.gameObject.GetComponent<PlayerHealth>();  
      if(plaerHealth != null)
      {
        plaerHealth.AddHealth(healAmount);
        Destroy(gameObject);  
      }    
    }
}
