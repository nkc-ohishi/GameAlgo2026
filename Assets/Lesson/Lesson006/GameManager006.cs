using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager006 : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
		if(Input.GetKeyDown(KeyCode.Return))
		{
			// リスタート
			SceneManager.LoadScene(0);
		}
    }
}
