using UnityEngine;

public class PlayerController003 : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
		Vector3 dir = Vector3.zero;
		dir.x = Input.GetAxisRaw("Horizontal");

		transform.position += dir * 5 * Time.deltaTime;
    }
}
