using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEditor.SearchService;
using Unity.VisualScripting;

public class WinUI : MonoBehaviour
{
    public void Lanjut(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void CobaLagi(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void Keluar()
    {
        Application.Quit();
    }
}
