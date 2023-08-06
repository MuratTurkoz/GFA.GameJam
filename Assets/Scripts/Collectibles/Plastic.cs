using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plastic : Collectable
{
    // Start is called before the first frame update
    public override void OnCollected()
    {
        GameManager.Instance.Plastic++;
        Debug.Log(GameManager.Instance.Gold);
    }
}
