using UnityEngine;
using System.Collections;
using TMPro;

public class Cultist : MonoBehaviour {
  
  [SerializeField]
  [TextArea(3, 10)]
  private string[] dialog;
  private int dialogIndex;
  [SerializeField]
  private TextMeshProUGUI textBox;
  [SerializeField]
  internal float speakSpeed = 20f;
  [SerializeField]
  private Animator anim;
  // * for shout
  
  private IEnumerator Say(string text) {
    textBox.text = "";
    int shoutCount = 0;
    float delay = 1f / speakSpeed;
    float shoutDelay = 0f;
    bool shouting = false;
    foreach (char letter in text.ToCharArray()) {
      if (letter == '*') {
        if (shouting == true) {
          yield return new WaitForSecondsRealtime(shoutDelay * 1.2f);
          shoutDelay = 0f;
        } else {
          anim.SetTrigger("Shake");
        }
        shouting = !shouting;
        yield return new WaitForSecondsRealtime(delay);
      } else {
        textBox.text += letter;
        if (!shouting) {
          yield return new WaitForSecondsRealtime(delay);
        } else {
          shoutDelay += delay;
        }
      }
    }
  }
  
  internal float Speak() {
    string line = dialog[dialogIndex];
    StartCoroutine(Say(line));
    dialogIndex++;
    return line.Length / speakSpeed;
  }
  
  private void Start() {
    
  }
}
