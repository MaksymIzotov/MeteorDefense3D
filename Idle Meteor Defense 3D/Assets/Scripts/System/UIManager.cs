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

    public TMP_Text waveText;
    public TMP_Text moneyText;


    public void WaveUpdate(int wave)
    {
        waveText.text = "Wave: " + wave;
    }

    public void UpdateMoney(float money)
    {
        moneyText.text = money.ToString("F0") + "$";
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

    private void PriceUpdate(TMP_Text text, float price)
    {
        text.text = price.ToString("F0") + "$";
    }
}
