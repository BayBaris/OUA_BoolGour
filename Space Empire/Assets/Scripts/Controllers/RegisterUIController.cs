using System.Collections;
using System.Collections.Generic;
using System;
using System.Net.Mail;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class RegisterUIController : MonoBehaviour
{
    VisualElement registerPanel;
    Label registerErrorText;
    TextField nameText;
    TextField emailText;
    TextField passwordText;
    TextField confirmPasswordText;
    Button registerButton;
    Button loginButton;
    VisualElement verifyCodePanel;
    Label verifyCodeErrorText;
    Button sendAgainButton;
    TextField verifyCodeText;
    Button verifyCodeButton;
    Button verifyCodeCancelButton;
    string code;

    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        registerPanel = root.Q<VisualElement>("registerPanel");
        registerErrorText = root.Q<Label>("registerErrorText");
        nameText = root.Q<TextField>("nameText");
        emailText = root.Q<TextField>("emailText");
        passwordText = root.Q<TextField>("passwordText");
        confirmPasswordText = root.Q<TextField>("confirmPasswordText");
        registerButton = root.Q<Button>("registerButton");
        loginButton = root.Q<Button>("loginButton");
        verifyCodePanel = root.Q<VisualElement>("verifyCodePanel");
        verifyCodeErrorText = root.Q<Label>("verifyCodeErrorText");
        sendAgainButton = root.Q<Button>("sendAgainButton");
        verifyCodeText = root.Q<TextField>("verifyCodeText");
        verifyCodeButton = root.Q<Button>("verifyCodeButton");
        verifyCodeCancelButton = root.Q<Button>("verifyCodeCancelButton");

        registerPanel.style.display = DisplayStyle.Flex;
        verifyCodePanel.style.display = DisplayStyle.None;

        loginButton.clicked += loginButtonClicked;
        registerButton.clicked += registerButtonClicked;
        sendAgainButton.clicked += sendMail;
        verifyCodeButton.clicked += verifyCodeButtonClicked;
        verifyCodeCancelButton.clicked += verifyCodeCancelButtonClicked;
    }

    void loginButtonClicked()
    {
        SceneManager.LoadScene("LoginScene");
    }

    void registerButtonClicked()
    {
        bool isEmail = IsValidEmail(emailText.text);
        if (
            nameText.text == ""
            || emailText.text == ""
            || passwordText.text == ""
            || confirmPasswordText.text == ""
        )
        {
            registerErrorText.text = "Please make sure to fill in all fields";
        }
        else if (passwordText.text != confirmPasswordText.text)
        {
            registerErrorText.text = "Password values do not match. Please check.";
        }
        else if (!isEmail)
        {
            registerErrorText.text = "Please make sure you have entered a valid email account.";
        }
        else
        {
            registerPanel.style.display = DisplayStyle.None;
            verifyCodePanel.style.display = DisplayStyle.Flex;
            sendMail();
        }
    }

    async void sendMail()
    {
        Debug.Log("sendmail");
        Guid uniqueId = Guid.NewGuid();
        code = uniqueId.ToString().Substring(0, 8);
        await SendMailController.Execute(
            emailText.text.Trim(),
            "Verify Code! - Verify Your E-mail Address",
            "Please enter the verification code in the required field.",
            "Verify Code: " + code
        );
    }

    void verifyCodeButtonClicked(){
        if (code != verifyCodeText.text)
        {
            verifyCodeErrorText.style.display = DisplayStyle.Flex;
            verifyCodeErrorText.text = "The verification code is incorrect. Please try again.";
        }else{
            Register();
        }
    }

    void verifyCodeCancelButtonClicked(){
        verifyCodePanel.style.display = DisplayStyle.None;
        registerPanel.style.display = DisplayStyle.Flex;
    }

    async void Register() {
        string registerResponse = await RealmController.Instance.Register(nameText.text, emailText.text, passwordText.text);
        if(registerResponse == "") {
            SceneManager.LoadScene("MenuScene");
        } else {
            verifyCodeErrorText.style.display = DisplayStyle.Flex;
            verifyCodeErrorText.text = registerResponse;
        }
    }

    static bool IsValidEmail(string email)
    {
        try
        {
            MailAddress mailAddress = new MailAddress(email);
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }
}
