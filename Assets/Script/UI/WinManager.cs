using UnityEngine;

public class WinManager : MonoBehaviour
{
    [SerializeField] private GameObject WinUI;
    private void OnEnable()
    {
        Movement.OnWin += Finished;
    }

    private void OnDisable()
    {
        Movement.OnWin -= Finished;
    }

    private void Finished()
    {
        WinUI.SetActive(true);
    }
}
