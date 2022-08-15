using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Dialogs
{
    public class DialogExampleScene : MonoBehaviour
    {

        private XMLHandler scriptHandler = new XMLHandler();
        public string filePath;
        public GameObject dialogUI;
        public Dialog dialogManager;

        private void Awake() {
            DialogsHandler.instance = new DialogsHandler();
            MonoScript ms = MonoScript.FromMonoBehaviour( this );
            string m_ScriptFilePath = AssetDatabase.GetAssetPath( ms );
 
            FileInfo fi = new FileInfo( m_ScriptFilePath);
            string  m_ScriptFolder = fi.Directory.ToString();
            
            scriptHandler.Start(m_ScriptFolder + filePath );
        }

        private void Start() {
            dialogManager.StartDialog(0);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                for (int i = 0; i < dialogUI.transform.childCount; i++)
                {
                    Destroy(dialogUI.transform.GetChild(i).gameObject);
                }

                DialogsHandler.instance.loadedDialogs = new Dictionary<int, Dictionary<int, Node>>();

                scriptHandler = new XMLHandler();
                scriptHandler.Start(filePath);
                dialogManager.StartDialog(0);
            }
        }
    }
}