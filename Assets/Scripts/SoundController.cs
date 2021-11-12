using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource gameMusic;
    public AudioSource evinronmentSound;
    private void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("Sounds");
        if(musicObj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
