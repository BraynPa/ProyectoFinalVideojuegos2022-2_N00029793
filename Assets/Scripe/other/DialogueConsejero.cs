using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueConsejero : MonoBehaviour
{
    [SerializeField] private GameObject dialogueMark;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField,TextArea(4,6)] private string[] dialogueLines;

    private float typingTime = 0.05f;
    private bool IsPlayerInRange;
    private bool didDialogueStart;
    private int lineIndex;

    // Update is called once per frame
    void Update()
    {  
        if(IsPlayerInRange && Input.GetKeyUp(KeyCode.T)){
            AudioManager.instance.PlayAudio(AudioManager.instance.button);
            if(!didDialogueStart){
                
                StartDialogue();
            }else if(dialogueText.text == dialogueLines[lineIndex]){

                NextDialogueLine();
            }
            else{
                StopAllCoroutines();
                dialogueText.text = dialogueLines[lineIndex];
            }
        }
        
    }

    private void StartDialogue(){
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        dialogueMark.SetActive(false);
        lineIndex = 0;
        Time.timeScale = 0f;
        StartCoroutine(ShowLine());
    }

    private void NextDialogueLine(){
        lineIndex++;
        if(lineIndex < dialogueLines.Length){
            StartCoroutine(ShowLine());
        }else{
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
            dialogueMark.SetActive(true);
            Time.timeScale = 1f;
        }
    }
    private IEnumerator ShowLine(){
        dialogueText.text = string.Empty;
        AudioManager.instance.PlayAudio(AudioManager.instance.text);
        foreach(char ch in dialogueLines[lineIndex]){
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(typingTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {

        if(collision.gameObject.CompareTag("Player")){
            IsPlayerInRange = true;
            dialogueMark.SetActive(true);
            
        }

        

    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player")){
            IsPlayerInRange = false;
            dialogueMark.SetActive(false);
            
        }
    }
}
