using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Attack : MonoBehaviour
{
    public float scaleX;
    public float scaleY;
    public GameObject[] attackKind;

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            AttackLeft(1);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            AttackRight(0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AttackFront(2);
        }     
    }

    void AttackRight(int kind)
    {
        Sequence sequence = DOTween.Sequence();

        var atKind = attackKind[kind].GetComponent<Path>();
        Vector3 p1 = atKind.points[0].transform.localPosition ;
        Vector3 p2 = atKind.points[1].transform.localPosition ;

        Vector3[] waypoints = new[] 
        {
            p1, p2, p1, new Vector3(0, 0, 0)
	    };
        
        sequence.Append(transform.DOLocalMove(new Vector2(-1f, 1), 0.2f));
        sequence.Join(transform.DOScale(new Vector2(scaleX, scaleY), 0.2f));
        sequence.Append(transform
        .DOLocalPath(waypoints, 0.6f, PathType.CatmullRom, gizmoColor:Color.red)
		.SetEase(Ease.InOutCubic));
        sequence.Append(transform.DOScale(new Vector2(0.25f, 0.25f), 0.1f)); 
    }

    void AttackLeft(int kind)
    {
        Sequence sequence = DOTween.Sequence();

        var atKind = attackKind[kind].GetComponent<Path>();
        Vector3 p1 = atKind.points[0].transform.localPosition ;
        Vector3 p2 = atKind.points[1].transform.localPosition ;

        Vector3[] waypoints = new[] 
        {
            p1, p2, p1, new Vector3(0, 0, 0)
	    };
        
        sequence.Append(transform.DOLocalMove(new Vector2(1f, 1), 0.2f));
        sequence.Join(transform.DOScale(new Vector2(scaleX, scaleY), 0.2f));
        sequence.Append(transform
        .DOLocalPath(waypoints, 0.6f, PathType.CatmullRom, gizmoColor:Color.red)
		.SetEase(Ease.InOutCubic));
        sequence.Append(transform.DOScale(new Vector2(0.25f, 0.25f), 0.1f)); 
    }

    void AttackFront(int kind)
    {
        Sequence sequence = DOTween.Sequence();

        var atKind = attackKind[kind].GetComponent<Path>();
        Vector3 p1 = atKind.points[0].transform.localPosition ;

        Vector3[] waypoints = new[] 
        {
            p1, new Vector3(0, 0, 0)
	    };
        
        sequence.Append(transform.DOLocalMove(new Vector2(0, 1.5f), 0.2f));
        sequence.Join(transform.DOScale(new Vector2(scaleX, scaleY), 0.2f));
        sequence.Append(transform
        .DOLocalPath(waypoints, 0.4f, PathType.CatmullRom, gizmoColor:Color.red)
		.SetEase(Ease.InOutCubic));
        sequence.Append(transform.DOScale(new Vector2(0.25f, 0.25f), 0.1f)); 
    }
}
