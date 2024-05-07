using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    static List<AudioClip> BGMList;
    static AudioSource currentBGM;
    static float musicVolume = 0.5f;
    float volumeAdjustMultiplier = 1;
    int index = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        BGMList = FindObjectOfType<MusicList>().musicList;
        currentBGM = GetComponent<AudioSource>(); // Connecting the Empty Audio Source object here.
    }

    // Update is called once per frame
    void Update()
    {
        currentBGM.volume = musicVolume;

        if (Input.GetKeyDown(KeyCode.Return)) // Music player tester
        {
            switch (index)
            {
                case 0:
                    playMusic("main music");
                    break;
                case 1:
                    playMusic("game over");
                    break;
                case 2:
                    playMusic("victory");
                    break;
                case 3:
                    playMusic("credits");
                    break;
                default:
                    break;
            }
            if(index == 3)
                index = 0;
            else
                index++;
        }


        // Used to control the music volume. Will be implemented in the new input system in a future.
        if (Input.GetKeyUp(KeyCode.Minus) || Input.GetKeyUp(KeyCode.Equals))
            volumeAdjustMultiplier = 1;
    }

    private void FixedUpdate() // Updates 50 times a second
    {
        // Used to control the music volume. Will be implemented in the new input system in a future.
        if (Input.GetKey(KeyCode.Minus))
        {
            musicVolume -= 0.001f * volumeAdjustMultiplier;
            if (musicVolume > 0.99)
                musicVolume -= 0.015f;
            if (volumeAdjustMultiplier < 4.5f)
                volumeAdjustMultiplier += 0.02f;
        }
        if (Input.GetKey(KeyCode.Equals))
        {
            musicVolume += 0.001f * volumeAdjustMultiplier;
            if (musicVolume < 0.01)
                musicVolume += 0.015f;
            if (volumeAdjustMultiplier < 4.5f)
                volumeAdjustMultiplier += 0.02f;
        }
    }

    public static void playMusic(string name)
    {
        foreach (AudioClip music in BGMList)
        {
            if (music.name == name)
            {
                if (currentBGM.isPlaying)
                    currentBGM.Stop();
                currentBGM.clip = music;
                currentBGM.Play();
                return;
            }
        }
        //If the foreach loop fails then...
        Debug.Log("Couldn't find a Music named: \"" + name + "\"");
    }
}