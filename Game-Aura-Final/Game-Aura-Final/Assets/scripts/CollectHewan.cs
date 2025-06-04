using UnityEngine;
using TMPro;

public class CollectHewan : MonoBehaviour
{
    public int totalHewan = 3;
    public int collected = 0;
    public TextMeshProUGUI countText;

    public GameObject winPanel;

    void Start()
    {
        UpdateText();
    }

    public void Collect()
    {
        collected++;
        UpdateText();

        if (collected >= totalHewan)
        {
            Debug.Log("Menang!");
            if (winPanel != null) winPanel.SetActive(true);
        }
    }

    void UpdateText()
    {
        if (countText != null)
            countText.text = collected + "/" + totalHewan + " Hewan";
    }

    // ✅ Tambahkan fungsi ini:
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger dengan: " + other.name);

        if (other.CompareTag("HewanBuruan"))
        {
            Debug.Log("Hewan ditemukan!");
            Collect();
            Destroy(other.gameObject);
        }
    }
}
