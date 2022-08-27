using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {
    public string playerName;
    public int carId;

    public Player(){
        playerName = "Racer";
        carId = 1;
    }
    public Player(string val){
        this.playerName = val;
    }
}

public class Car{
    public float speedBoost;
    public float speedControl;

    public Car(){
        speedBoost = 1;
        speedControl = 1;
    }
    public Car(float boost){
        this.speedBoost = boost;
    }
    public Car(float boost, float control){
        this.speedBoost = boost;
        this.speedControl = control;
    }
}