using UnityEngine;

public class MoveByTouch : MonoBehaviour
{
    public float Speed; 
    void Start()
    {
        Speed = 1f;

    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            float move = Speed * Time.deltaTime;
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            transform.position = Vector2.MoveTowards(transform.position, touchPosition, move);

        }
    }

}
