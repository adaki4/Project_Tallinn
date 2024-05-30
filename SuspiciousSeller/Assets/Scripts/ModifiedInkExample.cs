using System;
using Ink.Runtime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// This is a super bare bones example of how to play and display a ink story in Unity.
public class ModifiedInkExample : MonoBehaviour {
    public static event Action<Story> OnCreateStory;
	public static ModifiedInkExample instance;
	[SerializeField]
	private  Image image;
	[SerializeField]
	private TextAsset inkJSONAsset = null;
	public Story story;

	[SerializeField]
	public Canvas canvas = null;

	// UI Prefabs
	[SerializeField]
	private Text textPrefab = null;
	[SerializeField]
	private Button buttonPrefab = null;
    void Awake () {
		// Remove the default message
		image = canvas.gameObject.GetComponentInChildren<Image>();
		RemoveChildren();

		//only start story if its a story scene like the introduction or ending

        if (instance == null)
        {
            instance = this;
        }

		if (inkJSONAsset != null) StartStory();
    }

	// Creates a new Story object with the compiled story which we can then play!
	public void StartStory (TextAsset inkFile=null) {
		if (inkFile != null)
		{
			Debug.Log(inkFile.text);
			//Assign story 
			inkJSONAsset=inkFile;
			//variables
		}
		story = new Story (inkJSONAsset.text);

        // If NPC has story variables, update the story with them before progressing with it
        

        if (OnCreateStory != null) OnCreateStory(story);
		RefreshView();

        if(GameManager.instance!=null) GameManager.instance.FreezePlayer(true);
    }
	
	// This is the main function called every time the story changes. It does a few things:
	// Destroys all the old content and choices.
	// Continues over all the lines of text, then displays all the choices. If there are no choices, the story is finished!
	void RefreshView () {
		// Remove all the UI on screen
		RemoveChildren ();
		
		// Read all the content until we can't continue any more
		while (story.canContinue) {
			// Continue gets the next line of the story
			string text = story.Continue ();
			// This removes any white space from the text.
			text = text.Trim();
			// Display the text on screen!
			CreateContentView(text);
		}

		// Display all the choices, if there are any!
		if(story.currentChoices.Count > 0) {
			for (int i = 0; i < story.currentChoices.Count; i++) {
				Choice choice = story.currentChoices [i];
				Button button = CreateChoiceView (choice.text.Trim ());
				// Tell the button what to do when we press it
				button.onClick.AddListener (delegate {
					OnClickChoiceButton (choice);
				});
			}
		}
		// If we've read all the content and there's no choices, the story is finished!
		else {
			EndStory();
		}
	}

	void EndStory()
	{
        string currentScene = ScenesManager.instance.GetCurrentSceneName();
		Debug.Log(currentScene);
        string endingButtonMessage = " ";
        switch (currentScene)
        {
            case "StoreScene":
				{
					endingButtonMessage = "End Conversation"; break;
				}
            case "Introduction":
				{
					endingButtonMessage = "Start Criminal Life"; break;
				}
            case "Ending":
				{
					endingButtonMessage = "The end"; break;
				}
        }
        Button choice = CreateChoiceView(endingButtonMessage);
        choice.onClick.AddListener(delegate {
            //StartStory();

            if(GameManager.instance!=null) GameManager.instance.FreezePlayer(false);
            if (currentScene == "Introduction") { ScenesManager.instance.NewGame(); }
			else if (currentScene == "Ending") {/*finish game, restart?*/}
			RemoveChildren();

        });
    }
	// When we click the choice button, tell the story to choose that choice!
	void OnClickChoiceButton (Choice choice) {
		story.ChooseChoiceIndex (choice.index);
		RefreshView();
	}

	// Creates a textbox showing the the line of text
	void CreateContentView (string text) {
		Text storyText = Instantiate (textPrefab) as Text;
		storyText.text = text;
		storyText.transform.SetParent (image.gameObject.transform, false);
	}

	// Creates a button showing the choice text
	Button CreateChoiceView (string text) {
		// Creates the button from a prefab
		Button choice = Instantiate (buttonPrefab) as Button;
		choice.transform.SetParent (image.gameObject.transform, false);
		
		// Gets the text from the button prefab
		Text choiceText = choice.GetComponentInChildren<Text> ();
		choiceText.text = text;

		// Make the button expand to fit the text
		HorizontalLayoutGroup layoutGroup = choice.GetComponent <HorizontalLayoutGroup> ();
		layoutGroup.childForceExpandHeight = false;

		return choice;
	}

	// Destroys all the children of this gameobject (all the UI)
	void RemoveChildren () {
		int childCount = image.gameObject.transform.childCount;
		for (int i = childCount - 1; i >= 0; --i) {
			if (!image.gameObject.transform.GetChild(i).gameObject.CompareTag("DontKillChild")) {
				Destroy (image.gameObject.transform.GetChild (i).gameObject);
			}
		}
	}
}
