using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;


public class OptionManager : MonoBehaviour
{
    [Tooltip("Button Reference")]
    [SerializeField] private Button[] button;

    [SerializeField] private OptioncriptableObject[] scriptable_object;

    private List<itemData> itemDataList = new List<itemData>();

    private Button option1;
    private Button option2;
    private Button option3;
    private Button option4;

    [HideInInspector] public bool next;
    private bool randomize = true;

    private GenerateQuestion generateQuestion;

    public delegate void ChangeNextQuesiton();
    public event ChangeNextQuesiton OnChangeNextQuesiton;
    private struct itemData
    {
        public string text;
        public int id;
    }

    private void OnEnable()
    {
        generateQuestion = GetComponent<GenerateQuestion>();

        option1 = button[0];
        option2 = button[1];
        option3 = button[2];
        option4 = button[3];

        option1.onClick.AddListener(delegate { TaskOnClick(0); });
        option2.onClick.AddListener(delegate { TaskOnClick(1); });
        option3.onClick.AddListener(delegate { TaskOnClick(2); });
        option4.onClick.AddListener(delegate { TaskOnClick(3); });

        //All text set to empty string
        for(int i = 0; i < button.Length; i++)
        {
            button[i].GetComponentInChildren<TextMeshProUGUI>().text = string.Empty;
        }

    }


    private void Update()
    {
        if (next)
        {
            //Clear an option everytime reset or next question
            Clear();
            OnChangeNextQuesiton?.Invoke();
            next = false;
            randomize = true;
        }
        if (randomize)
        {
            RandomPick();
            randomize = false;
        }
    }
    private void RandomPick()
    {
        //Spawn the correct text in option panel randomly
        int index = Random.Range(0, button.Length);
        TextMeshProUGUI text;
        text = button[index].GetComponentInChildren<TextMeshProUGUI>();
        text.text = scriptable_object[0].text;

        //Store into the list
        itemDataList.Add(new itemData
        {
            text = text.text,
            id = scriptable_object[0].id
        });
       
        //Fill the rest with random pick item
        int i = 0;
        while (true)
        {
            text = null;
            if (i == button.Length)
            {
                break;
            }

            //Skip if item have been filled
            if (button[i].GetComponentInChildren<TextMeshProUGUI>().text != string.Empty)
            {
                i++;
                continue;
            }

            //Spawn random scripable object
            int randomIndex = Random.Range(0, scriptable_object.Length);
            text = button[i].GetComponentInChildren<TextMeshProUGUI>();
            var getText = scriptable_object[randomIndex].text;

            //Data contain in list, "continue" to pick another random data
            if (itemDataList.Any(
                data => data.text == getText
                ))
            {
                continue;
            }

            //Add data to list
            text.text = getText;
            itemDataList.Add(new itemData
            {
                text = getText,
                id = scriptable_object[randomIndex].id
            });
            i++;
        }
    }

    private void TaskOnClick(int indexSlot)
    {
        TextMeshProUGUI searchText = button[indexSlot].GetComponentInChildren<TextMeshProUGUI>();

        //Find the image contain inside list and return all of the data that related to
        var result = itemDataList.Where(d => d.text == searchText.text);
        foreach (var data in result)
        {
            if (data.id == generateQuestion.questionID)
            {
                print("Benar");
                next = true;
            }
            else
            {
                print("Salah");
                next = true;
            }
        }
    }

    private void Clear()
    {
        itemDataList.Clear();
        foreach (var item in button)
        {
            item.GetComponentInChildren<TextMeshProUGUI>().text = string.Empty;
        }
    }

}