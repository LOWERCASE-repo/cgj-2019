using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class Clock : MonoBehaviour { // not my best work
  
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
  [SerializeField]
  private Scoreboard sb;
  
  [SerializeField]
  private AudioSource audio;
  [SerializeField]
  private AudioClip clang;
  [SerializeField]
  private AudioClip splash;
  
  private Alerter alerter;
  
  private string desktop, username;
  
  private IEnumerator Start() {
    
    alerter = new Alerter();
    desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    username = Environment.UserName;
    
    // Debug.Log(File.Exists)
    
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
    yield return new WaitForSecondsRealtime(right.Speak());
    yield return new WaitForSecondsRealtime(left.Speak() + 0.5f);
    yield return new WaitForSecondsRealtime(right.Speak() + 0.5f);
    yield return new WaitForSecondsRealtime(left.Speak() + 0.3f);
    yield return new WaitForSecondsRealtime(right.Speak() + 0.3f);
    yield return new WaitForSecondsRealtime(left.Speak() + 0.3f);
    yield return new WaitForSecondsRealtime(right.Speak() + 0.3f);
    yield return new WaitForSecondsRealtime(left.Speak() + 0.3f); // bg
    background.SetTrigger("Throw");
    yield return new WaitForSecondsRealtime(1f);
    
    yield return new WaitForSecondsRealtime(right.Speak() + 0.3f); // ship
    player.SetTrigger("Throw");
    yield return new WaitForSecondsRealtime(1f);
    
    yield return new WaitForSecondsRealtime(left.Speak() + 0.5f);
    yield return new WaitForSecondsRealtime(right.Speak() + 0.5f); // catch
    roidCage.SetActive(false);
    yield return new WaitForSecondsRealtime(left.Speak() + 1.5f); // buffoon
    
    yield return new WaitForSecondsRealtime(right.Speak() + 0.3f);
    yield return new WaitForSecondsRealtime(left.Speak() + 0.3f); // have sb
    scoreboard.SetTrigger("Throw");
    yield return new WaitForSecondsRealtime(1.2f);
    
    yield return new WaitForSecondsRealtime(right.Speak() + 0.3f); // help
    left.speakSpeed = 60f;
    left.Speak(); // aaa
    left.speakSpeed = 10f;
    yield return new WaitForSecondsRealtime(0.2f);
    yield return new WaitForSecondsRealtime(right.Speak() + 0.4f); // shut up
    right.speakSpeed = 10f;
    yield return new WaitForSecondsRealtime(right.Speak() + 1f); // shoosh
    
    left.speakSpeed = 1f;
    right.speakSpeed = 1f;
    
    left.Speak(); // ...
    yield return new WaitForSecondsRealtime(right.Speak() + 8f);
    
    // Application.Quit();
    
    left.speakSpeed = 20f;
    right.speakSpeed = 20f;
    
    yield return new WaitForSecondsRealtime(left.Speak() + 1f); // do you think the player noticed?
    yield return new WaitForSecondsRealtime(right.Speak() + 1f); // nah
    
    left.speakSpeed = 30f;
    right.speakSpeed = 30f;
    
    yield return new WaitForSecondsRealtime(right.Speak() + 1f); // they probably thought it was a long loading screen
    yield return new WaitForSecondsRealtime(left.Speak() + 5f); // shame they'll never find out that this isn't a game
    
    // fire ambience
    
    yield return new WaitForSecondsRealtime(left.Speak() + 1f); // why asteroids?
    yield return new WaitForSecondsRealtime(right.Speak() + 1f); // you said to make this look like a game
    yield return new WaitForSecondsRealtime(left.Speak() + 1f); // but asteroids is *soo* 19th century
    yield return new WaitForSecondsRealtime(right.Speak() + 0.5f); // whateveerr the player seems to like it
    yield return new WaitForSecondsRealtime(right.Speak() + 1f);
    // potential branching
    
    yield return new WaitForSecondsRealtime(left.Speak() + 5f); // harrumph fine
    
    yield return new WaitForSecondsRealtime(left.Speak() + 1f); // aight, the cauldron's ready
    yield return new WaitForSecondsRealtime(right.Speak() + 1f); // *fi**nal**ly*
    yield return new WaitForSecondsRealtime(right.Speak() + 1f); // oh shoot i dropped the heart
    yield return new WaitForSecondsRealtime(left.Speak() + 1.5f); // where'd it go?
    yield return new WaitForSecondsRealtime(right.Speak() + 1f); // dunno, i'm looking for it
    yield return new WaitForSecondsRealtime(left.Speak() + 5f); // why are you like this
    
    yield return new WaitForSecondsRealtime(right.Speak() + 1f); // found it!
    yield return new WaitForSecondsRealtime(right.Speak() + 1f); // stale
    yield return new WaitForSecondsRealtime(left.Speak() + 2f);
    
    Directory.CreateDirectory(desktop + "/Cauldron");
    FileStream heart = File.Create(desktop + "/Cauldron/Heart");
    heart.Close();
    
    // * sploosh *
    
    yield return new WaitForSecondsRealtime(left.Speak() + 1f); // ready
    yield return new WaitForSecondsRealtime(right.Speak() + 1f); // no looking back
    yield return new WaitForSecondsRealtime(left.Speak() + 2f);
    
    for (int j = 0; j < 3; j++) {
      left.Speak();
      yield return new WaitForSecondsRealtime(right.Speak() + 1f);
    }
    
    left.speakSpeed = 15f;
    right.speakSpeed = 15f;
    
    left.Speak();
    yield return new WaitForSecondsRealtime(right.Speak() + 2.5f);
    
    left.speakSpeed = 20f;
    right.speakSpeed = 20f;
    
    yield return new WaitForSecondsRealtime(left.Speak() + 1f);
    yield return new WaitForSecondsRealtime(right.Speak() + 1f); // weird
    
    left.speakSpeed = 30f;
    right.speakSpeed = 30f;
    
    yield return new WaitForSecondsRealtime(left.Speak() + 1f); // did it work?
    right.Speak(); // I thi- YES
    yield return new WaitForSecondsRealtime(0.4f);
    alerter.Error();
    yield return new WaitForSecondsRealtime(left.Speak() + 0.3f); // by pope
    yield return new WaitForSecondsRealtime(right.Speak() + 0.3f); // foundation
    yield return new WaitForSecondsRealtime(left.Speak() + 0.3f); // take out
    yield return new WaitForSecondsRealtime(right.Speak() + 0.4f);
    yield return new WaitForSecondsRealtime(right.Speak() + 0.3f); // incredulous
    yield return new WaitForSecondsRealtime(left.Speak() + 0.3f); // yes take th
    yield return new WaitForSecondsRealtime(right.Speak() + 0.3f);
    Time.timeScale = 0f;
    yield return new WaitForSecondsRealtime(0.5f);
    
    
    Threaten("Too late.");
    Threaten("While my heart rests in the cauldron, I am IMMORTAL!");
    Threaten("AND NOW THE BICKERING FOOLS ARE FROZEN IN TIME AND UNABLE TO STOP ME");
    Threaten("MUA HAHA HA HA H-");
    Threaten("*cough* *wheeze*");
    yield return new WaitForSecondsRealtime(1f);
    Threaten("As for you...");
    Threaten(username + ".");
    yield return new WaitForSecondsRealtime(0.2f);
    int i = 0;
    while (true) {
      if (Threaten("YOUR SOUL IS NOW MINE")) break;
      yield return new WaitForSecondsRealtime(0.2f);
      if (Threaten("MAKE PEACE WITH YOUR GOD, FOR THIS IS THE DAY THEY DIE")) break;
      yield return new WaitForSecondsRealtime(0.2f);
      if (Threaten("I HOPE YOU ENJOY BEING ON FIRE FOREVER")) break;
      yield return new WaitForSecondsRealtime(0.2f);
      i++;
      if (i > 2) alerter.Alert("check your computer's desktop for any sketchy cauldrons with hearts in them ;)", "the developer!");
    }
    
    alerter.Alert("Wait.", "???");
    alerter.Alert("where is my heart.", "???");
    alerter.Alert("NOOOOOOOOOOOO", "???");
    alerter.Alert("OOOOOoo", "???");
    alerter.Alert("ooo", "???");
    yield return new WaitForSecondsRealtime(2f);
    alerter.Alert("o", "???");
    Time.timeScale = 1f;
    
    left.speakSpeed = 1f;
    right.speakSpeed = 1f;
    
    left.Speak(); // ...
    yield return new WaitForSecondsRealtime(right.Speak() + 1f);
    
    left.speakSpeed = 10f;
    yield return new WaitForSecondsRealtime(left.Speak() + 1f); // welp
    right.speakSpeed = 20f;
    yield return new WaitForSecondsRealtime(right.Speak() + 2f); // sums it up
    
    left.speakSpeed = 25f;
    right.speakSpeed = 25f;
    
    yield return new WaitForSecondsRealtime(left.Speak() + 1f); // wanna grab bubble tea?
    yield return new WaitForSecondsRealtime(right.Speak() + 1f); // yeah
    
    left.Shrink();
    right.Shrink();
    
    yield return new WaitForSecondsRealtime(right.Speak() + 1f); // that was fun tho
    yield return new WaitForSecondsRealtime(left.Speak() + 1f); // again?
    yield return new WaitForSecondsRealtime(right.Speak() + 2f); // heck yeah
    
    // door close
    
    yield return new WaitForSecondsRealtime(1f);
    
    // Application.Quit();
  }
  
  private bool Threaten(string text) {
    alerter.Alert(text, "???");
    return !File.Exists(desktop + "/Cauldron/Heart");
  }
}
