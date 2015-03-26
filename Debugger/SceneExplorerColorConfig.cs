﻿using System;
using UnityEngine;

namespace ModTools
{
    public class SceneExplorerColorConfig : GUIWindow
    {

        public SceneExplorerColorConfig() : base("Color configuration", new Rect(16.0f, 16.0f, 500.0f, 400.0f), skin)
        {
            onDraw = DrawWindow;
            onException = HandleException;
            visible = false;
        }

        void DrawColorControl(string name, ref Color value, ColorPicker.OnColorChanged onColorChanged)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label(name);
            GUILayout.FlexibleSpace();
            GUIControls.ColorField(name, "", ref value, 0.0f, null, true, true, onColorChanged);
            GUILayout.EndHorizontal();
        }

        void DrawWindow()
        {
            var config = ModTools.Instance.config;
            DrawColorControl("GameObject", ref config.gameObjectColor, color => config.gameObjectColor = color);
            DrawColorControl("Component (enabled)", ref config.enabledComponentColor, color => config.enabledComponentColor = color);
            DrawColorControl("Component (disabled)", ref config.disabledComponentColor, color => config.disabledComponentColor = color);
            DrawColorControl("Selected component", ref config.selectedComponentColor, color => config.selectedComponentColor = color);
            DrawColorControl("Keyword", ref config.keywordColor, color => config.keywordColor = color);
            DrawColorControl("Member name", ref config.nameColor, color => config.nameColor = color);
            DrawColorControl("Member type", ref config.typeColor, color => config.typeColor = color);
            DrawColorControl("Member modifier", ref config.modifierColor, color => config.modifierColor = color);
            DrawColorControl("Field type", ref config.memberTypeColor, color => config.memberTypeColor = color);
            DrawColorControl("Member value", ref config.valueColor, color => config.valueColor = color);

            GUILayout.BeginHorizontal();

            if (GUILayout.Button("Save", GUILayout.Width(128)))
            {
                ModTools.Instance.SaveConfig();
            }

            if (GUILayout.Button("Reset", GUILayout.Width(128)))
            {
                var template = new Configuration();

                config.gameObjectColor = template.gameObjectColor;
                config.enabledComponentColor = template.enabledComponentColor;
                config.disabledComponentColor = template.disabledComponentColor;
                config.selectedComponentColor = template.selectedComponentColor;
                config.nameColor = template.nameColor;
                config.typeColor = template.typeColor;
                config.modifierColor = template.modifierColor;
                config.memberTypeColor = template.memberTypeColor;
                config.valueColor = template.valueColor;

                ModTools.Instance.SaveConfig();
            }

            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
        }

        void HandleException(Exception ex)
        {
            Log.Error("Exception in SceneExplorerColorConfig - " + ex.Message);
            visible = false;
        }

    }
}