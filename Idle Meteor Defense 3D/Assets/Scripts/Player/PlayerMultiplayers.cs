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
    [HideInInspector] public float waveMoney;
    [HideInInspector] public float killMoney;

    [HideInInspector] public float p_damageMult;
    [HideInInspector] public float p_attackSpd;
    [HideInInspector] public float p_hpMult;
    [HideInInspector] public float p_hpRegen;
    [HideInInspector] public float p_waveMoney;
    [HideInInspector] public float p_killMoney;

    private HealthController playerHealth;


    private void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthController>();

        SetDefaults();

        playerHealth.SetData(); //Set health data again after updating multipliers

        UIManager.Instance.DamageUpdate();
        UIManager.Instance.SpeedUpdate();
        UIManager.Instance.HPMultUpdate();
        UIManager.Instance.HPRegenUpdate();
        UIManager.Instance.WaveMoneyUpdate();
        UIManager.Instance.KillMoneyUpdate();
    }

    private void SetDefaults()
    {
        damageMult = 1;
        attackSpd = 1f;
        hpMult = 1;
        hpRegen = 1f;
        waveMoney = 1;
        killMoney = 1;


        p_damageMult = 5;
        p_attackSpd = 10;
        p_hpMult = 10;
        p_hpRegen = 5;
        p_waveMoney = 5;
        p_killMoney = 10;
    }

    public void DamageUpgrade()
    {
        if (MoneyManager.Instance.money < p_damageMult) { return; }

        MoneyManager.Instance.ChangeMoney(p_damageMult);

        damageMult += damageMult * 0.2f;
        p_damageMult += p_damageMult * 0.3f;
    }

    public void AttackSpeedUpgrade()
    {
        if (MoneyManager.Instance.money < p_attackSpd) { return; }

        MoneyManager.Instance.ChangeMoney(p_attackSpd);

        attackSpd += attackSpd * 0.05f;
        p_attackSpd += p_attackSpd * 0.3f;
    }

    public void HpMultUpgrade()
    {
        if (MoneyManager.Instance.money < p_hpMult) { return; }

        MoneyManager.Instance.ChangeMoney(p_hpMult);

        hpMult += hpMult * 0.1f;
        p_hpMult += p_hpMult * 0.3f;

        playerHealth.maxHealth *= hpMult;
    }

    public void HpRegenUpgrade()
    {
        if (MoneyManager.Instance.money < p_hpRegen) { return; }

        MoneyManager.Instance.ChangeMoney(p_hpRegen);

        hpRegen += hpRegen * 0.1f;
        p_hpRegen += p_hpRegen * 0.3f;
    }

    public void WaveMoneyUpgrade()
    {
        if (MoneyManager.Instance.money < p_waveMoney) { return; }

        MoneyManager.Instance.ChangeMoney(p_waveMoney);

        waveMoney += waveMoney * 1.2f;
        p_waveMoney += p_waveMoney * 1.2f;
    }

    public void KillMoneyUpgrade()
    {
        if (MoneyManager.Instance.money < p_killMoney) { return; }

        MoneyManager.Instance.ChangeMoney(p_killMoney);

        killMoney += killMoney * 0.4f;
        p_killMoney += p_killMoney * 0.8f;
    }
}
