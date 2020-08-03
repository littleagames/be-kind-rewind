using UnityEngine;

public class Glow : MonoBehaviour
{
    public CollectTapesState GlowEnabledState;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.GetTapeManager().OnTapeStateChanged += OnTapeStateChanged;
    }

    void OnDestroy()
    {
        GameManager.Instance.GetTapeManager().OnTapeStateChanged -= OnTapeStateChanged;
    }

    private void OnTapeStateChanged(CollectTapesState state)
    {
        if (state != GlowEnabledState)
        {
            DisableGlow();
            return;
        }

        EnableGlow();
    }

    private void EnableGlow()
    {
        Debug.Log($"Enable glow for {gameObject.name}");
        var children = GetComponentsInChildren<SpriteRenderer>(true);
        foreach (var child in children)
        {
            if (child.name != "Glow")
            {
                continue;
            }

            child.enabled = true;
        }
    }

    private void DisableGlow()
    {
        Debug.Log($"Disable glow for {gameObject.name}");
        var children = GetComponentsInChildren<SpriteRenderer>(true);
        foreach (var child in children)
        {
            if (child.name != "Glow")
            {
                continue;
            }

            child.enabled = false;
        }
    }
}
