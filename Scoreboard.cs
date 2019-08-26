using UnityEngine;
using System.Collections;
using TMPro;

public class Scoreboard : MonoBehaviour {
  
  [SerializeField]
  private TextMeshProUGUI textBox;
  [SerializeField]
  private Animator animator;
  private int score;
  
  internal void AddScore() {
    score++;
    animator.SetTrigger("Score");
  }
  
  private void Update() {
    textBox.text = "" + score;
    for (int i = 0; i < score / 100; i++) {
      textBox.text += "!";
    }
  }
}
