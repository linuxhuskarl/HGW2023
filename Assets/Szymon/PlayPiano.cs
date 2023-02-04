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
    public AudioClip G_sound;
    public GameObject particle;
    bool [] pressed = {false,false,false,false};
    float timePassed = 0f;


    // Start is called before the first frame update
    void Start()
    {
        source.volume = 0.9f;
        particle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            source.clip = C_sound;
            pressed[0] = true;
            source.Stop();
            source.Play();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            source.clip = D_sound;
            if (pressed[0]==true && pressed[2]==false && pressed[3]==false)
            {
                pressed[1] = true;
            }
            else
            {
                pressed[0] = false;
                pressed[1] = false;
                pressed[2] = false;
                pressed[3] = false;
            }
            source.Stop();
            source.Play();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            source.clip = Dfis_sound;
            if (pressed[0] == true && pressed[1] == true && pressed[3] == false)
            {
                pressed[2] = true;
            }
            else
            {
                pressed[0] = false;
                pressed[1] = false;
                pressed[2] = false;
                pressed[3] = false;
            }
            source.Stop();
            source.Play();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            source.clip = G_sound;
            if (pressed[0] == true && pressed[1] == true && pressed[2] == true)
            {
                pressed[3] = true;
            }
            else
            {
                pressed[0] = false;
                pressed[1] = false;
                pressed[2] = false;
                pressed[3] = false;
            }
            source.Stop();
            source.Play();
        }

        if(pressed[0] == true && pressed[1] == true && pressed[2] == true && pressed[3]==true)
        {
            Debug.Log("EVENT");
            timePassed += Time.deltaTime;


        }
      
        if (timePassed > 5f)
        {
            Debug.Log("END");
            pressed[0] = false;
            pressed[1] = false;
            pressed[2] = false;
            pressed[3] = false;
            timePassed = 0;
        }

        if(source.isPlaying)
        {
            particle.SetActive(true);
        }
        else
        {
            particle.SetActive(false);
        }

    }
}
