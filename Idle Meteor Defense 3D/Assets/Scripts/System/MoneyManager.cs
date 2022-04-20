using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    #region Singleton Init
    public static MoneyManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    [HideInInspector] public float money;

    [SerializeField] private float startingMoney;
    private void Start()
    {
        SetDefaults();
    }

    private void SetDefaults()
    {
        money = startingMoney;

        UIManager.Instance.UpdateMoney(money);
    }

    public void ChangeMoney(float amount)
    {
        money -= amount;

        UIManager.Instance.UpdateMoney(money);
    }
}
