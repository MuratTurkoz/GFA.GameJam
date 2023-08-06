using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper :Collectable
{
    // Start is called before the first frame update
    public override void OnCollected()
    {
        GameManager.Instance.Paper++;
        Debug.Log(GameManager.Instance.Gold);
    }
}
