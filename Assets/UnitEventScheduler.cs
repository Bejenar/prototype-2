using System.Collections;
using UnityEngine;

public class UnitEventScheduler : MonoBehaviour
{
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            StartCoroutine(ScheduleUltimate(i));
        }
    }

    public IEnumerator ScheduleUltimate(int index)
    {
        var song = PersistentConfig.Instance.selectedSong;
        var selectedUnits = PersistentConfig.Instance.selectedUnits;

        var timeToWaitInSeconds = song.ultimateTimings[index] * song.audioClip.length;
        Debug.Log("Scheduling ultimate in second: " + timeToWaitInSeconds);

        yield return new WaitForSeconds(timeToWaitInSeconds);

        Debug.Log("Triggering ultimate from unit " + selectedUnits[index]?.unitName);

        if (selectedUnits[index]?.unitPrefab)
        {
            Instantiate(selectedUnits[index].unitPrefab, transform, false);
        }
    }
}