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
    Queue<IStoryPart> storyParts;
    IStoryPart currentStoryPart;
    private static bool created = false;

    // Start is called before the first frame update
    void Start() {
        storyParts = new Queue<IStoryPart>();
        currentStoryPart = null;
    }

    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
            Debug.Log("Awake: " + this.gameObject);
        }
    }

    // Update is called once per frame
    void Update() {
        
    }
    
    public void AddStoryPart(IStoryPart storyPart) {
        storyParts.Enqueue(storyPart);
        if (currentStoryPart == null && storyParts.Count == 0) {
            RunNextStory();
        }
    }

    public void RunNextStory() {
        if (currentStoryPart != null)
        {
            currentStoryPart.RemoveOnCompleteHandler(RunNextStory);
        }
        
        if (storyParts.Count > 0) {
            currentStoryPart = storyParts.Dequeue();
            currentStoryPart.AddOnCompleteHandler(RunNextStory);
            currentStoryPart.RunStory();
        }
    }
}
