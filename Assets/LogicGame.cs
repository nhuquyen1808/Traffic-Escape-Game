using DevDuck;
using UnityEngine;

public class LogicGame : MonoBehaviour
{

    [SerializeField] LayerMask carLayer;
    Camera cam;
    RaycastHit hit;

    public bool isCanClick = true;

    void Start()
    {
        cam = Camera.main;
        Observer.AddObserver(EventAction.EVENT_CAR_DONE_ACTION, CheckCanPlayGame);
    }

    private void CheckCanPlayGame(object obj)
    {
        isCanClick = (bool) obj;
        Debug.Log(isCanClick);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isCanClick)
        {
           Ray mousePos = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(mousePos,out hit, Mathf.Infinity,carLayer))
            {
                Car car = hit.collider.gameObject.GetComponent<Car>();
                if (car == null) return;
                isCanClick = false;
                car.CarMovement();
                Debug.Log(car.transform.name);
            }
        }
    }

}
