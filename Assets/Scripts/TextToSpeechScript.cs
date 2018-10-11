using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextToSpeechScript : MonoBehaviour {
    private string _text;
    private AudioSource _audio;

    public string Text
    {
        get
        {
            return _text;
        }
        set
        {
            _text = value;
        }
    }

    // Use this for initialization
    void Start () {
        _audio = gameObject.GetComponent<AudioSource>();
        //default text
        _text = "Failed";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator DownloadTheAudio()
    {
        //Youtube Video here>>>>> https://www.youtube.com/watch?v=RDkDXZ8P1bg
        //url for google tts
        string url = "http://translate.google.com/translate_tts?ie=UTF-8&total=1&idx=0&textlen=32&client=tv-ob&q=SampleText*tl=En-gb";

        WWW www = new WWW(url);

        yield return www;

        //chekcs extension so to know which audio type to set
        string extension = url.Substring(url.Length - 4);
        Debug.Log("extension: " + extension);

        if (extension.Equals(".ogg"))
            _audio.clip = www.GetAudioClip(true, true, AudioType.OGGVORBIS);
        else if (extension.Equals(".mp3"))
            _audio.clip = www.GetAudioClip(true, true, AudioType.MPEG);
        else if (extension.Equals(".wav"))
            _audio.clip = www.GetAudioClip(true, true, AudioType.WAV);
        else
            _audio.clip = www.GetAudioClip(true, true, AudioType.UNKNOWN);

        yield return new WaitForSeconds(0.5f);

        //set audio type
        _audio.clip = www.GetAudioClip(true, true, AudioType.ACC);
        //play
        _audio.Play();
    }
    public void PlayText(string text)
    {
        //gets text and set it into private text for tts
        _text = text;
        //calls enum
        StartCoroutine(DownloadTheAudio());
    }
}
