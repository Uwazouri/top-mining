# top-mining
A Valheim mod using BepInEx to make mining deposits less of a hassle

## Reference Libraries

For project to work we need some libraries from the Valheim directory (BepInEx installed). Copy these files from your personal Valheim installation directory to the Lib folder:

BepInEx\core\0Harmony.dll
BepInEx\core\BepInEx.dll
valheim_Data\Managed\assembly_valheim.dll
unstripped_managed\UnityEngine.dll (or unstripped_corlib\UnityEngine.dll)
unstripped_managed\UnityEngine.CoreModule.dll (or unstripped_corlib\UnityEngine.CoreModule.dll)
unstripped_managed\UnityEngine.PhysicsModule.dll (or unstripped_corlib\UnityEngine.PhysicsModule.dll)

## Auto NOTE

If you want to copy the mod into your BepInEx plugins folder automatically after build, set an environment variable called 'ValheimBepInExPlugins' to your full valheim bepinex plugins path (ex: C:\Steam\steamapps\common\Valheim\BepInEx\plugins)