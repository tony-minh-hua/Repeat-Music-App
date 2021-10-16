using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour
{
    public static AudioClip Song;
    public AudioSource SourceAudio;
    public InputField NumberPlaysInput;
    public Text NumberPlaysText;
    public int numberOfPlays;

        // Start is called before the first frame update
        void Start()
    {
        Screen.fullScreen = false;
        NumberPlaysText.text = "Number of Plays: " + numberOfPlays.ToString();
    }

    IEnumerator PlaySong ()
    {
        for (int i = 0; i < numberOfPlays; i++)
        {
            SourceAudio.PlayOneShot(Song);
            yield return new WaitForSeconds(Song.length);
        }
        //Application.Quit();
    }

    public void NumberOfPlaysInput()
    {
        numberOfPlays = int.Parse(NumberPlaysInput.text);
        NumberPlaysText.text = "Number of Plays: " + numberOfPlays.ToString();
    }

    public void PlayButton()
    {
        StartCoroutine(PlaySong());
    }

    public void StopButton()
    {
        SourceAudio.Stop();
    }

    public void QuitAppButton()
    {
        Application.Quit();
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("Screenmanager Resolution Width", 800);
        PlayerPrefs.SetInt("Screenmanager Resolution Height", 600);
        PlayerPrefs.SetInt("Screenmanager Is Fullscreen mode", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
