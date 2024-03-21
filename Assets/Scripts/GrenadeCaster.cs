using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeCaster : MonoBehaviour
{   public float damage = 50;
    
    public Rigidbody grenadePrefab;
    public Transform grenadeSourceTransform;
    
    public float force = 10;

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            var grenade = Instantiate(grenadePrefab);
            grenade.transform.position = grenadeSourceTransform.position;
            grenade.GetComponent<Rigidbody>().AddForce(grenadeSourceTransform.forward * force);
            grenade.GetComponent<Grenade>().damage = damage;
        }
    }
}