using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float maxSize = 5;
    public float Speed = 1;
    public float damage = 70;
    // Start is called before the first frame update
    private void Start()
    {
        transform.localScale = Vector3.zero;
    }
    private void Update()
    {
        transform.localScale += Vector3.one * Time.deltaTime * Speed;
        if(transform.localScale.x > maxSize)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        var PlayerHealth = other.GetComponent<PlayerHealth>();
        if(PlayerHealth != null)
        {
            PlayerHealth.DealDamage(damage);
        }
        var enemyHealth = other.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.DealDamage(damage);
        }
    }
}