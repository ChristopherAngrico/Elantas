using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public class HealthManager : MonoBehaviour
{
    private int health;
    [SerializeField] private List<Image> image;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;
    private void Start()
    {
        health = image.Count - 1;
        OptionManager.OnResetQuestion += (bool ans) =>
        {
            if(health >= 0)
            {
                image[health].sprite = emptyHeart;
                health -= 1;
            }
            if(health < 0)
            {
                print("Death");
            }
        };
    }
}
