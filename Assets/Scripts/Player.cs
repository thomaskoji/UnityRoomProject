using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public int attackPower = 10;
    public Transform attackPoint;
    public float attackRadius;
    public LayerMask enemyLayer;
    public AudioClip attackSE;
    public AudioClip deathAttackSE;

    bool canAttack;

    private void Start() 
    {
        canAttack = true;    
    }

    private void Update() 
    {
        if (canAttack == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
            } 
        }        
    }

    void Attack()
    {
        // サークル範囲内に、レイヤーがEnemyのオブジェクトがいたら取得
        Collider2D[] hitEnemys = 
        Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, enemyLayer);
        
        // 取得したそれぞれのEnemyにダメージを与える
        foreach (Collider2D hitEnemy in hitEnemys)
        {
            var enemy = hitEnemy.GetComponent<Enemy>();   
            if (enemy.isExhausted == true)
            {
                GameManager.instance.PlaySe(deathAttackSE);
                enemy.Death();
                canAttack = false;
            }
            else if (enemy.isExhausted == false)
            {
                GameManager.instance.PlaySe(attackSE);
                enemy.Damage(attackPower);
            }
        }
    }

    // AttackPointの表示
    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
}
