using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneController : MonoBehaviour
{
    public Button playButton;
    public Button settingsButton;
    public TMPro.TMP_Dropdown dropdownButton;

    void Start()
    {
        playButton.onClick.AddListener(play);
        settingsButton.onClick.AddListener(settings);
        dropdownItemSelected(dropdownButton);
        dropdownButton.onValueChanged.AddListener(
            delegate
            {
                dropdownItemSelected(dropdownButton);
            }
        );
    }

    void play()
    {
        SceneManager.LoadScene("MainScene");
    }

    void settings()
    {
        SceneManager.LoadScene("SettingsScene");
    }

    void dropdownItemSelected(TMPro.TMP_Dropdown dropdown) { 
        if (dropdown.value == 1)
        {
            SceneManager.LoadScene("PlayerProfileScene");
        }else if(dropdown.value == 2){
            SceneManager.LoadScene("LoginScene");
        }
    }
}
