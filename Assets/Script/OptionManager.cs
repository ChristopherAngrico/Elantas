using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Runtime.CompilerServices;

public class OptionManager : MonoBehaviour
{

    [SerializeField] private GameObject[] items;

    [SerializeField] private ScriptableObjects[] scriptable_object;

    private List<itemData> itemDataList = new List<itemData>();

    private Button item1;
    private Button item2;
    private Button item3;

    private bool next;
    private bool randomize = true;

    private struct itemData
    {
        public Sprite image;
        public int id;
    }

    private void OnEnable()
    {

        item1 = items[0].GetComponent<Button>();
        item2 = items[1].GetComponent<Button>();
        item3 = items[2].GetComponent<Button>();

        item1.onClick.AddListener(delegate { TaskOnClick(0); });
        item2.onClick.AddListener(delegate { TaskOnClick(1); });
        item3.onClick.AddListener(delegate { TaskOnClick(2); });
    }
    private void Update()
    {
        if (next)
        {
            Clear();
        }
        if (randomize)
        {
            RandomPick();
            randomize = false;
        }
    }
    private void RandomPick()
    {
        //Spawn the correct item in option panel randomly
        int index = Random.Range(0, items.Length);

        Image image;
        image = items[index].GetComponent<Image>();
        image.sprite = scriptable_object[0].sprite;

        itemDataList.Add(new itemData
        {
            image = image.sprite,
            id = scriptable_object[0].id
        });

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

            //Spawn random scripable object
            int randomIndex = Random.Range(0, scriptable_object.Length);
            image = items[i].GetComponent<Image>();
            var getImage = scriptable_object[randomIndex].sprite;

            //Data contain in list, "continue" to pick another random data
            if (itemDataList.Any(
                data => data.image == getImage
                ))
            {
                continue;
            }

            //Add data to list
            image.sprite = getImage;
            itemDataList.Add(new itemData
            {
                image = getImage,
                id = scriptable_object[randomIndex].id
            });
            i++;
        }
    }

    private void TaskOnClick(int indexSlot)
    {

        Sprite searchImage = items[indexSlot].GetComponent<Image>().sprite;

        //Find the image contain inside list and return all of the data that related to
        var result = itemDataList.Where(d => d.image == searchImage);
        foreach (var item in result)
        {
            if (item.id == 0)
            {
                next = true;
            }
            else
            {
                next = true;
            }
        }
    }

    private void Clear()
    {
        itemDataList.Clear();
        foreach (GameObject item in items)
        {
            item.GetComponent<Image>().sprite = null;
        }
    }

}
