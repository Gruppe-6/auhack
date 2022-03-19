using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitialStory : StoryPart
{
    private FreeTTS _jan;
    public InitialStory(FreeTTS jan)
    {
        _jan = jan;

        float money = 10;
        float owed = 69;
        int quicklåns = 65;
        float dramaPause = 3;

        Story += () =>
            Say("Welcome to luksusfælden, in this VR experience we will tell you about your terrible spending habits. " +
                "Your economy has reached a point where you either do something now or you will be indebted for the rest of your life. " +
                $"You have spent {EMPH("strong",$"{money}")} kroner on beer the last month. That strategy is completely and utterly unsustainable. This makes even less sense when you already owe {owed} to {quicklåns} quick loans. {BRK(dramaPause)} " +
                $"You have tossed the towel in the ring and given up, this is {EMPH("strong", "not")} okay");
        
    }

    private void Say(string words)
    {
        //TODO: Male voice?
        _jan.StartCoroutine(_jan.PlayTTS(words));
    }

    private IEnumerator Wait(float seconds, Action func)
    {
        yield return new WaitForSeconds(seconds);
        func();
    }
}
