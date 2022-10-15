using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommanderSpawnBullet : Toolbox
{
	[SerializeField]
	int numberOfProjectiles;

	public GameObject projectile;

	Vector2 startPoint;

	float moveSpeed;
	_Time timer = new _Time();
	// Use this for initialization
	void Start()
	{
		moveSpeed = 1.5f;
		Physics2D.IgnoreLayerCollision(13, 8);
	}

	// Update is called once per frame
	void Update()
	{
		if (ifclose(2.5f, "Commander"))
        {
			if (timer._wait(3))
			{
				startPoint = transform.position;
				SpawnProjectiles(numberOfProjectiles);
			}
		}

	}

	void SpawnProjectiles(int numberOfProjectiles)
	{
		float angleStep = 360f / numberOfProjectiles;
		float angle = 0f;

		for (int i = 0; i <= numberOfProjectiles - 1; i++)
		{

			float projectileDirXposition = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180);
			float projectileDirYposition = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180);

			Vector2 projectileVector = new Vector2(projectileDirXposition, projectileDirYposition);
			Vector2 projectileMoveDirection = (projectileVector - startPoint).normalized * moveSpeed;

			var proj = Instantiate(projectile, startPoint, Quaternion.identity);
			proj.GetComponent<Rigidbody2D>().velocity =
				new Vector2(projectileMoveDirection.x, projectileMoveDirection.y);

			angle += angleStep;
		}
	}
}
