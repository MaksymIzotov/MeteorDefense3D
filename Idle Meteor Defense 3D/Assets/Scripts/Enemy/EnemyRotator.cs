using UnityEngine;

public class EnemyRotator : MonoBehaviour
{
    [SerializeField] private float speed;

    private float rotX;
    private float rotY;
    private float rotZ;

    private Vector3 rot;

    private void Start()
    {
        RotationSetup();
    }

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        rot = new Vector3(rotX, rotY, rotZ);
        transform.Rotate(rot * speed * Time.deltaTime);
    }

    private void RotationSetup()
    {
        rotX = Random.Range(5, 50);
        rotY = Random.Range(5, 50);
        rotZ = Random.Range(5, 50);
    }
}