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
            pressed[0] = true;
            source.PlayOneShot(C_sound);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
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
            source.PlayOneShot(D_sound);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
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
            source.PlayOneShot(Dfis_sound);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
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
            source.PlayOneShot(G_sound);
        }

        if(pressed[0] == true && pressed[1] == true && pressed[2] == true && pressed[3]==true)
        {
           
            particle.SetActive(true);
            timePassed += Time.deltaTime;


        }
      
        if (timePassed > 3f)
        {
            Debug.Log("EVENT");
            particle.SetActive(false);
            pressed[0] = false;
            pressed[1] = false;
            pressed[2] = false;
            pressed[3] = false;
            timePassed = 0;
        }

    }
}
