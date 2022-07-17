using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    float XPush;
    float YPush;

    float Xofset;
    float Yofset;

    [Header("General Settings")]

    [Tooltip("How far the ship goes (Left and Right)")][SerializeField]float XScreenRange = 5f;
    [Tooltip("How far the ship goes (Up and down)")][SerializeField] float YScreenRange = 5f;
    [Tooltip("Controling the ships speed")][SerializeField] float SpeedControler=10f;

    [Header("Ship Movement")]

    [Tooltip("Controling the Pitch as the ship goes up and down")][SerializeField] float PitchControler = 2f;
    [Tooltip("Controling the yaw as the ship goes left and right")][SerializeField] float YawCotroler = -5f;
    [Tooltip("Controling the Roll as the ship goes left and right")][SerializeField] float RollControler = 2f;
    [Tooltip("Creating bumps as The ship reaches the maximum screen range")][SerializeField] float ScreenImpactControler = -10f;

    [Header("Particle Settings")]

    [Tooltip("Laser Controler")][SerializeField] GameObject[] lasers;
    
    
    void Start()
    {
       
       
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Rotating();
        FireControling();

    }

    void FireControling()
    {
        if(Input.GetButton("Fire1"))
        {
            LaserStatus(true);

        }
        else
        {
            LaserStatus(false);
        }
    }


    void LaserStatus(bool isActive)
    {
        
        foreach(GameObject laser in lasers)
        {
            var EmissionControler = laser.GetComponent<ParticleSystem>().emission;
            EmissionControler.enabled = isActive;
        }
    }

    void Rotating()
    {
        float pitch = transform.localPosition.y*PitchControler+YPush*ScreenImpactControler;
        float yaw = transform.localPosition.x *YawCotroler;
        float roll = XPush *RollControler ;
        transform.localRotation=Quaternion.Euler(pitch,yaw,roll);
    }

    void Movement()
    {
        XPush = Input.GetAxis("Horizontal");
        YPush = Input.GetAxis("Vertical");


        Xofset = XPush * Time.deltaTime * SpeedControler;
        Yofset = YPush * Time.deltaTime * SpeedControler;

        float Xpos = transform.localPosition.x + Xofset;
        float ypos = transform.localPosition.y + Yofset;

        float ClampXpos = Mathf.Clamp(Xpos, -XScreenRange, XScreenRange);
        float ClampYpos = Mathf.Clamp(ypos, -YScreenRange, YScreenRange);

        transform.localPosition = new Vector3(ClampXpos, ClampYpos, transform.localPosition.z);
    }
}
