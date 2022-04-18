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

        if (health <= 0)
            Die();
    }

    public void Die()
    {
        if (gameObject.tag == "Player")
        {
            //TODO: Death menu, pause game
        }

        //TODO: death effects (Maybe time slowdown)
        Destroy(gameObject);
    }

    public void SetData()
    {
        health = maxHealth;
    }
}
