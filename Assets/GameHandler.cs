using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public int Max_Health = 5;
    int health;
    public bool carryingChild = false;
    void Start()
    {
    health = Max_Health;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void DecreaseHealth() {
        health--;
        Debug.Log("Player hit!");
        if(health == 0) {
            Debug.Log("Game Over");
        }
    }
}
