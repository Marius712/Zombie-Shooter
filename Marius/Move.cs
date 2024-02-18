
using UnityEngine;

[RequireComponent (typeof(CharacterController))]

public class Move : MonoBehaviour
{
	public LayerMask groundMask;
	public Transform feet;
	public float speed = 7;
	public float gravity = -9.8f;
	public float jumpHeight = 2;
	private bool isGrounded;
	private float y;

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
    	isGrounded = Physics.CheckSphere(feet.position, 0.4f, groundMask);

    	if(isGrounded && y < 0)
    	{
    		y = 0;
    	}

        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");

        var direction = transform.right * x + transform.forward * z;
        var move = direction * speed * Time.deltaTime;      

        if(isGrounded && Input.GetButtonDown("Jump"))
        {
        	y = Mathf.Sqrt(jumpHeight * -2 * gravity) * Time.deltaTime;
        }
        y += gravity * Time.deltaTime * Time.deltaTime;
        move.y = y;
        controller.Move(move);

    }

    private void OnDrawGizmos()
    {
    	Gizmos.color = Color.yellow;
    	Gizmos.DrawSphere(feet.position, 0.4f);
    }
}
