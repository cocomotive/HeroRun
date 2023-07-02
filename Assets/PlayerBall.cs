using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<WinCheck>()?.Win();
    }
}
