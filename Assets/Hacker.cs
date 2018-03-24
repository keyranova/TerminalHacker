using UnityEngine;

public class Hacker :MonoBehaviour {

    // Game configuration data
    string[] level1Passwords = { "books", "teacher", "science", "grades", "football", "dance" };
    string[] level2Passwords = { "handcuffs", "deputy", "detective", "criminal", "handgun", "arrested" };
    string[] level3Passwords = { "judicial", "executive", "secretary", "homeland", "collusion", "representatives" };
    const string menuHint = "Type \"menu\" to return to main menu.";

	// Game state
	int level;
	enum Screen { MainMenu, Password, Win };
	Screen currentScreen;
    string password;

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
        } else if (input == "quit" || input == "close" || input == "exit") {
            Terminal.WriteLine("If on the web, close the tab.");
            Application.Quit();
		} else if (currentScreen == Screen.MainMenu) {
			RunMainMenu(input);
		} else if (currentScreen == Screen.Password) {
            CheckPassword(input);
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
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");

        if (isValidLevelNumber) {
            level = int.Parse(input);
            StartGame();
        } else if (input == "007") {
			Terminal.WriteLine("Please choose a level, Mr. Bond.");
		} else {
			Terminal.WriteLine("Please choose a valid level.");
            Terminal.WriteLine(menuHint);
        }
	}

	void StartGame() {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
    }

    void SetRandomPassword() {
        int index;

        switch (level) {
            case 1:
                index = Random.Range(0, level1Passwords.Length);
                password = level1Passwords[index];
                break;
            case 2:
                index = Random.Range(0, level2Passwords.Length);
                password = level2Passwords[index];
                break;
            case 3:
                index = Random.Range(0, level3Passwords.Length);
                password = level3Passwords[index];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    void CheckPassword(string input) {
        if (input == password) {
            DisplayWinScreen();
        } else {
            StartGame();
        }
    }

    void DisplayWinScreen() {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }

    void ShowLevelReward() {
        switch(level) {
            case 1:
                Terminal.WriteLine("Here's a book. Try a harder difficulty for a better reward.");
                Terminal.WriteLine(@"
    _______
   /      /,
  /      //
 /______//
(______(/
");
                break;
            case 2:
                Terminal.WriteLine("Here's a get out of jail free card.\nHave fun!");
                Terminal.WriteLine(@"
  _ ________,
  >`(==(----'
 (__/~~`            
");
                break;
            case 3:
                Terminal.WriteLine("The country is now yours. Things could be worse.");
                Terminal.WriteLine(@"
  o____
  |\\//|
  |//\\|
  |
  |
");
                break;
            default:
                Debug.LogError("invalid level error.");
                break;
        }
    }
}
