using UnityEngine;


/*
 * A generic base class for singleton classes to derive from, to avoid repeating singleton code in those classes
 * This needs to be generic so the static variables are bound to a specific type of the singleton class and not to the entire class
 */
/// <summary>
/// To use, have the singleton class derive from this class
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class BasicSingleton<T> : MonoBehaviour where T : BasicSingleton<T>
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
            // If accessing singleton before it is set, find it in the scene and set it
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
            }
            // The singleton is not in the scene, so throw an error message
            if (_instance == null)
            {
                throw new System.NullReferenceException($"The singleton instance of type {typeof(T)} is not set");
            }
            return _instance;
        }
        private set
        {
            if (_instance == null)
            {
                _instance = value;
                Debug.Log($"The singleton instance of type {_instance.GetType()} has been set to object {value}");
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
    private void Awake()
    {
        if (TryGetComponent<T>(out T singletonUser))
        {
            Instance = singletonUser;
            //Debug.Log($"{name}: Setting singleton instance to {singletonUser}");
        }
        else
        {
            Debug.LogError($"Could not set singleton instance");
        }
    }
}
