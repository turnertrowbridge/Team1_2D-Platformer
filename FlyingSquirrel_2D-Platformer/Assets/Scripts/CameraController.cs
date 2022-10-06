using UnityEngine;

public class CameraController : MonoBehaviour
{

   [SerializeField] private Transform player;
    [SerializeField] private int yCameraPosition;

    private void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y + yCameraPosition, transform.position.z);
    }

}
