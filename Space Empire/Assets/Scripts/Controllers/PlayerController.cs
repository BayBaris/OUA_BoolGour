using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{
    PhotonView view;
    public float moveSpeed = 5f;

    private void Start()
    {
        view = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if (DialogueManager.isActive)
            return;

        if (view.IsMine)
        {
            Vector3 input = new Vector3(
                Input.GetAxisRaw("Horizontal"),
                Input.GetAxisRaw("Vertical"),
                0
            );
            transform.position += input.normalized * moveSpeed * Time.deltaTime;
        }
    }
}
