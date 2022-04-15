using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Timer Instance;
    private void Awake()
    {
        Instance = this;
    }

    private bool isRepeat;
    private float delayMin;
    private float delayMax;

    private Action onTick;
    private Action onTimerEnd;

    public void StartTimer(float _delayMin, float _delayMax, bool _isRepeat, Action _onTick)
    {
        UpdateDelegates();

        delayMin = _delayMin;
        delayMax = _delayMax;
        isRepeat = _isRepeat;

        onTick = _onTick;

        StartCoroutine(GameTimer());
    }

    public void StartTimer(float _delayMin, float _delayMax, bool _isRepeat, Action _onTick, Action _onTimerEnd)
    {
        UpdateDelegates();

        delayMin = _delayMin;
        delayMax = _delayMax;
        isRepeat = _isRepeat;

        onTick = _onTick;
        onTimerEnd = _onTimerEnd;

        StartCoroutine(GameTimer());
    }

    IEnumerator GameTimer()
    {
        while (isRepeat)
        {
            onTick.Invoke();
            
            yield return new WaitForSeconds(UnityEngine.Random.Range(delayMin,delayMax));

            onTimerEnd?.Invoke();
        }
    }

    private void UpdateDelegates()
    {
        onTick = null;
        onTimerEnd = null;
    }
}
