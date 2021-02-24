using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class DialogSystem : MonoBehaviour
{
    public TextAsset asset;

    int i = 0;

    public Text textDialog;
    public Image characterImage;

   // public int[] charId;
    public Sprite[] charSprites;

    DialogSeting dialog;

    public GameObject[] buttons;
    public GameObject nextButton;

    void Start()
    {
        dialog = DialogSeting.Load(asset);
        StartCoroutine(TypeDialogueText(dialog.nodes[i].text));
        //  Next(0, "", "");
        // characterImage.GetComponent<Animator>().SetTrigger("go");
    }

    // Update is called once per frame
    void Update()
    {
       // textDialog.text = dialog.nodes[i].text;
        characterImage.sprite = charSprites[dialog.nodes[i].id] ;
        if(dialog.nodes[i].end != "true")
        {
            
            nextButton.SetActive(false);

            for(int j=0; j < dialog.nodes[i].answers.Length; j++)
            {
                buttons[j].SetActive(true);
                buttons[j].GetComponent<ButtonManager>().end="";
                buttons[j].GetComponentInChildren<Text>().text = dialog.nodes[i].answers[j].answerText;
                buttons[j].GetComponent<ButtonManager>().curI = dialog.nodes[i].answers[j].tonode;
                if (dialog.nodes[i].answers[j].end == "true")
                {
                    buttons[j].GetComponent<ButtonManager>().end = dialog.nodes[i].answers[j].end;
                    buttons[j].GetComponent<ButtonManager>().level = dialog.nodes[i].answers[j].level;
                    Debug.Log(dialog.nodes[i].answers[j].level);
                }
            }

        }
        else
        {
            nextButton.SetActive(true);
           
            for (int j = 0; j < buttons.Length; j++)
            {

                buttons[j].SetActive(false);
            }
        }

        
    }

    public void Next(int NextNode, string end, string level)
    {
       
        if (i <= dialog.nodes.Length - 1)
        {
            if (dialog.nodes[i].end == "true")
            {
                i++;
            }
            else
            {
                if (end != "true")
                {
                    i = NextNode;
                }
                else
                {
                   
                    SceneManager.LoadScene(level);
                }
            }
            characterImage.GetComponent<Animator>().Play("AnimationBegin");
            characterImage.GetComponent<Animator>().Play("Stay");


        }
        Debug.Log("op ");
        StopAllCoroutines();
      
        StartCoroutine(TypeDialogueText(dialog.nodes[i].text));
    }

    IEnumerator TypeDialogueText(string dial)
    {
        textDialog.text = "";
        foreach(char letter in dial.ToCharArray())
        {
            textDialog.text += letter;
            yield return null;
        }
    }

    public void NextB()
    {
        Next(0, "","");
    }
}
