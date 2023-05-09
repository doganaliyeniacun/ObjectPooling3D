using UnityEngine;

public class TriggerController : MonoBehaviour
{
    public const string RoadTrigger = "RoadTrigger";
    public const string Vehicles = "Vehicles";

    [SerializeField] private RoadPool roadPool;



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(RoadTrigger))
        {
            roadPool?.AddToQueue();
        }

        if (other.CompareTag(Vehicles))
        {
            GameplayManager.Instance.ReturnStartPosition();
            HealthManager.Instance.DecrementHealth();
        }
    }


}
