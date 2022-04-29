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

    [HideInInspector] public float diamondsMult;


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

    #region LoadData
    private void SetDefaults()
    {
        if (PlayerPrefs.HasKey("damageMult"))
            damageMult = PlayerPrefs.GetFloat("damageMult");
        else
            damageMult = 1;

        if (PlayerPrefs.HasKey("attackSpd"))
            attackSpd = PlayerPrefs.GetFloat("attackSpd");
        else
            attackSpd = 1;

        if (PlayerPrefs.HasKey("hpMult"))
            hpMult = PlayerPrefs.GetFloat("hpMult");
        else
            hpMult = 1;

        if (PlayerPrefs.HasKey("hpRegen"))
            hpRegen = PlayerPrefs.GetFloat("hpRegen");
        else
            hpRegen = 1;

        if (PlayerPrefs.HasKey("waveMoney"))
            waveMoney = PlayerPrefs.GetFloat("waveMoney");
        else
            waveMoney = 1;

        if (PlayerPrefs.HasKey("killMoney"))
            killMoney = PlayerPrefs.GetFloat("killMoney");
        else
            killMoney = 1;

        if (PlayerPrefs.HasKey("diamondsMult"))
            diamondsMult = PlayerPrefs.GetFloat("diamondsMult");
        else
            diamondsMult = 1;


        p_damageMult = 5;
        p_attackSpd = 10;
        p_hpMult = 10;
        p_hpRegen = 5;
        p_waveMoney = 5;
        p_killMoney = 10;

        playerHealth.maxHealth *= hpMult;
    }
    #endregion

    public void DamageUpgrade()
    {
        if (MoneyManager.Instance.money < p_damageMult) { return; }

        MoneyManager.Instance.ChangeMoney(p_damageMult);

        damageMult += damageMult * 0.1f;
        p_damageMult += 5 + p_damageMult * 0.02f;
    }

    public void AttackSpeedUpgrade()
    {
        if (MoneyManager.Instance.money < p_attackSpd) { return; }

        MoneyManager.Instance.ChangeMoney(p_attackSpd);

        attackSpd += attackSpd * 0.08f;
        p_attackSpd += 5 + p_attackSpd * 0.05f;
    }

    public void HpMultUpgrade()
    {
        if (MoneyManager.Instance.money < p_hpMult) { return; }

        MoneyManager.Instance.ChangeMoney(p_hpMult);

        hpMult += hpMult * 0.1f;
        p_hpMult += 5+ p_hpMult * 0.05f;

        playerHealth.maxHealth = hpMult * playerHealth.info.basicHealth;
    }

    public void HpRegenUpgrade()
    {
        if (MoneyManager.Instance.money < p_hpRegen) { return; }

        MoneyManager.Instance.ChangeMoney(p_hpRegen);

        hpRegen += hpRegen * 0.07f;
        p_hpRegen += 5 + p_hpRegen * 0.05f;
    }

    public void WaveMoneyUpgrade()
    {
        if (MoneyManager.Instance.money < p_waveMoney) { return; }

        MoneyManager.Instance.ChangeMoney(p_waveMoney);

        waveMoney += 5 + waveMoney * 0.1f;
        p_waveMoney += 5 + p_waveMoney * 0.2f;
    }

    public void KillMoneyUpgrade()
    {
        if (MoneyManager.Instance.money < p_killMoney) { return; }

        MoneyManager.Instance.ChangeMoney(p_killMoney);

        killMoney += killMoney * 0.1f;
        p_killMoney += 5 + p_killMoney * 0.1f;
    }
}
