using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBall : MonoBehaviour
{
    public Transform defaultPos;
    public Transform guardFrontPos;
    public Transform guardRightPos;
    public Transform guardBackPos;
    public Transform guardLeftPos;
    public float scaleValue;
    public float defaustScaleValue;

    void Update()
    {
        // 左クリック＋方向キーで各方向から攻撃
        Mouse(0);
        // 右クリックで防御＋方向キーで各方向へ防御
        Mouse(1);
    }

    void Mouse(int num)
    {
        var x = transform.localScale.x;
        var y = transform.localScale.y;
        
        if (Input.GetMouseButton(num) && Input.GetKey(KeyCode.W))
        {
            if (num == 0) ChangeShape(guardFrontPos, scaleValue, y); 
            if (num == 1) ChangeShape(guardFrontPos, x, scaleValue);   
        }

        if (Input.GetMouseButton(num) && Input.GetKey(KeyCode.D))
        {
            if (num == 0) ChangeShape(guardRightPos, x, scaleValue); 
            if (num == 1) ChangeShape(guardRightPos, scaleValue, y);      
        }

        if (Input.GetMouseButton(num) && Input.GetKey(KeyCode.S))
        {
            if (num == 0) ChangeShape(guardBackPos, scaleValue, y);
            if (num == 1) ChangeShape(guardBackPos, x, scaleValue);          
        }

        if (Input.GetMouseButton(num) && Input.GetKey(KeyCode.A))
        {
            if (num == 0) ChangeShape(guardLeftPos, x, scaleValue);
            if (num == 1) ChangeShape(guardLeftPos, scaleValue, y);          
        }

        if (Input.GetMouseButtonUp(num))
        {
            ChangeShape(defaultPos, defaustScaleValue, defaustScaleValue);            
        }
    }

    // 攻撃、もしくは防御によってWeaponBallの形を変える
    void ChangeShape (Transform pos, float xScaleValue, float yScaleValue)
    {
        transform.position = 
        Vector3.MoveTowards(transform.position, pos.position, 1);
        transform.localScale =  new Vector2(xScaleValue, yScaleValue);
    }
}
