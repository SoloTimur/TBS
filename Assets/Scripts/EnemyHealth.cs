using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public float value = 100;
    public Animator animator;
    
    public PlayerProgress playerProgress;
    
    
    public void DealDamage(float damage)
    {
        playerProgress.AddExperience(damage);
        
        value -= damage;
        if(value <= 0)
        {
            EnemyDeath(); 
        }
        else 
        {
            animator.SetTrigger("hit");
        }
    }
    
    private void EnemyDeath()
    {
        animator.SetTrigger("death");
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<EnemyAI>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
    }
     
}