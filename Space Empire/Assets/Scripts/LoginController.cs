using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;    

public class LoginController : MonoBehaviour
{
    public Button LoginButton;
    public Button RegisterButton;
    
    public TMP_InputField UsernameInput;
    public TMP_InputField PasswordInput;

   void Start() {
        UsernameInput.text = "doganneslihan84@gmail.com";
        PasswordInput.text = "123456";
        LoginButton.onClick.AddListener(Login);
        RegisterButton.onClick.AddListener(RegisterOpen);
    }

    async void Login() {
        if(await RealmController.Instance.Login(UsernameInput.text, PasswordInput.text) != "") {
            SceneManager.LoadScene("MainScene");
        }
    }
    void RegisterOpen(){
        SceneManager.LoadScene("RegisterScene");
    }
}
