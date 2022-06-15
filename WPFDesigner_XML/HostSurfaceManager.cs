using Microsoft.VsTemplateDesigner;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using WPFDesigner_XML;

namespace MagicSoftware.Studio.Designer
{


   /// <summary>
   /// Manages numerous HostSurfaces. Any services added to HostSurfaceManager
   /// will be accessible to all HostSurfaces
   /// </summary>
   public class HostSurfaceManager : DesignSurfaceManager
   {
      VsTemplateDesignerPackage package;
      public HostSurfaceManager(VsTemplateDesignerPackage package)
         : base()
      {
         this.package = package;
        

      }
      protected override DesignSurface CreateDesignSurfaceCore(IServiceProvider parentProvider)
      {
 
         return new HostSurface(parentProvider, package);
      }

      /// <summary>
      /// Gets a new HostSurface and loads it with the appropriate type of
      /// root component. 
      /// </summary>
      public HostControl GetNewHost()
      {
         HostSurface hostSurface = (HostSurface)this.CreateDesignSurface(this.ServiceContainer);
       
         BasicDesignerLoader loader = new BasicHostLoader();
         hostSurface.Loader = loader;
  
         hostSurface.BeginLoad(loader);
    
         this.ActiveDesignSurface = hostSurface;
         return new HostControl(hostSurface);
      }





      public void AddService(Type type, object serviceInstance)
      {
         this.ServiceContainer.AddService(type, serviceInstance);
      }


   }// class
}// namespace
