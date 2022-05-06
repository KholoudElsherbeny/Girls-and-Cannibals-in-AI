using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
  public bool isOnRight = false;
  public bool isMoving = false;
  public List<GameObject> players;

  private Animator animator;
  private AudioSource audioSource;

  void Start()
  {
    Initialize();
  }

  void Initialize()
  {
    animator = GetComponent<Animator>();
    audioSource = GetComponent<AudioSource>();
  }

  public void AddPlayer(GameObject player)
  {
    if (players.Count < 2)
    {
      players.Add(player);
    }
  }

  public void RemovePlayer(GameObject player)
  {
    players.Remove(player);
  }

  public void HandleMovement()
  {
    if (players.Count > 0 && !isMoving)
    {
      if (isOnRight)
        MoveLeft();
      else
        MoveRight();

      isOnRight = !isOnRight;
      ChangePlayerPosition(isOnRight);
    }
  }

  public void MoveLeft()
  {
    animator.SetTrigger("moveLeft");
  }

  public void MoveRight()
  {
    animator.SetTrigger("moveRight");
  }

  public void ChangePlayerPosition(bool isOnRight)
  {
    foreach (GameObject player in players)
    {
      player.GetComponent<Player>().isOnRight = isOnRight;
    }
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

  public void StartMoving()
  {
    Flip();
    isMoving = true;
    audioSource.Play();
  }

  public void StopMoving()
  {
    isMoving = false;
  }

  void Flip()
  {
    Vector3 scale = transform.localScale;
    scale.x *= -1;
    transform.localScale = scale;
  }
}
