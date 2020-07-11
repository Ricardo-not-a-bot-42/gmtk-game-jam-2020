using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonalityHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    public GameObject[] Children;
    public GameObject Camera;
    public string currentPersonality;
    public string[] Personalities;
    // Angry
    // Sad
    // Focused
    // Excited
    // Happy
    // Confused
    public Slider Timer;
    void Start()
    {
        InvokeRepeating("updateTimer", 1f, 1f / 10);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void updateTimer() {
        if(Timer.value > 0) {
            Timer.value -= 0.1f;
        } else {
            SwitchPersonality();
            Timer.value = 15f;
        }
    }

    public void SwitchPersonality() {
        if(currentPersonality == "Angry") {
            Player.GetComponent<PlayerController>().triggerExplosion = true;
        }
        string personalityToSwitch;
        do {
            personalityToSwitch = Personalities[Random.Range(0, Personalities.Length)];
        } while(currentPersonality == personalityToSwitch);
        currentPersonality = personalityToSwitch;
        PersonalityFunction();
        Debug.Log(currentPersonality);
    }
    
    void PersonalityFunction() {
        if(currentPersonality == "Sad") {
            Player.GetComponent<PlayerController>().IsSad = true;
        } else {
            Player.GetComponent<PlayerController>().IsSad = false;
        }
        if(currentPersonality == "Happy") {
            Player.GetComponent<PlayerController>().IsHappy = true;
        } else {
            Player.GetComponent<PlayerController>().IsHappy = false;

        }
        if(currentPersonality == "Excited") {
            Player.GetComponent<PlayerController>().forceToAdd = 12f;
            Player.GetComponent<PlayerController>().added_speed = 2f;
        } else {
                        Player.GetComponent<PlayerController>().forceToAdd = 7f;
            Player.GetComponent<PlayerController>().added_speed = 0f;
        }
        if(currentPersonality == "Focused") {

        }
        if(currentPersonality == "Confused") {
            Player.GetComponent<PlayerController>().IsConfused = -1;
        } else {
            Player.GetComponent<PlayerController>().IsConfused = 1;
        }
    }
}
