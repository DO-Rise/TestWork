using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameUI : MonoBehaviour
{
    public static GameUI Instance;

    [Header("Menu")]
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _gameUI;
    [SerializeField] private GameObject _winMenu;

    [Header("Game UI")]
    [SerializeField] private TMP_Text _coinsCollectText;
    [SerializeField] private TMP_Text _coinsCollectWinText;

    private int _currentCoins = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _coinsCollectText.text = _currentCoins.ToString();
    }

    public void AddCoin()
    {
        _currentCoins++;
        _coinsCollectText.text = _currentCoins.ToString();
    }

    public void WinWindow()
    {
        _coinsCollectWinText.text = _coinsCollectText.text;

        _gameUI.SetActive(false);
        _winMenu.SetActive(true);
    }

    public void PauseButton(bool active)
    {
        if (active)
        {
            Time.timeScale = 0f;
            _pauseMenu.SetActive(true);
            _gameUI.SetActive(false);
        }
        else
        {
            Time.timeScale = 1f;
            _gameUI.SetActive(true);
            _pauseMenu.SetActive(false);
        }
    }

    public void RestartButton(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
