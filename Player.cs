using UnityEngine;
using System.Collections;

public class Player : Entity {
  
  [SerializeField]
  private Camera cam;
  [SerializeField]
  private Bullet[] bullets;
  private int bulletIndex;
  [SerializeField]
  private Animator anim;
  [SerializeField]
  private float fireRate = 0.5f;
  
  internal void DestroyAnim() {
    Destroy(anim);
    rb.position = new Vector2(1f, -1f);
    StartCoroutine(Shoot());
  }
  
  private IEnumerator Shoot() {
    while (!Input.GetButton("Shoot")) {
      yield return null;
    }
    Bullet bullet = bullets[bulletIndex];
    bullet.transform.position = rb.position;
    bullet.transform.rotation = Quaternion.AngleAxis(rb.rotation, Vector3.forward);
    bullet.gameObject.SetActive(true); // needs to be after for the muzzle fx
    bullet.rb.velocity = transform.up * bullet.speed * 2f;
    bulletIndex = (bulletIndex + 1) % bullets.Length;
    yield return new WaitForSecondsRealtime(fireRate);
    StartCoroutine(Shoot());
  }
  
  protected override void Start() {
    base.Start();
  }

  private void FixedUpdate() {
    Vector2 moveDir = new Vector2(Input.GetAxisRaw("MoveHorz"), Input.GetAxisRaw("MoveVert"));
    Move(moveDir);
    Vector2 lookDir = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition) - rb.position;
    Rotate(lookDir);
  }
}
