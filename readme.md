
# FS-MAT - A FromSoftware MATBIN Editor
Very basic. For now it can only edit existing params and samplers inside a matbin file. Can also swap associated shader -- beware of unexpected results. 

## Usage
0. Copy oo2core_6_win64.dll from either Sekiro or Elden Ring install next to the exe.
1. Select a matbinbnd using **File->Load allmaterial**. It will load in all matbins, and will also create a **backup file** next to it. (The matbinbnd path is also stored for the next time you launch)
2. After that you can select the **material category** (character, map, parts etc), and the actual **material** below it. It will load in the **params** and **samplers** into the tables below, and will also select the corresponding **shader**.
 
 
 - Scrolling through the **shaders list** will NOT modify it in the material. To do that, just press **Override Shader**. This has unexpected results, since other shaders require different inputs. (It won't crash the game, however)
 - **Params**: You can edit simple params by double-clicking into the value field, and will be updated if you press **Enter**. Params that contain multiple values will open into a new window after one click, and will only be updated if you click **Save** on the new window. Editable fields: **Value**.
 - **Samplers**: Same as params. Editable fields: **Path**, **Unk14**.
 - **Reset Material**: resets the material back to *original*. **This only works if you haven't changed the active material ever since you made the changes!!!** Basically it will reset back to the state it was in when it became active. (Maybe I should implement it so that it resets it to the backup file counterpart.)
 - **Save Material**: this will save the currently open allmaterial binder file to the disk. If you're making changes to more than one material, it's enough to save only once at the end. (But it never hurts to save after each one!)
 
 - **File->Restore backup from default location**: It does exactly what it says. 
 - **File->Create backup at default location**: It does exactly what it says. 

# REQUIREMENTS
[SoulsFormats](https://github.com/JKAnderson/SoulsFormats) (er branch), oo2core_6_win64.dll from either Sekiro or Elden Ring install.

# CREDITS
[SoulsFormats](https://github.com/JKAnderson/SoulsFormats)