using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventsCreator : MonoBehaviour
{
    public UnityEvent[] eventsCreator;

    public void StartEvent(int eventIndex)
    {
        eventsCreator[eventIndex].Invoke();
    }
}
