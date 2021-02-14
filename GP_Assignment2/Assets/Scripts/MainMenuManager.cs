using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    public GameManager gm;

    public Toggle oversizeBallToggle;
    public Slider speedSlider;
    public TextMeshProUGUI speedText;
    public TMP_Dropdown colorChoice;

    //Color Choices
    public Color blue = new Color(0, 0, 255);
    public Color red = new Color(255, 0, 0);
    public Color green = new Color(0, 255, 0);
    public Color orange = new Color(255, 165, 0);
    public Color purple = new Color(128, 0, 128);

    // Start is called before the first frame update
    void Start()
    {
        //Set the settings
        speedSlider.value = gm.GetBallSpeed();
        speedText.text = "Ball Speed: " + speedSlider.value.ToString("0.0");

        oversizeBallToggle.isOn = gm.IsBallOversized();

        SetColorMenu();
    }

    void SetColorMenu()
    {
        Color defaultChoice = gm.GetBallColor();

        if (defaultChoice == blue)
        {
            colorChoice.value = 0;
        }
        if (defaultChoice == red)
        {
            colorChoice.value = 1;
        }
        if (defaultChoice == green)
        {
            colorChoice.value = 2;
        }
        if (defaultChoice == orange)
        {
            colorChoice.value = 3;
        }
        if (defaultChoice == purple)
        {
            colorChoice.value = 4;
        }
    }

    public void OnOversizeToggle()
    {
        gm.ChangeBallOverSized(oversizeBallToggle.isOn);
    }

    public void OnSpeedChange()
    {
        gm.ChangeBallSpeed(speedSlider.value);
        speedText.text = "Ball Speed: " + speedSlider.value.ToString("0.0");
    }

    public void OnColorChange()
    {
        switch (colorChoice.value)
        {
            case 0:
                {
                    gm.ChangeBallColor(blue);
                    break;
                }
            case 1:
                {
                    gm.ChangeBallColor(red);
                    break;
                }
            case 2:
                {
                    gm.ChangeBallColor(green);
                    break;
                }
            case 3:
                {
                    gm.ChangeBallColor(orange);
                    break;
                }
            case 4:
                {
                    gm.ChangeBallColor(purple);
                    break;
                }
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MiniGame");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
