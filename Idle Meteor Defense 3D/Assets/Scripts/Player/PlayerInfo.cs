using UnityEngine;

[CreateAssetMenu(fileName = "Info", menuName = "ScriptableObjects/PlayerInfo", order = 2)]
public class PlayerInfo : ScriptableObject
{
    public float attackSpeed;
    public float damage;

    public float range;
}
