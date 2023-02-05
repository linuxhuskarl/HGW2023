using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    public RectTransform healthPoints;
    public Text notesDisplay;
    public PlayerController player;
    public PlayPiano piano;

    private float healthPointWidth;
    private float healthWidth;
    // Start is called before the first frame update
    void Start()
    {
        healthPointWidth = healthPoints.sizeDelta.x;
        healthWidth = healthPointWidth / 3;
    }

    // Update is called once per frame
    void Update()
    {
        healthPoints.sizeDelta = new Vector2( healthWidth * player.healthPoints, healthPoints.sizeDelta.y);

        notesDisplay.text = piano.GetCurrentNotesText();
    }
}
