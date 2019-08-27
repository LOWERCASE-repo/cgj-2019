using UnityEngine;
using System.Collections;

public class Bullet : Entity {
  
  [SerializeField]
  private Scoreboard scoreboard;
  [SerializeField]
  private GameObject muzzle;
  [SerializeField]
  private GameObject explosion; // rename to impact next time
  
  protected override void Start() {
    base.Start();
  }
  
  private void OnEnable() {
    muzzle.transform.position = transform.position;
    muzzle.transform.rotation = transform.rotation;
    muzzle.SetActive(true);
  }

  private void FixedUpdate() {
    Move(rb.velocity);
    Rotate(rb.velocity);
  }
  
  private void OnTriggerEnter2D(Collider2D collider) {
    if (collider.gameObject.name == "Cage") {
      gameObject.SetActive(false);
    } else if (collider.gameObject.name == "Asteroid") {
      Asteroid roid = collider.gameObject.GetComponent<Asteroid>();
      roid.Reset();
      scoreboard.AddScore();
      gameObject.SetActive(false);
    }
  }
  
  private void OnTriggerExit2D() {
    gameObject.SetActive(false);
  }
  
  private void OnDisable() {
    explosion.transform.position = rb.position;
    explosion.SetActive(true);
  }
}
