
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Line
{

    /* ----- CONTENTS AND APPEARANCE -----*/

    private string text; //Text to be printed

    //Font
    //Color

    /* ----- DRAWING SPEED AND EFFECTS -----*/

    //How many seconds to wait before printing the next character.
    private float drawing_speed; 

    //Shaking effects?
    //Text wrapping? This currently seems unnecessary
    //Handling multiple pages of text?

    public Line(string text_, float drawing_speed_)
    {
        text = text_;
        drawing_speed = drawing_speed_;
    }

    public string GetText()
    {
        return text;
    }

    public float GetDrawingSpeed()
    {
        return drawing_speed;
    }

}

//A Sentence is a list of Lines; each Line has it's own text, drawing speed,
//font, color, effects, etc. 
public class Sentence
{
    private List<Line> sentence;
    //Two kinds of triggers as to when to print a Sentence:
    //Choice trigger: Went through door 1, just entered a room, etc;
    //Reactive triggers: Head turned left in Room 29, walked away from parent, etc;
    //Of course, choice triggers are easy to handle, but what of reactive triggers?

    private int current_index = 0;

    public Sentence(Line[] lines)
    {
        sentence = new List<Line>();
        for (int i = 0; i < lines.Length; i++)
        {
            sentence.Add(lines[i]);
        }

    }

    //For simple sentences
    public Sentence(string whatever, float whatever2)
    {
        sentence = new List<Line>();
        Line myLine = new Line(whatever, whatever2);
        sentence.Add(myLine);
    }

    public Line GetNext()
    {
        //current_index += 1;
        return sentence[current_index];
    }

    public bool IsFinished()
    {
        return !(current_index < sentence.Count);
    }
}
