using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Player _bird;
    [SerializeField] private float _offsetX;

    private void Update()
    {
        transform.position = new Vector3(_bird.transform.position.x + _offsetX, transform.position.y, transform.position.z);
    }
}
