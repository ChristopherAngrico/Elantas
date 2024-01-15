using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using System.Collections;

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

    [HideInInspector] public int nextQuestion;

    public delegate void Answer(int value);
    public delegate void NextQuiz();
    public delegate void EndQuiz();

    public static event Answer OnAnswer;
    public static event NextQuiz OnNextQuestion;

    private struct itemData
    {
        public string text;
        public bool ans;
    }

    private void OnEnable()
    {
        Random.InitState(System.DateTime.Now.Millisecond);

        option1 = button[0];
        option2 = button[1];
        option3 = button[2];
        option4 = button[3];

        option1.onClick.AddListener(delegate { TaskOnClick(0); });
        option2.onClick.AddListener(delegate { TaskOnClick(1); });
        option3.onClick.AddListener(delegate { TaskOnClick(2); });
        option4.onClick.AddListener(delegate { TaskOnClick(3); });

        //All text set to empty string
        for (int i = 0; i < button.Length; i++)
        {
            button[i].GetComponentInChildren<TextMeshProUGUI>().text = string.Empty;
        }

        RandomPick();
        nextQuestion++;

    }


    private void RandomPick()
    {
        //Clear itemDataList
        Clear();

        TextMeshProUGUI text;

        //Fill the rest with random wrong answer
        for (int i = 0; i < button.Length;)
        {
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
                ans = scriptable_object[randomIndex].ans
            });
            i++;
        }
    }

    private void TaskOnClick(int indexSlot)
    {
        TextMeshProUGUI searchText = button[indexSlot].GetComponentInChildren<TextMeshProUGUI>();

        //Find the image contain inside list and return all of the data that related to
        var result = itemDataList.Where(d => d.text == searchText.text).ToList(); // Create a copy
        foreach (var data in result)
        {
            if (data.ans == true)
            {
                StartCoroutine(Delay(2, indexSlot, data.ans));
            }
            else
            {
                StartCoroutine(Delay(0, indexSlot, data.ans));
            }
        }
    }

    IEnumerator Delay(int value, int indexSlot, bool determineAnswer)
    {
        if (determineAnswer)
        {
            button[indexSlot].GetComponent<Image>().color = Color.green;

        }
        else
        {
            button[indexSlot].GetComponent<Image>().color = Color.red;
        }

        yield return new WaitForSeconds(1f);

        for (int i = 0; i < button.Length; i++)
        {
            button[i].GetComponent<Image>().color = Color.white;
        }

        OnAnswer?.Invoke(value);
        OnNextQuestion?.Invoke();
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
