using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public bool active;

    public void ChangeActive()
    {
        active = !active;
    }
}
