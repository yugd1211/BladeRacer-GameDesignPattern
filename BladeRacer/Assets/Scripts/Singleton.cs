using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance != null)
                return _instance;
            
            _instance = FindObjectOfType<T>();
            if (_instance != null)
                return _instance;
            
            GameObject obj = new GameObject
            {
                name = typeof(T).Name,
            };
            _instance = obj.AddComponent<T>();
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
