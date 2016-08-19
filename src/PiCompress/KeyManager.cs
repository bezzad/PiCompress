using System;
using System.Configuration;
using System.Windows.Forms;
using PiCompress.Properties;

namespace PiCompress
{
    public partial class KeyManager : Form
    {
        public KeyManager()
        {
            InitializeComponent();
            this.Text = Localization.KeyManager;
            gbTinifyApiKeys.Text = Localization.TinifyAPIKeys;
            colRow.HeaderText = Localization.Row;
            colKeyName.HeaderText = Localization.Name;
            colKeyValue.HeaderText = Localization.API_Key;
            colKeyRemainCount.HeaderText = Localization.CompressRemainCount;
        }

        private async void KeyManager_Load(object sender, EventArgs e)
        {
            int row = 1;
            foreach (SettingsProperty prop in Settings.Default.Properties)
            {
                var tinifyKey = prop.DefaultValue.ToString();
                var count = await TinifyImage.CompressRemainCountAsync(tinifyKey);
                dgvKeys.Rows.Add(row++, prop.Name, tinifyKey, TinifyImage.MaxCompressCount - count);
            }
        }
    }
}
