using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    int diamonds = 0;

    public TMP_Text diamondsText;

    private void Start()
    {
        SetData();
        SetUI();
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
            diamonds = PlayerPrefs.GetInt("Diamonds");
        else
            diamonds = 0;
    }

    private void SetUI()
    {
        diamondsText.text = "Diamonds: " + diamonds;
    }

    public void StartGame()
    {
        //TODO: Set multipliers

        SceneManager.LoadScene("Game");
    }
}
