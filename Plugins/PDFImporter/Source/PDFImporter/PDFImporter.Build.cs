// Some copyright should be here...

using UnrealBuildTool;
using System;
using System.IO;

public class PDFImporter : ModuleRules
{
	public PDFImporter(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = ModuleRules.PCHUsageMode.UseExplicitOrSharedPCHs;
	
		PublicDependencyModuleNames.AddRange(
			new string[]
			{
				"Core",
                "CoreUObject",
                "Engine",
                "InputCore",
                "SlateCore",
                "UnrealEd",
                "AssetTools",
				// ... add other public dependencies that you statically link with here ...
			}
			);
			
		
		PrivateDependencyModuleNames.AddRange(
			new string[]
			{
				"CoreUObject",
				"Engine",
				"Slate",
				"SlateCore",
				// ... add private dependencies that you statically link with here ...	
			}
			);

        string GhostscriptPath = Path.Combine(ModuleDirectory, "..", "..", "..", "..", "ThirdParty", "Ghostscript");
        string Platform = string.Empty;
        switch(Target.Platform)
        {
            case UnrealTargetPlatform.Win64:    Platform = "Win64";     break;
            case UnrealTargetPlatform.Win32:    Platform = "Win32";     break;
            default:
                throw new Exception(string.Format("Unsupported platform {0}", Target.Platform.ToString()));
        }
        GhostscriptPath = Path.Combine(GhostscriptPath, Platform, "gsdll.dll");

        if(!File.Exists(GhostscriptPath))
        {
            throw new Exception(string.Format("File not found {0}", GhostscriptPath));
        }

        RuntimeDependencies.Add(GhostscriptPath);
    }
}
