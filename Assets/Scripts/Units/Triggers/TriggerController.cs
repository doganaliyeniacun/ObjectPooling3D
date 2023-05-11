using UnityEngine;

public class TriggerController : MonoBehaviour
{
    public const string ROAD_TRIGGER = "RoadTrigger";
    public const string VEHICLES = "Vehicles";

    [SerializeField] private RoadPool roadPool;



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ROAD_TRIGGER))
        {
            roadPool?.AddToQueue();
        }

        if (other.CompareTag(VEHICLES))
        {
            GameplayManager.Instance.ReturnStartPosition();
            HealthManager.Instance.DecrementHealth();
        }
    }


}
