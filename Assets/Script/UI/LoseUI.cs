using UnityEngine.SceneManagement;
using UnityEngine;

public class LoseUI : MonoBehaviour
{
    public void CobaLagi(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void Keluar()
    {
        SceneManager.LoadScene(0);
    }
}
