using UnityEngine;

[CreateAssetMenu(fileName = "Info", menuName = "ScriptableObjects/EnemyInfo", order = 1)]
public class EnemyInfo : ScriptableObject
{
    public float speed;
    public float damage;

    public float price;
}
