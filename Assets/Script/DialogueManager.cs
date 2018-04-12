using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour {

	public Text nameText;
	public Text dialogueText;
    public GameObject image;
    public Animator animator;
    private Queue<string> sentences;
    public Dialogue dialogue;
    private bool isPaused;
    public GameObject player1;
    public Light light;
    public GameObject player2;

    // Use this for initialization
    private void Update()
    {
        if (isPaused)
        {
            player2.SetActive(false);
            player1.SetActive(false);
            Cursor.visible = true;
            light.color = Color.grey;
        
            
        } else Time.timeScale = 1f;
        if (Input.GetButtonDown("FireA")){
            DisplayNextSentence();
        }
    }
    void Start () {
		sentences = new Queue<string>();
        
        animator.SetBool("IsOpen", true);
		nameText.text = dialogue.name;
        
        sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
        isPaused = true;
    }

	public void DisplayNextSentence ()
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
		animator.SetBool("IsOpen", false);
        image.SetActive(false);
        isPaused = false;
        Cursor.visible = false;
        player2.SetActive(true);
        player1.SetActive(true);
        light.color = Color.white;
    }

}
