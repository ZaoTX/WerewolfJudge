using M2MqttUnity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using UniRx;
using UnityEngine;
using uPLibrary.Networking.M2Mqtt.Messages;


public struct InPacket
{
    public string channel;
    public string command;
    public JToken payload;
}

[DefaultExecutionOrder(-1000)]
public class Mqtt : M2MqttUnityClient
{
    public static Mqtt Instance { get; private set; }
    public static readonly Subject<InPacket> ServerMessagesAsync = new Subject<InPacket>();

    private BehaviorSubject<bool> _isConnected = new BehaviorSubject<bool>(false);
    private string Sender = Guid.NewGuid().ToString();
    public IObservable<bool> Connected => _isConnected.Where(x => x).First();


    private Dictionary<string, Func<string, string, string>> _subscribers = new Dictionary<string, Func<string, string, string>>();

    protected override void OnEnable()
    {
        Instance = this;
        Connect();

        ConnectionSucceeded += () => _isConnected.OnNext(true);

        ConnectionFailed += () => _isConnected.OnNext(false);

    }

    private void OnDestroy()
    {
        Disconnect();
    }
    protected override void OnConnectionFailed(string errorMessage)
    {
        base.OnConnectionFailed(errorMessage);

        this.gameObject.SetActive(false);
    }
    protected override void OnConnectionLost()
    {
        base.OnConnectionLost();

        this.gameObject.SetActive(false);
    }
    public async void Publish(string channel, JToken payload)
    {
        //await Connected;

        payload["sender"] = Sender;
        var encoding = new UTF8Encoding();
        var msgString = JsonConvert.SerializeObject(payload);

        var rawData = encoding.GetBytes(msgString);
        client.Publish(channel, rawData, MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE, false);
    }



    public void Publish(string topic, string payload)
    {
        // TODO: unnecessary?
        //var lastBracket = payload.LastIndexOf('}');
        //var newPayload = payload.Substring(0, lastBracket) + $", \"sender\": \"{Sender}\"}}";

        var encoding = new UTF8Encoding();
        var rawData = encoding.GetBytes(payload);
        client.Publish(topic, rawData);
    }

    protected void Subscribe(string uri)
    {
        client.Subscribe(new[] { uri }, new byte[] { 0 });
    }

    public void RegisterCallback(Func<string, string, string> callback, string topic)
    {
        // TODO: maybe use list?
        if (_subscribers.ContainsKey(topic))
            Debug.LogWarning("Tried to register two or more callbacks on same topic: " + topic);

        Subscribe(topic);
        _subscribers.Add(topic, callback);
    }
}
