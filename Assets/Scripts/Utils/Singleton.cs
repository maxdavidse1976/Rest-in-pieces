using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T I { get; private set;}

    [SerializeField] private bool dontDestroyOnLoad;

    protected virtual void Awake()
    {
        if (I == null)
        {
            I = this as T;
            if (dontDestroyOnLoad)
                DontDestroyOnLoad(gameObject);
        }
        else if (I != null && I != this)
        {
            Debug.LogError("There's more than one singleton " + gameObject.name + " of type " + GetType());
            Destroy(gameObject);
        }
    }
}
