using UnityEngine;

public class PreGameUpgrades : MonoBehaviour
{
    #region Singleton Init
    public static PreGameUpgrades Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    [HideInInspector] public float damageMult;
    [HideInInspector] public float attackSpd;
    [HideInInspector] public float hpMult;
    [HideInInspector] public float hpRegen;
    [HideInInspector] public float waveMoney;
    [HideInInspector] public float killMoney;
    [HideInInspector] public float diamondsMult;

    [HideInInspector] public float p_damageMult;
    [HideInInspector] public float p_attackSpd;
    [HideInInspector] public float p_hpMult;
    [HideInInspector] public float p_hpRegen;
    [HideInInspector] public float p_waveMoney;
    [HideInInspector] public float p_killMoney;
    [HideInInspector] public float p_diamondsMult;

    private void Start()
    {
        SetDefaults();

        MainMenuUIManager.Instance.DamageUpdate();
        MainMenuUIManager.Instance.SpeedUpdate();
        MainMenuUIManager.Instance.HPMultUpdate();
        MainMenuUIManager.Instance.HPRegenUpdate();
        MainMenuUIManager.Instance.WaveMoneyUpdate();
        MainMenuUIManager.Instance.KillMoneyUpdate();
        MainMenuUIManager.Instance.DiamondMultUpdate();
    }

    #region LoadData
    private void SetDefaults()
    {
        //UPGRADES

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

        //PRICES

        if (PlayerPrefs.HasKey("p_damageMult"))
            p_damageMult = PlayerPrefs.GetFloat("p_damageMult");
        else
            p_damageMult = 10;

        if (PlayerPrefs.HasKey("p_attackSpd"))
            p_attackSpd = PlayerPrefs.GetFloat("p_attackSpd");
        else
            p_attackSpd = 10;

        if (PlayerPrefs.HasKey("p_hpMult"))
            p_hpMult = PlayerPrefs.GetFloat("p_hpMult");
        else
            p_hpMult = 10;

        if (PlayerPrefs.HasKey("p_hpRegen"))
            p_hpRegen = PlayerPrefs.GetFloat("p_hpRegen");
        else
            p_hpRegen = 10;

        if (PlayerPrefs.HasKey("p_waveMoney"))
            p_waveMoney = PlayerPrefs.GetFloat("p_waveMoney");
        else
            p_waveMoney = 10;

        if (PlayerPrefs.HasKey("p_killMoney"))
            p_killMoney = PlayerPrefs.GetFloat("p_killMoney");
        else
            p_killMoney = 10;

        if (PlayerPrefs.HasKey("p_diamondsMult"))
            p_diamondsMult = PlayerPrefs.GetFloat("p_diamondsMult");
        else
            p_diamondsMult = 10;
    }
    #endregion

    public void DamageUpgrade()
    {
        if (MainMenuManager.Instance.diamonds < p_damageMult) { return; }

        MainMenuManager.Instance.ChangeMoney(p_damageMult);

        damageMult += damageMult * 0.1f;
        p_damageMult += p_damageMult * 0.5f;

        PlayerPrefs.SetFloat("damageMult", damageMult);
        PlayerPrefs.SetFloat("p_damageMult", p_damageMult);
    }

    public void AttackSpeedUpgrade()
    {
        if (MainMenuManager.Instance.diamonds < p_attackSpd) { return; }

        MainMenuManager.Instance.ChangeMoney(p_attackSpd);

        attackSpd += attackSpd * 0.06f;
        p_attackSpd += p_attackSpd * 0.5f;

        PlayerPrefs.SetFloat("attackSpd", attackSpd);
        PlayerPrefs.SetFloat("p_attackSpd", p_attackSpd);
    }

    public void HpMultUpgrade()
    {
        if (MainMenuManager.Instance.diamonds < p_hpMult) { return; }

        MainMenuManager.Instance.ChangeMoney(p_hpMult);

        hpMult += hpMult * 0.1f;
        p_hpMult += p_hpMult * 0.5f;

        PlayerPrefs.SetFloat("hpMult", hpMult);
        PlayerPrefs.SetFloat("p_hpMult", p_hpMult);
    }

    public void HpRegenUpgrade()
    {
        if (MainMenuManager.Instance.diamonds < p_hpRegen) { return; }

        MainMenuManager.Instance.ChangeMoney(p_hpRegen);

        hpRegen += hpRegen * 0.07f;
        p_hpRegen += p_hpRegen * 0.5f;
    }

    public void WaveMoneyUpgrade()
    {
        if (MainMenuManager.Instance.diamonds < p_waveMoney) { return; }

        MainMenuManager.Instance.ChangeMoney(p_waveMoney);

        waveMoney += 5 + waveMoney * 0.1f;
        p_waveMoney += p_waveMoney * 0.5f;

        PlayerPrefs.SetFloat("waveMoney", waveMoney);
        PlayerPrefs.SetFloat("p_waveMoney", p_waveMoney);
    }

    public void KillMoneyUpgrade()
    {
        if (MainMenuManager.Instance.diamonds < p_killMoney) { return; }

        MainMenuManager.Instance.ChangeMoney(p_killMoney);

        killMoney += killMoney * 0.1f;
        p_killMoney += p_killMoney * 0.5f;

        PlayerPrefs.SetFloat("killMoney", killMoney);
        PlayerPrefs.SetFloat("p_killMoney", p_killMoney);
    }

    public void DiamondsMultUpgrade()
    {
        if (MainMenuManager.Instance.diamonds < p_diamondsMult) { return; }

        MainMenuManager.Instance.ChangeMoney(p_diamondsMult);

        diamondsMult += diamondsMult * 0.1f;
        p_diamondsMult += p_diamondsMult * 0.9f;

        PlayerPrefs.SetFloat("diamondsMult", diamondsMult);
        PlayerPrefs.SetFloat("p_diamondsMult", p_diamondsMult);
    }
}

