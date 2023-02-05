using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static AnimalController;
using static Unity.VisualScripting.Member;


public class PlayPiano : MonoBehaviour
{
    public enum SoundNote
    {
        None = 0,
        C,
        D,
        Dis,
        G
    }

    KeyCode[] keysToListenTo = { KeyCode.DownArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.RightArrow };

    public AudioSource source;
    public AudioClip C_sound;
    public AudioClip D_sound;
    public AudioClip Dfis_sound;
    public AudioClip G_sound;
    public ParticleSystem particle;
    public List<SoundNote> playedNotes;
    public AnimalController animalController;

    private float timeSinceLastNote;

    public string GetCurrentNotesText()
    {
        string ret = "";

        foreach(var note in playedNotes)
        {
            ret += note.ToString() + "\n";
        }

        return ret;
    }
    private AudioClip GetAudioClip(SoundNote note)
    {
        return note switch
        {
            SoundNote.C => C_sound,
            SoundNote.D => D_sound,
            SoundNote.Dis => Dfis_sound,
            SoundNote.G => G_sound,
            _ => null
        };
    }
	List<List<SoundNote>> usedSongs = new List<List<SoundNote>>();
	private SoundNote KeyCodeToSoundNote(KeyCode keyCode)
    {
        return keyCode switch
        {
            KeyCode.DownArrow => SoundNote.C,
            KeyCode.UpArrow => SoundNote.Dis,
            KeyCode.LeftArrow => SoundNote.G,
            KeyCode.RightArrow => SoundNote.D,
            _ => SoundNote.None
        };
    }
    // Start is called before the first frame update
    void Start()
    {
        source.volume = 0.9f;
        particle.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastNote += Time.deltaTime;
        foreach (KeyCode key in keysToListenTo)
        {
            if (Input.GetKeyDown(key))
            {
                SoundNote sn = KeyCodeToSoundNote(key);
                playedNotes.Add(sn);

                Debug.Log("Played note " + sn.ToString());
                Debug.Log("Current count " + playedNotes.Count);

                timeSinceLastNote = 0.0f;

                source.Stop();
                source.clip = GetAudioClip(sn);
                source.Play();
                particle.Emit(1);
            }
        }

        if (playedNotes.Count == 3)
        {
            if (usedSongs.Any(x => playedNotes.SequenceEqual(x)))
            {
				animalController?.ClearAttack();
            }
            else
            {
				animalController?.Attack();
                usedSongs.Add(new List<SoundNote>(playedNotes));
			}
            playedNotes.RemoveRange(0, playedNotes.Count);
        }

        if (playedNotes.Count > 0 && timeSinceLastNote > 1.0f)
        {
            Debug.Log("Time out");
            playedNotes.RemoveRange(0, playedNotes.Count);
            animalController?.ClearAttack();
        }

    }
}
