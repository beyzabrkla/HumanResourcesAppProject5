namespace HumanResourcesApp
{
    partial class frmStaffAddress
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStaffAddress));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.label2 = new System.Windows.Forms.Label();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.txt_adress = new Bunifu.UI.WinForms.BunifuTextBox();
            this.bunifuElipse3 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuGradientPanel1 = new Bunifu.UI.WinForms.BunifuGradientPanel();
            this.bunifuFormControlBox1 = new Bunifu.UI.WinForms.BunifuFormControlBox();
            this.lbl_Main = new System.Windows.Forms.Label();
            this.btnsave = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.bunifuGradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Book Antiqua", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label2.Location = new System.Drawing.Point(143, 137);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 31);
            this.label2.TabIndex = 23;
            this.label2.Text = "Personel Adresi:";
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 50;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 40;
            this.bunifuElipse2.TargetControl = this.txt_adress;
            // 
            // txt_adress
            // 
            this.txt_adress.AcceptsReturn = false;
            this.txt_adress.AcceptsTab = true;
            this.txt_adress.AnimationSpeed = 200;
            this.txt_adress.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txt_adress.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txt_adress.AutoSizeHeight = true;
            this.txt_adress.BackColor = System.Drawing.Color.Transparent;
            this.txt_adress.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txt_adress.BackgroundImage")));
            this.txt_adress.BorderColorActive = System.Drawing.Color.MidnightBlue;
            this.txt_adress.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txt_adress.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.txt_adress.BorderColorIdle = System.Drawing.Color.Silver;
            this.txt_adress.BorderRadius = 40;
            this.txt_adress.BorderThickness = 1;
            this.txt_adress.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txt_adress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_adress.DefaultFont = new System.Drawing.Font("Book Antiqua", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_adress.DefaultText = "";
            this.txt_adress.FillColor = System.Drawing.Color.White;
            this.txt_adress.HideSelection = true;
            this.txt_adress.IconLeft = null;
            this.txt_adress.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_adress.IconPadding = 10;
            this.txt_adress.IconRight = null;
            this.txt_adress.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_adress.Lines = new string[0];
            this.txt_adress.Location = new System.Drawing.Point(148, 181);
            this.txt_adress.Margin = new System.Windows.Forms.Padding(4);
            this.txt_adress.MaxLength = 32767;
            this.txt_adress.MinimumSize = new System.Drawing.Size(1, 1);
            this.txt_adress.Modified = false;
            this.txt_adress.Multiline = true;
            this.txt_adress.Name = "txt_adress";
            stateProperties1.BorderColor = System.Drawing.Color.MidnightBlue;
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txt_adress.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txt_adress.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txt_adress.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.Silver;
            stateProperties4.FillColor = System.Drawing.Color.White;
            stateProperties4.ForeColor = System.Drawing.Color.Empty;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txt_adress.OnIdleState = stateProperties4;
            this.txt_adress.Padding = new System.Windows.Forms.Padding(4);
            this.txt_adress.PasswordChar = '\0';
            this.txt_adress.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txt_adress.PlaceholderText = "Adres";
            this.txt_adress.ReadOnly = false;
            this.txt_adress.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_adress.SelectedText = "";
            this.txt_adress.SelectionLength = 0;
            this.txt_adress.SelectionStart = 0;
            this.txt_adress.ShortcutsEnabled = true;
            this.txt_adress.Size = new System.Drawing.Size(587, 225);
            this.txt_adress.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.txt_adress.TabIndex = 24;
            this.txt_adress.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_adress.TextMarginBottom = 0;
            this.txt_adress.TextMarginLeft = 3;
            this.txt_adress.TextMarginTop = 1;
            this.txt_adress.TextPlaceholder = "Adres";
            this.txt_adress.UseSystemPasswordChar = false;
            this.txt_adress.WordWrap = true;
            // 
            // bunifuElipse3
            // 
            this.bunifuElipse3.ElipseRadius = 40;
            this.bunifuElipse3.TargetControl = this;
            // 
            // bunifuGradientPanel1
            // 
            this.bunifuGradientPanel1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel1.BackgroundImage")));
            this.bunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel1.BorderRadius = 1;
            this.bunifuGradientPanel1.Controls.Add(this.bunifuFormControlBox1);
            this.bunifuGradientPanel1.Controls.Add(this.lbl_Main);
            this.bunifuGradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bunifuGradientPanel1.GradientBottomLeft = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(92)))), ((int)(((byte)(188)))));
            this.bunifuGradientPanel1.GradientBottomRight = System.Drawing.Color.DeepPink;
            this.bunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.DodgerBlue;
            this.bunifuGradientPanel1.GradientTopRight = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(60)))), ((int)(((byte)(212)))));
            this.bunifuGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuGradientPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.bunifuGradientPanel1.Name = "bunifuGradientPanel1";
            this.bunifuGradientPanel1.Quality = 10;
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(847, 73);
            this.bunifuGradientPanel1.TabIndex = 5;
            // 
            // bunifuFormControlBox1
            // 
            this.bunifuFormControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuFormControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuFormControlBox1.BunifuFormDrag = null;
            this.bunifuFormControlBox1.CloseBoxOptions.BackColor = System.Drawing.Color.Transparent;
            this.bunifuFormControlBox1.CloseBoxOptions.BorderRadius = 0;
            this.bunifuFormControlBox1.CloseBoxOptions.Enabled = true;
            this.bunifuFormControlBox1.CloseBoxOptions.EnableDefaultAction = true;
            this.bunifuFormControlBox1.CloseBoxOptions.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.bunifuFormControlBox1.CloseBoxOptions.Icon = ((System.Drawing.Image)(resources.GetObject("bunifuFormControlBox1.CloseBoxOptions.Icon")));
            this.bunifuFormControlBox1.CloseBoxOptions.IconAlt = null;
            this.bunifuFormControlBox1.CloseBoxOptions.IconColor = System.Drawing.Color.White;
            this.bunifuFormControlBox1.CloseBoxOptions.IconHoverColor = System.Drawing.Color.White;
            this.bunifuFormControlBox1.CloseBoxOptions.IconPressedColor = System.Drawing.Color.Transparent;
            this.bunifuFormControlBox1.CloseBoxOptions.IconSize = new System.Drawing.Size(18, 18);
            this.bunifuFormControlBox1.CloseBoxOptions.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.bunifuFormControlBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.bunifuFormControlBox1.ForeColor = System.Drawing.Color.White;
            this.bunifuFormControlBox1.HelpBox = true;
            this.bunifuFormControlBox1.HelpBoxOptions.BackColor = System.Drawing.Color.Transparent;
            this.bunifuFormControlBox1.HelpBoxOptions.BorderRadius = 0;
            this.bunifuFormControlBox1.HelpBoxOptions.Enabled = true;
            this.bunifuFormControlBox1.HelpBoxOptions.EnableDefaultAction = true;
            this.bunifuFormControlBox1.HelpBoxOptions.HoverColor = System.Drawing.Color.LightGray;
            this.bunifuFormControlBox1.HelpBoxOptions.Icon = ((System.Drawing.Image)(resources.GetObject("bunifuFormControlBox1.HelpBoxOptions.Icon")));
            this.bunifuFormControlBox1.HelpBoxOptions.IconAlt = null;
            this.bunifuFormControlBox1.HelpBoxOptions.IconColor = System.Drawing.Color.White;
            this.bunifuFormControlBox1.HelpBoxOptions.IconHoverColor = System.Drawing.Color.Black;
            this.bunifuFormControlBox1.HelpBoxOptions.IconPressedColor = System.Drawing.Color.Black;
            this.bunifuFormControlBox1.HelpBoxOptions.IconSize = new System.Drawing.Size(22, 22);
            this.bunifuFormControlBox1.HelpBoxOptions.PressedColor = System.Drawing.Color.Silver;
            this.bunifuFormControlBox1.Location = new System.Drawing.Point(638, 7);
            this.bunifuFormControlBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bunifuFormControlBox1.MaximizeBox = true;
            this.bunifuFormControlBox1.MaximizeBoxOptions.BackColor = System.Drawing.Color.Transparent;
            this.bunifuFormControlBox1.MaximizeBoxOptions.BorderRadius = 0;
            this.bunifuFormControlBox1.MaximizeBoxOptions.Enabled = false;
            this.bunifuFormControlBox1.MaximizeBoxOptions.EnableDefaultAction = true;
            this.bunifuFormControlBox1.MaximizeBoxOptions.HoverColor = System.Drawing.Color.Silver;
            this.bunifuFormControlBox1.MaximizeBoxOptions.Icon = ((System.Drawing.Image)(resources.GetObject("bunifuFormControlBox1.MaximizeBoxOptions.Icon")));
            this.bunifuFormControlBox1.MaximizeBoxOptions.IconAlt = ((System.Drawing.Image)(resources.GetObject("bunifuFormControlBox1.MaximizeBoxOptions.IconAlt")));
            this.bunifuFormControlBox1.MaximizeBoxOptions.IconColor = System.Drawing.Color.White;
            this.bunifuFormControlBox1.MaximizeBoxOptions.IconHoverColor = System.Drawing.Color.Black;
            this.bunifuFormControlBox1.MaximizeBoxOptions.IconPressedColor = System.Drawing.Color.Black;
            this.bunifuFormControlBox1.MaximizeBoxOptions.IconSize = new System.Drawing.Size(16, 16);
            this.bunifuFormControlBox1.MaximizeBoxOptions.PressedColor = System.Drawing.Color.Silver;
            this.bunifuFormControlBox1.MinimizeBox = true;
            this.bunifuFormControlBox1.MinimizeBoxOptions.BackColor = System.Drawing.Color.Transparent;
            this.bunifuFormControlBox1.MinimizeBoxOptions.BorderRadius = 0;
            this.bunifuFormControlBox1.MinimizeBoxOptions.Enabled = true;
            this.bunifuFormControlBox1.MinimizeBoxOptions.EnableDefaultAction = true;
            this.bunifuFormControlBox1.MinimizeBoxOptions.HoverColor = System.Drawing.Color.LightGray;
            this.bunifuFormControlBox1.MinimizeBoxOptions.Icon = ((System.Drawing.Image)(resources.GetObject("bunifuFormControlBox1.MinimizeBoxOptions.Icon")));
            this.bunifuFormControlBox1.MinimizeBoxOptions.IconAlt = null;
            this.bunifuFormControlBox1.MinimizeBoxOptions.IconColor = System.Drawing.Color.White;
            this.bunifuFormControlBox1.MinimizeBoxOptions.IconHoverColor = System.Drawing.Color.Black;
            this.bunifuFormControlBox1.MinimizeBoxOptions.IconPressedColor = System.Drawing.Color.Black;
            this.bunifuFormControlBox1.MinimizeBoxOptions.IconSize = new System.Drawing.Size(14, 14);
            this.bunifuFormControlBox1.MinimizeBoxOptions.PressedColor = System.Drawing.Color.Silver;
            this.bunifuFormControlBox1.Name = "bunifuFormControlBox1";
            this.bunifuFormControlBox1.ShowDesignBorders = false;
            this.bunifuFormControlBox1.Size = new System.Drawing.Size(195, 63);
            this.bunifuFormControlBox1.TabIndex = 5;
            // 
            // lbl_Main
            // 
            this.lbl_Main.AutoSize = true;
            this.lbl_Main.Font = new System.Drawing.Font("Book Antiqua", 20.75F);
            this.lbl_Main.ForeColor = System.Drawing.Color.White;
            this.lbl_Main.Location = new System.Drawing.Point(20, 15);
            this.lbl_Main.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Main.Name = "lbl_Main";
            this.lbl_Main.Size = new System.Drawing.Size(259, 41);
            this.lbl_Main.TabIndex = 1;
            this.lbl_Main.Text = "Adres Güncelle";
            // 
            // btnsave
            // 
            this.btnsave.AllowAnimations = true;
            this.btnsave.AllowMouseEffects = true;
            this.btnsave.AllowToggling = false;
            this.btnsave.AnimationSpeed = 200;
            this.btnsave.AutoGenerateColors = false;
            this.btnsave.AutoRoundBorders = true;
            this.btnsave.AutoSizeLeftIcon = true;
            this.btnsave.AutoSizeRightIcon = true;
            this.btnsave.BackColor = System.Drawing.Color.Transparent;
            this.btnsave.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.btnsave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnsave.BackgroundImage")));
            this.btnsave.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Dot;
            this.btnsave.ButtonText = "Kaydet";
            this.btnsave.ButtonTextMarginLeft = 0;
            this.btnsave.ColorContrastOnClick = 45;
            this.btnsave.ColorContrastOnHover = 45;
            this.btnsave.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnsave.CustomizableEdges = borderEdges1;
            this.btnsave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnsave.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnsave.DisabledFillColor = System.Drawing.Color.Empty;
            this.btnsave.DisabledForecolor = System.Drawing.Color.Empty;
            this.btnsave.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnsave.Font = new System.Drawing.Font("Book Antiqua", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnsave.ForeColor = System.Drawing.Color.White;
            this.btnsave.IconLeft = null;
            this.btnsave.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsave.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnsave.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnsave.IconMarginLeft = 11;
            this.btnsave.IconPadding = 10;
            this.btnsave.IconRight = null;
            this.btnsave.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnsave.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnsave.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnsave.IconSize = 25;
            this.btnsave.IdleBorderColor = System.Drawing.Color.Empty;
            this.btnsave.IdleBorderRadius = 0;
            this.btnsave.IdleBorderThickness = 0;
            this.btnsave.IdleFillColor = System.Drawing.Color.Empty;
            this.btnsave.IdleIconLeftImage = null;
            this.btnsave.IdleIconRightImage = null;
            this.btnsave.IndicateFocus = false;
            this.btnsave.Location = new System.Drawing.Point(155, 432);
            this.btnsave.Margin = new System.Windows.Forms.Padding(4);
            this.btnsave.Name = "btnsave";
            this.btnsave.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnsave.OnDisabledState.BorderRadius = 48;
            this.btnsave.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnsave.OnDisabledState.BorderThickness = 1;
            this.btnsave.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnsave.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnsave.OnDisabledState.IconLeftImage = null;
            this.btnsave.OnDisabledState.IconRightImage = null;
            this.btnsave.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnsave.onHoverState.BorderRadius = 48;
            this.btnsave.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnsave.onHoverState.BorderThickness = 1;
            this.btnsave.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnsave.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnsave.onHoverState.IconLeftImage = null;
            this.btnsave.onHoverState.IconRightImage = null;
            this.btnsave.OnIdleState.BorderColor = System.Drawing.Color.DeepPink;
            this.btnsave.OnIdleState.BorderRadius = 48;
            this.btnsave.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Dot;
            this.btnsave.OnIdleState.BorderThickness = 1;
            this.btnsave.OnIdleState.FillColor = System.Drawing.Color.DeepPink;
            this.btnsave.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnsave.OnIdleState.IconLeftImage = null;
            this.btnsave.OnIdleState.IconRightImage = null;
            this.btnsave.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnsave.OnPressedState.BorderRadius = 48;
            this.btnsave.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnsave.OnPressedState.BorderThickness = 1;
            this.btnsave.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnsave.OnPressedState.ForeColor = System.Drawing.Color.LightGray;
            this.btnsave.OnPressedState.IconLeftImage = null;
            this.btnsave.OnPressedState.IconRightImage = null;
            this.btnsave.Size = new System.Drawing.Size(200, 48);
            this.btnsave.TabIndex = 88;
            this.btnsave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnsave.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnsave.TextMarginLeft = 0;
            this.btnsave.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnsave.UseDefaultRadiusAndThickness = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // frmStaffAddress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(31)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(847, 555);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.txt_adress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bunifuGradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmStaffAddress";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmWage";
            this.Load += new System.EventHandler(this.frmWage_Load);
            this.bunifuGradientPanel1.ResumeLayout(false);
            this.bunifuGradientPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuFormControlBox bunifuFormControlBox1;
        private Bunifu.UI.WinForms.BunifuGradientPanel bunifuGradientPanel1;
        private System.Windows.Forms.Label lbl_Main;
        private Bunifu.UI.WinForms.BunifuTextBox txt_adress;
        public System.Windows.Forms.Label label2;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse3;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnsave;
    }
}