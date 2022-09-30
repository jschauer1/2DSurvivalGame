using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class MoveByTouch : Toolbox
{
    private Rigidbody2D _rigidbody;
    [SerializeField]Joystick joystick;
    [SerializeField] private float _moveSpeed;
    [SerializeField]GameObject SpawnEnemyPrefab;
    float horizontal;
    float speed;
    float Vertical;
    int _count;
    int numspawn;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        speed = 1;
        numspawn = 1;
    }
    void FixedUpdate()
    {
        Vertical = joystick.Vertical;
        horizontal = joystick.Horizontal;
        _rigidbody.velocity = new Vector3(horizontal * speed,Vertical*speed, _rigidbody.velocity.y);
    }
    public void spawnclick()//Is called with unity button press
    {
        if (_count <= numspawn){
            Transform Commander1 = ObjectReference("Commander");
            float move = 0 * Time.deltaTime;
            Instantiate(SpawnEnemyPrefab, Commander1.position, Quaternion.identity);

        }
        if (_count == 20)
        {
            numspawn = 100000;
        }
        _count++;
    }
}
//Movement method with screen touch instead of joystick.
/*        if (p == 0) 
        {
            if (Input.touchCount > 0)
            {
                float move = Speed * Time.deltaTime;
                foreach (Touch s in Input.touches)
                {
                    int id = s.fingerId;
                    if (EventSystem.current.IsPointerOverGameObject(id)) { }
                    if ((s.phase == TouchPhase.Ended) || (s.phase == TouchPhase.Canceled)) { }
                    else { tracktouches = Input.GetTouch(0); }
                }
                Vector2 touchPosition = Camera.main.ScreenToWorldPoint(tracktouches.position);
                transform.position = Vector2.MoveTowards(transform.position, touchPosition, move);

            }
        }*/
