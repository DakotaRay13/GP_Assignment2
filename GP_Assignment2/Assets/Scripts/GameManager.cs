using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static float BALL_SPEED = 1f;
    public static Color BALL_COLOR = new Color(255, 0, 0);
    public static bool BALL_OVERSIZE = false;

    public float GetBallSpeed()
    {
        return BALL_SPEED;
    }

    public Color GetBallColor()
    {
        return BALL_COLOR;
    }

    public bool IsBallOversized()
    {
        return BALL_OVERSIZE;
    }

    public void ChangeBallSpeed(float newSpeed)
    {
        BALL_SPEED = newSpeed;
    }

    public void ChangeBallColor(Color newColor)
    {
        BALL_COLOR = newColor;
    }

    public void ChangeBallOverSized(bool newSetting)
    {
        BALL_OVERSIZE = newSetting;
    }
}
