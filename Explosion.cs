using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {
  
  [SerializeField]
  private Animator anim;
  
  internal void Disable() {
    gameObject.SetActive(false);
  }
}
