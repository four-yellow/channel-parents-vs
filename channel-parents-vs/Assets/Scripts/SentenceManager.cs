using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SentenceManager : MonoBehaviour
{


    private List<Sentence> sentences; //How to load up elegantly?
    private Sentence first;
    private Sentence test1;
    private Sentence test2;
    private int current_sentence = 1;


    private Text text_comp;
    private bool updating_text = false; //True if "printing", or updating text box
    private bool skip_effects = false; //If true, instantly fill the dialogue box.
    void Start()
    {
        text_comp = this.GetComponent<Text>();
        first = new Sentence("Press enter for the next line...", 0.0f);
        this.GetComponent<Text>().text = first.GetNext().GetText();

        test1 = new Sentence("This is a very long sentence to demonstrate the existence of text wrapping in the current system ", 0.01f);
        test2 = new Sentence("Is this?", 0.05f);
        sentences = new List<Sentence>();
        //Clever load up should be here
        sentences.Add(test1);
        sentences.Add(test2);
    }

    //Checks to see if a Sentence needs to be printed onto the text box
    //Currently just auto prints a sentence
    void CheckTrigger()
    {
        int num_sentences = sentences.Count;
        int cur_index = 0;

        while (cur_index < num_sentences)
        {
            StartCoroutine(DrawSentence(sentences[current_sentence]));
            return;
        }

    }

    //Need to check if the text won't fit the box
    IEnumerator DrawSentence(Sentence sentence)
    {
        Line current_line;
        string text;
        float drawing_speed;

        current_line = sentence.GetNext();
        text = current_line.GetText();
        drawing_speed = current_line.GetDrawingSpeed();

        //Used when slow drawing is enabled; keeps track of how much of the string to print.
        int current_index = 0;

        while (true)
        {

            if (drawing_speed == 0.0f || skip_effects)
            {
                text_comp.text = text;
                current_index = text.Length;
                skip_effects = false;
            }

            if (current_index < text.Length)
            {
                text_comp.text = text.Substring(0, current_index + 1);
                current_index++;
                yield return new WaitForSeconds(drawing_speed);
            } else
            {
                updating_text = false;
                yield break;
            }

        } 
    }


    void Update() //For drawing speed and other fancy effects, this is a must.
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (updating_text)
            {
                skip_effects = true;
            } else
            {
                current_sentence = (current_sentence == 0) ? 1 : 0; //Garbage currently
                CheckTrigger();
                updating_text = true;
            }
        }
    }
}
