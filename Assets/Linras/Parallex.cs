using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallex : MonoBehaviour
{
    private float length, startpos;
    public GameObject cam;
    public float parallexEffect;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float temp = (cam.transform.position.x * (1 - parallexEffect));
        float dist = (cam.transform.position.x * parallexEffect);

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

    //HINT: a workaround to make a cycle after background is over

        if (temp > startpos + length)
        {
            startpos += length;
        }
        else if (temp < startpos - length)
        {
            startpos -= length;
        }
    }
}
