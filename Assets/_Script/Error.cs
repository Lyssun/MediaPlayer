using UnityEngine;

/**
 * Let the Error message appear on the menu if we got an error.
 */

public class Error : MonoBehaviour {
    [SerializeField]
    [Tooltip("The Canvas of the error message")]
    private GameObject errorMsg;

    /**
     * Hide the error message if we don't have any error in playerPrefs.
     * Otherwise, that would print the message and delete the playerPrefs key
     */
    void Start()
    {
        if (PlayerPrefs.HasKey("Error"))
        {
            //errorMsg.SetActive(true);
            Destroy(errorMsg, 3f);
            PlayerPrefs.DeleteKey("Error");
        }
        else
        {
            errorMsg.SetActive(false);
        }

    }


}
