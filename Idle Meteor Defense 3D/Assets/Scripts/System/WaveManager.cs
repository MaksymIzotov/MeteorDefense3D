using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private float waveTime;
    [SerializeField] private float waveStartDelay;

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        StartCoroutine(WaveStart());
    }

    IEnumerator WaveStart()
    {
        EnemySpawner.Instance.StartWave();
        yield return new WaitForSeconds(waveTime);

        EnemySpawner.Instance.StopWave();
        StartCoroutine(WaveEnd());
    }

    IEnumerator WaveEnd()
    {
        yield return new WaitForSeconds(waveStartDelay);

        //TODO: Increase difficulty

        StartCoroutine(WaveStart());
    }
}
