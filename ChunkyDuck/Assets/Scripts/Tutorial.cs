using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [Header("UI Elements")]
    public Text dialogueText;

    [Header("Dialogue Settings")]
    [TextArea(2, 5)] public string[] sentences;
    public float typingSpeed = 0.05f;

    private int index = 0;
    private bool isTyping = false;
    private Coroutine typingCoroutine;

    void Start()
    {
        dialogueText.text = "";
        StartTypingCurrentSentence();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isTyping)
            {
                StopCoroutine(typingCoroutine);
                dialogueText.text = sentences[index];
                isTyping = false;
            }
            else
            {
                index++;

                if (index < sentences.Length)
                {
                    StartTypingCurrentSentence();
                }
                else
                {
                    dialogueText.text = "";
                    gameObject.SetActive(false);
                }
            }
        }
    }

    void StartTypingCurrentSentence()
    {
        typingCoroutine = StartCoroutine(TypeSentence(sentences[index]));
    }

    IEnumerator TypeSentence(string sentence)
    {
        isTyping = true;
        dialogueText.text = "";

        foreach (char letter in sentence)
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }
}