using UnityEngine;
using TMPro;

public class MainMenuUIManager : MonoBehaviour
{
    #region Singleton Init
    public static MainMenuUIManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public PlayerInfo info;

    public GameObject damageButton;
    public GameObject speedButton;
    public GameObject hpMultButton;
    public GameObject hpRegenButton;
    public GameObject waveMoneyButton;
    public GameObject killMoneyButton;
    public GameObject diamondMultButton;

    public TMP_Text diamondsText;
    public TMP_Text topWaveText;


    public void UpdateTopWave(int wave)
    {
        topWaveText.text = "Highest wave: " + wave;
    }

    public void UpdateMoney(float money)
    {
        diamondsText.text = "Diamonds: "+ money.ToString("F0");
    }

    public void DamageUpdate()
    {
        float damage = info.damage;
        damageButton.transform.GetChild(0).GetComponent<TMP_Text>().text = "Damage: " + (damage * PreGameUpgrades.Instance.damageMult).ToString("F1");

        PriceUpdate(damageButton.transform.GetChild(1).GetComponent<TMP_Text>(), PreGameUpgrades.Instance.p_damageMult);
    }

    public void SpeedUpdate()
    {
        float speed = info.attackSpeed;
        speedButton.transform.GetChild(0).GetComponent<TMP_Text>().text = "Speed: " + (speed * PreGameUpgrades.Instance.attackSpd).ToString("F2");

        PriceUpdate(speedButton.transform.GetChild(1).GetComponent<TMP_Text>(), PreGameUpgrades.Instance.p_attackSpd);
    }

    public void HPMultUpdate()
    {
        float hp = PreGameUpgrades.Instance.hpMult;
        hpMultButton.transform.GetChild(0).GetComponent<TMP_Text>().text = "HP X: " + (hp).ToString("F2");

        PriceUpdate(hpMultButton.transform.GetChild(1).GetComponent<TMP_Text>(), PreGameUpgrades.Instance.p_hpMult);
    }

    public void HPRegenUpdate()
    {
        float regen = PreGameUpgrades.Instance.hpRegen;
        hpRegenButton.transform.GetChild(0).GetComponent<TMP_Text>().text = "HP Regen: " + (regen).ToString("F2");

        PriceUpdate(hpRegenButton.transform.GetChild(1).GetComponent<TMP_Text>(), PreGameUpgrades.Instance.p_hpRegen);
    }

    public void WaveMoneyUpdate()
    {
        float waveMoney = PreGameUpgrades.Instance.waveMoney;
        waveMoneyButton.transform.GetChild(0).GetComponent<TMP_Text>().text = "$/Wave: " + (waveMoney).ToString("F0");

        PriceUpdate(waveMoneyButton.transform.GetChild(1).GetComponent<TMP_Text>(), PreGameUpgrades.Instance.p_waveMoney);
    }

    public void KillMoneyUpdate()
    {
        float killMoney = PreGameUpgrades.Instance.killMoney;
        killMoneyButton.transform.GetChild(0).GetComponent<TMP_Text>().text = "$/Kill: " + (killMoney).ToString("F2");

        PriceUpdate(killMoneyButton.transform.GetChild(1).GetComponent<TMP_Text>(), PreGameUpgrades.Instance.p_killMoney);
    }

    public void DiamondMultUpdate()
    {
        float diamondsMult = PreGameUpgrades.Instance.diamondsMult;
        diamondMultButton.transform.GetChild(0).GetComponent<TMP_Text>().text = "Diamonds X: " + (diamondsMult).ToString("F2");

        PriceUpdate(diamondMultButton.transform.GetChild(1).GetComponent<TMP_Text>(), PreGameUpgrades.Instance.p_diamondsMult);
    }

    private void PriceUpdate(TMP_Text text, float price)
    {
        text.text = price.ToString("F0") + " diamonds";
    }
}
