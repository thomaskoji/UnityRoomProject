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
    public SpriteRenderer spriteRenderer;
    bool canAttack;
    bool canDeathAttack;

    private void Start() 
    {
        canAttack = true;
        canDeathAttack = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update() 
    {
        // サークル範囲内に、レイヤーがEnemyのオブジェクトがいたら取得
        Collider2D[] hitEnemys = 
        Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, enemyLayer);

        if (canAttack == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack(hitEnemys);
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                DeahAttack(hitEnemys);
            }
            
            if (Input.GetKey(KeyCode.E))
            {
                Guard();
            }
            else if (Input.GetKeyUp(KeyCode.E))
            {
                ResetColor();
            }  
        }        
    }

    void Attack(Collider2D[] hitEnemys)
    {
        // 取得したそれぞれのEnemyにダメージを与える
        foreach (Collider2D hitEnemy in hitEnemys)
        {
            var enemy = hitEnemy.GetComponent<Enemy>();              
            if (enemy.isExhausted == false)
            {
                GameManager.instance.PlaySe(attackSE);
                enemy.Damage(attackPower);
            }
        }
    }

    void DeahAttack(Collider2D[] hitEnemys)
    {
        foreach (Collider2D hitEnemy in hitEnemys)
        {
            var enemy = hitEnemy.GetComponent<Enemy>();              
            if (enemy.isExhausted == true)
            {
                GameManager.instance.PlaySe(deathAttackSE);
                enemy.Death();
            }
        }
    }


    void Guard()
    {
        spriteRenderer.color = Color.yellow;
    }

    void ResetColor()
    {
        spriteRenderer.color = Color.blue;
    }

    // AttackPointの表示
    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
}
