using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public GameObject boat;
  public GameObject leftLand;
  public GameObject rightLand;

  private bool isOnBoat = false;
  public bool isOnRight = false;


  void OnMouseDown()
  {
    HandleClick();
  }

  public void HandleClick()
  {
    if (Input.GetKeyDown(KeyCode.Mouse0) && isOnBoat)
      GetOffBoat();
    else if (Input.GetKeyDown(KeyCode.Mouse0) && !isOnBoat)
      GetOnBoat();
  }

  public void GetOffBoat()
  {
    isOnBoat = false;
    Flip();
    GetBoatClass().RemovePlayer(gameObject);
    transform.parent = GetLand().transform;

    SetPosition(GetLand());
    GetLandClass().AddPlayer(gameObject);
  }

  void SetPosition(GameObject parent)
  {
    Slots slotsClass = parent.GetComponent<Slots>();
    int index = GetAvailableSlot(slotsClass);
    float x = slotsClass.slots[index].transform.localPosition.x;
    transform.localPosition = new Vector2(x, transform.localPosition.y);
  }

  int GetAvailableSlot(Slots slotsClass)
  {
    int index = 0;
    int i = 0;
    foreach (GameObject slot in slotsClass.slots)
    {
      Slot slotClass = slot.GetComponent<Slot>();
      if (slotClass.isAvailable)
      {
        index = i;
        break;
      }
      i++;
    }
    return index;
  }

  public void GetOnBoat()
  {
    if (IsBoatSameSide() && GetBoatClass().players.Count < 2)
    {
      isOnBoat = true;
      transform.parent = boat.transform;
      Flip();

      SetPosition(boat);
      GetBoatClass().AddPlayer(gameObject);
      GetLandClass().RemovePlayer(gameObject);
    }
  }

  bool IsBoatSameSide()
  {
    return GetBoatClass().isOnRight == isOnRight;
  }

  GameObject GetLand()
  {
    return isOnRight ? rightLand : leftLand;
  }

  Land GetLandClass()
  {
    return GetLand().GetComponent<Land>();
  }

  Boat GetBoatClass()
  {
    return boat.GetComponent<Boat>();
  }

  void Flip()
  {
    Vector3 scale = transform.localScale;
    scale.x *= -1;
    transform.localScale = scale;
  }
}