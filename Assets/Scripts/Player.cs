using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public int attackPower = 10;
    public Transform attackPoint;
    public float attackRadius;
    public LayerMask enemyLayer;

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }    
    }

    void Attack()
    {
        // サークル範囲内にEnemyレイヤーがいたら取得
        Collider2D[] hitEnemys = 
        Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, enemyLayer);
        
        // 取得したそれぞれのEnemyにダメージを与える
        foreach (Collider2D hitEnemy in hitEnemys)
        {
            Debug.Log(hitEnemy.gameObject.name + "に攻撃");
            hitEnemy.GetComponent<Enemy>().Damage(attackPower);
        }
    }

    // AttackPointの表示
    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
}
