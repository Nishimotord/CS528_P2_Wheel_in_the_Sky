using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip[] song;
    AudioSource parent;
    // Start is called before the first frame update
    void Start()
    {
        parent = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetMusic(int selection)
    {
        parent.Stop();
        parent.clip = song[selection];
        parent.Play();
    }
}
