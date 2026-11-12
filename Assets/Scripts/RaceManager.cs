using UnityEngine;

public class RaceManager : MonoBehaviour
{
    public GameObject[] barriers;
    public GameObject finishTrigger;
    public bool IsRaceActive { get; private set; }

    void Start()
    {
        IsRaceActive = false;
        foreach (GameObject barrier in barriers)
        {
            if (barrier != null) barrier.SetActive(false);
        }

        if (finishTrigger != null) finishTrigger.SetActive(false);
    }

    public void StartRace()
    {
        if (IsRaceActive)
        return;

        IsRaceActive = true;

        foreach (GameObject barrier in barriers)
        {
            if (barrier != null)
            barrier.SetActive(true);
        }

        if (finishTrigger != null) finishTrigger.SetActive(true);
        Debug.Log("Race Started");
    }

    public void FinishRace()
    {
        if (!IsRaceActive)
        return;

        IsRaceActive = false;

        foreach (GameObject barrier in barriers)
        {
            if (barrier != null)
            barrier.SetActive(false);
        }

        if (finishTrigger != null) finishTrigger.SetActive(false);
        Debug.Log("Race Finished");
    }
}
