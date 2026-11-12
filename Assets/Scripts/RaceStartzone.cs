using UnityEngine;

public class RaceStartzone : MonoBehaviour
{
    public RaceManager raceManager;
    private bool playerNearby;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
            Debug.Log("Press E");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            Debug.Log("Leaving The Starting Area");
        }
    }

    void Update()
    {
        if (playerNearby && raceManager != null && !raceManager.IsRaceActive && Input.GetKeyDown(KeyCode.E))
        {
            raceManager.StartRace();
        }
    }
}
