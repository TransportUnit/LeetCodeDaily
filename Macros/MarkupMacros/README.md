# MarkupMacros - Visual Studio Extension

## Building the Extension

After a successful build, the `.vsix` file will be generated in:
_bin\Debug\MarkupMacros.vsix_<br/>
or<br/>
_bin\Release\MarkupMacros.vsix_

## Installing the Extension Locally

1. Locate the generated `.vsix` file in the `bin` folder.
2. Double-click the `.vsix` file to launch the Visual Studio VSIX Installer.
3. Select the version of Visual Studio where you want to install the extension.
4. Click **Install** and wait for the installation to complete.
5. Restart Visual Studio if necessary to activate the commands.

## Assigning Keyboard Shortcuts

1. Open Visual Studio and go to **Tools → Options → Environment → Keyboard**.
2. In the **"Show commands containing"** field, search for the macro command, e.g., `Tools.SurroundwithSuperscript`.
3. Select the command and assign your preferred keyboard shortcut.
4. Click **Assign** and then **OK**.

You can now use your keyboard shortcut to execute the macro directly in the editor.
