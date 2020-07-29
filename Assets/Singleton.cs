using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Component
{
    private static T instance;
    private static bool appQuitting = false;
   
    /// <summary> Returns the singleton instance of the object
    /// If no instance exists, creates a new one and returns it. </summary>
    public static T GetInstance()
    {
        if (appQuitting) return null;
        if (instance == null) 
        {
            instance = FindObjectOfType<T>();
            if (instance == null)
            {
                GameObject obj = new GameObject();
                obj.name = typeof(T).Name;
                instance = obj.AddComponent<T>();
            }
        }
        return instance;
    }

    /// <summary>
    /// Deletes the gameObject if an instance already exists during runtime.
    /// </summary>
    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        appQuitting = true;
    }
}
