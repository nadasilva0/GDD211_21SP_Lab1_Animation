using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacemanController3D : MonoBehaviour
{
    [SerializeField] private Animator animator;
	[SerializeField] private float walkSpeed;

	private float facing = 1;

	private void Update()
	{
		float input = (Input.GetAxisRaw("Horizontal"));

		facing = input;

		if (facing < 0)
		{
			transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0f, 270f, 0f), Time.deltaTime * 4f);
		}
		else if(facing > 0)
		{
			transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0f, 90f, 0f), Time.deltaTime * 4f);
		}

		transform.position += new Vector3(input * walkSpeed * Time.deltaTime, 0f);

		animator.SetFloat("MoveSpeed", Mathf.Abs(input));
	}
}
