using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
  public Timer timer;
  public HighScore highscore;
  string destination;
  FileStream file;
  BinaryFormatter bf;

  public int level;

  void Start()
  {
    Initialize();
    Load();
  }

  void Initialize()
  {
    destination = Application.persistentDataPath + "/save" + level + ".dat";
    bf = new BinaryFormatter();
  }

  public void Load()
  {
    if (File.Exists(destination))
    {
      file = File.OpenRead(destination);
      GameData gameData = (GameData)bf.Deserialize(file);
      highscore.highScore = gameData.highScore;
    }
    else
    {
      file = File.Create(destination);
      GameData gameData2 = new GameData();
      gameData2.highScore = new TimeSpan(0, 0, 0);
      bf.Serialize(file, gameData2);
      highscore.highScore = gameData2.highScore;
    }

    file.Close();
  }

  public void Save()
  {
    file = File.OpenWrite(destination);
    GameData gameData = new GameData();
    gameData.highScore = GetUpdatedHighScore();

    bf.Serialize(file, gameData);
    file.Close();
  }

  TimeSpan GetUpdatedHighScore()
  {
    TimeSpan highScoreTimeSpan = highscore.highScore;
    TimeSpan currentTimeSpan = timer.stopwatch.Elapsed;

    if (isCurrentTimeSpanFaster())
      return currentTimeSpan;
    else
      return highScoreTimeSpan;
  }

  bool isCurrentTimeSpanFaster()
  {
    TimeSpan highScoreTimeSpan = highscore.highScore;
    TimeSpan currentTimeSpan = timer.stopwatch.Elapsed;
    if (highScoreTimeSpan == new TimeSpan(0, 0, 0))
      return true;
    return TimeSpan.Compare(highScoreTimeSpan, currentTimeSpan) == 1;
  }

  public void Reset()
  {
    File.Delete(destination);
    Load();
  }
}