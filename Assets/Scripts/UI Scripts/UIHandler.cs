using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIHandler : MonoBehaviour
{
    [SerializeField] TMP_Text titleText;
    [SerializeField] Button placeHolder;
    [SerializeField] Button gameButton;
    [SerializeField] Button creditsButton;
    [SerializeField] Button optionsButton;
    [SerializeField] Button rulesButton;

    public static bool isOnGame = false;
    public static bool isOnCredits = false;
    public static bool isOnOptions = false;
    public static bool isOnRules = false;
    public static bool playMainMusicOnLoop = true;

    // Update is called once per frame
    void Update()
    {
        if(!SceneManager.GetSceneByName("Options UI").isLoaded)
            placeHolder.Select();
        

        if (isOnGame && !isOnCredits && !isOnOptions && !isOnRules) // clicked on Start Game
        {
            hideAll();
        }
        else if (!isOnGame && isOnCredits && !isOnOptions && !isOnRules) // clicked on Credits
        {
            hideAll();
        }
        else if(!isOnGame && !isOnCredits && isOnOptions && !isOnRules) // clicked on Options
        {
            gameButton.gameObject.SetActive(false);
            creditsButton.gameObject.SetActive(false);
            optionsButton.gameObject.SetActive(false);
            rulesButton.gameObject.SetActive(false);
        }
        else if(!isOnGame && !isOnCredits && !isOnOptions && isOnRules) // clicked on How to play
        {
            gameButton.gameObject.SetActive(false);
            creditsButton.gameObject.SetActive(false);
            optionsButton.gameObject.SetActive(false);
            rulesButton.gameObject.SetActive(false);
        }
        else // Is on main menu
        {
            showAll();
            if (playMainMusicOnLoop)
            {
                playMainMusic();
                playMainMusicOnLoop = false;
            }
        }
    }

    void showAll()
    {
        titleText.gameObject.SetActive(true);
        gameButton.gameObject.SetActive(true);
        creditsButton.gameObject.SetActive(true);
        optionsButton.gameObject.SetActive(true);
        rulesButton.gameObject.SetActive(true);
    }

    void hideAll()
    {
        titleText.gameObject.SetActive(false);
        gameButton.gameObject.SetActive(false);
        creditsButton.gameObject.SetActive(false);
        optionsButton.gameObject.SetActive(false);
        rulesButton.gameObject.SetActive(false);
    }

    void playMainMusic()
    {
        MusicPlayer.playMusic("main music");
    }
}
