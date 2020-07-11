using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplode : MonoBehaviour
{

    public GameObject BOOMParticles;
    public GameObject HitBox;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimesUp());
        
    }

    IEnumerator TimesUp()
    {
        yield return new WaitForSeconds(3);
        GetComponent<CircleCollider2D>().enabled = true;

        Destroy(gameObject, 0.5f);
        Instantiate(BOOMParticles, transform.position, Quaternion.identity);
        
        
    }

}
