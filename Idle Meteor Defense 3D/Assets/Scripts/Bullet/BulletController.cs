using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Transform target;
    [SerializeField] private float speed;

    [HideInInspector] public float damage;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Vector3.Distance(transform.position, target.position) < 0.001f) { return; }

        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Enemy") { return; }

        collision.gameObject.GetComponent<HealthController>().TakeDamage(damage);
        Destroy(gameObject);
    }
}
