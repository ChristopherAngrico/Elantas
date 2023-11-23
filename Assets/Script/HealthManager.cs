using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private List<Image> image;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;

    private void Update()
    {
        if(health > image.Count)
        {
            health = image.Count;
        }
        for (int i = 0; i < image.Count; i++)
        {
            if(i < health)
            {
                image[i].sprite = fullHeart;
            }
            else
            {
                image[i].sprite = emptyHeart;
            }
        }
    }
}
