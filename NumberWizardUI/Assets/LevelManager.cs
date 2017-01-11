using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	// needs to be public, to call loadlevel in unity..
	public void LoadLevel(string name) {
		Debug.Log ("Level load requested for: " + name);
		Application.LoadLevel(name);
		// this takes us to the next game scene
	}
	
	public void Quit() {
		Debug.Log ("The Game Will Now Exit.");
		Application.Quit(); 
		// bad practices for applications, only works for windows builds and pc builds
		// doesn't work for web builds
		// better to let the users system handle quit requests
	}
}
