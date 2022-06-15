using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.Design.Serialization;

namespace WPFDesigner_XML
{
   public  class BasicHostLoader : BasicDesignerLoader
   {
      private IDesignerLoaderHost host;
      public BasicHostLoader()
      {
        
      }

      protected override void PerformFlush(IDesignerSerializationManager serializationManager)
      {
      }

      protected override void PerformLoad(IDesignerSerializationManager serializationManager)
      {
         this.host = this.LoaderHost;
         object instance = host.CreateComponent(typeof(TestForm));
      }
   }
}
