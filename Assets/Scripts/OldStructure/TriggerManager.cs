using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class TriggerManager : MonoBehaviour
{
    [SerializeField] Transform[] newSpawns;

    public virtual void ChangeScene(Player player)
    {
        SceneManager.LoadScene(1);
    }
}
