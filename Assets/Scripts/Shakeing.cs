using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Shakeing : MonoBehaviour
{
    public float time;
    public float strength;
    public int vibrato;
    public int randomness;
    public bool snap;
    public bool fadeOut;

    void Start() 
    {
        this.transform.DOShakePosition
        (time, strength, vibrato, randomness, snap, fadeOut).SetLoops(-1);
    }

}
