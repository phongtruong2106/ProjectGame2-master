using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
    [Header("Params")]
    [SerializeField] private float typingSpeed = 0.04f;

    [Header("Dialogue UI")]
    [SerializeField]
    private GameObject dialoguePanel;
    [SerializeField]
    private GameObject continueIcon;
    [SerializeField]
    private TextMeshProUGUI dialoggueText;
    [SerializeField]
    private TextMeshProUGUI displayNameText;
    [SerializeField]
    private Animator portraitAnimator;
    private Animator layoutAnimator;

    [Header("Choices UI")]
    [SerializeField]
    private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    private static DialogueManager instance;

    private Story currentStory;
    public bool dialogueIsPlaying {  get; private set; }

    private bool canContinueToNextLine = false;

    private Coroutine displayLineCoroutine;

    [SerializeField]
    private Player player;

    private const string SPEAKER_TAG = "speaker";
    private const string PROTRAIT_TAG = "portrait";
    private const string LAYOUT_TAG = "layout";


    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Found more than one DiaLogue Manager in the scene");
        }
        instance = this;
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        layoutAnimator = dialoguePanel.GetComponent<Animator>();

        //get all of the choices text
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach(GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    private void Update()
    {
        if(!dialogueIsPlaying)
        {
            return;
        }
        if (canContinueToNextLine 
            && currentStory.currentChoices.Count == 0 
            && Input.GetKeyDown(KeyCode.Space))
        {
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

         ContinueStory();
    }

    private IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(0.2f);
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialoggueText.text = "";
        player.enabled = true;
    }

    private void ContinueStory()
    {
        if(currentStory.canContinue)
        {
            if(displayLineCoroutine != null)
            {
                StopCoroutine(displayLineCoroutine);
            }

            displayLineCoroutine = StartCoroutine(DisplayLine(currentStory.Continue()));
            HandleTags(currentStory.currentTags);
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }

    private IEnumerator DisplayLine(string line)
    {
        dialoggueText.text = "";

        continueIcon.SetActive(false);
        HideChoices();

        canContinueToNextLine = false;

        foreach(char letter in line.ToCharArray())
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                dialoggueText.text = line;
                break;
            }
            dialoggueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        continueIcon.SetActive(true);
        DisplayChoise();

        canContinueToNextLine = true;
    }

    private void HideChoices()
    {
        foreach (GameObject choiceButton in choices)
        {
            choiceButton.SetActive(false);
        }
    }

    private void HandleTags(List<string> currentTags)
    {
        foreach(string tag in currentTags)
        {
            string[] splitTag = tag.Split(':');
            if(splitTag.Length != 2)
            {
                Debug.LogError("Tag could not be appropriately parsed: " +  tag);
            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            //handle the tag
            switch (tagKey)
            {
                case SPEAKER_TAG:
                    displayNameText.text = tagValue;
                    break;
                case PROTRAIT_TAG:
                    portraitAnimator.Play(tagValue);
                    break;
                case LAYOUT_TAG:
                    layoutAnimator.Play(tagValue);
                    break;
                default:
                    Debug.LogWarning("Tga came in but is not cuttently being handled: " + tag);
                    break;
            }
        }
    }
    private void DisplayChoise()
    {
        List<Choice> currentChoices = currentStory.currentChoices;
        if(currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than the UI can support . Number of choices given: " 
                + currentChoices.Count);
        }

        int index = 0;
        
        foreach(Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        for(int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }
        StartCoroutine(SelectFirstChoice());
    }

    private IEnumerator SelectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void MakecChoice(int choiceIndex)
    {
        if(canContinueToNextLine)
        {
            currentStory.ChooseChoiceIndex(choiceIndex);
            if(Input.GetKeyDown(KeyCode.Space)) {
                ContinueStory();
            }

        }
    }
}
