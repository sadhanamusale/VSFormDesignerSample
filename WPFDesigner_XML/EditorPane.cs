/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

***************************************************************************/

using System;
using System.ComponentModel.Design;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using Microsoft.VisualStudio.TextManager.Interop;
using Microsoft.VisualStudio.Shell;

using MagicSoftware.Studio.Designer;
using System.Drawing.Design;
using System.Windows.Forms.Integration;

namespace Microsoft.VsTemplateDesigner
{
   /// <summary>
   /// This control hosts the editor and is responsible for
   /// handling the commands targeted to the editor 
   /// </summary>

   [ComVisible(true)]
    public sealed class EditorPane : WindowPane
    {
        #region Fields
        private VsTemplateDesignerPackage _thisPackage;
        private string _fileName = string.Empty;
       
      
      #endregion
      public static HostSurfaceManager hostSurfaceManager;

      private ElementHost elementHost;
      /// <summary>
      /// This is a required override from the Microsoft.VisualStudio.Shell.WindowPane class.
      /// It returns the extended rich text box that we host.
      /// </summary>
      public override IWin32Window Window
      {
         get
         {
            return elementHost;
         }
      }

      /// <summary>
      /// Constructor that calls the Microsoft.VisualStudio.Shell.WindowPane constructor then
      /// our initialization functions.
      /// </summary>
      /// <param name="package">Our Package instance.</param>
      public EditorPane(VsTemplateDesignerPackage package, string fileName, IVsTextLines textBuffer)
            : base(null)
        {
            _thisPackage = package;
            _fileName = fileName;
           
         elementHost = new ElementHost();
    
         if (hostSurfaceManager == null)
         {
            hostSurfaceManager = new HostSurfaceManager((VsTemplateDesignerPackage)package);
            IToolboxService service = (IToolboxService)Package.GetGlobalService(typeof(IToolboxService));
            hostSurfaceManager.AddService(typeof(IToolboxService), service);
            hostSurfaceManager.GetNewHost();
         }
         
         WindowsFormsHost windowsFormsHost = new WindowsFormsHost();
         windowsFormsHost.Child = hostSurfaceManager.ActiveDesignSurface.ComponentContainer.Components[0] as Control;
         elementHost.Child = windowsFormsHost;

      }

        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// returns the name of the file currently loaded
        /// </summary>
        public string FileName
        {
            get { return _fileName; }
        }

    }
}
