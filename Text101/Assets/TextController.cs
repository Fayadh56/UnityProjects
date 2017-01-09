/* Project Name: Text101 - Hitman - Piano Redemption
 * Creator: Fayadh A. 
 * Github: @fayadh56
 * Unity 4.6.9
 * -----------------------------------------------------------------------
 * Revision History
 * -----------------------------------------------------------------------
 * 08/01/2017 - Created Initial Version of the Game, Finished Cell Scene.
 * -----------------------------------------------------------------------
 * To Do:
 * Add the Second Scene, from the Story. 
 *
 */
using UnityEngine;
// need to import UnityEngine.UI namespace, needed whenever you do something with the UI. 
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	// create a text variable,  of type Text which is public
	public Text text;
	
	private enum States {cell, bed_0, wire, lock_0, bed_1, take_wire, cell_wire, whistle, take_keys, freedom};
	private States currentState;
	
	// Use this for initialization
	void Start () {
		text.text = "Welcome to Hitman, Press the Space Bar to begin.";
		currentState = States.cell;
	}
	
	// Update is called once per frame
	void Update () {
	print (currentState); // log to console
	
		if ((currentState == States.cell)) 			{state_cell();} 
		else if (currentState == States.bed_0) 		{state_bed_0();}
		else if (currentState == States.wire) 		{state_wire();}
		else if (currentState == States.lock_0)  	{state_lock_0();}
		else if (currentState == States.bed_1)		{state_bed_1();}
		else if (currentState == States.take_wire) 	{state_take_wire();}
		else if (currentState == States.cell_wire)  {state_cell_wire();}
		else if (currentState == States.whistle) 	{state_whistle();}
		else if (currentState == States.take_keys)  {state_take_keys();}
		else if (currentState == States.freedom)	{state_freedom();}
	}
	
	void state_cell () {
		text.text = "You wake up groggy from the night before, where am I? You look around, it looks like a prision cell..huh??? " +
					"How did you get here? You see a bed, and the locked door. You see something else its glinting, what could it" +
				    " be? Could you use it is to make your escape? You are No47 afterall you think to yourself.\n\nPress B to " +
				    "look under the Bed, D to try the Door or S to inspect the Shiny object";
				    
		if (Input.GetKeyDown(KeyCode.B)) 			{currentState = States.bed_0;} //look under bed
		else if (Input.GetKeyDown(KeyCode.D))		{currentState = States.lock_0;} //try the door
		else if (Input.GetKeyDown(KeyCode.S))		{currentState = States.wire;} //inspect shiny object
	}
	
	void state_bed_0 () {
		text.text = "You decide to look under the bed, Yuck you wish you hadn't. Do they not clean these places in prisons you wonder? " +
					"As you brush off cobwebs from your face, and was that a dead rat you saw under there? Disgusting.\n\n" +
					"Press R to return to roaming your cell. ";
		if (Input.GetKeyDown (KeyCode.R)) 			{currentState = States.cell;}
	}
	
	void state_bed_1 () {
		text.text = "Having the Piano Wire doesn't make the cobwebs or the dead rats go away. No way you're going under there." + 
					"\n\nPress R to return to your cell.";
		if (Input.GetKeyDown (KeyCode.R)) 			{currentState = States.cell_wire;} // return to the cell with wire
	}
	
	void state_wire() {
		text.text = "You look around for the shiny object, its on some kind of shelf. It's some piano wire! You start to grin, " + 
					"as if what you were about to do has been drilled into your muscle memory.\n\nPress T to Take the wire, or " + 
					"Press R to return to roaming your cell.";
		if (Input.GetKeyDown (KeyCode.T)) 			{currentState = States.take_wire;} //take the wire
		else if (Input.GetKeyDown(KeyCode.R))		{currentState = States.cell;} //return to cell
	}
	
	void state_lock_0() {
		text.text = "This is one of those old school locks. You wish you had something to fashion a pick out of, as you've " + 
					"picked locks like this dozens of times.\n\nPress R to return to your cell.";
		if (Input.GetKeyDown(KeyCode.R))		   {currentState = States.cell;} //return to cell
	}
	
	void state_take_wire() {
		text.text = "You grab the Piano Wire, knowing what you could do with it.\n\nPress R to continue roaming your cell.";
		if (Input.GetKeyDown(KeyCode.R))		   {currentState = States.cell_wire;} //return to cell
	}
	
	void state_cell_wire() {
		text.text = "The name \"Agent 47\" is just a whisper on the lips of the dead... because if he comes calling for " + 
					"you... you will never even know... until it's too late. Then, like a ghost, he'll disappear. A phantom. " + 
					"A legend. But what would happen if the legend was finally exposed as fact... and the cold sights of death " + 
					"were finally aimed on him?\nHuh? Did I just say that outloud? What the? You hear footsteps in the distance, " + 
					"what do you do?\n\nPress B to hide under the bed, or Press W to Whistle.";
		if (Input.GetKeyDown(KeyCode.B))		   {currentState = States.bed_1;} // under the bed again
		else if (Input.GetKeyDown(KeyCode.W))	   {currentState = States.whistle;} //whistle
	}
	
	void state_whistle() {
		text.text = "You whistle, \"Huh, what was that you hear someone say.\"\nThe guards almost at your cell, what do you do?" + 
					"\n\nPress K to Kill the Guard using the Piano Wire.";
		if (Input.GetKeyDown(KeyCode.K))		   {currentState = States.take_keys;} // kill the guard
	}
	
	void state_take_keys() {
		text.text = "This cell, this wire. There's a bullet for everyone. And a time. And a place. An end. Yes... maybe this " + 
					"is how it has to be. I have to escape. I can't let you keep me here.\n\nPress U to take the dead " + 
					"guards keys and unlock your cell.";
		if (Input.GetKeyDown(KeyCode.U))		   {currentState = States.freedom;}
	}
	
	void state_freedom() {
		text.text = "You unlock the cell, and step outside into the dimly lit corridor. The dead guards body lying on " + 
					"the floor beside you. What do you do? You take in your surroundings, you see some stairs across the " + 
					"hallway. There also appears to be a closet.\n\nPress S to try the Stairs, C to go into the closet and " + 
					"T to take the guards clothes.";
		if (Input.GetKeyDown(KeyCode.S))		   {currentState = States.cell;} // to be continued
		else if (Input.GetKeyDown(KeyCode.C))	   {currentState = States.cell;} // to be continued
		else if (Input.GetKeyDown(KeyCode.T))	   {currentState = States.cell;} // to be continued
	}
}
