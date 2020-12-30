using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacemanControllerBlend : MonoBehaviour
{
    [SerializeField] private Animator animator;
	[SerializeField] private float walkSpeed;

	private float facing = 1;
	private float speed = 0f;

	private void Update()
	{
		float input = (Input.GetAxisRaw("Horizontal"));

		facing = input;

		if (input != 0f)
		{
			speed = Mathf.Lerp(speed, input * walkSpeed, Time.deltaTime);
			speed = Mathf.Clamp(speed, -walkSpeed, walkSpeed);
		}
		else
		{
			speed = Mathf.Lerp(speed, 0f, Time.deltaTime * 5f);
		}

		if (facing < 0)
		{
			transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0f, 270f, 0f), Time.deltaTime * 4f);
		}
		else if(facing > 0)
		{
			transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0f, 90f, 0f), Time.deltaTime * 4f);
		}

		transform.position += new Vector3(speed, 0f);

		animator.SetFloat("MoveSpeed", Mathf.Abs(speed));
	}
}
