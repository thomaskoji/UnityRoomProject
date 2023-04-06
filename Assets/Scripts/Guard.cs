using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Guard : MonoBehaviour
{
    

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            GuardDirection(0, 1f, 1.5f, 0.3f);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            GuardDirection(-1f, 0, 0.3f, 1.5f);
        } 
        if (Input.GetKeyDown(KeyCode.D))
        {
            GuardDirection(1f, 0, 0.3f, 1.5f);
        }  
    }

    void GuardDirection(float x, float y, float scaleX, float scaleY)
    {
        var sequence = DOTween.Sequence();
            
        sequence.Append(this.transform.DOLocalMove(new Vector2(x, y), 0.05f));
        sequence.Join(this.transform.DOScale(new Vector3(scaleX, scaleY, 1f), 0.1f));
        sequence.Append(this.transform.DOLocalMove(new Vector2(0, 0), 0.1f));
        sequence.Join(this.transform.DOScale(new Vector3(0.25f, 0.25f, 1f), 0.1f));
    }
}
