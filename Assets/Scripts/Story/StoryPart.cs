using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StoryPart
{
    private event OnComplete _onComplete;

    protected Action Story;
    
    public void RunStory()
    {
        Story?.Invoke();
    }

    protected int PlayerChoice(string option1, string option2, string option3)
    {
        
        return -1;
    }
    protected string EMPH(string level, string sentence) => $"<emphasis level=\"{level}\">{sentence}</emphasis>";
    protected string BRK(float seconds) => $"<break time=\"{seconds}s\" />";
    public void AddOnCompleteHandler(OnComplete handler)
    {
        _onComplete += handler;
    }

    public void RemoveOnCompleteHandler(OnComplete handler)
    {
        _onComplete -= handler;
    }
}
