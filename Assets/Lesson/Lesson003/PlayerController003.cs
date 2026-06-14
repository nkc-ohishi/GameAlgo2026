using UnityEngine;

public class PlayerController003 : MonoBehaviour
{
	float speed = 5;

    void Start()
    {
        
    }

    void Update()
    {
		// 左右キーの入力情報
		Vector3 dir = Vector3.zero;
		dir.x = Input.GetAxisRaw("Horizontal");

		transform.position += dir * 5 * Time.deltaTime;
    }
}
