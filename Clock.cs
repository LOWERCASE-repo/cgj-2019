using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class Clock : MonoBehaviour {
  
  [SerializeField]
  private Cultist left;
  [SerializeField]
  private Cultist right;
  [SerializeField]
  private Animator background;
  [SerializeField]
  private Animator player;
  [SerializeField]
  private Animator scoreboard;
  [SerializeField]
  private GameObject roidCage;
  
  private Alerter alerter;
  
  private IEnumerator Start() {
    
    alerter = new Alerter();
    string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    string username = Environment.UserName;
    Debug.Log(username);
    
    // Debug.Log(File.Exists)
    // StartCoroutine(anta.Spiel());
    
    yield return new WaitForSecondsRealtime(1f);
    
    yield return new WaitForSecondsRealtime(left.Speak() + 1.5f);
    yield return new WaitForSecondsRealtime(right.Speak() + 1f);
    yield return new WaitForSecondsRealtime(left.Speak() + 2f);
    Directory.CreateDirectory(desktop + "/Cauldron");
    yield return new WaitForSecondsRealtime(right.Speak() + 1f);
    yield return new WaitForSecondsRealtime(left.Speak() + 1f);
    yield return new WaitForSecondsRealtime(right.Speak());
    
    left.speakSpeed = 30f;
    right.speakSpeed = 30f;
    
    yield return new WaitForSecondsRealtime(left.Speak() + 1f);
    yield return new WaitForSecondsRealtime(left.Speak() + 0.5f);
    yield return new WaitForSecondsRealtime(right.Speak() - 0.05f);
    yield return new WaitForSecondsRealtime(left.Speak() + 0.5f);
    yield return new WaitForSecondsRealtime(right.Speak() + 0.5f);
    yield return new WaitForSecondsRealtime(left.Speak() + 0.3f);
    yield return new WaitForSecondsRealtime(right.Speak() + 0.3f);
    yield return new WaitForSecondsRealtime(left.Speak() + 0.3f);
    yield return new WaitForSecondsRealtime(right.Speak() + 0.3f);
    yield return new WaitForSecondsRealtime(left.Speak() + 0.3f);
    background.SetTrigger("Throw");
    yield return new WaitForSecondsRealtime(right.Speak() + 0.3f);
    player.SetTrigger("Throw");
    yield return new WaitForSecondsRealtime(left.Speak() + 0.5f);
    yield return new WaitForSecondsRealtime(right.Speak() + 0.5f);
    roidCage.SetActive(false);
    yield return new WaitForSecondsRealtime(left.Speak() + 0.5f);
    yield return new WaitForSecondsRealtime(right.Speak() + 0.3f);
    yield return new WaitForSecondsRealtime(left.Speak() + 0.3f);
    scoreboard.SetTrigger("Throw");
    yield return new WaitForSecondsRealtime(right.Speak());
    left.Speak();
    left.speakSpeed = 10f;
    yield return new WaitForSecondsRealtime(0.3f);
    yield return new WaitForSecondsRealtime(right.Speak() + 0.2f);
    right.speakSpeed = 10f;
    yield return new WaitForSecondsRealtime(right.Speak() + 1f);
    
    left.speakSpeed = 1f;
    right.speakSpeed = 1f;
    
    left.Speak();
    yield return new WaitForSecondsRealtime(right.Speak() + 2f);
    
    alerter.Alert("whoops ran out of content", "oh no");
    alerter.Alert("see you around, " + username + " ;)", "oh no");
    // Application.Quit();
    
    /*
    left.speakSpeed = 20f;
    right.speakSpeed = 20f;
    
    yield return new WaitForSecondsRealtime(left.Speak() + 1f);
    yield return new WaitForSecondsRealtime(right.Speak() + 1f);
    
    left.speakSpeed = 30f;
    right.speakSpeed = 30f;
    
    yield return new WaitForSecondsRealtime(left.Speak() + 1f);
    yield return new WaitForSecondsRealtime(left.Speak() + 1f);
    yield return new WaitForSecondsRealtime(left.Speak() + 1f);
    yield return new WaitForSecondsRealtime(right.Speak() + 1f);
    yield return new WaitForSecondsRealtime(left.Speak() + 1.5f);
    yield return new WaitForSecondsRealtime(right.Speak() + 1f);
    yield return new WaitForSecondsRealtime(right.Speak() + 1f);
    yield return new WaitForSecondsRealtime(left.Speak() + 1f);
    yield return new WaitForSecondsRealtime(right.Speak() + 1f);
    yield return new WaitForSecondsRealtime(left.Speak() + 1f);
    yield return new WaitForSecondsRealtime(right.Speak() + 1f);
    yield return new WaitForSecondsRealtime(left.Speak() + 1f);
    yield return new WaitForSecondsRealtime(right.Speak() + 5f);
    
    */
    
    // File.Create(desktop + "/Cauldron/Heart");
  }
}
