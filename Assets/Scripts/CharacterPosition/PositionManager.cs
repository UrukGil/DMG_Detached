using System.Numerics;
using UnityEngine;

public class PositionManager : MonoBehaviour
{
    public static PositionManager instance;
    public UnityEngine.Vector2 nextSpawnPoint;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void SetSpawnPoint(UnityEngine.Vector2 newSpawnPoint)
    {
        nextSpawnPoint = newSpawnPoint;
    }
}
