using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEffects : MonoBehaviour
{
    public static CameraEffects Singleton;

    private float duration, intensity;
    private bool isShaking = false;
    private Vector3 positionInitial;
    private float timer = 0;

    [SerializeField] private Transform cible;

    private void Awake()
    {
        if(Singleton == null)
        {
            Singleton = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        FollowCible();

        if (!isShaking) return;

        timer += Time.deltaTime;

        if(timer > duration)
        {
            isShaking = false;
            timer = 0;
        }

        this.transform.position = positionInitial + (Random.insideUnitSphere * intensity);   
    }

    public void FollowCible()
    {
        if (!cible) return;

        Vector3 positionCibleEtape;

        positionCibleEtape = Vector3.Lerp(this.transform.position, cible.position, 1 * Time.deltaTime);
        positionCibleEtape.z = -10;

        this.transform.position = positionCibleEtape;
    }

    public void SetCible(Transform newCible)
    {
        cible = newCible;
    }

    public void ShakeCamera(float duration, float intensity)
    {
        this.duration = duration;
        this.intensity = intensity;


        if (isShaking) return;

        positionInitial = this.transform.position;
        isShaking = true;
    }
    
}
