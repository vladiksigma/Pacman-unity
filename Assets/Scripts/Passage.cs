using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Passage : MonoBehaviour
{
    public Transform connection;
    public Vector2 face;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Movement>().direction == face)
        {
            Vector3 position = connection.position;
            position.z = other.transform.position.z;
            other.transform.position = position;
        }
    }

}
