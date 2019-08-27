using UnityEngine;
using System.Collections;
using TMPro;

public class Scoreboard : MonoBehaviour {
  
  [SerializeField]
  private TextMeshProUGUI textBox;
  [SerializeField]
  private Animator animator;
  private int score;
  [SerializeField]
  private AudioSource audio;
  [SerializeField]
  private AudioClip clip;
  [SerializeField]
  private AudioClip hit;
  
  
  internal void AddScore() {
    score++;
    animator.SetTrigger("Score");
    audio.pitch = 1.1f - Random.value * 0.2f;
    audio.volume = 0.1f;
    audio.PlayOneShot(clip);
  }
  
  internal void LoseScore() {
    score--;
    animator.SetTrigger("Hit");
    audio.pitch = 1.1f - Random.value * 0.2f;
    audio.volume = 0.3f;
    audio.PlayOneShot(hit);
  }
  
  private void Update() {
    textBox.text = "" + score;
    for (int i = 0; i < score / 100; i++) {
      textBox.text += "!";
    }
  }
}
