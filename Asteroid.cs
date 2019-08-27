using UnityEngine;
using System.Collections;

public class Asteroid : Entity {
  
  [SerializeField]
  private Scoreboard sb;
  
  [SerializeField]
  private GameObject grind;
  
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
  
  private void OnCollisionEnter2D(Collision2D collision) {
    if (collision.gameObject.name == "Player") {
      Vector2 pos = collision.GetContact(0).point;
      float ang = Vector2.SignedAngle(Vector2.up, pos - rb.position);
      Quaternion rot = Quaternion.AngleAxis(ang, Vector3.forward);
      Instantiate(grind, pos, rot);
      sb.LoseScore();
    }
  }
}
