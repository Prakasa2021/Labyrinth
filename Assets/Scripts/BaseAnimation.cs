using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BaseAnimation : ScriptableObject
{
    [SerializeField] public float duration;

    public virtual void Animate(Transform visual){}
}
