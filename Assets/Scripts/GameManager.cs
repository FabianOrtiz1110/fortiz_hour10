using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public GoalScript blue, green, red, orange;
	private bool isGameOver = true;
	private float elapsedTime = 0;
	private bool isRunning = true;	

	private void StartGame()
	{
		elapsedTime = 0;
		isRunning = true;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	void Update ()
	{
		// If all four goals are solved then the game is over
		isGameOver = blue.isSolved && green.isSolved && red.isSolved && orange.isSolved;

		// Add time to the clock if the game is running

		if (isRunning)
		{
			elapsedTime = elapsedTime + Time.deltaTime;
		}
	}		



	public void OnGUI()
	{
		if(isGameOver) {
			Rect rect = new Rect (Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 75);
			GUI.Box (rect, "Game Over");
			Rect rect2 = new Rect (Screen.width / 2 - 30, Screen.height / 2 - 25, 60, 50);
			GUI.Label (rect2, "Good Job!");
			GUI.Box(new Rect(Screen.width / 2 - 65, Screen.height - 115, 130, 40), "Your Time Was");
			GUI.Label(new Rect(Screen.width / 2 - 10, Screen.height - 100, 20, 30), ((int)elapsedTime).ToString());
			isRunning = false;

			string message; 
			{
				message = "Press Enter to Play Again";
			}

			//Define a new rectangle for the UI on the screen
			Rect startButton = new Rect(Screen.width/2 - 120, Screen.height/2 + 50, 240, 40);

			if (GUI.Button(startButton, message) || Input.GetKeyDown(KeyCode.Return))
			{
				//start the game if the user clicks to play
				StartGame ();
			}

		}
		else if(isRunning)
		{ 
			// If the game is running, show the current time
			GUI.Box(new Rect(Screen.width / 2 - 65, Screen.height - 115, 130, 40), "Your Time Is");
			GUI.Label(new Rect(Screen.width / 2 - 10, Screen.height - 100, 20, 30),  ((int)elapsedTime).ToString());
		}
	}
}