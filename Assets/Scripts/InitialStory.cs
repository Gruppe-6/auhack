using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(StoryRunner))]
public class InitialStory : MonoBehaviour, IStoryPart
{
    StoryRunner storyRunner;
    event OnComplete onComplete;
    // Start is called before the first frame update
    void Start()
    {
        storyRunner = GetComponent<StoryRunner>();
        storyRunner.AddStoryPart(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RunStory()
    {
        SceneManager.LoadScene("SampleScene");
        onComplete?.Invoke();
    }

    public void AddOnCompleteHandler(OnComplete handler)
    {
        onComplete += handler;
    }

    public void RemoveOnCompleteHandler(OnComplete handler)
    {
        onComplete -= handler;
    }
}
