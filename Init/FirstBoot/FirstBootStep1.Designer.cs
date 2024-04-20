﻿namespace IDE.Init;

partial class FirstBootStep1
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
            this.label1 = new System.Windows.Forms.Label();
            this.uiStyleManager1 = new Sunny.UI.UIStyleManager(this.components);
            this.uiButton1 = new Sunny.UI.UIButton();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 32F);
            this.label1.Location = new System.Drawing.Point(14, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(571, 70);
            this.label1.TabIndex = 0;
            this.label1.Text = "欢迎使用RYCB Editor!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiStyleManager1
            // 
            this.uiStyleManager1.GlobalFont = true;
            this.uiStyleManager1.GlobalFontName = "微软雅黑";
            // 
            // uiButton1
            // 
            this.uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiButton1.Location = new System.Drawing.Point(518, 357);
            this.uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Radius = 15;
            this.uiButton1.Size = new System.Drawing.Size(78, 33);
            this.uiButton1.TabIndex = 1;
            this.uiButton1.Text = "下一步";
            this.uiButton1.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton1.Click += new System.EventHandler(this.Next);
            // 
            // uiLabel1
            // 
            this.uiLabel1.AutoSize = true;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel1.Location = new System.Drawing.Point(333, 187);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(252, 27);
            this.uiLabel1.TabIndex = 2;
            this.uiLabel1.Text = "海内存知己，天涯若比邻。";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FirstBootStep1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(603, 396);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.uiButton1);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "FirstBootStep1";
            this.Text = "Welcome";
            this.TitleFont = new System.Drawing.Font("微软雅黑", 12F);
            this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 800, 450);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private Sunny.UI.UIStyleManager uiStyleManager1;
    private Sunny.UI.UIButton uiButton1;
    private Sunny.UI.UILabel uiLabel1;
}