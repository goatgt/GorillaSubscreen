using System;
using System.IO;
using System.Reflection;
using BepInEx;
// using TMPro; If you want to change the text, uncomment this out.
using UnityEngine;

namespace Subscribe
{
	[BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
	public class Plugin : BaseUnityPlugin
	{
        private GameObject SubscriberBoard;
        private Vector3 POS = new Vector3(-194.0529f, 27.484f, -95.2336f); // This is the POS of the SubscriberBoard
        // private TextMeshPro Text; This goes with changing the text

        void Start()
        {
            var bundle = LoadAssetBundle("Subscribermod.Assets.subscribe");
            //var Subscriber = bundle.LoadAsset<GameObject>("Subscribe Mod");
            SubscriberBoard = bundle.LoadAsset<GameObject>("Subscribe Mod");

            GorillaTagger.OnPlayerSpawned(OnGameInitialized);
        }
        
        void OnGameInitialized()
        {
            SubscriberBoard = Instantiate(SubscriberBoard);
            SubscriberBoard.transform.position = POS;
            SubscriberBoard.name = "SubscriberBoard";

            /*
            This chnages the text if you want to use it
             
            Text = GameObject.Find("SubscriberBoard/SUB").GetComponent<TextMeshPro>();
            Text.text = "subscribe"
            */
        }

        public AssetBundle LoadAssetBundle(string path)
        {
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path);
            AssetBundle bundle = AssetBundle.LoadFromStream(stream);
            stream.Close();
            return bundle;
        }
    }
}