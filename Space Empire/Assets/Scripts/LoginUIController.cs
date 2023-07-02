using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System;

public class LoginUIController : MonoBehaviour
{
    VisualElement loginPanel;
    TextField emailText;
    TextField passwordText;
    Button forgotPasswordButton;
    Button loginButton;
    Button registerButton;
    Label errorText;
    VisualElement enterMailPanel;
    Label enterMailErrorText;
    TextField enterMailText;
    public Button enterMailButton;
    public Button enterMailCancelButton;
    public VisualElement verifyCodePanel;
    public Label verifyCodeErrorText;
    public Button sendAgainButton;
    public TextField verifyCodeText;
    public Button verifyCodeButton;
    public Button verifyCodeCancelButton;
    public VisualElement resetPasswordPanel;
    public Label resetPasswordErrorText;
    public TextField resetPasswordText;
    public TextField resetPasswordAgainText;
    public Button resetPasswordButton;

    string code;

    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        loginPanel = root.Q<VisualElement>("loginPanel");
        emailText = root.Q<TextField>("emailText");
        passwordText = root.Q<TextField>("passwordText");
        forgotPasswordButton = root.Q<Button>("forgotPasswordButton");
        loginButton = root.Q<Button>("loginButton");
        registerButton = root.Q<Button>("registerButton");
        errorText = root.Q<Label>("errorText");

        enterMailPanel = root.Q<VisualElement>("enterMailPanel");
        enterMailErrorText = root.Q<Label>("enterMailErrorText");
        enterMailText = root.Q<TextField>("enterMailText");
        enterMailButton = root.Q<Button>("enterMailButton");
        enterMailCancelButton = root.Q<Button>("enterMailCancelButton");

        verifyCodePanel = root.Q<VisualElement>("verifyCodePanel");
        verifyCodeErrorText = root.Q<Label>("verifyCodeErrorText");
        sendAgainButton = root.Q<Button>("sendAgainButton");
        verifyCodeText = root.Q<TextField>("verifyCodeText");
        verifyCodeButton = root.Q<Button>("verifyCodeButton");
        verifyCodeCancelButton = root.Q<Button>("verifyCodeCancelButton");

        resetPasswordPanel = root.Q<VisualElement>("resetPasswordPanel");
        resetPasswordErrorText = root.Q<Label>("resetPasswordErrorText");
        resetPasswordText = root.Q<TextField>("resetPasswordText");
        resetPasswordAgainText = root.Q<TextField>("resetPasswordAgainText");
        resetPasswordButton = root.Q<Button>("resetPasswordButton");

        loginPanel.style.display = DisplayStyle.Flex;
        enterMailPanel.style.display = DisplayStyle.None;
        verifyCodePanel.style.display = DisplayStyle.None;
        resetPasswordPanel.style.display = DisplayStyle.None;

        loginButton.clicked += loginButtonClicked;
        registerButton.clicked += registerButtonClicked;
        forgotPasswordButton.clicked += forgotPassClicked;
        enterMailButton.clicked += enterMailButtonClicked;
        verifyCodeCancelButton.clicked += verifyCancelButtonClicked;
        verifyCodeButton.clicked += verifyCodeButtonClicked;
        sendAgainButton.clicked += sendMail;

        emailText.value = "doganneslihan84@gmail.com";
        passwordText.value = "123456";
    }

    async void loginButtonClicked()
    {
        if (emailText.text.Trim() != "" && passwordText.text.Trim() != "")
        {
            string loginResponse = await RealmController.Instance.Login(
                emailText.value.Trim(),
                passwordText.value.Trim()
            );
            if (loginResponse == "")
            {
                SceneManager.LoadScene("MainScene");
            }
            else
            {
                errorText.style.display = DisplayStyle.Flex;
                errorText.text = "Error: " + loginResponse;
            }
        }
        else
        {
            errorText.style.display = DisplayStyle.Flex;
            errorText.text = "Error: Email and password fields are required.";
        }
    }

    void registerButtonClicked()
    {
        SceneManager.LoadScene("RegisterScene");
    }

    void forgotPassClicked()
    {
        loginPanel.style.display = DisplayStyle.None;
        enterMailPanel.style.display = DisplayStyle.Flex;
    }

    void enterMailButtonClicked()
    {
        enterMailPanel.style.display = DisplayStyle.None;
        verifyCodePanel.style.display = DisplayStyle.Flex;
        sendMail();
    }

    async void sendMail(){
        Guid uniqueId = Guid.NewGuid();
        code = uniqueId.ToString().Substring(0, 8);
        await SendMailController.Execute(
            enterMailText.text.Trim(),
            "Verify Code! - Reset Password",
            "Please enter the verification code in the required field.",
            "Verify Code: " + code
        );
    }

    void verifyCancelButtonClicked()
    {
        enterMailPanel.style.display = DisplayStyle.Flex;
        verifyCodePanel.style.display = DisplayStyle.None;
    }

    void verifyCodeButtonClicked()
    {
        if (verifyCodeText.text.Trim() == code)
        {
            resetPasswordPanel.style.display = DisplayStyle.Flex;
            verifyCodePanel.style.display = DisplayStyle.None;
        }
        else
        {
            verifyCodeErrorText.style.display = DisplayStyle.Flex;
            verifyCodeErrorText.text = "You entered the wrong code. Please check again.";
        }
    }
}
