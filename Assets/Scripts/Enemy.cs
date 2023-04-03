using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 100;

    SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    public void Damage(int damage)
    {
        hp -= damage;
        Debug.Log ("敵のHP" + hp);
    }
}
