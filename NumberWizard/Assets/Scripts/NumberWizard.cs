/*  NumberWizard.cs
 *  Author: Fayadh Ahmed
 *
 *  Created: 07/01/2017
 *  Description: Simple number guessing game that runs in the unity console, and allows the user to set the guessing number range
 *  utilizes binary search to accomplish the guess. 
 *  
 *  Made with Unity 4.6.9
 */



using UnityEngine;
using System.Collections;

public class NumberWizard : MonoBehaviour {

	int maximum;
	int minimum;
	int guess;
	private string userInput;
	
	private bool minSet;
	private bool maxSet;
	private bool ready;
	private bool printInstr;
	
	// Use this for initialization
	void Start () {
		StartGame ();
	}
	
	
	// Update is called once per frame
	void Update () {
	
		// det if game needs initializing 
		if (ready == false) {
			// initialize
			if (minSet == false){ 
				// get min value
				if (printInstr == true) {
					print ("Set the min value: ");
					printInstr = false;
					userInput = "";
				}
				getUserInput("Min"); 
			}
			else if (maxSet == false){ 
				if (printInstr == true) {
					print ("Set the max value now");
					printInstr = false;
					userInput = "";
				}
				getUserInput("Max"); 
			}
			else {
			//min and max are now set
			print ("Now pick a number between " + maximum + " and " + minimum + " and keep it in memory");
			maximum += 1;
			guess = Random.Range(maximum, minimum);
			print ("Is the Number Higher or Lower than " + guess + " ?");
			print ("Up Key if Higher, Down if Lower, and Enter if Correct!");
			
			// game is now ready
			ready = true;
			}
		} else {
			if (Input.GetKeyDown(KeyCode.UpArrow)) {
				//print("Up Arrow Pressed");
				minimum = guess;
				NextGuess();
			} else if (Input.GetKeyDown(KeyCode.DownArrow)) {
				//print("Down Arrow Pressed");
				maximum = guess;
				NextGuess();
			} else if (Input.GetKeyDown(KeyCode.Return)) {
				print("YOU WON!");
				StartGame();
			}
		}
		
		
	}
	
	void StartGame() {
		
		print ("========================================");
		print ("Welcome to Number Wizard!");
		print ("Please Enter a Maximum and Minimum Value for the game: ");
		//guess the number
		ready = false;
		minSet = false;
		maxSet = false;
		printInstr = true;
		
	}
	
	void NextGuess() {
		guess = Random.Range(maximum, minimum);
		print ("Is it Higher or Lower than" + guess);
	}
	
	void getUserInput(string valueType) {
		foreach (char c in Input.inputString) {
			if (c == "\b"[0]) {
				// User pressed backspace
				if (userInput.Length != 0) {
					userInput = userInput.Substring(0, userInput.Length - 1);
					// delete the last char if it exists
				}
			}
			else if (c == "\n"[0] || c == "\r"[0]) {
				// User pressed the Enter or Return Key
				if (userInput.Length > 0) {
					// set the value based on the given type of value
					if (valueType == "Min") {
						minimum = int.Parse(userInput); // parse input from String to Integer
						print ("Minimum Value is now: " + minimum);
						minSet = true;
					}
					else if (valueType == "Max") {
						// max value gets the input then
						maximum = int.Parse(userInput);
						if (maximum > minimum) {
							print ("Maximum Value is now: " + maximum);
							maxSet = true;
						} else {
							// dont set maxSet = true, thus allowing max value to be input again
							print ("ERROR: Please input a value that is larger than your minimum value!");
						}	
						
					}
					userInput = "";
				}
			}
			else {
				// char input
				int no = 0;
				if (int.TryParse(c.ToString(), out no)) {
					//its a number
					userInput += no.ToString();
				}
			}
		}
	} // End get getUserInput()
	
}
	
