using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public Rigidbody2D rb;
	public float speed = 7f;
	public Transform firepoint;
	public GameObject laserToFire;

	void Start()
	{
	}

	private void Update()
	{
		rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed;

		Vector3 mouse = Input.mousePosition;

		Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);

		Vector2 offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
		float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, angle);

		if (Input.GetButtonDown("Fire1"))
		{
			Instantiate(laserToFire, firepoint.position, transform.rotation);
		}
	}


}