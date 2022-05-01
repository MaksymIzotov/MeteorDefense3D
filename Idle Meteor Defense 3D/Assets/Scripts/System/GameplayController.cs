using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour
{
    #region Singleton Init
    public static GameplayController Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public bool isPlaying = true;

    private void Start()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (isPlaying) { return; }

        Time.timeScale = Mathf.Lerp(Time.timeScale, 0, 1f * Time.deltaTime);

        if (Time.timeScale <= 0.2f)
            Time.timeScale = 0;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
