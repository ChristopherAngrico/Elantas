using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public class HealthManager : MonoBehaviour
{
    private int health;
    [SerializeField] private List<Image> image;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;

    public delegate void Fail();
    public static event Fail OnFail;

    private void OnEnable()
    {
        health = image.Count - 1;
        OptionManager.OnResetQuiz += ResetAQuiz;
    }

    private void ResetAQuiz(bool n)
    {
        if (health >= 0)
        {
            image[health].sprite = emptyHeart;
            health -= 1;
        }
        if (health < 0)
        {
            OnFail?.Invoke();
        }
    }

    private void OnDisable()
    {
        OptionManager.OnResetQuiz -= ResetAQuiz;
    }
}
