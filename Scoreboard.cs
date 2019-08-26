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
  
  
  internal void AddScore() {
    score++;
    animator.SetTrigger("Score");
    audio.pitch = 1.1f - Random.value * 0.2f;
    audio.PlayOneShot(clip);
  }
  
  private void Update() {
    textBox.text = "" + score;
    for (int i = 0; i < score / 100; i++) {
      textBox.text += "!";
    }
  }
}
