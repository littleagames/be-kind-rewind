using UnityEngine;

public class TapesText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var tapeManager = GameManager.Instance.GetTapeManager();
        tapeManager.OnTapesRemainingChanged += OnTapeRemainingChanged;

        SetTapeCountText(tapeManager.GetTapesRemaining());
    }

    private void OnTapeRemainingChanged(int tapesRemaining)
    {
        Debug.Log("TapesText.OnTapeRemainingChanged");
        SetTapeCountText(tapesRemaining);
    }

    private void SetTapeCountText(int tapesRemaining)
    {
        var tapesRemainingText = GetComponent<TMPro.TMP_Text>();
        tapesRemainingText.SetText($"Tapes Left: {tapesRemaining}");
    }
}
