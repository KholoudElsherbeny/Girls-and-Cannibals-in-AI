using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
  public Text stopwatchText;
  public bool isPaused = false;
  public Stopwatch stopwatch;

  void Start()
  {
    Initialize();
  }

  void Initialize()
  {
    stopwatch = new Stopwatch();
  }

  void Update()
  {
    HandleStopwatch();
    SetStopwatchText();
  }

  void HandleStopwatch()
  {
    if (isPaused)
      stopwatch.Stop();
    else
      stopwatch.Start();
  }

  void SetStopwatchText()
  {
    stopwatchText.text = GetTime();
  }

  public string GetTime()
  {
    return new DateTime(stopwatch.Elapsed.Ticks).ToString("mm:ss");
  }
}
