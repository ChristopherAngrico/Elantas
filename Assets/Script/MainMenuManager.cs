using UnityEngine.SceneManagement;
using UnityEngine;
using Unity.VisualScripting;

public class MainMenuManager : MonoBehaviour
{
    public void Mulai()
    {
        SceneManager.LoadScene(1);
    }

    public void Keluar()
    {
        Application.Quit();
    }
}
