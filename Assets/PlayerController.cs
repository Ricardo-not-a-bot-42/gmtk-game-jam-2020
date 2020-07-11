using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
        public Rigidbody2D rigidbody;
        public int FacingRight = 1;
        public GameObject Picked_Child;
        public float max_speed = 3f;
        int Pick_CD = 0;
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
  {
    HandleMovement();
    if(GetComponent<GameHandler>().carryingChild == true && Picked_Child == null) {
        GetComponent<GameHandler>().carryingChild = false;
        GetComponent<GameHandler>().updateChildHealthCounter(0);
    }
    if(GetComponent<GameHandler>().carryingChild == true) {
        Picked_Child.transform.position = new Vector2(gameObject.transform.position.x + 0.35f * FacingRight, gameObject.transform.position.y + 0.2f);
        GetComponent<GameHandler>().updateChildHealthCounter(Picked_Child.GetComponent<ChildHandler>().health);
    }
    if(Pick_CD > 0) {
        Pick_CD--;
    }
    if (Input.GetKeyDown(KeyCode.Space) && GetComponent<GameHandler>().carryingChild == true && Pick_CD == 0)
    {
        Debug.Log("Let go!");
        Picked_Child.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1f;
        float bowlingSpeed;
        GetComponent<GameHandler>().updateChildHealthCounter(0);
        if(GetComponent<Rigidbody2D>().velocity.y == 0) {
            bowlingSpeed = 10f;
        } else {
            bowlingSpeed = 1f;
        }
        Debug.Log(bowlingSpeed);
        Picked_Child.GetComponent<Rigidbody2D>().AddForce(new Vector2(40f * FacingRight + (GetComponent<Rigidbody2D>().velocity.x / 2 * bowlingSpeed), 30f * (GetComponent<Rigidbody2D>().velocity.y) / 2));
        GetComponent<GameHandler>().carryingChild = false;
    }
  }

  void OnTriggerStay2D(Collider2D collision) {
          if (Input.GetKeyDown(KeyCode.Space) && collision.gameObject.tag == "child" && GetComponent<GameHandler>().carryingChild == false)
    {
        Debug.Log("Picked!");
        collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
        Picked_Child = collision.gameObject;
        Pick_CD = 30;
        GetComponent<GameHandler>().carryingChild = true;
    }
  }

  private void HandleMovement()
  {
    if (Input.GetKey("right") && rigidbody.velocity.x < max_speed)
    {
      rigidbody.AddForce(new Vector2(5f, 0f));
      FacingRight = 1;
    }
    if (Input.GetKey("left") && rigidbody.velocity.x > -max_speed)
    {
      rigidbody.AddForce(new Vector2(-5f, 0f));
      FacingRight = -1;
    }
    if (Input.GetKeyDown("up") && rigidbody.velocity.y == 0)
    {
      rigidbody.AddForce(new Vector2(0, 350f));
    }

    if (rigidbody.velocity.y != 0f && max_speed != 1f)
    {
      max_speed = 1f;
    }
    else if (max_speed != 3f)
    {
      max_speed = 3f;
    }
  }
}
