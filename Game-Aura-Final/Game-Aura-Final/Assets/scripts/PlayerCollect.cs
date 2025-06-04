using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    public CollectHewan collectHewan;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("HewanBuruan"))
        {
            collectHewan.Collect();
            Destroy(other.gameObject);
        }
    }
}
