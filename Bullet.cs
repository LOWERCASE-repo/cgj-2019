using UnityEngine;
using System.Collections;

public class Bullet : Entity {
  
  protected override void Start() {
    base.Start();
  }

  protected void FixedUpdate() {
    Move(rb.velocity);
    Rotate(rb.velocity);
  }
  
  private void OnCollisionEnter2D(Collision2D collision) {
    Asteroid roid = collision.gameObject.GetComponent<Asteroid>();
    roid.Reset();
    gameObject.SetActive(false);
    // add score
  }
  
  private void OnTriggerEnter2D(Collider2D collider) {
    if (collider.gameObject.name == "Cage") {
      gameObject.SetActive(false);
    }
  }
  
  private void OnTriggerExit2D() {
    gameObject.SetActive(false);
  }
}
