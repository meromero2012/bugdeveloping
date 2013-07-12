using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaBus.ConnectorSQL;



namespace FrbaBus.Selector_Principal
{
    public partial class SelectorPrincipal : Form
    {
        public SelectorPrincipal()
        {
            InitializeComponent();
        }

        ConnectorClass conn;

       

        private void FormFiltrarRol_Load(object sender, EventArgs e)
        {

        }

        public void bFiltrar_Click(String rolId)
        {
            conn = ConnectorClass.Instance;

            String query = "SELECT F.FUNCIONALIDAD_NOMBRE  FROM BUGDEVELOPING.FUNCIONALIDAD F JOIN BUGDEVELOPING.FUNROL FR  ON FR.FUNROL_FUNCIONALIDAD_ID = F.FUNCIONALIDAD_ID JOIN BUGDEVELOPING.ROL R ON R.ROL_ID = FR.FUNROL_ROL_ID WHERE R.ROL_ID = 1";

            selectorFuncionalidades.DataSource = conn.executeQuery(query);
            selectorFuncionalidades.Enabled = true;
        }

        private void dgvRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((selectorFuncionalidades.Rows.Count > 0) && (selectorFuncionalidades.Columns[e.ColumnIndex].HeaderText == "Seleccionar"))
            {
               /*FormModifRol form = new FormModifRol();
                FormModifRol.RolCodigo = Convert.ToInt16(dgvRoles.CurrentRow.Cells[1].Value.ToString());
                FormModifRol.RolNombre = dgvRoles.CurrentRow.Cells["ROL_NOMBRE"].Value.ToString();
                FormModifRol.RolActivo = dgvRoles.CurrentRow.Cells["ROL_HABILITACION"].Value.ToString();
                form.ShowDialog(this);
                 */               
            
            }
        }
    }
}
