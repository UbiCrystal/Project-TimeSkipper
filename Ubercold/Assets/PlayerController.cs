using UnityEngine;

[RequireComponent(typeof(movement))]
public class PlayerController : MonoBehaviour 
{
    #region Variables (private)
    [SerializeField]
    private float speed;
    private movement move;
    private float lookSensitivity = 3;
    #endregion

    #region Properties (public)
    
    #endregion

    #region Unity event functions

    void Start ()
    {
        move = GetComponent<movement>();
    }
	
    void Update ()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * xMove;
        Vector3 moveVertical = transform.forward * zMove;

        Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;

        move.Move(velocity);

        float yRot = Input.GetAxisRaw("Mouse X");

        Vector3 rotation = new Vector3(0f, yRot, 0f) * lookSensitivity;

        move.Rotation(rotation);

        float xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 cameraRotation = new Vector3(-xRot, 0f, 0f) * lookSensitivity;

        move.RotateCamera(cameraRotation);
    }

    #endregion

    #region Methods

    #endregion Methods
}
