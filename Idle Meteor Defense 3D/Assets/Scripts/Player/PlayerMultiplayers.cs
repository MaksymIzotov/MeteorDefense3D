using UnityEngine;

public class PlayerMultiplayers : MonoBehaviour
{
    public static PlayerMultiplayers Instance;
    private void Awake()
    {
        Instance = this;
    }

    [HideInInspector] public float damageMult;
    [HideInInspector] public float attackSpd;
    [HideInInspector] public float hpMult;
    [HideInInspector] public float hpRegen;

    private void Start()
    {
        SetDefaults();
    }

    private void SetDefaults()
    {
        damageMult = 1;
        attackSpd = 1;
        hpMult = 1;
        hpRegen = 0.1f;
    }

    public void DamageUpgrade() => damageMult += damageMult * 0.2f;
    public void AttackSpeedUpgrade() => attackSpd += attackSpd * 0.05f;
    public void HpMultUpgrade() => hpMult += hpMult * 0.1f;
    public void HpRegenUpgrade() => hpRegen += hpRegen * 0.2f;
}
