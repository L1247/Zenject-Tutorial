using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace PureCsharp.Core
{
    public class MenuUI : MonoBehaviour
    {
        [SerializeField]
        private Button button1;

        [SerializeField]
        private Button button2;

        [Inject]
        private ZenjectSceneLoader sceneLoader;

        private void Start()
        {
            button1.onClick.AddListener(() => LoadSceneWithArg(20f));
            button2.onClick.AddListener(() => LoadSceneWithArg(10f));
        }

        private void LoadSceneWithArg(float moveSpeed)
        {
            sceneLoader.LoadScene("ExampleScene" , LoadSceneMode.Single ,
                                  container => { container.BindInstance(moveSpeed).WithId("MoveSpeed"); });
        }
    }
}