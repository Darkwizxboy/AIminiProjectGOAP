using UnityEngine;
using AsyncIO;
using NetMQ;
using NetMQ.Sockets;
using UnityEngine;

public class HelloClient : MonoBehaviour
{
    private HelloRequester _helloRequester;
    public bool SendPack = true;
    public Quaternion joint;
    public Transform pos;
    string message;
    public int  niceguy = 5;
    void Update()
    {
        if (SendPack)
        {
            _helloRequester.messageToSend = niceguy.ToString();
            
            _helloRequester.Continue();
        } else if (!SendPack)
        {
            _helloRequester.Pause();
        }
    }

    private void Start()
    {
        message = "hahaha i have sent a message";
        _helloRequester = new HelloRequester();
        _helloRequester.Start();
    }

    private void OnDestroy()
    {
        _helloRequester.Stop();
    }
}