using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackEvent : MonoBehaviour
{   public EnemyAI enemyAI;
    
    public void AttackDamageEvent()
    {
        enemyAI.AttackDamage();
    }
}
