using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Dialog : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI textDisplay;

    public string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject continueButton;
    public GameObject panel;
    private int SentencesLength;
    public bool DialogOn = false;
    private GameObject Player;
    private Player playerscript;
    private void Start()
    
    {
        Player = GameObject.Find("Player");
        playerscript = Player.GetComponent<Player>();
    }
    void Update()
    {
        if (textDisplay.text == sentences[index]) //Text length is same as index, display button
        {
            continueButton.SetActive(true);
        }
    }
    IEnumerator Type()
    {
        playerscript.dialogOn = true;


        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);

        }
    }
    public void NextSentence() //Gets next sentence
    {
        SentencesLength = sentences.Length;
        continueButton.SetActive(false);
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }

        else
        {
            textDisplay.text = ""; //Close dialog 
            continueButton.SetActive(false);
            panel.SetActive(false);
            playerscript.dialogOn = false;

        }

    }
    private void OnTriggerEnter(Collider collision)
    {

        if (collision.tag == "Player")
        {
            panel.SetActive(true);
            StartCoroutine(Type());

        }
    }


}
