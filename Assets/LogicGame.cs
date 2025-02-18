using DevDuck;
using UnityEngine;

public class LogicGame : MonoBehaviour
{

    LayerMask carLayer;
    Camera cam;
    RaycastHit hit;

    private bool isCanClick = true;

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
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Car car = hit.collider.gameObject.GetComponent<Car>();
                if (car == null) return;

                isCanClick = false;
               // car.carClicked = true;
                car.CarMovement();
            }
        }
    }

}
