//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Events;

//public class SignalListener : MonoBehaviour
//{
//    [Tooltip("Signal to listen for")]
//    public Signal signal; // Obiekt sygna³u, który nas³uchujemy

//    [Tooltip("Event to invoke when the signal is raised")]
//    public UnityEvent signalEvent; // Zdarzenie wywo³ywane po odebraniu sygna³u

//    public void OnSignalRaised()
//    {
//        if (signalEvent != null)
//        {
//            signalEvent.Invoke();
//        }
//        else
//        {
//            Debug.LogWarning("Signal event is null in SignalListener: " + gameObject.name);
//        }
//    }

//    //private void OnEnable()
//    //{
//    //    if (signal != null)
//    //    {
//    //        signal.RegisterListener(this);
//    //    }
//    //    else
//    //    {
//    //        Debug.LogError("Signal is null in OnEnable for SignalListener: " + gameObject.name);
//    //    }
//    //}

//    //private void OnDisable()
//    //{
//    //    if (signal != null)
//    //    {
//    //        signal.DeRegisterListener(this);
//    //    }
//    //    else
//    //    {
//    //        Debug.LogError("Signal is null in OnDisable for SignalListener: " + gameObject.name);
//    //    }
//    //}
//}
