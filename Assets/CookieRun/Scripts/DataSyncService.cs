using System.Collections.Generic;
using System;
using UnityEngine;
using System.Collections;

//TODO: Create enums for each step of the process (eg, fetching sets, fetching cards, etc) 
//TODO: Add a way to check for new sets, cards, and updates 

public class DataSyncService : MonoBehaviour
{
    private bool _isSyncing;
    private HashSet<string> _existingImages;

    public event Action<float, string> OnSyncProgressUpdated;
    public event Action<float, int> OnCardSyncProgressUpdated;

    public event Action OnSyncComplete;
    public bool IsSyncComplete { get; private set; }

    private void Start()
    {
        Debug.Log("DataSyncService::Start");

        DontDestroyOnLoad(gameObject);
        StartSync();
    }

    public void StartSync()
    {
        Debug.Log("ProgressTracker::StartSync");

        if (_isSyncing)
        {
            Debug.LogWarning("Sync already in progress");
            return;
        }

        _isSyncing = true;
        IsSyncComplete = false;
        StartCoroutine(SyncRoutine());
    }

    private IEnumerator SyncRoutine()
    {
        Debug.Log("ProgressTracker::SyncRoutine");

        yield return StartCoroutine(HandleDataSync());

        _isSyncing = false;
        IsSyncComplete = true;

        OnSyncComplete?.Invoke();
    }

    private IEnumerator HandleDataSync()
    {
        Debug.Log("ProgressTracker::HandleDataSync");
        yield return null;
    }
}
