using UnityEngine;

public class GameDifficultyManager : MonoBehaviour
{
    #region Singleton Init
    public static GameDifficultyManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    #endregion

    public float enemyHPMult;
    public float enemyDamageMult;

    public float waveTimeMult;

    public void IncreaseDifficulty()
    {
        enemyDamageMult += enemyDamageMult * 0.1f;
        enemyHPMult += enemyHPMult * 0.2f;

        waveTimeMult += waveTimeMult * 0.05f;
    }
}
