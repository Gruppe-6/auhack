using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void OnComplete();

public interface IStoryPart
{
    void RunStory();
    void AddOnCompleteHandler(OnComplete handler);
    void RemoveOnCompleteHandler(OnComplete handler);
}

public class StoryRunner : MonoBehaviour
{
    List<StoryPart> storyParts = new List<StoryPart>();
    StoryPart currentStoryPart;
    private static bool created = false;
    [SerializeField] private FreeTTS jan;
    [SerializeField] private DialogChoice dc;
    
    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(gameObject);
            created = true;
            Debug.Log("Awake: " + gameObject);
            AddStoryPart(new InitialStory(jan, dc));
        }
    }

    public void AddStoryPart(StoryPart storyPart) {
        storyParts.Add(storyPart);
        if (currentStoryPart == null && storyParts.Count != 0) {
            RunNextStory();
        }
    }

    public void RunNextStory() {
        if (currentStoryPart != null)
        {
            currentStoryPart.RemoveOnCompleteHandler(RunNextStory);
            storyParts.RemoveAt(0);
        }
        
        if (storyParts.Count > 0) {
            currentStoryPart = storyParts[0];
            currentStoryPart.AddOnCompleteHandler(RunNextStory);
            currentStoryPart.RunStory();
        }
    }
}
