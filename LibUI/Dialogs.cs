﻿using LibUI.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LibUI
{
    /// <summary>
    /// Provides functions to open dialog boxes.
    /// </summary>
    public static class Dialogs
    {
        #region Interop
        [DllImport("libui.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern string uiOpenFile(ref uiControl window);
        [DllImport("libui.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern string uiSaveFile(ref uiControl window);
        [DllImport("libui.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern void uiMsgBox(ref uiControl window, string title, string desc);
        [DllImport("libui.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern void uiMsgBoxError(ref uiControl window, string title, string desc);
        #endregion

        /// <summary>
        /// Pops up an open file dialog.
        /// </summary>
        /// <param name="owner">The window that owns this dialog.</param>
        /// <returns>What the user picked; null if cancelled.</returns>
        public static string OpenFileDialog(this Window owner)
        {
            return uiOpenFile(ref owner.Substrate);
        }

        /// <summary>
        /// Pops up a save file dialog.
        /// </summary>
        /// <param name="owner">The window that owns this dialog.</param>
        /// <returns>What the user picked; null if cancelled.</returns>
        public static string SaveFileDialog(this Window owner)
        {
            return uiSaveFile(ref owner.Substrate);
        }

        /// <summary>
        /// Pops up a message dialog.
        /// </summary>
        /// <param name="owner">The window that owns this dialog.</param>
        /// <param name="title">The title of the dialog.</param>
        /// <param name="description">The message.</param>
        /// <param name="error">If this dialog should be shown as an error dialog.</param>
        public static void MessageBox(this Window owner,
            string title, string description, bool error = false)
        {
            if (error)
                uiMsgBoxError(ref owner.Substrate, title, description);
            else
                uiMsgBox(ref owner.Substrate, title, description);
        }
    }
}
