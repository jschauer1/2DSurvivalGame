using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class MoveByTouch : Toolbox
{
    private Rigidbody2D _rigidbody;
    _TrackPlayerInfo Trackmon = new _TrackPlayerInfo();
    [SerializeField] Joystick joystick;
    [SerializeField] private float _moveSpeed;
    [SerializeField] GameObject SpawnEnemyPrefab;
    [SerializeField] GameObject Friendprefab;
    float horizontal;
    float speed;
    float Vertical;
    int _count;
    int numspawn;
    Vector2 laggedposition;
    GameObject destroythis;
    int j;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        speed = 1;
    }
    void FixedUpdate()
    {
        Vertical = joystick.Vertical;
        horizontal = joystick.Horizontal;
        _rigidbody.velocity = new Vector3((horizontal * speed), Vertical * speed, _rigidbody.velocity.y);
        laggedposition = ObjectReference("Commander").position;
    }
    public void spawnclickdrop()//Is called with unity button press
    {
        if (Trackmon._getmoney() >= 5) {
            float move = 0 * Time.deltaTime;
            Instantiate(SpawnEnemyPrefab, laggedposition, Quaternion.identity);
            Trackmon._totalmoney(-5);

        }
    }
    public void spawnclickpickup()//Is called with unity button press
    {
        float move = 0 * Time.deltaTime;
        GameObject[] ListofHelp = GameObject.FindGameObjectsWithTag("Commander");
        foreach (GameObject item in ListofHelp)
        {
            if (item != GameObject.Find("Commander"))
            {
                Destroy(item);
                Trackmon._totalmoney(+5);
            }

        }

        

    }
    public void devmode()
    {
        j++;
        if (j >= 5)
        { Trackmon._totalmoney(10000); }
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
