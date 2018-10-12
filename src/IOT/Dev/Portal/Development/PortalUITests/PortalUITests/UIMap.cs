namespace PortalUITests
{
    using System;
    using System.Collections.Generic;
    using System.CodeDom.Compiler;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;
    using System.Drawing;
    using System.Windows.Input;
    using System.Text.RegularExpressions;
    using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
    
    
    public partial class UIMap
    {
        /// <summary>
        /// Navigate to login and enter data
        /// </summary>
        public void Login(String username, String password)
        {
            #region Variable Declarations
            HtmlHyperlink uILoginHyperlink = this.UIHomeDiamondCircleIntWindow.UIHomeDiamondCircleDocument.UILoginHyperlink;
            HtmlEdit uIUsernameEdit = this.UIHomeDiamondCircleIntWindow.UILoginDiamondCircleDocument.UIUsernameEdit;
            HtmlEdit uIPasswordEdit = this.UIHomeDiamondCircleIntWindow.UILoginDiamondCircleDocument.UIPasswordEdit;
            HtmlInputButton uILoginButton = this.UIHomeDiamondCircleIntWindow.UILoginDiamondCircleDocument.UILoginFormCustom.UILoginButton;
            #endregion

            // Click 'Login' link
            Mouse.Click(uILoginHyperlink, new Point(312, 86));

            // Type 'lucascullen' in 'User name' text box
            uIUsernameEdit.Text = username;

            // Type '{Tab}' in 'User name' text box
            Keyboard.SendKeys(uIUsernameEdit, this.LoginParams.UIUsernameEditSendKeys, ModifierKeys.None);

            // Type '********' in 'Password' text box
            uIPasswordEdit.Password = password;

            // Click 'Login' button
            Mouse.Click(uILoginButton, new Point(228, 61));
        }
    }
}
