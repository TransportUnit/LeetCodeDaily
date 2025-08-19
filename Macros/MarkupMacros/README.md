# MarkupMacros - Visual Studio Extension

**MarkupMacros** is a Visual Studio extension that provides a collection of macros for markup editing. These macros can be assigned to keyboard shortcuts, allowing you to perform common text transformations quickly and efficiently without using the mouse.

## Features

- Apply superscript formatting with a single keyboard shortcut.
- Add additional macros as needed for HTML, XML, or other markup languages.
- Branchless and lightweight implementation for fast execution within the editor.

## Building the Extension

1. Open the solution `MarkupMacros.sln` in Visual Studio.
2. Ensure the target framework is set to **.NET Framework 4.7.2** (or the framework specified in the project).
3. Build the project in **Debug** or **Release** mode.
4. After a successful build, the `.vsix` file will be generated in:
_bin\Debug\MarkupMacros.vsix_<br/>
or<br/>
_bin\Release\MarkupMacros.vsix_

## Installing the Extension Locally

1. Locate the generated `.vsix` file in the `bin` folder.
2. Double-click the `.vsix` file to launch the Visual Studio VSIX Installer.
3. Select the version of Visual Studio where you want to install the extension.
4. Click **Install** and wait for the installation to complete.
5. Restart Visual Studio if necessary to activate the commands.

> Tip: During development, you can press **F5** in Visual Studio to launch an experimental instance with the extension loaded without permanently installing it.

## Assigning Keyboard Shortcuts

1. Open Visual Studio and go to **Tools → Options → Environment → Keyboard**.
2. In the **"Show commands containing"** field, search for the macro command, e.g., `Tools.SurroundwithSuperscript`.
3. Select the command and assign your preferred keyboard shortcut.
4. Click **Assign** and then **OK**.

You can now use your keyboard shortcut to execute the macro directly in the editor.