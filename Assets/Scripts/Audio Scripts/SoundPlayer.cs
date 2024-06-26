using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SoundPlayer : MonoBehaviour
{
    static List<AudioSource> SFXList;
    public static float sfxVolume;
    float volumeAdjustMultiplier = 1;
    //int index = 0;
    bool increasingVol = false;
    bool decreasingVol = false;

    // Start is called before the first frame update
    void Start()
    {
        SFXList = FindObjectOfType<SoundsList>().soundsList;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (AudioSource sfx in SFXList)
        {
            sfx.volume = sfxVolume;
        }

        /*if (Input.GetKeyDown(KeyCode.LeftShift)) // Music player tester
        {
            switch(index)
            {
                case 0:
                    playSound("teleport 1");
                    break;
                case 1:
                    playSound("teleport 2");
                    break;
                case 2:
                    playSound("teleport 3");
                    break;
                case 3:
                    playSound("shield up");
                    break;
                case 4:
                    playSound("shield breaks");
                    break;
                case 5:
                    playSound("warning");
                    break;
                case 6:
                    playSound("ship breaking apart");
                    break;
                case 7:
                    playSound("game over sfx");
                    break;
                default:
                    break;
            }
            if (index == 7)
                index = 0;
            else
                index++;
        }*/

        if (Keyboard.current.leftBracketKey.wasReleasedThisFrame || Keyboard.current.rightBracketKey.wasReleasedThisFrame)
        {
            volumeAdjustMultiplier = 1;
            increasingVol = false;
            decreasingVol = false;
        }
    }

    private void FixedUpdate() // Updates 50 times a second
    {
        if (increasingVol)
        {
            sfxVolume += 0.001f * volumeAdjustMultiplier;
            if (sfxVolume < 0.01f)
                sfxVolume += 0.015f;
            if (volumeAdjustMultiplier < 4.5f)
                volumeAdjustMultiplier += 0.01f;
        }
        else if (decreasingVol)
        {
            sfxVolume -= 0.001f * volumeAdjustMultiplier;
            if (sfxVolume > 0.99f)
                sfxVolume -= 0.015f;
            if (volumeAdjustMultiplier < 4.5f)
                volumeAdjustMultiplier += 0.01f;
        }
    }

    public static void playSound(string name)
    {
        foreach (AudioSource sfx in SFXList)
        {
            if (sfx.name == name)
            {
                sfx.Play();
                return;
            }
        }
        //If the foreach loop fails then...
        Debug.Log("Couldn't find a SFX named: \"" + name + "\"");
    }

    public void OnSFXVolume(InputValue value)
    {
        if (value.Get<float>() > 0)
            increasingVol = true;
        else if (value.Get<float>() < 0)
            decreasingVol = true;
    }
}
