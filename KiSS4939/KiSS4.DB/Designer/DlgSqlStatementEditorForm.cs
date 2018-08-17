using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

using Kiss.Infrastructure;

namespace KiSS4.DB.Designer
{
    /// <summary>
    /// Summary description for DlgSqlStatementEditorForm.
    /// </summary>
    public partial class DlgSqlStatementEditorForm : Form
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        readonly SqlConnection _connection = new SqlConnection();

        /// <summary>
        /// Contains the labels for the SQL-Parameters
        /// </summary>
        readonly List<Label> _parameterLabels = new List<Label>();

        /// <summary>
        /// Contains the TextBoxes for the SQL-Parameters
        /// </summary>
        private readonly List<TextBox> _parameterTextBoxes = new List<TextBox>();

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public DlgSqlStatementEditorForm()
        {
            InitializeComponent();

            FillConnectionsIntoComboBox();
            CreateParameterInputs(0);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the edited statement
        /// </summary>
        public string SelectStatement
        {
            get
            {
                return edtStatement.Text.Replace("\r\n", "\n").Replace("\r", "\n").Replace("\n", "\r\n");
            }
            set
            {
                edtStatement.Text = value;
                if (value != null)
                {
                    MatchCollection matches = Regex.Matches(value, @"{\d+}");
                    CreateParameterInputs(matches);
                    tmrValidateSQL.Start();
                }
                else
                {
                    CreateParameterInputs(0);
                }
            }
        }

        #endregion

        #region EventHandlers

        /// <summary>
        /// Eventhandler: Button "Show Error" was pressed
        /// Shows an error dialog which explains why the statement is wrong
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">Event data</param>
        private void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                MatchCollection matches = Regex.Matches(edtStatement.Text, @"{\d+}");
                CreateParameterInputs(matches);
                SqlCommand cmd = CreateSqlCommand(edtStatement.Text, _connection, GetParameters());
                cmd.ExecuteNonQuery();
                MessageBox.Show(this, "Statement verified");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "SQL-Fehler");
            }
        }

        /// <summary>
        /// Eventhandler: Button "Execute Query" was pressed
        /// Opens a SqlQuery with the edited statement and shows the results in the preview grid 
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">Event data</param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                if (!gridPreview.Visible)
                {
                    pnCenter.Height += 122;
                    gridPreview.Visible = true;
                }
                SqlCommand cmd = CreateSqlCommand(edtStatement.Text, _connection, GetParameters());
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);

                gridPreview.DataSource = table;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "SQL-Fehler");
            }
        }

        private void chbSuppressContinuousChecks_CheckedChanged(object sender, EventArgs e)
        {
            if (chbSuppressContinuousChecks.Checked)
            {
                tmrValidateSQL.Stop();
                edtStatement.BackColor = SystemColors.Window;
            }
            else
            {
                tmrValidateSQL.Start();
            }
        }

        private void edtConnection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (edtConnection.SelectedItem == null)
                return;

            KeyValuePair<string, string> selectedItem = (KeyValuePair<string, string>)edtConnection.SelectedItem;
            string connectionString = DecryptConnectionString(selectedItem.Value);

            if (_connection.State != ConnectionState.Closed)
            {
                _connection.Close();
            }

            _connection.ConnectionString = connectionString;

            try
            {
                _connection.Open();

                if (!string.IsNullOrEmpty(edtStatement.Text))
                {
                    tmrValidateSQL.Start();
                }
            }
            catch { }
        }

        private void edtStatement_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                edtStatement.SelectedText = "  ";
                e.Handled = true;
            }
        }

        private void edtStatement_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\t')
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Event: the statement was modified by the user
        /// colorizes the input box according to if the syntax is ok
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">Event data</param>
        private void edtStatement_TextChanged(object sender, EventArgs e)
        {
            tmrValidateSQL.Stop();

            if (chbSuppressContinuousChecks.Checked == false)
            {
                tmrValidateSQL.Start();
            }
        }

        /// <summary>
        /// Handles the Tick event of the tmrValidateSQL control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void tmrValidateSQL_Tick(object sender, EventArgs e)
        {
            tmrValidateSQL.Enabled = false;
            try
            {
                MatchCollection matches = Regex.Matches(edtStatement.Text, @"{\d+}");
                CreateParameterInputs(matches);

                if (_connection.State != ConnectionState.Open)
                {
                    return;
                }

                string commandText = string.Format("SET NOEXEC ON\r\n{0}\r\nSET NOEXEC OFF", edtStatement.Text);
                SqlCommand cmd = CreateSqlCommand(commandText, _connection, GetParameters());
                cmd.ExecuteNonQuery();

                edtStatement.BackColor = Color.FromArgb(224, 255, 224);
                edtSyntaxError.Visible = false;
                btnCheck.Visible = false;
            }
            catch (SqlException ex)
            {
                edtStatement.BackColor = Color.FromArgb(255, 224, 224);
                edtSyntaxError.Text = ex.Message;
                edtSyntaxError.Visible = true;
                btnCheck.Visible = true;
            }
        }

        #endregion

        #region Methods

        #region Private Static Methods

        private static SqlCommand CreateSqlCommand(string sqlStatement, SqlConnection connection, params object[] sqlParameters)
        {
            SqlCommand cmd;

            if (sqlParameters != null)
            { // replace parameter placeholders
                Regex rgxParams = new Regex(@"{(?<nr>\d+)}");   // eg: where fieldA = {0} and fieldB = {1}
                string sql = sqlStatement;
                BitArray ba = new BitArray(sqlParameters.Length, false); // contains a bit for each parameter index used

                int offset = 0;

                MatchCollection matches = rgxParams.Matches(sql);
                foreach (Match m in matches)
                {
                    // replace a parameter placeholder with @pN and and the bit to ba
                    try
                    {
                        int nr = int.Parse(m.Groups["nr"].Captures[0].Value);
                        string paramName = DBUtil.Normalized(sqlParameters[nr]) == DBNull.Value ? "NULL" : "@p" + nr;

                        sql = sql.Substring(0, m.Index + offset) + paramName + sql.Substring(m.Index + offset + m.Length);
                        offset += paramName.Length - m.Length;
                        ba[nr] = true;
                    }
                    catch
                    {
                        if (Debugger.IsAttached)
                        {
                            Debugger.Break();
                        }
                    }
                }

                cmd = new SqlCommand(sql, connection);

                for (int i = 0; i < sqlParameters.Length; i++)
                {
                    if (ba[i])
                    {
                        cmd.Parameters.AddWithValue("@p" + i, DBUtil.Normalized(sqlParameters[i]));
                    }
                }
            }
            else
            {
                cmd = new SqlCommand(sqlStatement, connection);
            }

            return cmd;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates inputs for parameters found in a regex query
        /// </summary>
        /// <param name="matches">Results of a regex query to display parameters for</param>
        private void CreateParameterInputs(MatchCollection matches)
        {
            ArrayList list = new ArrayList();
            foreach (Match m in matches)
            {
                if (!list.Contains(m.Value))
                {
                    list.Add(m.Value);
                }
            }
            CreateParameterInputs(list.Count);
        }

        /// <summary>
        /// Creates as many inputs for parameters as specified
        /// </summary>
        /// <param name="parameterCount">Number of input controls to create</param>
        private void CreateParameterInputs(int parameterCount)
        {
            SuspendLayout();

            // show / hide Parameters, resize Form
            //int oldParameterHeight = gbParameters.Visible ? gbParameters.Height : 0;
            gbParameters.Height = parameterCount > 0 ? parameterCount * 28 + 40 : 0;
            gbParameters.Visible = parameterCount > 0;
            //pnTop.Height += gbParameters.Height - oldParameterHeight;

            if (!gridPreview.Visible)
            {
                pnCenter.Height = gbParameters.Height + pnControls.Height;
            }

            // remove parameter inputs that are no longer necessary
            for (int i = _parameterLabels.Count - 1; i >= parameterCount; i--)
            {
                _parameterLabels[i].Parent = null;
                _parameterLabels.RemoveAt(i);
                _parameterTextBoxes[i].Parent = null;
                _parameterTextBoxes.RemoveAt(i);
            }

            // create parameter inputs for additional params
            for (int i = _parameterLabels.Count; i < parameterCount; i++)
            {
                Label lbl = new Label
                {
                    Text = string.Format("{{{0}}}", i),
                    Left = 8,
                    Top = 28 + i * 28,
                    Height = 12,
                    Width = 24,
                    Parent = gbParameters
                };
                _parameterLabels.Add(lbl);

                TextBox tb = new TextBox
                {
                    Left = 40,
                    Top = 24 + i * 28,
                    Width = gbParameters.Width - 52,
                    Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right,
                    Parent = gbParameters
                };
                _parameterTextBoxes.Add(tb);
            }

            ResumeLayout();
        }

        private string DecryptConnectionString(string connectionString)
        {
            Scrambler scrambler = new Scrambler("KiSS4");
            Regex rgx = new Regex(@"password=(?<scrambled>[A-Za-z0-9\+/]+=*)"); // matches a password placeholder
            Match m = rgx.Match(connectionString);

            if (m.Success)
            {
                Capture cap = m.Groups["scrambled"].Captures[0];
                string pwPlain = scrambler.DecryptString(cap.Value);

                return connectionString.Substring(0, cap.Index) + pwPlain + connectionString.Substring(cap.Index + cap.Length);
            }
            return connectionString;
        }

        private void FillConnectionsIntoComboBox()
        {
            try
            {
                var doc = new XmlDocument();
                doc.Load(Properties.Settings.Default.MainAppConfigPath);
                var appSettingsNode = doc.SelectSingleNode("/configuration/appSettings");

                if (appSettingsNode == null)
                {
                    return;
                }

                var envCountNode = appSettingsNode.SelectSingleNode("add[@key=\"EnvCount\"]");

                if (envCountNode == null || envCountNode.Attributes == null)
                {
                    return;
                }

                var envCount = int.Parse(envCountNode.Attributes["value"].Value);
                var lastEnvName = Convert.ToString(Session.UserAppDataRegistry.GetValue("LastEnvironment", null));

                // load environments
                for (int i = 0; i < envCount; i++)
                {
                    var nameNode = appSettingsNode.SelectSingleNode(string.Format("add[@key=\"Env{0}.Name\"]", i));

                    if (nameNode == null || nameNode.Attributes == null)
                    {
                        continue;
                    }

                    string name = nameNode.Attributes["value"].Value;

                    var csNode = appSettingsNode.SelectSingleNode(string.Format("add[@key=\"Env{0}.ConnectionString\"]", i));

                    if (csNode == null || csNode.Attributes == null)
                    {
                        return;
                    }

                    string connectionString = csNode.Attributes["value"].Value;
                    int index = edtConnection.Items.Add(new KeyValuePair<string, string>(name, connectionString));

                    if (name == lastEnvName)
                    {
                        edtConnection.SelectedIndex = index;
                    }
                }

                if (edtConnection.Items.Count > 0 && edtConnection.SelectedIndex == -1)
                {
                    edtConnection.SelectedIndex = 0;
                }
            }
            catch { }
        }

        /// <summary>
        /// Gets an array of the parameters entered by the user
        /// </summary>
        /// <returns></returns>
        private object[] GetParameters()
        {
            MatchCollection matches = Regex.Matches(edtStatement.Text, @"{\d+}");
            object[] parameters = new object[matches.Count];
            int userParameterCount = Math.Min(matches.Count, _parameterTextBoxes.Count);
            for (int i = 0; i < userParameterCount; i++)
            {
                parameters[i] = _parameterTextBoxes[i].Text;
                try
                {
                    parameters[i] = int.Parse(_parameterTextBoxes[i].Text);
                }
                catch { }
            }
            return parameters;
        }

        #endregion

        #endregion
    }
}