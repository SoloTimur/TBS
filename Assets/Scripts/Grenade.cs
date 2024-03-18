using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float Time;
    public GameObject explosionPrefab;
    private void OnCollisionEnter(Collision collision)
    {
        Invoke("Boom", Time);
    }
    private void Boom()
    {
        Destroy(gameObject);
        var explosion = Instantiate(explosionPrefab);
        explosion.transform.position = transform.position;
    }
}