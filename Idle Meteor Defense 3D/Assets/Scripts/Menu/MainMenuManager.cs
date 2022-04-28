using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    #region Singleton Init
    public static MainMenuManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    [HideInInspector] public float diamonds = 0;

    private void Start()
    {
        SetData();

        MainMenuUIManager.Instance.UpdateMoney(diamonds);

        if(PlayerPrefs.HasKey("TopWave"))
            MainMenuUIManager.Instance.UpdateTopWave(PlayerPrefs.GetInt("TopWave"));
        else
            MainMenuUIManager.Instance.UpdateTopWave(0);
    }

    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                MenuManager.Instance.OpenMenu("main");
            }
        }
    }

    private void SetData()
    {
        if (PlayerPrefs.HasKey("Diamonds"))
            diamonds = PlayerPrefs.GetFloat("Diamonds");
        else
            diamonds = 0;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ChangeMoney(float amount)
    {
        diamonds -= amount;
        PlayerPrefs.SetFloat("Diamonds", diamonds);

        MainMenuUIManager.Instance.UpdateMoney(diamonds);
    }
}
