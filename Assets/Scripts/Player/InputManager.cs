using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] float speedTreshold;
    // Start is called before the first frame update

    public void MoveCharacter(Vector3 dir)
    {
        Vector3 direction = new Vector3(dir.x, 0, dir.y);
        transform.Translate(direction.normalized * Time.deltaTime * speedTreshold, Space.World);
    }

}
