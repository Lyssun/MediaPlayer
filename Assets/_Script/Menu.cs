using UnityEngine;
using UnityEngine.SceneManagement;


/**
 * Method allowing to load the mediaplayer or to quit the application.
 */
public class Menu : MonoBehaviour {

    /**
     * Load the mediaPlayer Scene
     */
	public void Jouer () {
        SceneManager.LoadScene(1);
	}
	
    /**
     * Quit the application.
     */
    public void Quitter ()
    {
        Application.Quit();
    }
}
