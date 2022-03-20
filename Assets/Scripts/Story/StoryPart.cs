using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StoryPart
{
    private event OnComplete _onComplete;

    protected Action Story;
    private DialogChoice _dialogChoice;

    public StoryPart(DialogChoice dc)
    {
        _dialogChoice = dc;
    }
    
    public void RunStory()
    {
        Story?.Invoke();
    }

    protected void PlayerChoice(string question, string option1, string option2, string option3, Action<int> callback)
    {
        _dialogChoice.AskQuestion(question, option1, option2, option3, callback);
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
