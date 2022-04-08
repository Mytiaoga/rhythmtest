using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conductor : MonoBehaviour
{
    //Song beats per minute
    //This is determined by the song you're trying to sync up to
    public float songBpm;

    //The number of seconds for each song beat
    public float secPerBeat;

    //Current song position, in seconds
    public float songPosition;

    //Current song position, in beats
    public float songPositionInBeats;

    //How many seconds have passed since the song started
    public float dspSongTime;

    //an AudioSource attached to this GameObject that will play the music.
    public AudioSource musicSource;

    //The offset to the first beat of the song in seconds
    public float firstBeatOffset;

    //the number of beats in each loop
    public float beatsPerLoop;

    //the total number of loops completed since the looping clip first started
    public int completedLoops = 0;

    //The current position of the song within the loop in beats.
    public float loopPositionInBeats;

    public bool playNow;

    [Header("Metronome")]
    public AudioSource metronome;
    public float met;
    public int beat = 0;
    public int beatLoop;

    [Header("Input")]
    public float inp;
    public int inpu = 0;
    public float inputLoop;
    
    void Start()
    {
        //Load the AudioSource attached to the Conductor GameObject
        //musicSource = GetComponent<AudioSource>();

        //Calculate the number of seconds in each beat
        secPerBeat = 60f / songBpm;

        //Record the time when the music starts
        dspSongTime = (float)AudioSettings.dspTime;

        //Start the music
        musicSource.Play();

        metronome = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //determine how many seconds since the song started
        songPosition = (float)(AudioSettings.dspTime - dspSongTime - firstBeatOffset);

        //determine how many beats since the song started
        songPositionInBeats = songPosition / secPerBeat;

        //calculate the loop position
        if (songPositionInBeats >= (completedLoops + 1) * beatsPerLoop)
        {
            completedLoops++;
            //metronome.Play();
        }
        loopPositionInBeats = songPositionInBeats - completedLoops * beatsPerLoop;


        if (songPositionInBeats >= (beat + 1) * beatLoop)
        {
            beat++;
            metronome.Play();
            playNow = true;
        }
        met = songPositionInBeats - beat * beatLoop;

       
  
        if(inp > .3f)
        {
            Debug.Log("Early");
        }
        else if(inp > .8f)
        {
            Debug.Log("Perfect");
        }
        else if(inp > 1f)
        {
            Debug.Log("Late");
        }
    }

    public void go()
    {
        if (songPositionInBeats >= (inpu + 1) * inputLoop)
        {
            inpu++;
        }
        inp = songPositionInBeats - inpu * inputLoop;
    }
}

