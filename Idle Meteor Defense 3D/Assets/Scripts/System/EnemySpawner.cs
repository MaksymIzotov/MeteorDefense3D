using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;
    private void Awake()
    {
        Instance = this;
    }

    [SerializeField] private GameObject[] enemies;

    [SerializeField] private float delayMin;
    [SerializeField] private float delayMax;

    [SerializeField] private float radius;

    public void StartWave()
    {
        Timer.Instance.StartTimer(delayMin / GameDifficultyManager.Instance.waveTimeMult, delayMax / GameDifficultyManager.Instance.waveTimeMult, true, Spawn);
    }

    public void StopWave()
    {
        Timer.Instance.StopAllCoroutines();
    }

    private void Spawn()
    {
        GameObject enemy = Instantiate(enemies[0], GetRandomPosition(), Quaternion.identity);
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 pos;

        float x = Random.Range(-radius, radius);
        float y = Random.Range(-radius, radius);
        float z = Random.Range(-radius, radius);

        pos = new Vector3(x, y, z);

        while (Vector3.Distance(pos, Vector3.zero) < radius)
            pos += pos;

        return pos;
    }
}
