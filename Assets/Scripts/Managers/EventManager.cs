using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static Dictionary<System.Enum, _Event> events = new Dictionary<System.Enum, _Event>();

    private void OnDestroy()
    {
        events.Clear();      
    }

}

public static class ExtensionDictionary
{
    public static V SearchOrCreate<K,V>(this Dictionary<K,V> dic, K key) where V : new() 
    {
        V result;

        if(!dic.TryGetValue(key, out result))
        {
            result = new V();
            dic.Add(key, result);
        }

        return result;
    }


    public static T SearchOrCreate<K, V, T>(this Dictionary<K, V> dic, K key) where T : V, new()
    {
        V result;

        if (!dic.TryGetValue(key, out result))
        {
            result = new T();
            dic.Add(key, result);
        }

        return (T)result;
    }



}

/// <summary>
/// Clase destinada a managear los eventos
/// </summary>
public class _Event
{
    public delegate void _event(params object[] parameters);

    public event _event action;
    
    public virtual void Trigger(params object[] parameters)
    {
        action?.Invoke(parameters);
    }
}

/// <summary>
/// class de eventos especifica para botones, donde el evento action es el down, el press es mientras se presiona, y el up al finalizar
/// </summary>
public class _EventButton : _Event
{
    public event System.Action<Vector3> up;
    public event System.Action<Vector3> press;
    public virtual void TriggerPress(Vector3 vec)
    {
        press?.Invoke(vec);
    }

    public virtual void TriggerUp(Vector3 vec)
    {
        up?.Invoke(vec);
    }
}