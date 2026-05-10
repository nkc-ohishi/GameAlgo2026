using UnityEngine;

public class CubeController0511 : MonoBehaviour
{
    float rotSpeed; // void Start()ÇÃÇPçsè„Ç…í«â¡

    void Start()
    {
        Debug.Log("CubeController0511Ç™é¿çsÇ≥ÇÍÇ‹ÇµÇΩÅB");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rotSpeed = 10;
        }
        transform.Rotate(0, 0, rotSpeed);
    }
}
