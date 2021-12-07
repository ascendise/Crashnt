using System;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{

    [SerializeField]
    private Button continueButton;

    public event EventHandler ContinueButtonClick;

    // Start is called before the first frame update
    void Start()
    {
        continueButton.onClick.AddListener(ContinueButton_OnClick);
    }

    private void ContinueButton_OnClick()
    {
        OnContinueButtonClick(this, EventArgs.Empty);
    }

    private void OnContinueButtonClick(object sender, EventArgs e)
    {
        ContinueButtonClick?.Invoke(this, EventArgs.Empty);
    }
}
