using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    public float maxHealth;

    private float health;

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

        //TODO: death effects
        Destroy(gameObject);
    }

    public void SetData()
    {
        if (gameObject.tag == "Player")
            health = maxHealth * PlayerMultiplayers.Instance.hpMult;
        else
            health = maxHealth * GameDifficultyManager.Instance.enemyHPMult;
    }
}
