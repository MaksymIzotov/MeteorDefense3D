using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyController : MonoBehaviour
{
    public EnemyInfo info;

    private void Start()
    {
        if (info == null)
            Debug.LogError("NO INFO SCRIPT ON ENEMY");
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Vector3.Distance(transform.position, Vector3.zero) < 0.001f) { return; }

        var step = info.speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, step);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player") { return; }
        //DO DAMAGE

        Destroy(gameObject);
    }
}
