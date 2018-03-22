using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker :MonoBehaviour {

	// Game state
	int level;
	enum Screen { MainMenu, Password, Win };
	Screen currentScreen;

	// Use this for initialization
	void Start () {
		ShowMainMenu();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnUserInput(string input) {
		if (input == "menu") {
			ShowMainMenu();
		} else if (currentScreen == Screen.MainMenu) {
			RunMainMenu(input);
		} else if (currentScreen == Screen.Password) {
            if (level == 1 && input == "foobar") {
                Terminal.WriteLine("Congratulations, you're in!");
            } else if (level == 2 && input == "bizbaz") {
                Terminal.WriteLine("Congratulations, you're in!");
            } else if (level == 3 && input == "fizbar") {
                Terminal.WriteLine("Congratulations, you're in!");
            } else {
                Terminal.WriteLine("access denied");
            }
		} else if (currentScreen == Screen.Win) {

		}
	}

	void ShowMainMenu() {
		currentScreen = Screen.MainMenu;

		Terminal.ClearScreen();
		Terminal.WriteLine("What would you like to hack into?\n\n" +
			"Press 1 for the high school\n" +
			"Press 2 for the police department\n" +
			"Press 3 for the government\n\n" +
			"Enter your selection: "
		);
	}

	void RunMainMenu(string input) {
		if (input == "1") {
			level = 1;
			StartGame();
		} else if (input == "2") {
			level = 2;
			StartGame();
		} else if (input == "3") {
			level = 3;
			StartGame();
		} else if (input == "007") {
			Terminal.WriteLine("Please choose a level, Mr. Bond.");
		} else {
			Terminal.WriteLine("Please choose a valid level.");
		}
	}

	void StartGame() {
		currentScreen = Screen.Password;
		Terminal.WriteLine("You have chosen level " + level);
		Terminal.WriteLine("Please enter your password: ");
	}
}
