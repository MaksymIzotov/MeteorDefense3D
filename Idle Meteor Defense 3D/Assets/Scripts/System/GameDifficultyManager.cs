using UnityEngine;

public class GameDifficultyManager : MonoBehaviour
{
    public static GameDifficultyManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    public float enemyHPMult;
    public float enemyDamageMult;

    public void IncreaseDifficulty()
    {
        enemyDamageMult += enemyDamageMult * 0.2f;
        enemyHPMult += enemyHPMult * 0.2f;
    }
}
