using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class CountDown : MonoBehaviour
{
    [SerializeField] private int duration;

    public UnityEvent onCountFinished = new UnityEvent();
    public UnityEvent<int> onCount = new UnityEvent<int>();

    bool isCounting;
    Sequence seq;

    // Coroutine countCoroutine;
    
    // public void StartCount()
    // {
    //     if (isCounting == true)
    //     {
    //         return;
    //     }
    //     else
    //     {
    //         isCounting = true;
    //     }
        
    //     seq = DOTween.Sequence();
    //     onCount.Invoke(duration);
    //     for (int i = duration - 1; i >= 0; i--)
    //     {
    //         var count = i;
    //         seq.Append(transform.DOMove(this.transform.position, 1).SetUpdate(true).OnComplete(() => onCount.Invoke(count)));
    //     }

    //     seq.Append(transform.DOMove(this.transform.position, 1)).SetUpdate(true).OnComplete(() => { isCounting = false; onCountFinished.Invoke(); });
    // }

    public void StartCount()
    {
        if(isCounting == true)
            // StopCoroutine(countCoroutine);
            StopAllCoroutines();
        
        // countCoroutine = 
        StartCoroutine(CountCoroutine());
    }

    private IEnumerator CountCoroutine()
    {
        isCounting = true;
        for (int i = duration; i >= 0; i--)
        {
            onCount.Invoke(i);
            yield return new WaitForSecondsRealtime(1);
        }

        isCounting = false;
        onCountFinished.Invoke();
    }
}
