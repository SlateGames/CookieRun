using Matchplay.Client;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QueueTimerController : MenuControllerBase
{
    [SerializeField] private TextMeshProUGUI queueTimerText;
    [SerializeField] private TextMeshProUGUI queueStatusText;

    [SerializeField] private Button queueCancelButton;

    private Coroutine timerCoroutine;

    public override void Start()
    {
        Debug.Log("QueueTimerController::Start");

        base.Start();

        queueCancelButton.onClick.AddListener(HideOverlay);
        timerCoroutine = StartCoroutine(UpdateTimerCoroutine());

        MatchplayMatchmaker.Instance.OnMatchmakingStatusChanged += OnMatchmakingStatusChanged;
    }

    private void OnMatchmakingStatusChanged(string newStatus)
    {
        Debug.Log("QueueTimerController::OnMatchmakingStatusChanged");
        queueStatusText.text = newStatus;
    }

    public override void HideOverlay()
    {
        Debug.Log("QueueTimerController::HideOverlay");

        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
            timerCoroutine = null;
        }

        TournamentManager.Instance.LeaveMatchmakingQueue();
        queueCancelButton.onClick.RemoveListener(HideOverlay);

        base.HideOverlay();
    }

    private IEnumerator UpdateTimerCoroutine()
    {
        Debug.Log("QueueTimerController::UpdateTimerCoroutine");

        float elapsedTime = 0f;
        while (true)
        {
            elapsedTime += Time.deltaTime;

            int minutes = Mathf.FloorToInt(elapsedTime / 60f);
            int seconds = Mathf.FloorToInt(elapsedTime % 60f);
            queueTimerText.SetText($"{minutes}:{seconds:D2}");

            yield return null;
        }
    }
}
