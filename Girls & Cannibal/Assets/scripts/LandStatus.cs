using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LandStatus : MonoBehaviour
{
  public List<Image> icons;

  public Sprite playerIcon;
  public Sprite emptyIcon;

  public void RenderIcon(int playerNum)
  {
    ResetIcon();

    for (int i = 0; i < playerNum; i++)
    {
      icons[i].sprite = playerIcon;
    }
  }

  void ResetIcon()
  {
    foreach (Image icon in icons)
    {
      icon.sprite = emptyIcon;
    }
  }
}
