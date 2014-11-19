using UnityEngine;
using System.Collections;

public class Dialogue : MonoBehaviour {

	public string[] text01;
	private bool showText;
	private string currentTextLine;
	public Player player;

	public int windowWidth = 100;
	public int windowHeight = 100;
	public int offsetY = -50;

	string scene = "start";
	

	void OnGUI()
	{
		//GUI.skin = skin;
		
		
		GUILayout.BeginArea(new Rect(50,50, 250,250));
		
		if(scene == "start")
		{
			GUILayout.BeginVertical();
			GUILayout.Label("Howdy.");
			
			if(GUILayout.Button("O hai."))
			{
				scene = "hello";
			}
			
			if(GUILayout.Button("Where the party is?"))
			{
				scene = "party";
			}
			
			GUILayout.EndVertical();
		}
		else if(scene == "hello")
		{
			GUILayout.BeginVertical();
			GUILayout.Label("Cool talk to you later.");
			GUILayout.EndVertical();
		}
		else if(scene == "party")
		{
			GUILayout.BeginVertical();
			GUILayout.Label("I would also like to know.");
			GUILayout.EndVertical();
		}
		
		GUILayout.EndArea();

		/*
		 * 
		 Vector3 getPixelPos = Camera.main.WorldToScreenPoint( player.transform.position );
		getPixelPos.y = Screen.height - getPixelPos.y;
		GUI.Label( new Rect(getPixelPos.x - windowWidth/2 ,getPixelPos.y + offsetY - windowHeight, windowWidth, windowHeight) , "It's Me, Mario! :D");

		 */
	}
}