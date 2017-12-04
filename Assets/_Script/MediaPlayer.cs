using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

/**
 * Play a video which is located in the folder /Video of the project,
 * When we finished to play every video, we return to the menu.
 */
public class MediaPlayer : MonoBehaviour {
    
    /**
     * List of the url of the video. We update it at every new video
     */
    private List<string> listVideo;
    /**
     * Counter allowing us to know the actual position
     */
    private int compteur = -1;

    /**
     * Launch at the start of the scene, get the videoPlayer and
     * set the volume to the level chosen by the user
     * Add the Auto changing function at the end of the video.
     */
    void Start()
    {
        VideoPlayer videoPlayer = GetComponent<VideoPlayer>();
        SetVolume();
        listVideo = ListUrlOfVideo;
        videoPlayer.loopPointReached += EndReached;
        EndReached(videoPlayer);
    }

    /**
     * Get the url to all the .MP4 file in the /Video directory
     * Go to the menu and print an error message if the directory isn't found
     */
    List<string> ListUrlOfVideo
    {
        get
        {
            try
            {
                return Directory.GetFiles(Application.dataPath + "/Video", "*.mp4").ToList();
            }
            catch (System.Exception)
            {
                PlayerPrefs.SetString("Error", "1");
                SceneManager.LoadScene(0);
            }
            return null;
        }
    }

    /**
     * Change to the next video,
     * If the value of the counter is out of bound, we load the menu.
     */
    void EndReached(VideoPlayer vp)
    {
        listVideo = ListUrlOfVideo;
        if (++compteur < listVideo.Count())
        {
            if (listVideo[compteur] != null)
            {

                vp.url = listVideo[compteur];
                vp.Play();
            }
        }
        else
            SceneManager.LoadScene(0);
    }

    /**
     * Load and play the next video.
     */
    public void NextVideo()
    {
        if (GetComponent<VideoPlayer>().isPlaying)
            EndReached(GetComponent<VideoPlayer>());
    }

    /**
     * Change to the previous video,
     * If the value of the counter is out of bound, we load the menu.
     */
    public void PrevVideo()
    {
        if (GetComponent<VideoPlayer>().isPlaying)
        {
            listVideo = ListUrlOfVideo;
            if (--compteur < listVideo.Count() && compteur >= 0)
            {
                if (listVideo[compteur] != null)
                {
                    VideoPlayer vp = GetComponent<VideoPlayer>();
                    vp.url = listVideo[compteur];
                    vp.Play();
                }
            }
            else
                SceneManager.LoadScene(0);
        }
    }

    /**
     * Load the volume information from the PlayerPrefs and change the sound level of the audioSource
     */
    void SetVolume()
    {
        if (PlayerPrefs.HasKey("Volume"))
            GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Volume");
    }
}
