﻿using System;
using System.IO;
using MelonLoader.Fixes;
using MelonLoader.Godot.Utils;
using MelonLoader.Interfaces;
using MelonLoader.Utils;

namespace MelonLoader.Godot.EngineModule;

public class EngineModule : IEngineModule
{
    public string EngineName => "Godot";
    
    public string EngineVersion { get; private set; }
    public string GameName { get; private set; }

#if NET35_OR_GREATER || NETSTANDARD2_1_OR_GREATER
    public string RuntimeName => "Mono";
#elif NET6_0_OR_GREATER
    public string RuntimeName => $".Net {Environment.Version}";
#endif

    public void Initialize()
    {
        string pckPath = Path.Combine(MelonEnvironment.MelonBaseDirectory,
            $"{MelonEnvironment.GameExecutableName}.pck");
        
        GodotEnvironment.Initialize(pckPath);
        
        GameName = GodotEnvironment.GameName;
        EngineVersion = GodotEnvironment.EngineVersion.ToString();
        MelonDebug.Msg($"Engine Version: {GodotEnvironment.EngineVersion}");
        
    }
}