using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using DevDuck;

public enum Directions
{
    UP,
    DOWN,
    RIGHT,
    LEFT
}


public class Car : MonoBehaviour
{
    [SerializeField] List<Directions> ListDirection;
    [SerializeField] MapPoint from;

    public Vector3 startPos;
    public Transform dummyTarget;

    public List<Vector3> ListPosition = new List<Vector3>();
    [SerializeField] float delayTime;
    public LayerMask carLayer;
    public LayerMask pointLayer;
    public Sequence sequence;
    public Sequence sequenceDummy;
    int t = 0;
    public bool carClicked;
    bool canInsCoin;
    public GameObject coin;
    Plane[] cameraFrustum;
    public BoxCollider meshCol;
    RaycastHit hitInfo;
    public bool isInScene;

    private void Start()
    {
        startPos = transform.position;
        meshCol = gameObject.GetComponent<BoxCollider>();
        GetDirRayCast();
        AddPoint();
    }

    public void CarMovement()
    {
        ListPosition.Add(startPos);
        MapPoint current = from;
        MapPoint last = null;
        bool aChance = true;
        for (int i = 0; i >= 0 && i < ListDirection.Count; ++i)
        {
            last = current;
            switch (ListDirection[i])
            {
                case Directions.UP:
                    current = current.up;
                    break;
                case Directions.DOWN:
                    current = current.down;
                    break;
                case Directions.LEFT:
                    current = current.left;
                    break;
                case Directions.RIGHT:
                    current = current.right;
                    break;
            }
            // 
            if (current != null)
            {
                aChance = true;

                ListPosition.Add(current.transform.position);
                if (i == ListDirection.Count - 1)
                {
                    ListPosition.Add(current.transform.position + (current.transform.position - last.transform.position).normalized * 100);
                }
            }
            //        
            else if (aChance)
            {
                i -= 2;
                current = last;
                aChance = false;
            }
            else break;
        }

        //Kiem tra o to co di duoc hay khong
        for (int i = 1; i < ListPosition.Count; ++i)
        {
            Vector3 temp = ListPosition[i] - ListPosition[i - 1];

            if (Physics.Raycast(ListPosition[i - 1] + new Vector3(0, 0.5f, 0), temp, out hitInfo, temp.magnitude, carLayer))
            {
                check.Add(1);

            }
            /* else if (Physics.Raycast(ListPosition[i - 1] + new Vector3(0, 0.5f, 0), temp, out hitInfo, temp.magnitude, human))
             {
                 check.Add(1);

             }*/
            else
            {
                check.Add(0);
                carCanMove++;

            }
        }

        t = 0;
        sequence = DOTween.Sequence();
        sequence.PrependInterval(delayTime);
        sequenceDummy = DOTween.Sequence();

        for (int i = 1; i < ListPosition.Count; ++i)
        {
            Vector3 temp = ListPosition[i] - ListPosition[i - 1];
            //  (listPosition[i] - listPosition[i - 1]).magnitude / 10 :  time = distance / velocity ;

            sequence.PrependCallback(() => { canInsCoin = true; });

            sequence.Append(transform.DOMove(ListPosition[i], (ListPosition[i] - ListPosition[i - 1]).magnitude / 25f)
                .OnUpdate(() =>
                {
                    if (ListDirection.Count == 1) return;
                    Vector3 angle = (dummyTarget.transform.position - transform.position).normalized;
                    float v = Mathf.Atan2(angle.z, -angle.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, v - 90, 0), 20f);
                    //PosToInstantiateCoin();
                })
                .OnComplete(() =>
                {
                    ++t;
                }
            ).SetEase(Ease.Linear)).SetAutoKill(true);

            sequenceDummy.Append(dummyTarget.DOMove(ListPosition[i], (ListPosition[i] - ListPosition[i - 1]).magnitude / 25f).SetEase(Ease.Linear)).SetAutoKill(true);
        }
    }
    public List<int> check;
    public int carCanMove;
    private void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.CompareTag("Car"))
        {
            Observer.Notify(EventAction.EVENT_CAR_DONE_ACTION, true);

            Car carPref = col.transform.GetComponent<Car>();
            //carPref.ShakeCar(transform.forward, carPref.startPos);
            sequence.Pause();
            sequenceDummy.Pause();
            dummyTarget.position = transform.position;

            sequence = DOTween.Sequence();
            sequence.PrependInterval(delayTime);
            sequenceDummy = DOTween.Sequence();

            ListPosition[t + 1] = col.transform.position;

            for (int i = t; i >= 0; --i)
            {
                sequence.Append(transform.DOMove(ListPosition[i], (ListPosition[i + 1] - ListPosition[i]).magnitude / 15f).OnUpdate(() =>
                {
                    Vector3 angle = (dummyTarget.transform.position - transform.position).normalized;
                    float v = Mathf.Atan2(angle.z, -angle.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, v + 90, 0), 15f);
                }).SetEase(Ease.Linear).OnComplete(() =>
                {
                    ++t;

                    if (transform.position == startPos)
                    {
                        Observer.Notify(EventAction.EVENT_CAR_DONE_ACTION, true);
                        ListPosition.Clear();
                        carClicked = false;
                        Debug.Log("Can click");
                    }
                })).SetAutoKill(true);
                sequenceDummy.Append(dummyTarget.DOMove(ListPosition[i], (ListPosition[i + 1] - ListPosition[i]).magnitude / 15f).SetEase(Ease.Linear)).SetAutoKill(true);
            }

        }
    }
    public bool checkHitRedLight;
    public int count;

    public bool isShake;
    private void ShakeCar(Vector3 dir, Vector3 startPosition)
    {

        Vector3 des = startPosition + dir;
        transform.DOMove(des, /*(des - startPosition).magnitude /5f*/ 0.2f).OnComplete(() =>
        {
            transform.DOMove(startPosition, /*(des - startPosition).magnitude / 5*/ 0.2f);
        });
    }
    public void PosToInstantiateCoin()
    {
        var bounds = meshCol.bounds;
        cameraFrustum = GeometryUtility.CalculateFrustumPlanes(Camera.main);
        if (GeometryUtility.TestPlanesAABB(cameraFrustum, bounds))
        {
        }
        else
        {
            if (canInsCoin)
            {

                Vector3 v = meshCol.transform.position - 4.5f * transform.forward + new Vector3(0, 2f, 0);
                Vector3 g = v - 4.5f * transform.forward + new Vector3(0, 0, Random.Range(2, 7));
                GameObject coinPref = Instantiate(coin, v, Quaternion.identity);
                coinPref.transform.DOMove(g, 1).SetEase(Ease.OutQuad);
                Destroy(coinPref, 1f);
                canInsCoin = false;

            }
            isInScene = true;
        }

    }

    void AddPoint()
    {
        RaycastHit hitPoint;
        if (Physics.Raycast(transform.position /*+ new Vector3(0, 0.5f, 0)*/, -GetDirRayCast(), out hitPoint, Mathf.Infinity, pointLayer))
        {
            from = hitPoint.transform.gameObject.GetComponent<MapPoint>();
        }
    }
    public Vector3 GetDirRayCast()
    {
        if (ListDirection[0] == Directions.UP)
        {
            return Vector3.forward;
        }
        if (ListDirection[0] == Directions.DOWN)
        {
            return -Vector3.forward;
        }
        if (ListDirection[0] == Directions.LEFT)
        {
            return Vector3.left;
        }
        else
        {
            return Vector3.right;
        }
    }
    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position + new Vector3(0, 0.5f, 0), -transform.forward * 50f, Color.red);
        Debug.DrawRay(transform.position + new Vector3(0, 0.5f, 0), transform.forward * 50f, Color.yellow);
    }

    private void OnTriggerEnter(Collider other)
    {

    }

}



