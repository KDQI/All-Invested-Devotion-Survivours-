using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour
{
	public static MainCamera instance;
	public float interpVelocity;
	public float minDistance;
	public float followDistance;
	public GameObject target;
	public static bool isFollowingPlayer;
	public Vector3 offset;
	public Vector3 targetPos;
	private Vector3 minBounds, maxBounds;
	private float halfHeight, halfWidth;
	public BoxCollider2D boundsBox;



	void Start()
	{
		instance = this;
		isFollowingPlayer = true;
		targetPos = transform.position;
		maxBounds = boundsBox.bounds.max;
		minBounds = boundsBox.bounds.min;
		halfHeight = Camera.main.orthographicSize;
		halfWidth = halfHeight * Screen.width / Screen.height;
	}


	void FixedUpdate()
	{
		if (target && isFollowingPlayer)
		{
			Vector3 posNoZ = transform.position;
			posNoZ.z = target.transform.position.z;

			Vector3 targetDirection = (target.transform.position - posNoZ);

			interpVelocity = targetDirection.magnitude * 5f;

			targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);

			transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.25f);

		}
	}

	private void LateUpdate()
	{
		float clampedX = Mathf.Clamp(transform.position.x, minBounds.x + halfWidth, maxBounds.x - halfWidth);
		float clampedY = Mathf.Clamp(transform.position.y, minBounds.y + halfHeight, maxBounds.y - halfHeight);
		transform.position = new Vector2(clampedX, clampedY);
	}
}

