using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public float minS;
    public float maxS;
    float speed;
    float Explode;
    public GameObject DestroyParticles;
    public GameObject BombEnemy;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(minS, maxS);
        Explode = Random.Range(0, 20);
    
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        
    }
    void OnTriggerEnter2D(Collider2D hitObject)
    {
        if (hitObject.tag == "char" && hitObject is CapsuleCollider2D)
        {
            print("Im Hit");
            Destroy(gameObject);
            Instantiate(DestroyParticles, transform.position, Quaternion.identity);
        }
        if (hitObject.tag == "Floor" && Explode != 12)
        {
            //print("Cara no chão");
            Destroy(gameObject);
            Instantiate(DestroyParticles, transform.position, Quaternion.identity);
        }
        if (hitObject.tag == "Floor" && Explode == 12)
        {
            //print("Cara no chão");
            Destroy(gameObject);
            Instantiate(BombEnemy, transform.position, Quaternion.identity);
        }
    }
}
