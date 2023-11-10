using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using static UnityEditor.Progress;

public class OptionManager : MonoBehaviour
{

    [SerializeField] private GameObject[] items;

    [SerializeField] private ScriptableObjects[] scriptable_object;

    private List<itemData> itemDataList = new List<itemData>();
    private struct itemData
    {
        public Sprite image;
        public int id;
    }

    private void Start()
    {
        RandomPick();
    }

    private void RandomPick()
    {
        //Spawn the correct item in option panel randomly
        int index = Random.Range(0, items.Length);

        Image image = items[index].GetComponent<Image>();
        image.sprite = scriptable_object[0].sprite;

        itemDataList.Add(new itemData
        {
            image = image.sprite,
            id = scriptable_object[0].id
        });
        print(image.sprite);
        //Fill the rest with random pick item
        int i = 0;
        while (true)
        {
            if (i == items.Length)
            {
                break;
            }
            //Skip if item have been filled
            if (items[i].GetComponent<Image>().sprite != null)
            {
                i++;
                continue;
            }

            Image images = items[i].GetComponent<Image>();

            //Spawn random scripable object
            int randomIndex = Random.Range(0, scriptable_object.Length);
            var getImage = scriptable_object[randomIndex].sprite;
            itemDataList.Add(new itemData
            {
                image = getImage,

            });

            //Data contain in list, "continue" to pick another random number
            if (itemDataList.Any(
                data => data.image == getImage
                ))
            {
                continue;
            }

            images.sprite = getImage;
        }
    }
}
