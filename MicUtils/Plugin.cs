using System;
using BepInEx;
using UnityEngine;
using Utilla;
using UnityEngine.InputSystem;

namespace MicUtils
{
    /// <summary>
    /// This is your mod's main class.
    /// </summary>

    /* This attribute tells Utilla to look for [ModdedGameJoin] and [ModdedGameLeave] */
    [ModdedGamemode]
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        bool inRoom;
        private Rect window;
        private bool show;
        
        void Start()
        {
           
            int width = 200;
            int height = 100;
            window = new Rect(Screen.width - width - 10, 10, width, height);

            Utilla.Events.GameInitialized += OnGameInitialized;
        }

        void OnGUI()
        {
            if (show)
            {
                window = GUI.Window(621, window, Window, "MicUtils");
            }
        }

        void Window(int window)
        {         
            if (GUILayout.Button("Enable Mic"))
            {
                EnableDisable.Ena();
            }

            if (GUILayout.Button("Disable Mic"))
            {
                EnableDisable.Dis();
            }

            if (GUILayout.Button("Refresh Mic"))
            {
                Refresh.Ref();
            }
            GUI.DragWindow();
        }

        void OnEnable()
        {
            /* Set up your mod here */
            /* Code here runs at the start and whenever your mod is enabled*/

            HarmonyPatches.ApplyHarmonyPatches();
        }

        void OnDisable()
        {
            /* Undo mod setup here */
            /* This provides support for toggling mods with ComputerInterface, please implement it :) */
            /* Code here runs whenever your mod is disabled (including if it disabled on startup)*/

            HarmonyPatches.RemoveHarmonyPatches();
        }

        void OnGameInitialized(object sender, EventArgs e)
        {
            /* Code here runs after the game initializes (i.e. GorillaLocomotion.Player.Instance != null) */
        }

        void Update()
        {
            if (Keyboard.current.mKey.wasPressedThisFrame)
            {
                show = !show;
            }
        }

        /* This attribute tells Utilla to call this method when a modded room is joined */
        [ModdedGamemodeJoin]
        public void OnJoin(string gamemode)
        {
            /* Activate your mod here */
            /* This code will run regardless of if the mod is enabled*/

            inRoom = true;
        }

        /* This attribute tells Utilla to call this method when a modded room is left */
        [ModdedGamemodeLeave]
        public void OnLeave(string gamemode)
        {
            /* Deactivate your mod here */
            /* This code will run regardless of if the mod is enabled*/

            inRoom = false;
        }
    }
}
