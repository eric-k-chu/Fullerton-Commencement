using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager instance { get; private set; }

    public event Action onPlayerGraduates;

    private void Awake()
    {
        instance = this;
    }

    public void EndGraduation()
    {
        onPlayerGraduates?.Invoke();
    }
}
