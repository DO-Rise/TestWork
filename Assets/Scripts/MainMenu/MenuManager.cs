using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _menus;

    public void OpenMenu(GameObject openMenu)
    {
        openMenu.SetActive(true);

        foreach (GameObject menu in _menus)
        {
            if (menu != openMenu)
                menu.SetActive(false);
        }
    }

    public void GameSelection(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
