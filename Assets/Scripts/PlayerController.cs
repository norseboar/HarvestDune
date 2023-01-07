using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject TurretPrefab;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CreateTurret((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition));
            // Debug.Log("mouse pressed");
            // RaycastHit hit;

            // if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            // {
            //     Debug.Log(hit.point);
            // }
        }
    }

    public void CreateTurret(Vector2 position)
    {
        Instantiate(TurretPrefab, position, Quaternion.identity);
    }
}
