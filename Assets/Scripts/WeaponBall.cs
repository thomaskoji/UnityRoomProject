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
        var x = transform.localScale.x;
        var y = transform.localScale.y;
        
        if (Input.GetMouseButton(1) && Input.GetKey(KeyCode.W))
        {
            Guard(guardFrontPos, x, scaleValue);
        }

        if (Input.GetMouseButton(1) && Input.GetKey(KeyCode.D))
        {
            Guard(guardRightPos, scaleValue, y);      
        }

        if (Input.GetMouseButton(1) && Input.GetKey(KeyCode.S))
        {
            Guard(guardBackPos, x, scaleValue);          
        }

        if (Input.GetMouseButton(1) && Input.GetKey(KeyCode.A))
        {
            Guard(guardLeftPos, scaleValue, y);          
        }

        if (Input.GetMouseButtonUp(1))
        {
            Guard(defaultPos, defaustScaleValue, defaustScaleValue);            
        }
    }

    void Guard (Transform pos, float xScaleValue, float yScaleValue)
    {
        transform.position = 
        Vector3.MoveTowards(transform.position, pos.position, 1);
        transform.localScale =  new Vector2(xScaleValue, yScaleValue);
    }
}
