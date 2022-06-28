using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlungerController : MonoBehaviour
{
    [field: SerializeField] 
    public float MaxPower { get; set; } = 100f;
    [field: SerializeField] 
    public Slider PowerSlider { get; set; }

    private List<Rigidbody> BallList { get; set; }
    private float Power { get; set; }
    private float MinPower { get; set; } = 0.0f;
    private bool IsBallReady { get; set; }

    private void Start()
    {
        PowerSlider.minValue = 0.0f;
        PowerSlider.maxValue = MaxPower;
        BallList = new List<Rigidbody>();
    }

    private void Update()
    {
        if (IsBallReady == true)
        {
            PowerSlider.gameObject.SetActive(true);
        }
        else
        {
            PowerSlider.gameObject.SetActive(false);
        }
        
        PowerSlider.value = Power;

        if (BallList.Count > 0)
        {
            IsBallReady = true;
            if (Input.GetKey(KeyCode.Space))
            {
                if (Power <= MaxPower)
                {
                    Power += 100 * Time.deltaTime;
                }
            }
            
            if (Input.GetKeyUp(KeyCode.Space))
            {
                foreach (Rigidbody ballRigidbody in BallList)
                {
                    ballRigidbody.AddForce(Power*Vector3.up);
                }
            }
        }
        else
        {
            IsBallReady = false;
            Power = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            BallList.Add(other.gameObject.GetComponent<Rigidbody>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            BallList.Remove(other.gameObject.GetComponent<Rigidbody>());
            Power = 0;
        }
    }
}
