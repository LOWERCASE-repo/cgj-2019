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
  [SerializeField]
  private AudioClip clip;
  [SerializeField]
  private AudioClip shout;
  [SerializeField]
  private AudioSource audio;
  // * for shout
  
  private IEnumerator ShrinkText() {
    textBox.fontSize -= Time.deltaTime * 2.5f;
    if (textBox.fontSize < 0f) {
      textBox.fontSize = 0f;
      // door close sfx
    }
    audio.volume = textBox.fontSize / 36f;
    yield return null;
    StartCoroutine(ShrinkText());
  }
  
  internal void Shrink() {
    StartCoroutine(ShrinkText());
  }
  
  private bool sounded;
  internal IEnumerator Say(string text) { // should be private but i wanted to say the player's score
    textBox.text = "";
    int shoutCount = 0;
    float delay = 1f / speakSpeed;
    float shoutDelay = 0f;
    bool shouting = false;
    foreach (char letter in text.ToCharArray()) {
      if (letter == '*') {
        if (shouting == true) {
          yield return new WaitForSecondsRealtime(0.1f);
          audio.pitch = 1.05f - Random.value * 0.1f;
          audio.PlayOneShot(shout);
          yield return new WaitForSecondsRealtime(shoutDelay);
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
          if (!sounded && letter != '.') {
            audio.pitch = 1.1f - Random.value * 0.2f;
            audio.PlayOneShot(clip);
          }
          sounded = !sounded;
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
}
