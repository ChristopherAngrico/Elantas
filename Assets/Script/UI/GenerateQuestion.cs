using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public class GenerateQuestion : MonoBehaviour
{

    [SerializeField] private QuestionScriptableObject[] questionScriptableObject;

    [SerializeField] private Image image;

    private List<int> QuestionList = new List<int>();
    
    private int getRandom;

    [HideInInspector] public int questionID { get; private set; }

    private OptionManager optionManager;

    private void OnEnable()
    {
        optionManager = GetComponent<OptionManager>();
        Random.InitState(System.DateTime.Now.Millisecond);
        RandomPick();
        optionManager.OnChangeNextQuesiton += () =>
        {
            RandomPick();
        };
    }

    private void RandomPick()
    {
        while (true)
        {
            getRandom = Random.Range(0, questionScriptableObject.Length);
            if (!QuestionList.Contains(getRandom))
            {
                break;
            }
        }
        QuestionList.Add(getRandom);
        image.sprite = questionScriptableObject[getRandom].sprite;
        questionID = questionScriptableObject[getRandom].id;
    }
}