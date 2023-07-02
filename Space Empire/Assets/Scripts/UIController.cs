using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public TextField verifyCodeText;
    public Button continueButton;
    public Button cancelButton;
    public Label errorText;

    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        verifyCodeText = root.Q<TextField>("verifyCodeText");
        continueButton = root.Q<Button>("continueButton");
        cancelButton = root.Q<Button>("cancelButton");
        errorText = root.Q<Label>("errorText");

        continueButton.clicked += ContinueButtonClicked;
        cancelButton.clicked += CancelButtonClicked;
    }

    void ContinueButtonClicked()
    {
        SceneManager.LoadScene("MainScene");
    }
    void CancelButtonClicked()
    {
       gameObject.SetActive(false);
    }
}
