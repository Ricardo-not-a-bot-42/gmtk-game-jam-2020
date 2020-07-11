using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public int Max_Health = 3;
    int health;
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
        Debug.Log("Child hit!");
        if(health == 0) {
            Destroy(gameObject);
        }
    }
}
