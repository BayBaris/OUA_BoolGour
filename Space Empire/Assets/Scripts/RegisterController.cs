using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro; 
using UnityEngine.UIElements;

public class RegisterController : MonoBehaviour {

    public UnityEngine.UI.Button RegisterButton;
    public UnityEngine.UI.Button CancelButton;
    public TMP_InputField NameInput;
    public TMP_InputField UsernameInput;
    public TMP_InputField PasswordInput;
    public TextMeshProUGUI ErrorText;
    public UIDocument verifywindow;
    

    void Awake() {
        ErrorText.gameObject.SetActive(false);
    }

    void Start() {
        NameInput.text = "";
        UsernameInput.text = "";
        PasswordInput.text = "";
        RegisterButton.onClick.AddListener(Register);
        CancelButton.onClick.AddListener(Login);
    }

    void VerifyCodeWindow(){
        verifywindow.gameObject.SetActive(true);
    }

    async void Register() {
        string registerResponse = await RealmController.Instance.Register(NameInput.text, UsernameInput.text, PasswordInput.text);
        if(registerResponse == "") {
            SceneManager.LoadScene("MainScene");
        } else {
            ErrorText.gameObject.SetActive(true);
            ErrorText.text = "ERROR: " + registerResponse;
        }
    }

    void Login() {
        SceneManager.LoadScene("LoginScene");
    }

    void Update() {
        if(Input.GetKey("escape")) {
            Application.Quit();
        }
    }

}