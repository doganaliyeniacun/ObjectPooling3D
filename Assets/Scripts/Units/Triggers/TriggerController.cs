using UnityEngine;

public class TriggerController : MonoBehaviour
{
    public const string RoadTrigger = "RoadTrigger";

    [SerializeField] private RoadPool roadPool;
        
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(RoadTrigger))
        {
            roadPool?.AddToQueue();

        }
    }
}
