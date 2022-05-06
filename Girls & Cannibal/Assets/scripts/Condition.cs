using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Condition : MonoBehaviour
{
    public GameObject boat;
    public GameObject leftLand;
    public GameObject rightLand;
    public Modal modal;

    void Update()
    {
        Win();
        StartCoroutine(Lose());
    }

    void Win()
    {
        if (IsWin())
        {
            modal.ShowWin();
        }
    }

    bool IsWin()
    {
        int total = leftLand.GetComponent<Slots>().slots.Count;
        int missionaryNumber = RightLandClass().GetMissionaryNumber();
        int cannibalNumber = RightLandClass().GetCannibalNumber();

        if (missionaryNumber + cannibalNumber == total)
            return true;
        else
            return false;
    }

    IEnumerator Lose()
    {
        if (IsLose())
        {

            yield return new WaitForSeconds(2.5f);
            modal.ShowGameover();
        }
    }

    bool IsLose()
    {
        int leftMissionaryNumber = LeftLandClass().GetMissionaryNumber();
        int leftCannibalNumber = LeftLandClass().GetCannibalNumber();
        if (!BoatClass().isOnRight)
        {
            leftMissionaryNumber += BoatClass().GetMissionaryNumber();
            leftCannibalNumber += BoatClass().GetCannibalNumber();
        }

        int rightMissionaryNumber = RightLandClass().GetMissionaryNumber();
        int rightCannibalNumber = RightLandClass().GetCannibalNumber();
        if (BoatClass().isOnRight)
        {
            rightMissionaryNumber += BoatClass().GetMissionaryNumber();
            rightCannibalNumber += BoatClass().GetCannibalNumber();
        }

        if (IsMissionaryLessThanCannibal(leftMissionaryNumber, leftCannibalNumber))
        {
            return true;
        }

        if (IsMissionaryLessThanCannibal(rightMissionaryNumber, rightCannibalNumber))
        {
            return true;
        }

        return false;
    }

    bool IsMissionaryLessThanCannibal(int missionary, int cannibal)
    {
        if (missionary < cannibal && missionary > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    Boat BoatClass()
    {
        return boat.GetComponent<Boat>();
    }

    Land LeftLandClass()
    {
        return leftLand.GetComponent<Land>();
    }

    Land RightLandClass()
    {
        return rightLand.GetComponent<Land>();
    }
}
