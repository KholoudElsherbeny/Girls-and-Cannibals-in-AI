using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
  public Text highScoreText;
  public TimeSpan highScore;

  void Update()
  {
    highScoreText.text = new DateTime(highScore.Ticks).ToString("mm:ss");
  }
}
