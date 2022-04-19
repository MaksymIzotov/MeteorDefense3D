using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    public GameObject damageButton;
    public GameObject speedButton;

    public TMP_Text waveText;

    public void WaveUpdate(int wave)
    {
        waveText.text = "Wave: " + wave;
    }

    public void DamageUpdate()
    {
        float damage = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShoot>().info.damage;
        damageButton.transform.GetChild(0).GetComponent<TMP_Text>().text = "Damage: " + (damage * PlayerMultiplayers.Instance.damageMult).ToString("F1");

        //TODO: Price Update.
    }

    public void SpeedUpdate()
    {
        float speed = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShoot>().info.attackSpeed;
        speedButton.transform.GetChild(0).GetComponent<TMP_Text>().text = "Speed: " + (speed * PlayerMultiplayers.Instance.attackSpd).ToString("F2");

        //TODO: Price Update.
    }
}
