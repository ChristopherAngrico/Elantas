using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject PauseUI;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUI.SetActive(true);
        }
    }

    public void Lanjut(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void MainUlang(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void Keluar()
    {
        Application.Quit();
    }

    public void Cancle()
    {
        PauseUI.SetActive(false);
    }
}
