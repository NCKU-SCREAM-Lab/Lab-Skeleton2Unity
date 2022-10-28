using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class unity_humanbones : MonoBehaviour
{
	Animator anim;

	//  Bone stuff
    Transform head;
    Transform upperchest;
    Transform spine;
	Transform hip;
    Transform L_upperarm;
    Transform L_lowerarm;
    Transform L_hand;
    Transform L_upperleg;
    Transform L_lowerleg;
    Transform L_foot;
    Transform R_upperarm;
    Transform R_lowerarm;
    Transform R_hand;
    Transform R_upperleg;
    Transform R_lowerleg;
    Transform R_foot;

    string[] w_head;
    string[] w_spine;
    string[] w_hip;
    string[] w_l_upperarm;
    string[] w_l_lowerarm;
    string[] w_l_hand;
    string[] w_r_upperarm;
    string[] w_r_lowerarm;
    string[] w_r_hand;
    string[] w_l_upperleg;
    string[] w_l_lowerleg;
    string[] w_l_foot;
    string[] w_r_upperleg;
    string[] w_r_lowerleg;
    string[] w_r_foot;

    [HideInInspector] public bool isTxStarted = false;

    [SerializeField] string IP = "127.0.0.1"; // local host
    [SerializeField] int rxPort = 8000; // port to receive data from Python on
    [SerializeField] int txPort = 8001; // port to send data to Python on

    int i = 0; // DELETE THIS: Added to show sending data from Unity to Python via UDP

    // Create necessary UdpClient objects
    UdpClient client;
    IPEndPoint remoteEndPoint;
    Thread receiveThread; // Receiving Thread
    
    public void SendData(string message) // Use to send data to Python
    {
        try
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            client.Send(data, data.Length, remoteEndPoint);
        }
        catch (Exception err)
        {
            print(err.ToString());
        }
    }

    void Awake()
    {
        // Create remote endpoint (to Matlab) 
        remoteEndPoint = new IPEndPoint(IPAddress.Parse(IP), txPort);

        // Create local client
        client = new UdpClient(rxPort);

        // local endpoint define (where messages are received)
        // Create a new thread for reception of incoming messages
        receiveThread = new Thread(new ThreadStart(ReceiveData));
        receiveThread.IsBackground = true;
        receiveThread.Start();

        // Initialize (seen in comments window)
        print("UDP Comms Initialised");

        
    }

    // Receive data, update packets received
    private void ReceiveData()
    {
        while (true)
        {
            try
            {
                IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
                byte[] data = client.Receive(ref anyIP);
                string text = Encoding.UTF8.GetString(data);
                string[] subs = text.Split(',');
                
                w_head = subs[0].Split(' ');
                w_spine = subs[1].Split(' ');
                w_hip = subs[8].Split(' ');
                w_l_upperarm = subs[5].Split(' ');
                w_l_lowerarm = subs[6].Split(' ');
                w_l_hand = subs[7].Split(' ');
                w_r_upperarm = subs[2].Split(' ');
                w_r_lowerarm = subs[3].Split(' ');
                w_r_hand = subs[4].Split(' ');
                w_l_upperleg = subs[12].Split(' ');
                w_l_lowerleg = subs[13].Split(' ');
                w_l_foot = subs[14].Split(' ');
                w_r_upperleg = subs[9].Split(' ');
                w_r_lowerleg = subs[10].Split(' ');
                w_r_foot = subs[11].Split(' ');
                print(">> " + w_head[0]);
                // print(">> " + text);
                ProcessInput(text);
            }
            catch (Exception err)
            {
                print(err.ToString());
            }
        }
    }

    private void ProcessInput(string input)
    {
        // PROCESS INPUT RECEIVED STRING HERE

        if (!isTxStarted) // First data arrived so tx started
        {
            isTxStarted = true;
        }
    }

    //Prevent crashes - close clients and threads properly!
    void OnDisable()
    {
        if (receiveThread != null)
            receiveThread.Abort();

        client.Close();
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
        // Get avatar skeleton position
        head = anim.GetBoneTransform(HumanBodyBones.Head);
        spine = anim.GetBoneTransform(HumanBodyBones.Spine);
		hip = anim.GetBoneTransform(HumanBodyBones.Hips);
        L_upperarm = anim.GetBoneTransform(HumanBodyBones.LeftUpperArm);
        L_lowerarm = anim.GetBoneTransform(HumanBodyBones.LeftLowerArm);
        L_hand = anim.GetBoneTransform(HumanBodyBones.LeftHand);
        L_upperleg = anim.GetBoneTransform(HumanBodyBones.LeftUpperLeg);
        L_lowerleg = anim.GetBoneTransform(HumanBodyBones.LeftLowerLeg);
        L_foot = anim.GetBoneTransform(HumanBodyBones.LeftFoot);
        R_upperarm = anim.GetBoneTransform(HumanBodyBones.RightUpperArm);
        R_lowerarm = anim.GetBoneTransform(HumanBodyBones.RightLowerArm);
        R_hand = anim.GetBoneTransform(HumanBodyBones.RightHand);
        R_upperleg = anim.GetBoneTransform(HumanBodyBones.RightUpperLeg);
        R_lowerleg = anim.GetBoneTransform(HumanBodyBones.RightLowerLeg);
        R_foot = anim.GetBoneTransform(HumanBodyBones.RightFoot);
        // print(hip);
        
    }

    // Update is called once per frame
    void Update()
    {
        anim = GetComponent<Animator>();

        // Get avatar skeleton position
        head = anim.GetBoneTransform(HumanBodyBones.Head);
        spine = anim.GetBoneTransform(HumanBodyBones.Spine);
        upperchest = anim.GetBoneTransform(HumanBodyBones.UpperChest);
		hip = anim.GetBoneTransform(HumanBodyBones.Hips);
        L_upperarm = anim.GetBoneTransform(HumanBodyBones.LeftUpperArm);
        L_lowerarm = anim.GetBoneTransform(HumanBodyBones.LeftLowerArm);
        L_hand = anim.GetBoneTransform(HumanBodyBones.LeftHand);
        L_upperleg = anim.GetBoneTransform(HumanBodyBones.LeftUpperLeg);
        L_lowerleg = anim.GetBoneTransform(HumanBodyBones.LeftLowerLeg);
        L_foot = anim.GetBoneTransform(HumanBodyBones.LeftFoot);
        R_upperarm = anim.GetBoneTransform(HumanBodyBones.RightUpperArm);
        R_lowerarm = anim.GetBoneTransform(HumanBodyBones.RightLowerArm);
        R_hand = anim.GetBoneTransform(HumanBodyBones.RightHand);
        R_upperleg = anim.GetBoneTransform(HumanBodyBones.RightUpperLeg);
        R_lowerleg = anim.GetBoneTransform(HumanBodyBones.RightLowerLeg);
        R_foot = anim.GetBoneTransform(HumanBodyBones.RightFoot);

        // SendData("local_head:" + head.position);
        // SendData(""+head.position+"\n"+upperchest.position+"\n"+hip.position+"\n"+L_upperarm.position+"\n"+L_lowerarm.position+"\n"+L_hand.position+"\n"+L_upperleg.position+"\n"+L_lowerleg.position+"\n"+L_foot.position+"\n"+R_upperarm.position+"\n"+R_lowerarm.position+"\n"+R_hand.position+"\n"+R_upperleg.position+"\n"+R_lowerleg.position+"\n"+R_foot.position+"\n");
        // print(head.position.x);
        if (w_head[0] != null)
        {
            head.position = new Vector3((float)Convert.ToDouble(w_head[0]), (float)Convert.ToDouble(w_head[1]), (float)Convert.ToDouble(w_head[2]));
            spine.position = new Vector3((float)Convert.ToDouble(w_spine[0]), (float)Convert.ToDouble(w_spine[1]), (float)Convert.ToDouble(w_spine[2]));
            hip.position = new Vector3((float)Convert.ToDouble(w_hip[0]), (float)Convert.ToDouble(w_hip[1]), (float)Convert.ToDouble(w_hip[2]));
            L_upperarm.position = new Vector3((float)Convert.ToDouble(w_l_upperarm[0]), (float)Convert.ToDouble(w_l_upperarm[1]), (float)Convert.ToDouble(w_l_upperarm[2]));
            L_lowerarm.position = new Vector3((float)Convert.ToDouble(w_l_lowerarm[0]), (float)Convert.ToDouble(w_l_lowerarm[1]), (float)Convert.ToDouble(w_l_lowerarm[2]));
            L_hand.position = new Vector3((float)Convert.ToDouble(w_l_hand[0]), (float)Convert.ToDouble(w_l_hand[1]), (float)Convert.ToDouble(w_l_hand[2]));
            L_upperleg.position = new Vector3((float)Convert.ToDouble(w_l_upperleg[0]), (float)Convert.ToDouble(w_l_upperleg[1]), (float)Convert.ToDouble(w_l_upperleg[2]));
            L_lowerleg.position = new Vector3((float)Convert.ToDouble(w_l_lowerleg[0]), (float)Convert.ToDouble(w_l_lowerleg[1]), (float)Convert.ToDouble(w_l_lowerleg[2]));
            L_foot.position = new Vector3((float)Convert.ToDouble(w_l_foot[0]), (float)Convert.ToDouble(w_l_foot[1]), (float)Convert.ToDouble(w_l_foot[2]));
            R_upperarm.position = new Vector3((float)Convert.ToDouble(w_r_upperarm[0]), (float)Convert.ToDouble(w_r_upperarm[1]), (float)Convert.ToDouble(w_r_upperarm[2]));
            R_lowerarm.position = new Vector3((float)Convert.ToDouble(w_r_lowerarm[0]), (float)Convert.ToDouble(w_r_lowerarm[1]), (float)Convert.ToDouble(w_r_lowerarm[2]));
            R_hand.position = new Vector3((float)Convert.ToDouble(w_r_hand[0]),(float) Convert.ToDouble(w_r_hand[1]), (float)Convert.ToDouble(w_r_hand[2]));
            R_upperleg.position = new Vector3((float)Convert.ToDouble(w_r_upperleg[0]), (float)Convert.ToDouble(w_r_upperleg[1]), (float)Convert.ToDouble(w_r_upperleg[2]));
            R_lowerleg.position = new Vector3((float)Convert.ToDouble(w_r_lowerleg[0]), (float)Convert.ToDouble(w_r_lowerleg[1]), (float)Convert.ToDouble(w_r_lowerleg[2]));
            R_foot.position = new Vector3((float)Convert.ToDouble(w_r_foot[0]), (float)Convert.ToDouble(w_r_foot[1]), (float)Convert.ToDouble(w_r_foot[2]));
        }
        
        
        // print("head:" + head.position + ", spine:" + spine.position + ", hip:" + hip.position);
        // print("L_upperarm:" + L_upperarm.position + ", L_lowerarm:" + L_lowerarm.position + ", L_hand:" + L_hand.position);
        // print("R_upperarm:" + R_upperarm.position + ", R_lowerarm:" + R_lowerarm.position + ", R_hand:" + R_hand.position);
        // print("L_upperleg:" + L_upperleg.position + ", L_lowerleg:" + L_lowerleg.position + ", L_foot:" + L_foot.position);
        // print("R_upperleg:" + R_upperleg.position + ", R_lowerleg:" + R_lowerleg.position + ", R_foot:" + R_foot.position);
        

        // SendData("head:" + head.position);
        // print(spine.position);
        // hip.position = new Vector3(10, 10, 10);
    }
}
