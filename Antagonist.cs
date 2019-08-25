using UnityEngine;
using System.Collections;

public class Antagonist : MonoBehaviour {
  
  private Alerter alerter;
  
  private void Speak(string text) {
    alerter.Alert(text, "???");
    // check if file exists
  }
  
  internal IEnumerator Spiel() {
    alerter.Error();
    
    alerter.Alert("WHO DARES WAKE ME FROM MY SLUMBER?", "???");
    alerter.Alert("<USERNAME>!", "???");
    alerter.Alert("IT WAS YOU WHO WOKE ME UP!", "???");
    alerter.Alert("I WILL FORCE FEED YOU A CHEESE GRATER", "???");
    alerter.Alert("MAKE PEACE WITH YOUR GOD, FOR THIS IS THE DAY THEY DIE", "???");
    alerter.Alert("I SHALL DEFENESTRATE YOU", "???");
    alerter.Alert("HOPE YOU ENJOY BEING ON FIRE FOREVER", "???");
    alerter.Alert("BET THE RUN TO YOUR NEAREST POLICE STATION IS LONGER THAN TEN MINUTES", "???");
    yield return null;
  }
  
  private void Start() {
    alerter = new Alerter();
  }
}
