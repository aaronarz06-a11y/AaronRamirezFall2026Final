using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    public RaceManager raceManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && raceManager != null && raceManager.IsRaceActive)
        {
            raceManager.FinishRace();
        }
    }
}