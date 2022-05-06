using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Modal : MonoBehaviour
{
  public GameObject modal;
  public GameObject instructionPanel;
  public GameObject gameoverPanel;
  public GameObject winPanel;

  public Text winText;


  void Start()
  {
    ShowInstruction();
  }
  public void ShowInstruction()
  {
    modal.SetActive(true);
    instructionPanel.SetActive(true);    
    gameoverPanel.SetActive(false);
    winPanel.SetActive(false);    
  }

  public void ShowGameover()
  {
    modal.SetActive(true);
    instructionPanel.SetActive(false);    
    gameoverPanel.SetActive(true);
    winPanel.SetActive(false);    
  }

  public void ShowWin()
  {
    modal.SetActive(true);
    instructionPanel.SetActive(false);    
    gameoverPanel.SetActive(false);
    winPanel.SetActive(true);        
  }

  public void Play()
  {
    instructionPanel.SetActive(false);    
    gameoverPanel.SetActive(false);
    winPanel.SetActive(false);    
  }

  public void Retry(string scene)
  {
    SceneManager.LoadScene(scene);
  }
}
