using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    public HealthInfo info;

    private float health;
    [HideInInspector] public float maxHealth;

    [SerializeField] private GameObject deathParticles;

    public UnityEvent onLose;

    private void Start()
    {
        SetData();
    }

    private void Update()
    {
        if (gameObject.tag != "Player") { return; }

        if (health < maxHealth)
            health += PlayerMultiplayers.Instance.hpRegen * Time.deltaTime;

        UIManager.Instance.UpdateHealth(health);
    }

    public void TakeDamage(float damage)
    {
        health = health - damage;        

        if (health <= 0)
            Die();
    }

    public void Die()
    {
        if (gameObject.tag == "Player")
        {
            GameplayController.Instance.isPlaying = false;
            onLose.Invoke();
        }
        else
        {
            MoneyManager.Instance.ChangeMoney(-(GetComponent<EnemyController>().info.price * PlayerMultiplayers.Instance.killMoney));
        }

        Instantiate(deathParticles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void SetData()
    {
        if (gameObject.tag == "Player")
            health = info.basicHealth * PlayerMultiplayers.Instance.hpMult;
        else
            health = info.basicHealth * GameDifficultyManager.Instance.enemyHPMult;
    }
}
