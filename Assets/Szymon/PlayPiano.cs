using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;


public class PlayPiano : MonoBehaviour
{
    public AudioSource source;
    public AudioClip C_sound;
    public AudioClip D_sound;
    public AudioClip Dfis_sound;
    // Start is called before the first frame update
    void Start()
    {
        source.volume = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            source.PlayOneShot(C_sound);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            source.PlayOneShot(D_sound);
        }

    }
}
