using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steel : Collectable
{
    public override void OnCollected()
    {
        GameManager.Instance.Steel++;
        Debug.Log(GameManager.Instance.Gold);
    }
}
