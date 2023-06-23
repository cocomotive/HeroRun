using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSystem : MonoBehaviour
{
    public LoadSystem instance;

    [SerializeField]
    Image barra;

    private void Awake()
    {
        if(instance!=null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this);
    }

    public void LoadScene(string sc)
    {
        StartCoroutine(_LoadScene(sc));
    }


    IEnumerator _LoadScene(string sc)
    {
        //prendo canvas


        //////////////////////////////////////////////////////////////////////
        var async = SceneManager.LoadSceneAsync(sc);

        while (!async.isDone)
        {
            barra.fillAmount = async.progress;
            yield return null;
        }
        /////////////////////////////////////////////////////////////////////


        //apago canvas
    }
}
