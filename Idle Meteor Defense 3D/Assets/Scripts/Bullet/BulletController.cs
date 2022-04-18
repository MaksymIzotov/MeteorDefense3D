using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Transform target;
    [SerializeField] private float speed;

    [HideInInspector] public float damage;

    private Vector3 dir;

    private void Start()
    {
        GetDirection();
    }

    private void Update()
    {
        if (target == null)
            MoveInDirection();
        else
            Move();
    }

    private void MoveInDirection()
    {
        var step = speed * Time.deltaTime;
        transform.position += dir * step;

        if (Vector3.Distance(transform.position, Vector3.zero) > 50)
            Destroy(gameObject);
    }

    private void Move()
    {
        if (Vector3.Distance(transform.position, target.position) < 0.001f) { return; }

        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }

    private void GetDirection()
    {
        dir = target.position - transform.position;
        dir = dir.normalized;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Enemy") { return; }

        collision.gameObject.GetComponent<HealthController>().TakeDamage(damage);
        Destroy(gameObject);
    }
}
