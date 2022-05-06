using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
  public int missionaryLeft;
  public int cannibalLeft;
  public int missionaryRight;
  public int cannibalRight;
  public bool isOnRight;
  public string op;

  public State(int missionaryLeft, int cannibalLeft, int missionaryRight, int cannibalRight, bool isOnRight)
  {
    this.missionaryLeft = missionaryLeft;
    this.cannibalLeft = cannibalLeft;
    this.missionaryRight = missionaryRight;
    this.cannibalRight = cannibalRight;
    this.isOnRight = isOnRight;
  }

  public State(int missionaryLeft, int cannibalLeft, int missionaryRight, int cannibalRight, bool isOnRight, string op)
  {
    this.missionaryLeft = missionaryLeft;
    this.cannibalLeft = cannibalLeft;
    this.missionaryRight = missionaryRight;
    this.cannibalRight = cannibalRight;
    this.isOnRight = isOnRight;
    this.op = op;
  }

  public bool isGoal()
  {
    return missionaryLeft == 0 && cannibalLeft == 0;
  }

  public bool isValid()
  {
    if (IsPlayerEnough() && IsMissionaryGreaterThanCannibal())
      return true;
    else
      return false;
  }

  public bool IsPlayerEnough()
  {
    return missionaryLeft >= 0 && cannibalLeft >= 0 && missionaryRight >= 0 && cannibalRight >= 0;
  }

  public bool IsMissionaryGreaterThanCannibal()
  {
    return (missionaryLeft == 0 || missionaryLeft >= cannibalLeft) && (missionaryRight == 0 || missionaryRight >= cannibalRight);
  }
}
