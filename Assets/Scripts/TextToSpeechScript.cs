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
        _text = "Testing this thing";
        _audio = gameObject.GetComponent<AudioSource>();
        StartCoroutine(DownloadTheAudio());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator DownloadTheAudio()
    {
        //Youtube Video here>>>>> https://www.youtube.com/watch?v=RDkDXZ8P1bg
        string url = "http://transalte.google.com/translate_tts?ie=UTF-8&total=1&idx=O&textlen=32&client=tw-ob&q="+_text+"&tl=En-gb";
        WWW www = new WWW(url);
        yield return www;
        _audio.clip = www.GetAudioClip(false, true, AudioType.MPEG);
        _audio.Play();
    }
}
