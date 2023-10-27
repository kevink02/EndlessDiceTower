using UnityEngine;


/*
 * A generic base class for singleton classes to derive from, to avoid repeating singleton code in those classes
 * This needs to be generic so the static variables are bound to a specific type of the singleton class and not to the entire class
 */
/// <summary>
/// To use, have the singleton class derive from this class and have it implement the <seealso cref="ISingletonUser"/> interface
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class BasicSingleton<T> : MonoBehaviour where T : ISingletonUser
{
    /*
     * Class variables
     */
    private static T _instance;


    /*
     * Properties
     */
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError($"The singleton instance of type {typeof(T)} is not set");
            }
            return _instance;
        }
        protected set
        {
            if (_instance == null)
            {
                _instance = value;
            }
            else if (_instance.Equals(value))
            {
                Debug.LogWarning($"The singleton instance of type {_instance.GetType()} has already been set to object {value}");
            }
            // If setting the singleton instance to another object when it has already been set, destroy the new object trying to be set to the instance
            else if (!_instance.Equals(value))
            {
                if (value is MonoBehaviour)
                {
                    Debug.LogError($"The singleton instance of type {_instance.GetType()} has already been set and could not be reset to object {value}");
                    // Extra instances of a class type should be disabled as well as destroyed
                    // Disabling prevents the rest of Awake() from running (disabled objects in the hierarchy do not run)
                    // Destroying them is not immediate (objects marked for destruction can still finish executing their Awake())
                    // ... but will still destroy clone instances to prevent any further execution on their part
                    MonoBehaviour monoBehaviour = value as MonoBehaviour;
                    GameObject gameObject = monoBehaviour.gameObject;
                    gameObject.SetActive(false);
                    Object.Destroy(gameObject);
                }
                else
                {
                    Debug.LogError($"The alternate singleton instance {value} could not be destroyed");
                }
            }
        }
    }


    /*
     * Unity methods
     */
    protected void Awake()
    {
        if (TryGetComponent<ISingletonUser>(out ISingletonUser singletonUser))
        {
            _instance = (T)singletonUser;
        }
        if (_instance != null)
        {
            _instance.SetSingletonInstance();
        }
        else
        {
            Debug.LogError($"Could not set singleton instance");
        }
    }
}
