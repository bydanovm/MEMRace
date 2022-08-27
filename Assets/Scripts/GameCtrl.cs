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
}
