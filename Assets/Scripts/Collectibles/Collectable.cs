using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnCollected();
            gameObject.SetActive(false);
            Debug.Log(gameObject.name);
        }
    }
    public abstract void OnCollected();
}
