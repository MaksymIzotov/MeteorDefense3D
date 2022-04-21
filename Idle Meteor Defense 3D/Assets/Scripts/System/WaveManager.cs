using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    private enum STATE { START = 0, FINISH = 1 }

    [SerializeField] private float waveTime;
    [SerializeField] private float waveStartDelay;

    private STATE waveState;
    private int waveCounter;

    private float moneyPerWave = 1;

    [SerializeField] private Image timerBar; 
    private float timer = 0;
    private float fillAmount = 0;

    private void Start()
    {
        StartGame();
    }

    private void Update()
    {
        if(waveState == STATE.START)
        {
            timer -= Time.deltaTime;
            fillAmount = timer / waveTime;
        }
        else
        {
            timer -= Time.deltaTime;
            fillAmount = 1 - (timer / waveStartDelay);
        }

        timerBar.fillAmount = fillAmount;
    }

    public void StartGame()
    {
        waveCounter = 1;
        UIManager.Instance.WaveUpdate(waveCounter);
        StartCoroutine(WaveStart());
    }

    IEnumerator WaveStart()
    {
        waveState = STATE.START;
        timer = waveTime;

        EnemySpawner.Instance.StartWave();
        yield return new WaitForSeconds(waveTime);

        EnemySpawner.Instance.StopWave();
        StartCoroutine(WaveEnd());
    }

    IEnumerator WaveEnd()
    {
        waveState = STATE.FINISH;
        timer = waveStartDelay;

        yield return new WaitForSeconds(waveStartDelay);

        GameDifficultyManager.Instance.IncreaseDifficulty();

        MoneyManager.Instance.ChangeMoney(-(moneyPerWave * PlayerMultiplayers.Instance.waveMoney));

        waveCounter++;
        UIManager.Instance.WaveUpdate(waveCounter);

        StartCoroutine(WaveStart());
    }

    public void UpdateLoseWave()
    {
        UIManager.Instance.LoseWaveUpdate(waveCounter);
    }
}
