using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour
{
    void Start()
    {
        if (PositionManager.instance != null)
        {
            transform.position = PositionManager.instance.nextSpawnPoint;
        }
    }
}
