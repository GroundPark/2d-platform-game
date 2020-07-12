using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class dialogue_manager : MonoBehaviour
{
    private PlayerController questIs;

    public bool is1Finished;
    public bool is2Finished;
    public bool is3Finished;
    public bool is4Finished;
    public string check_return;

    public Animator animator;

    public Text nameText;
    public Text dialogueText;

    public Queue<string> sentences;
    // Queue의 FIFO으로 string 제어

    public GameObject TheButton;

    void Start()
    {
        sentences = new Queue<string>();
    }

    void Update()
    {

        questIs = FindObjectOfType<PlayerController>();

        check_return = questIs.currentMapName;

        is1Finished = questIs.quest1Finished;
        is2Finished = questIs.quest2Finished;
        is3Finished = questIs.quest3Finished;
        is4Finished = questIs.quest4Finished;

        if (is1Finished == true && is2Finished == true && is3Finished == true && is4Finished == true && check_return == "Island_esc")
        {
            TheButton.gameObject.SetActive(true);
        }
    }

    public void StartDialogue(dialogue Dialogue)
    {
        animator.SetBool("isOpen", true);
        nameText.text = Dialogue.NPC_name;

        sentences.Clear();

        foreach (string sentence in Dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
    

         DisplayNextSentence();

    }



    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();

            return;
        }

        string sentence = sentences.Dequeue();
        
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));


    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }



    void EndDialogue()
    {
        animator.SetBool("isOpen", false);
    }


    public void ending_scene()
    {
        GameObject.Find("Player_Idle1").GetComponent<PlayerController>().Self_Destroy();
        GameObject.Find("Canvas").GetComponent<Canvas_control>().Self_Destroy_UI();

        SceneManager.LoadScene("ending");
    }


}
