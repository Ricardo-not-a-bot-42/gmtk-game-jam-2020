using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public int Max_Health = 5;
    public GameObject[] Health_Images;
    public GameObject[] Child_Health_Images;
    int health;
    public bool carryingChild = false;
    void Start()
    {
    health = Max_Health;
    updateHealthCounter();
    updateChildHealthCounter(0);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void DecreaseHealth() {
        health--;
        Debug.Log("Player hit!");
        updateHealthCounter();
        if(health == 0) {
            Debug.Log("Game Over");
        }
    }

    void updateHealthCounter() {
        for(int i = 0; i < 5; i++) {
            if(i < health) {
                Health_Images[i].GetComponent<Image>().enabled = true;
            } else {
                Health_Images[i].GetComponent<Image>().enabled = false;
            }
        }
    }
    public void updateChildHealthCounter(int child_health) {
        for(int i = 0; i < 3; i++) {
            if(i < child_health) {
                Child_Health_Images[i].GetComponent<Image>().enabled = true;
            } else {
                Child_Health_Images[i].GetComponent<Image>().enabled = false;
            }
        }
    }
}