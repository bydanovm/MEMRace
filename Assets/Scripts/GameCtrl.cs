using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : MonoBehaviour
{
    public GameObject road;
    private float speed = 2f;
    private GameObject newRoad;
    private GameObject spawnRoad;
    private Transform newRoadTF;
    private Transform spawnRoadTF;
    public GameObject[] cars;


    private float[] positions = { 1.9f, 0.66f, -0.66f, -1.9f };
    // Start is called before the first frame update
    void Start()
    {
        // Создаем дорогу при старте из префаба
        newRoad = Instantiate(road, new Vector3(0f, 2.3f, 0f), this.transform.rotation);
        spawnRoad = Instantiate(road, new Vector3(0f, 17.66f, 0f), this.transform.rotation);

        StartCoroutine(spawn());

        GameObject player = GameObject.Find("Player");
        PlayerCtrl playerControl = player.GetComponent<PlayerCtrl>();
        playerControl.carWallCollision += EventCarWallCollision;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate() {
        newRoadTF = newRoad.GetComponent<Transform>();
        newRoadTF.transform.Translate(Vector3.down * speed * Time.deltaTime);
        spawnRoadTF = spawnRoad.GetComponent<Transform>();
        spawnRoadTF.transform.Translate(Vector3.down * speed * Time.deltaTime);
        if(newRoadTF.transform.position.y < -15){
            Destroy(newRoad);
            newRoad = Instantiate(road, new Vector3(0f, 15.70f, 0f), this.transform.rotation);
        }
        if(spawnRoadTF.transform.position.y < -15){
            Destroy(spawnRoad);
            spawnRoad = Instantiate(road, new Vector3(0f, 15.70f, 0f), this.transform.rotation);
        }
    }

    IEnumerator spawn()
    {
        while(true) 
        {
            Instantiate(
                cars[Random.Range(0, cars.Length)],
                new Vector3(positions[Random.Range(0, positions.Length)], 8f, 0),
                Quaternion.Euler(new Vector3(0, 0, 270))
                );
            yield return new WaitForSeconds(2.5f);
        }
    }

    private void EventCarWallCollision()
    {
        
        GameObject playerCar = GameObject.Find("Player");
        Rigidbody rbPlayerCar = playerCar.GetComponent<Rigidbody>();
        Transform tranPlayerCar = playerCar.GetComponent<Transform>();
        Vector3 carThrow = new Vector3(0.2f,0.2f,0f);
        Vector3 tempVectorY = new Vector3(0f, carThrow.y, 0f);
        // Vector3 _vc3 = new Vector3((tranPlayerCar.transform.position - 
        //                 tranPlayerCar.transform.up * 10 * 
        //                 1 * Time.fixedDeltaTime).x,
        //                 (tranPlayerCar.transform.position + 
        //                 tranPlayerCar.transform.right * 10 * 
        //                 1 * Time.fixedDeltaTime).y,
        //                 0f);
        rbPlayerCar.MovePosition(tranPlayerCar.transform.position + tempVectorY);
        // GameObject mainCamera = GameObject.Find("Main Camera");
        // Transform transMainCamera = mainCamera.GetComponent<Transform>();
        // Transform backupTransMainCamera = mainCamera.GetComponent<Transform>();
        // for(int i = 0; i < 10; i++){
        //     transMainCamera.transform.Translate(Vector3.right * i * Time.deltaTime);
        // }
        // transMainCamera = backupTransMainCamera;
        Debug.Log("EventCarWallCollision");
        Debug.Log(tranPlayerCar.transform.position + tempVectorY);
    }
}
