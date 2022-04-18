using UnityEngine;

public class HealthController : MonoBehaviour
{
    public float maxHealth;

    private float health;

    private void Start()
    {
        SetData();
    }

    public void TakeDamage(float damage)
    {
        health = health - damage;
        Debug.Log(health);

        if (health <= 0)
            Die();
    }

    public void Die()
    {
        //TODO: Death menu, pause game

        //TODO: death effects (Maybe time slowdown)
        Destroy(gameObject);
    }

    public void SetData()
    {
        health = maxHealth;
    }
}
