using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    #region Singleton Init
    public static UIManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public GameObject damageButton;
    public GameObject speedButton;
    public GameObject hpMultButton;
    public GameObject hpRegenButton;
    public GameObject waveMoneyButton;
    public GameObject killMoneyButton;

    public TMP_Text waveText;
    public TMP_Text moneyText;
    public TMP_Text healthText;
    public TMP_Text loseWaveText;
    public TMP_Text loseDiamondsText;


    public void LoseWaveUpdate(int wave)
    {
        loseWaveText.text = "Wave reached: " + wave;
    }

    public void LoseDiamondsTextUpdate(int amount)
    {
        loseDiamondsText.text = "Diamonds: " + amount;
    }

    public void WaveUpdate(int wave)
    {
        waveText.text = "Wave: " + wave;
    }

    public void UpdateMoney(float money)
    {
        moneyText.text = money.ToString("F0") + "$";
    }

    public void UpdateHealth(float health)
    {
        healthText.text = "HP: " + health.ToString("F0");
    }

    public void DamageUpdate()
    {
        float damage = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShoot>().info.damage;
        damageButton.transform.GetChild(0).GetComponent<TMP_Text>().text = "Damage: " + (damage * PlayerMultiplayers.Instance.damageMult).ToString("F1");

        PriceUpdate(damageButton.transform.GetChild(1).GetComponent<TMP_Text>(), PlayerMultiplayers.Instance.p_damageMult); //Change price
    }

    public void SpeedUpdate()
    {
        float speed = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShoot>().info.attackSpeed;
        speedButton.transform.GetChild(0).GetComponent<TMP_Text>().text = "Speed: " + (speed * PlayerMultiplayers.Instance.attackSpd).ToString("F2");

        PriceUpdate(speedButton.transform.GetChild(1).GetComponent<TMP_Text>(), PlayerMultiplayers.Instance.p_attackSpd);
    }

    public void HPMultUpdate()
    {
        float hp = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthController>().maxHealth;
        hpMultButton.transform.GetChild(0).GetComponent<TMP_Text>().text = "Max HP: " + (hp).ToString("F2");

        PriceUpdate(hpMultButton.transform.GetChild(1).GetComponent<TMP_Text>(), PlayerMultiplayers.Instance.p_hpMult);
    }

    public void HPRegenUpdate()
    {
        float regen = PlayerMultiplayers.Instance.hpRegen;
        hpRegenButton.transform.GetChild(0).GetComponent<TMP_Text>().text = "HP Regen: " + (regen).ToString("F2");

        PriceUpdate(hpRegenButton.transform.GetChild(1).GetComponent<TMP_Text>(), PlayerMultiplayers.Instance.p_hpRegen);
    }

    public void WaveMoneyUpdate()
    {
        float waveMoney = PlayerMultiplayers.Instance.waveMoney;
        waveMoneyButton.transform.GetChild(0).GetComponent<TMP_Text>().text = "$/Wave: " + (waveMoney).ToString("F0");

        PriceUpdate(waveMoneyButton.transform.GetChild(1).GetComponent<TMP_Text>(), PlayerMultiplayers.Instance.p_waveMoney);
    }

    public void KillMoneyUpdate()
    {
        float killMoney = PlayerMultiplayers.Instance.killMoney;
        killMoneyButton.transform.GetChild(0).GetComponent<TMP_Text>().text = "$/Kill: " + (killMoney).ToString("F2");

        PriceUpdate(killMoneyButton.transform.GetChild(1).GetComponent<TMP_Text>(), PlayerMultiplayers.Instance.p_killMoney);
    }

    private void PriceUpdate(TMP_Text text, float price)
    {
        text.text = price.ToString("F0") + "$";
    }
}
