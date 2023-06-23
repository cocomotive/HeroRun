using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entities : MonoBehaviour
{
    [Header("Entities")]

    public Health health;

    public Color damged;

    protected Color color
    {
        set
        {
            foreach (var item in _renderer)
            {
                item.material.color = value;
            }
        }
    }

    [SerializeField]
    List<Drop> drop = new List<Drop>();

    Renderer[] _renderer;

    Color[] original;

    Timer timerDmg;

    [SerializeField]
    float timeColorDmg;

    [SerializeField]
    int feedbackFrequency = 10;

    [SerializeField]
    GameObject particlesOnDead;

    void PrivateWhileDmg()
    {
        if(((int)(Time.realtimeSinceStartup * feedbackFrequency)) % 2 == 0)
        {
            WhileDmg();
        }
        else
        {
            ElseWhileDmg();
        }
    }

    protected virtual void WhileDmg()
    {
        color = damged;
    }

    protected virtual void ElseWhileDmg()
    {
        for (int i = 0; i < original.Length; i++)
        {
            _renderer[i].material.color = original[i];
        }
    }

    protected virtual void EndDamage()
    {
        for (int i = 0; i < original.Length; i++)
        {
            _renderer[i].material.color = original[i];
        }
    }

    protected void Health_onDamage()
    {
        timerDmg.Reset();
    }

    private void Health_onDeath()
    {
        PoolManager.SpawnPoolObject(PoolManager.SrchInCategory("Particulas", particlesOnDead.name), transform.position);

        for (int i = 0; i < drop.Count; i++)
        {
            var aux = drop[i].random;

            for (int ii = 0; ii < aux; ii++)
            {
                var offset = new Vector3(Random.Range(-1,2), 0.5f, Random.Range(-1, 2));

                PoolManager.SpawnPoolObject(PoolManager.SrchInCategory("Recolectables", drop[i].gameObject.name), transform.position + offset);
            }
            //Instantiate(drop[i], transform.position + new Vector3(Random.Range(-1, 2), 0, Random.Range(-1, 2)), Quaternion.identity);
        }

        //Instantiate(drop[Random.Range(0, drop.Count)], transform.position + new Vector3(Random.Range(-1, 2), 0, Random.Range(-1, 2)), Quaternion.identity);
    }

    public virtual void TakeDamage(float dmg, Vector3 dirDamage)
    {
        health.TakeDamage(dmg);
    }

    protected virtual void Awake()
    {
        _renderer = GetComponentsInChildren<Renderer>();

        List<Color> colors = new List<Color>();

        foreach (var item in _renderer)
        {
            colors.Add(item.material.color);
        }

        original= colors.ToArray();

        timerDmg = TimersManager.Create(timeColorDmg, PrivateWhileDmg, EndDamage).Stop();

        health.onDamage += Health_onDamage;

        health.onDeath += Health_onDeath;
    }

    private void OnDestroy()
    {
        timerDmg.Stop();
    }

}

[System.Serializable]
public class Health
{
    public Tim life;

    public event System.Action onDeath;

    public event System.Action onDamage;

    public event System.Action onRecovery;

    public event System.Action<IGetPercentage> onLifeChange;

    public void TakeDamage(float dmg)
    {
        if (life.current == 0)
            return;

        LifeChange(-dmg);

        onDamage?.Invoke();

        if(life.current==0)
        {
            onDeath?.Invoke();
        }
    }

    public void LifeRecovery(float recovery)
    {
        if (life.current == life.total)
            return;

        LifeChange(recovery);

        onRecovery?.Invoke();
    }

    void LifeChange(float addLife)
    {
        life.current += addLife;

        onLifeChange?.Invoke(life);
    }

}

[System.Serializable]
public struct Drop
{
    public GameObject gameObject;

    public int min;
    public int max;

    public int random => Random.Range(min, max-1);
}