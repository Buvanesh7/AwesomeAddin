
namespace AwesomeAddin.Views
{
    partial class WallCreationWindow
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
            this.label1 = new System.Windows.Forms.Label();
            this.cb_BaseLevel = new System.Windows.Forms.ComboBox();
            this.cb_TopLevel = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_WallTypes = new System.Windows.Forms.ComboBox();
            this.cb_Structural = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_BaseOffset = new System.Windows.Forms.TextBox();
            this.btn_Create = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Base Level:";
            // 
            // cb_BaseLevel
            // 
            this.cb_BaseLevel.FormattingEnabled = true;
            this.cb_BaseLevel.Location = new System.Drawing.Point(131, 22);
            this.cb_BaseLevel.Name = "cb_BaseLevel";
            this.cb_BaseLevel.Size = new System.Drawing.Size(152, 32);
            this.cb_BaseLevel.TabIndex = 1;
            // 
            // cb_TopLevel
            // 
            this.cb_TopLevel.FormattingEnabled = true;
            this.cb_TopLevel.Location = new System.Drawing.Point(422, 22);
            this.cb_TopLevel.Name = "cb_TopLevel";
            this.cb_TopLevel.Size = new System.Drawing.Size(152, 32);
            this.cb_TopLevel.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(306, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Top Level:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 110);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Wall Type:";
            // 
            // cb_WallTypes
            // 
            this.cb_WallTypes.FormattingEnabled = true;
            this.cb_WallTypes.Location = new System.Drawing.Point(131, 107);
            this.cb_WallTypes.Name = "cb_WallTypes";
            this.cb_WallTypes.Size = new System.Drawing.Size(252, 32);
            this.cb_WallTypes.TabIndex = 5;
            // 
            // cb_Structural
            // 
            this.cb_Structural.AutoSize = true;
            this.cb_Structural.Location = new System.Drawing.Point(422, 111);
            this.cb_Structural.Name = "cb_Structural";
            this.cb_Structural.Size = new System.Drawing.Size(107, 28);
            this.cb_Structural.TabIndex = 6;
            this.cb_Structural.Text = "Structural";
            this.cb_Structural.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 191);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "Base Offset:";
            // 
            // tb_BaseOffset
            // 
            this.tb_BaseOffset.Location = new System.Drawing.Point(131, 188);
            this.tb_BaseOffset.Name = "tb_BaseOffset";
            this.tb_BaseOffset.Size = new System.Drawing.Size(175, 29);
            this.tb_BaseOffset.TabIndex = 8;
            // 
            // btn_Create
            // 
            this.btn_Create.Location = new System.Drawing.Point(266, 251);
            this.btn_Create.Name = "btn_Create";
            this.btn_Create.Size = new System.Drawing.Size(117, 40);
            this.btn_Create.TabIndex = 9;
            this.btn_Create.Text = "Create Wall";
            this.btn_Create.UseVisualStyleBackColor = true;
            this.btn_Create.Click += new System.EventHandler(this.btn_Create_Click);
            // 
            // WallCreationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 323);
            this.Controls.Add(this.btn_Create);
            this.Controls.Add(this.tb_BaseOffset);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cb_Structural);
            this.Controls.Add(this.cb_WallTypes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cb_TopLevel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_BaseLevel);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "WallCreationWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wall Creation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_BaseLevel;
        private System.Windows.Forms.ComboBox cb_TopLevel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_WallTypes;
        private System.Windows.Forms.CheckBox cb_Structural;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_BaseOffset;
        private System.Windows.Forms.Button btn_Create;
    }
}