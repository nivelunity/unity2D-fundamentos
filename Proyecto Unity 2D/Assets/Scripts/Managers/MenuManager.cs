using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Slider mySlider;
    [SerializeField] private Toggle myToggle;
    [SerializeField] private TMP_InputField myInput;

    void Start()
    {
        // Asignar valores iniciales
        mySlider.value = PersistenceManager.Instance.GetFloat("MusicVolumen");
        myToggle.isOn = PersistenceManager.Instance.GetBool("Music"); 
        myInput.text = PersistenceManager.Instance.GetString("UserName"); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
