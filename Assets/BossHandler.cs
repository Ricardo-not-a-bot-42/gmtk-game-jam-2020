using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHandler : MonoBehaviour
{

    public Slider HP_Bar;
    public int Health = 150;
    // Start is called before the first frame update
    void Start()
    {
        HP_Bar.maxValue = Health;
        HP_Bar.value = Health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void decreaseHealth(int value) {
        Health -= value;
        HP_Bar.value = Health;
    }
}
