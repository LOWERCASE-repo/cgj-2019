using UnityEngine;
using System.Collections;

public class Asteroid : Entity {
  
  // [SerializeField]
  // private Scoreboard sb;
  
  internal void Reset() {
    rb.position = Random.insideUnitCircle.normalized * 10f;
    rb.velocity = -rb.position + Random.insideUnitCircle * 3f;
  }
  
  protected override void Start() {
    base.Start();
  }

  protected void FixedUpdate() {
    Move(rb.velocity);
  }
  
  private void OnTriggerExit2D() {
    rb.velocity = -rb.position + Random.insideUnitCircle * 3f;
  }
  
  private void OnCollisionEnter2D() {
    // check for player
  }
}
