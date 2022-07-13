using System;
using System.Windows.Forms;
using System.ComponentModel.Design;

namespace WPFDesigner_XML
{
   public partial class HostControl : UserControl, INotifyNewSelection
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
    
      private HostSurface _hostSurface;

      public HostControl(HostSurface hostSurface)
      {
         // This call is required by the Windows.Forms Form Designer.
         InitializeComponent();
         InitializeHost(hostSurface);
      }

      internal void InitializeHost(HostSurface hostSurface)
      {
         try
         {
            if (hostSurface == null)
               return;

            _hostSurface = hostSurface;

            Control control = _hostSurface.View as Control;

            // Preclude the overlay control residing inside the DesignerFrame (stored as _hostSurface.View),
            // from displaying scrollbars when DesignerForm's edges are set too close to the edge of the client area
            // of FormDesignerScreen presenter. There is a minimum default scroll margin which needs to be set to zero
            // in both dimensions to prevent these pesky scrollbars from appearing automatically when this happens.
            ScrollableControl s = control.Controls[0] as ScrollableControl;
            if (s != null)
               s.SetAutoScrollMargin(0, 0);


            control.BackColor = System.Drawing.Color.DarkGray;
            control.Parent = this;
            control.Dock = DockStyle.Fill;
            control.Visible = true;

         }

         catch (Exception )
         {
            
         }
      }

      /// <summary>
      /// Check if the key that was pressed is a-z or 1-9.
      /// </summary>
      /// <param name="e"></param>
      /// <returns></returns>
      bool IsLetterOrDigitPressed(System.Windows.Forms.KeyEventArgs e)
      {
         if (e.Modifiers == Keys.Alt || e.Modifiers == Keys.Control)
            return false;
         else
         {
            KeysConverter kc = new KeysConverter();
            string keyChar = kc.ConvertToString(e.KeyData);
            if (char.IsLetterOrDigit(keyChar, 0))
               return true;
            else
               return false;
         }
      }

      /// <summary>
      /// get the key down events, to enable processing of keyboard events on the designer
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      void control_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
      {
      }

      public HostSurface HostSurface
      {
         get
         {
            return _hostSurface;
         }
      }
      public IDesignerHost DesignerHost
      {
         get
         {
            return (IDesignerHost)_hostSurface.GetService(typeof(IDesignerHost));
         }
      }

      #region INotifyNewSelection Members


      #endregion

      /// <summary>
      /// When switching between task tabs, the controls in the form designer are assigned with a new font, what may 
      /// (e.g. in TextBox) causes a recalculation and change of the control's height, which in turn causes the dirty 
      /// indication to be turned on with no good reason. This override function stops this from happening by preventing 
      /// the default treatment of OnFontChanged in the HostControl
      /// </summary>
      /// <param name="e"></param>
      protected override void OnFontChanged(EventArgs e)
      {
      }

      /// <summary>
      /// make the system know the tab key was processed
      /// </summary>
      /// <param name="msg"></param>
      /// <param name="keyData"></param>
      /// <returns></returns>
      protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
      {
         bool ret = base.ProcessCmdKey(ref msg, keyData);
         if ((keyData & Keys.KeyCode) == Keys.Tab)
            ret = true;

         return ret;
      }
   }
}
