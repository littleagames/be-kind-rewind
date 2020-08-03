using UnityEngine;

public class PlayerTapeHandler : MonoBehaviour
{
    private GameObject _tapeOnHand = null;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Tape")
        {
            TryCollectTape(other.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Rewinder")
        {
            GameManager.Instance.GetTapeManager().CollectTape();
            Destroy(_tapeOnHand);
            _tapeOnHand = null;
        }
    }

    private void TryCollectTape(GameObject tapeObject)
    {
        if (_tapeOnHand != null)
        {
            return;
        }

        tapeObject.transform.parent = transform;
        _tapeOnHand = tapeObject;
        GameManager.Instance.GetTapeManager().SetCollectTapeState(CollectTapesState.ReturnToRewinder);
    }
}
