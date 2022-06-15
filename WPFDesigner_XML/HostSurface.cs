using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VsTemplateDesigner;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Drawing;



namespace WPFDesigner_XML
{
   public class HostSurface : DesignSurface
   {
      internal const string ClipboardBaseString = "MAGIC_CONTROLS_DATA";


      internal VsTemplateDesignerPackage Package { get; private set; }

      private BasicDesignerLoader _loader;
      public BasicDesignerLoader Loader
      {
         get
         {
            return _loader;
         }
         set
         {
            _loader = value;
         }
      }
     
      internal IDesignerHost DesignerHost { get { return (IDesignerHost)GetService(typeof(IDesignerHost)); } }
    
     
      /// <summary>
      /// list of transaction that should be ignored by magic mechanisms
      /// </summary>
      public static List<string> TransactionsToIgnore = new List<string>()
      {
         "No Description Available",
      };

      

      /// <summary>
      /// CTOR
      /// </summary>
      public HostSurface()
         : base()
      {
        
      }

      /// <summary>
      /// CTOR
      /// </summary>
      /// <param name="parentProvider"></param>
      /// <param name="package"></param>
      public HostSurface(IServiceProvider parentProvider, VsTemplateDesignerPackage package)
         : base(parentProvider)
      {
         this.Package = package;

      }

      /// <param name="e"></param>
      protected override void OnViewActivate(EventArgs e)
      {
         base.OnViewActivate(e);
         IVsWindowFrame service = (IVsWindowFrame)base.GetService(typeof(IVsWindowFrame));
         if (service != null)
            service.Show();

      }
   }// class
}
