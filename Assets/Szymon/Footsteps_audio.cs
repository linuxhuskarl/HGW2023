using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps_audio : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    public AudioClip clipJump;
    

    void Start()
    {
        source.volume = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            source.PlayOneShot(clip);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {

            source.Stop();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            source.PlayOneShot(clip);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {

            source.Stop();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {

            source.PlayOneShot(clipJump);
        }


    }
}
