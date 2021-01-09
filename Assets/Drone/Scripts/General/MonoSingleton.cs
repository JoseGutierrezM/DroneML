using UnityEngine;

public abstract class MonoSingleton<T> : MonoBehaviour where T : Component
{
    private static T instance;

    private static bool m_applicationIsQuitting = false;

    public static T GetInstance()
    {
        if (m_applicationIsQuitting) { return null; }

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

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            SetDontDestroyOnLoad();
        }
        else if (instance != this as T)
        {
            Destroy(gameObject);
        }
        else
        {
            SetDontDestroyOnLoad();
        }

        if (transform.parent != null)
        {
            Debug.LogWarningFormat("Singleton of type {0} cannot be set DontDestroyOnLoad as it is a child of another object", instance.GetType().ToString());
        }
    }

    private void SetDontDestroyOnLoad()
    {
        instance.transform.SetParent(null, true);
        DontDestroyOnLoad(gameObject);
    }

    private void OnApplicationQuit()
    {
        m_applicationIsQuitting = true;
    }
}