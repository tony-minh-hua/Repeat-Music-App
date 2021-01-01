using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class MusicLoader : MonoBehaviour
{
    private string musicFile;

    public Text ActiveSongText;
    public GameObject Panel;
    public GameObject ButtonPrefab;

    private void Start()
    {
        ReadFileNames();
    }

    private void ReadFileNames ()
    {
        DirectoryInfo dir = new DirectoryInfo(Application.streamingAssetsPath);
        FileInfo[] info = dir.GetFiles("*.ogg");
        info.Select(f => f.FullName).ToArray();

        foreach (FileInfo f in info)
        {
            Debug.Log(f.Name);
            GameObject instance = Instantiate(ButtonPrefab);
            instance.transform.SetParent(Panel.transform);
            instance.GetComponentInChildren<Text>().text = f.Name;
            instance.GetComponentInChildren<Button>().onClick.AddListener(delegate { SetMusicFile(f.Name); }) ;
        }
    }

    private void SetMusicFile (string name)
    {
        musicFile = name;
        ActiveSongText.text = musicFile;
        StartCoroutine(LoadMusic());
    }

    public static string GetFileLocation(string relativePath) {
        return "file://" + Path.Combine(Application.streamingAssetsPath, relativePath);
    }

    IEnumerator LoadMusic ()
    {
        WWW www = new WWW(GetFileLocation(musicFile));
        MusicPlayer.Song = www.GetAudioClip();
        yield return new WaitUntil(() => MusicPlayer.Song.isReadyToPlay);
    }
    
}
