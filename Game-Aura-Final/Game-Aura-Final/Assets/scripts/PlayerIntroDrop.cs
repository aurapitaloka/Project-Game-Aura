using UnityEngine;

public class PlayerIntroDrop : MonoBehaviour
{
    private Vector3 targetPosition;
    private bool isDropping = true;
    public float dropSpeed = 5f;

    void Start()
    {
        // Simpan posisi target (tanah)
        targetPosition = transform.position;

        // Mulai dari atas (misalnya naik 5 unit)
        transform.position += new Vector3(0, 5f, 0);
    }

    void Update()
    {
        if (isDropping)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, dropSpeed * Time.deltaTime);

            if (transform.position == targetPosition)
            {
                isDropping = false;
                // Setelah sampai tanah, bisa aktifkan kontrol player kalau perlu
            }
        }
    }
}
