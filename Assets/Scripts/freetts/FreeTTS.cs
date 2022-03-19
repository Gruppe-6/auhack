using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System;
using System.Web;
using UnityEngine.Networking;

[Serializable]
public class FirstResponse
{
    public string Msg;
    public string id;
    public int counts;
}

[RequireComponent(typeof(AudioSource))]
public class FreeTTS : MonoBehaviour
{
    AudioSource audioData;

    // Start is called before the first frame update
    void Start()
    {

        audioData = GetComponent<AudioSource>();
        StartCoroutine(PlayTTS("The red sun in the sky"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PlayTTS(string message, string language = "en-GB", string voice_name = "Amy_Female", string id = "Amy")
    {
        var url = "https://freetts.com/Home/PlayAudio?" + 
            "Language=" + UnityWebRequest.EscapeURL(language) + 
            "&Voice=" + UnityWebRequest.EscapeURL(voice_name) + 
            "&id=" + UnityWebRequest.EscapeURL(id) + 
            "&type=1&TextMessage=" + UnityWebRequest.EscapeURL(message);

        UnityWebRequest create_audio_request = UnityWebRequest.Get(url);
        yield return create_audio_request.SendWebRequest();

        if (create_audio_request.isNetworkError || create_audio_request.isHttpError)
        {
            Debug.LogError(string.Format("Error: {0}", create_audio_request.error));
            yield break;
        }
        // Response can be accessed through: request.downloadHandler.text
        Debug.Log(create_audio_request.downloadHandler.text);
        var decoded = JsonUtility.FromJson<FirstResponse>(create_audio_request.downloadHandler.text);

        var urlid = decoded.id;

        var url2 = "https://freetts.com/audio/" + UnityWebRequest.EscapeURL(urlid);
        var audio_request = UnityWebRequestMultimedia.GetAudioClip(url2, AudioType.MPEG);
        yield return audio_request.SendWebRequest();

        if (audio_request.isNetworkError || audio_request.isHttpError)
        {
            Debug.LogError(string.Format("Error: {0}", audio_request.error));
            yield break;
        }

        audioData.clip = DownloadHandlerAudioClip.GetContent(audio_request);

        audioData.Play(0);
    }
}
