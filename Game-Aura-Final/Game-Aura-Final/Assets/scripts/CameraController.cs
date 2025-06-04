using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Room camera
    [SerializeField] private float transitionSpeed = 0.3f;
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;

    // Follow player
    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance = 1.0f;
    [SerializeField] private float cameraSpeed = 5f;
    private float lookAhead = 0f;

    private bool isFollowingPlayer = true;

    private void Update()
    {
        if (isFollowingPlayer)
        {
            // Kamera mengikuti player
            lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
            transform.position = new Vector3(player.position.x + lookAhead, transform.position.y, transform.position.z);
        }
        else
        {
            // Kamera berpindah ke posisi ruangan baru
            transform.position = Vector3.SmoothDamp(
                transform.position,
                new Vector3(currentPosX, transform.position.y, transform.position.z),
                ref velocity,
                transitionSpeed
            );

            // Jika sudah dekat dengan target, aktifkan follow player lagi
            if (Mathf.Abs(transform.position.x - currentPosX) < 0.1f)
            {
                isFollowingPlayer = true;
            }
        }
    }

    public void MoveToNewRoom(Transform _newRoom)
    {
        currentPosX = _newRoom.position.x;
        isFollowingPlayer = false;
    }
}
