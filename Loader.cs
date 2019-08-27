using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour {
  
  private void Update() {
    if (Input.GetButton("Shoot")) SceneManager.LoadScene("SampleScene");
  }
}
