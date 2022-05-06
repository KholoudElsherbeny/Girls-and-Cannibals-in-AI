using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land : MonoBehaviour
{
  public List<GameObject> players;

  public LandStatus missionaryStatus;
  public LandStatus cannibalStatus;

  void Update()
  {
    UpdateStatus();
  }

  void UpdateStatus()
  {
    missionaryStatus.RenderIcon(GetMissionaryNumber());
    cannibalStatus.RenderIcon(GetCannibalNumber());
  }

  public void AddPlayer(GameObject player)
  {
    players.Add(player);
  }

  public void RemovePlayer(GameObject player)
  {
    players.Remove(player);
  }

  public int GetMissionaryNumber()
  {
    int num = 0;
    foreach (GameObject player in players)
    {
      if (player.CompareTag("Missionary"))
        num++;
    }
    return num;
  }

  public int GetCannibalNumber()
  {
    int num = 0;
    foreach (GameObject player in players)
    {
      if (player.CompareTag("Cannibal"))
        num++;
    }
    return num;
  }

  public Player GetMissionary()
  {
    foreach (GameObject player in players)
    {
      if (player.CompareTag("Missionary"))
        return player.GetComponent<Player>();
    }
    return null;
  }

  public Player GetCannibal()
  {
    foreach (GameObject player in players)
    {
      if (player.CompareTag("Cannibal"))
        return player.GetComponent<Player>();
    }
    return null;
  }
}
