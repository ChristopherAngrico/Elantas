using UnityEngine.SceneManagement;
using UnityEngine;

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
        SceneManager.LoadScene(0);
    }
}
