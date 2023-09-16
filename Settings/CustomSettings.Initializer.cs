﻿using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace IDE;
public partial class CustomSettings
{
    private static readonly IniFile _I18nFile = new(Application.StartupPath + $"\\Languages\\{GlobalSettings.language}\\Settings.relang", System.Text.Encoding.UTF8);

    private void InitializeTranslation()
    {
        this.Text = _I18nFile.ReadString("I18n", this.Text, this.Text);
        var Theme = GlobalSettings.theme.Item1;
        var Fore = GlobalSettings.theme.Item2;
        var Back = GlobalSettings.theme.Item3;
        this.MainTabCtrl.FillColor = Fore;
        this.MainTabCtrl.TabBackColor = Back;
        if (Theme == "Light")
        {
            uiButton1.Show();
            this.TitleColor = Back;
            this.TitleForeColor = Fore;
            this.MainTabCtrl.MenuStyle = UIMenuStyle.White;
            this.MainTabCtrl.StyleCustomMode = false;
        }
        foreach (TabPage item in MainTabCtrl.TabPages)
        {
            item.Text = _I18nFile.ReadString("I18n", item.Text, item.Text);
            item.ForeColor = Fore;
            item.BackColor = Back;

            foreach (Control ctrls in item.Controls)
            {
                if (ctrls.Text is null)
                {
                    continue;
                }

                ctrls.Text = _I18nFile.ReadString("I18n", ctrls.Text, ctrls.Text);
                ctrls.ForeColor = Fore;
                ctrls.BackColor = Back;
                if (ctrls is UIButton button) { button.FillColor = Back; button.ForeColor = Fore; }
                if (ctrls is UILine line) { line.FillColor = Back; line.ForeColor = Fore; }
                if (ctrls is UITextBox box) { box.FillReadOnlyColor = Back; box.ForeReadOnlyColor = Fore; }
                if (ctrls is UIUserControl control) { control.FillColor = Back; control.ForeColor = Fore; }
            }
        }
        this.NUDFontSize.ForeColor = Fore; 
        this.NUDFontSize.BackColor = Back;
    }

    private List<Control> GetAllControls(Control control)
    {
        var controls = new List<Control>();
        foreach (Control c in control.Controls)
        {
            controls.Add(c);
            controls.AddRange(GetAllControls(c));
        }
        return controls;
    }

    private void InitializeTranslationWrite()
    {
#if DEBUG
        try
        {
            foreach (TabPage item in MainTabCtrl.TabPages)
            {
                if (_I18nFile.KeyExists("I18n", item.Text))
                {
                    continue;
                }

                _I18nFile.Write("I18n", item.Text, "");
                foreach (Control ctrls in item.Controls)
                {
                    if (_I18nFile.KeyExists("I18n", ctrls.Text))
                    {
                        continue;
                    }

                    _I18nFile.Write("I18n", ctrls.Text, "");

                }
            }
            foreach (string item in CBoxTheme.Items)
            {
                if (_I18nFile.KeyExists("I18n", item))
                {
                    continue;
                }

                _I18nFile.Write("I18n", item, "");
            }
        }
        catch { }
#else
return;
#endif
    }
}