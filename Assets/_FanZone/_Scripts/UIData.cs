using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIData : MonoBehaviour
{
    void Update()
    {
        var eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        if (results.Where(r => r.gameObject.layer == 6).Count() > 0) //6 being my UILayer
        {
            Debug.Log(results[0].gameObject.name); //The UI Element
        }
    }
}
