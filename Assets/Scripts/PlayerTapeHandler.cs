using System.Collections;
using System.Collections.Generic;
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
        else
        {
            tapeObject.transform.parent = transform;
            _tapeOnHand = tapeObject;
        }
    }
}
