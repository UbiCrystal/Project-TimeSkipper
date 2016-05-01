using UnityEngine;

[RequireComponent(typeof(CharacterMotor))]
public class ChracterMovement : MonoBehaviour 
{
    #region Variables (private)
    [SerializeField]
    private float speed;
    private CharacterMotor motor;
    private float lookSensitivity = 3;
    #endregion

    #region Properties (public)
    public GameObject enemy;
    #endregion

    #region Unity event functions

    void Start()
    {
        motor = GetComponent<CharacterMotor>();
    }

    void Update()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * xMove;
        Vector3 moveVertical = transform.forward * zMove;

        Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;

        motor.Move(velocity);

        float yRot = Input.GetAxisRaw("Mouse X");

        Vector3 rotation = new Vector3(0f, yRot, 0f) * lookSensitivity;

        motor.Rotation(rotation);

        float xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 cameraRotation = new Vector3(-xRot, 0f, 0f) * lookSensitivity;

        motor.RotateCamera(cameraRotation);

        if (yRot != 0 || xRot != 0)
        {
            enemy.gameObject.GetComponent<Enemy>().moveSpeed = 5f;
            enemy.gameObject.GetComponent<Enemy>().Damping = 4f;
        }
        else
        {
            enemy.gameObject.GetComponent<Enemy>().moveSpeed = 0.1f;
            enemy.gameObject.GetComponent<Enemy>().Damping = 0.09f;
        }
    }

    #endregion

    #region Methods

    #endregion Methods
}
