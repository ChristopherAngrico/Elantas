using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public class OptionButton : MonoBehaviour
{
    private Image image;
    private void OnEnable()
    {
        image = GetComponent<Image>();
        //int number = Random.Range(0, OptionManager.instance.scriptable_object.Length);
        //if (!OptionManager.instance.getRandomIndex.Contains(number))
        //{
        //    OptionManager.instance.getRandomIndex.Add(number);
        //    print(number);
        //}
        //image.sprite = OptionManager.instance.scriptable_object
        //    [].sprite;
    }
}
