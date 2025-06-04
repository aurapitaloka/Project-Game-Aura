using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    public GameObject winPanel; // Drag panel 'sukses' ke sini
    public CollectHewan collectHewan; // Drag object yang punya script CollectHewan

    private bool finished = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !finished)
        {
            if (collectHewan != null && collectHewan.collected >= collectHewan.totalHewan)
            {
                winPanel.SetActive(true);
                finished = true;
                Debug.Log("Menang! Semua hewan dikumpulkan & sampai FinishPoint.");
            }
            else
            {
                Debug.Log("Belum semua hewan dikumpulkan.");
            }
        }
    }
    void Start()
{
    if (winPanel != null)
    {
        winPanel.SetActive(false); 
    }
}

}
