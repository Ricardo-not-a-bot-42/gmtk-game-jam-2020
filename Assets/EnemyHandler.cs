using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "char" && collision is CapsuleCollider2D) {
            collision.gameObject.GetComponent<GameHandler>().DecreaseHealth();
        }
        if(collision.gameObject.tag == "child") {
            collision.gameObject.GetComponent<ChildHandler>().DecreaseHealth();
        }
    }
}
